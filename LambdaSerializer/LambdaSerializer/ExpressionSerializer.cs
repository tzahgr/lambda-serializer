using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using LambdaSerializer.DTOs;

namespace LambdaSerializer
{
    public class ExpressionSerializer : ExpressionDispatcher<ExpressionDto>
    {
        #region Private Fields

        private readonly Dictionary<CatchBlock, CatchBlockDto> catchBlocks;

        private readonly Dictionary<ElementInit, ElementInitDto> elementInits;

        private readonly Dictionary<Expression, ExpressionDto> expressions;

        private readonly Dictionary<LabelTarget, LabelTargetDto> labelTargets;

        private readonly Dictionary<MemberBinding, MemberBindingDto> memberBindings;

        private readonly Dictionary<SwitchCase, SwitchCaseDto> switchCases;

        #endregion

        #region Ctor's

        public ExpressionSerializer()
        {
            this.expressions = new Dictionary<Expression, ExpressionDto>();
            this.labelTargets = new Dictionary<LabelTarget, LabelTargetDto>();
            this.switchCases = new Dictionary<SwitchCase, SwitchCaseDto>();
            this.elementInits = new Dictionary<ElementInit, ElementInitDto>();
            this.catchBlocks = new Dictionary<CatchBlock, CatchBlockDto>();
            this.memberBindings = new Dictionary<MemberBinding, MemberBindingDto>();
        }

        #endregion

        #region Public Methods

        public void Serialize(Expression expression, Stream stream)
        {
            var dto = Visit(expression);
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, dto);
        }

        #endregion

        #region Protected Methods

        protected override ExpressionDto Visit(Expression expression)
        {
            if(this.expressions.ContainsKey(expression))
            {
                return this.expressions[expression];
            }
            var result = base.Visit(expression);
            this.expressions.Add(expression, result);
            return result;
        }

        protected override ExpressionDto Visit(BinaryExpression expression)
        {
            return new BinaryExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                Left = Visit(expression.Left),
                Right = Visit(expression.Right),
                Conversion = Visit((Expression)expression.Conversion) as LambdaExpressionDto,
                IsLiftedToNull = expression.IsLiftedToNull,
                Method = expression.Method
            };
        }

        protected override ExpressionDto Visit(BlockExpression expression)
        {
            return new BlockExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                Expressions = ListSelect(expression.Expressions, Visit),
                Variables = ListSelect(expression.Variables, a => Visit((Expression)a) as ParameterExpressionDto),
                Result = Visit(expression.Result)
            };
        }

        protected override ExpressionDto Visit(ConditionalExpression expression)
        {
            return new ConditionalExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                Test = Visit(expression.Test),
                IfTrue = Visit(expression.IfTrue),
                IfFalse = Visit(expression.IfFalse),
            };
        }

        protected override ExpressionDto Visit(ConstantExpression expression)
        {
            return new ConstantExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                Value = expression.Value
            };
        }

        protected override ExpressionDto Visit(DebugInfoExpression expression)
        {
            return null;
        }

        protected override ExpressionDto Visit(DefaultExpression expression)
        {
            return new DefaultExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type
            };
        }

        protected override ExpressionDto Visit(DynamicExpression expression)
        {
            throw new InvalidOperationException();
        }

        protected override ExpressionDto Visit(GotoExpression expression)
        {
            return new GotoExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                Kind = expression.Kind,
                Value = Visit(expression.Value),
                Target = GetLabelTarget(expression.Target)
            };
        }

        protected override ExpressionDto Visit(IndexExpression expression)
        {
            return new IndexExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                Object = Visit(expression.Object),
                Indexer = expression.Indexer,
                Arguments = ListSelect(expression.Arguments, Visit)
            };
        }

        protected override ExpressionDto Visit(InvocationExpression expression)
        {
            return new InvocationExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                Expression = Visit(expression.Expression),
                Arguments = ListSelect(expression.Arguments, Visit)
            };
        }

        protected override ExpressionDto Visit(LabelExpression expression)
        {
            return new LabelExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                DefaultValue = Visit(expression.DefaultValue),
                Target = GetLabelTarget(expression.Target)
            };
        }

        protected override ExpressionDto Visit(LambdaExpression expression)
        {
            return new LambdaExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                Parameters = ListSelect(expression.Parameters, a => Visit((Expression)a) as ParameterExpressionDto),
                Body = Visit(expression.Body),
                Name = expression.Name,
                ReturnType = expression.ReturnType,
                TailCall = expression.TailCall
            };
        }

        protected override ExpressionDto Visit(ListInitExpression expression)
        {
            return new ListInitExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                NewExpression = Visit((Expression)expression.NewExpression) as NewExpressionDto,
                Initializers = ListSelect(expression.Initializers, GetElementInit)
            };
        }

        protected override ExpressionDto Visit(LoopExpression expression)
        {
            return new LoopExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                Body = Visit(expression.Body),
                BreakLabel = GetLabelTarget(expression.BreakLabel),
                ContinueLabel = GetLabelTarget(expression.ContinueLabel),
            };
        }

        protected override ExpressionDto Visit(MemberExpression expression)
        {
            return new MemberExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                Member = expression.Member,
                Expression = Visit(expression.Expression)
            };
        }

        protected override ExpressionDto Visit(MemberInitExpression expression)
        {
            return new MemberInitExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                NewExpression = Visit((Expression)expression.NewExpression) as NewExpressionDto,
                Bindings = ListSelect(expression.Bindings, GetMemberBinding),
            };
        }

        protected override ExpressionDto Visit(MethodCallExpression expression)
        {
            return new MethodCallExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                Method = expression.Method,
                Object = Visit(expression.Object),
                Arguments = ListSelect(expression.Arguments, Visit)
            };
        }

        protected override ExpressionDto Visit(NewArrayExpression expression)
        {
            return new NewArrayExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                Expressions = ListSelect(expression.Expressions, Visit)
            };
        }

        protected override ExpressionDto Visit(NewExpression expression)
        {
            return new NewExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                Constructor = expression.Constructor,
                Members = expression.Members.ToList(),
                Arguments = ListSelect(expression.Arguments, Visit)
            };
        }

        protected override ExpressionDto Visit(ParameterExpression expression)
        {
            return new ParameterExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                IsByRef = expression.IsByRef,
                Name = expression.Name
            };
        }

        protected override ExpressionDto Visit(RuntimeVariablesExpression expression)
        {
            return new RuntimeVariablesExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                Variables = ListSelect(expression.Variables, a => Visit((Expression)a) as ParameterExpressionDto)
            };
        }

        protected override ExpressionDto Visit(SwitchExpression expression)
        {
            return new SwitchExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                DefaultBody = Visit(expression.DefaultBody),
                Comparison = expression.Comparison,
                SwitchValue = Visit(expression.SwitchValue),
                Cases = ListSelect(expression.Cases, GetSwitchCase)
            };
        }

        protected override ExpressionDto Visit(TryExpression expression)
        {
            return new TryExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                Body = Visit(expression.Body),
                Fault = Visit(expression.Fault),
                Finally = Visit(expression.Finally),
                Handlers = ListSelect(expression.Handlers, GetCatchBlock)
            };
        }

        protected override ExpressionDto Visit(TypeBinaryExpression expression)
        {
            return new TypeBinaryExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                Expression = Visit(expression.Expression),
                TypeOperand = expression.TypeOperand
            };
        }

        protected override ExpressionDto Visit(UnaryExpression expression)
        {
            return new UnaryExpressionDto
            {
                NodeType = expression.NodeType,
                Type = expression.Type,
                Method = expression.Method,
                Operand = Visit(expression.Operand)
            };
        }

        #endregion

        #region Private Methods

        private LabelTargetDto GetLabelTarget(LabelTarget obj)
        {
            if(this.labelTargets.ContainsKey(obj))
                return this.labelTargets[obj];

            var res = new LabelTargetDto
            {
                Type = obj.Type,
                Name = obj.Name
            };
            this.labelTargets.Add(obj, res);
            return res;
        }

        private SwitchCaseDto GetSwitchCase(SwitchCase obj)
        {
            if(this.switchCases.ContainsKey(obj))
                return this.switchCases[obj];

            var res = new SwitchCaseDto
            {
                Body = Visit(obj.Body),
                TestValues = ListSelect(obj.TestValues, Visit)
            };
            this.switchCases.Add(obj, res);
            return res;
        }

        private ElementInitDto GetElementInit(ElementInit obj)
        {
            if(this.elementInits.ContainsKey(obj))
                return this.elementInits[obj];

            var res = new ElementInitDto
            {
                AddMethod = obj.AddMethod,
                Arguments = ListSelect(obj.Arguments, Visit)
            };
            this.elementInits.Add(obj, res);
            return res;
        }

        private CatchBlockDto GetCatchBlock(CatchBlock obj)
        {
            if(this.catchBlocks.ContainsKey(obj))
                return this.catchBlocks[obj];

            var res = new CatchBlockDto
            {
                Body = Visit(obj.Body),
                Filter = Visit(obj.Filter),
                Test = obj.Test,
                Variable = Visit((Expression)obj.Variable) as ParameterExpressionDto
            };
            this.catchBlocks.Add(obj, res);
            return res;
        }

        private MemberBindingDto GetMemberBinding(MemberBinding obj)
        {
            if(this.memberBindings.ContainsKey(obj))
                return this.memberBindings[obj];
            MemberBindingDto result = null;
            var memberAssignment = obj as MemberAssignment;
            if(memberAssignment != null)
                result = new MemberAssignmentDto
                {
                    BindingType = memberAssignment.BindingType,
                    Member = memberAssignment.Member,
                    Expression = Visit(memberAssignment.Expression)
                };
            var memberListBinding = obj as MemberListBinding;
            if(memberListBinding != null)
                result = new MemberListBindingDto
                {
                    BindingType = memberListBinding.BindingType,
                    Member = memberListBinding.Member,
                    Initializers = ListSelect(memberListBinding.Initializers, GetElementInit)
                };
            if(result == null)
                throw new InvalidOperationException();
            this.memberBindings.Add(obj, result);
            return result;
        }

        private List<TResult> ListSelect<T, TResult>(IEnumerable<T> coll, Func<T, TResult> selector)
        {
            if(coll == null) return null;
            return coll.Select(selector).ToList();
        }

        #endregion

    }
}
