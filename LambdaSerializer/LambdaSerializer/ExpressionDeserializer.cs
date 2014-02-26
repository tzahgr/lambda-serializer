using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using LambdaSerializer.DTOs;

namespace LambdaSerializer
{
    public class ExpressionDeserializer : ExpressionDtoDispatcher<Expression>
    {

        #region Private Fields

        private readonly Dictionary<CatchBlockDto, CatchBlock> catchBlocks;

        private readonly Dictionary<ElementInitDto, ElementInit> elementInits;

        private readonly Dictionary<ExpressionDto, Expression> expressions;

        private readonly Dictionary<LabelTargetDto, LabelTarget> labelTargets;

        private readonly Dictionary<MemberBindingDto, MemberBinding> memberBindings;

        private readonly Dictionary<SwitchCaseDto, SwitchCase> switchCases;

        #endregion

        #region Ctor's

        public ExpressionDeserializer()
        {
            this.expressions = new Dictionary<ExpressionDto, Expression>();
            this.labelTargets = new Dictionary<LabelTargetDto, LabelTarget>();
            this.switchCases = new Dictionary<SwitchCaseDto, SwitchCase>();
            this.elementInits = new Dictionary<ElementInitDto, ElementInit>();
            this.catchBlocks = new Dictionary<CatchBlockDto, CatchBlock>();
            this.memberBindings = new Dictionary<MemberBindingDto, MemberBinding>();
        }

        #endregion

        #region Public Methods

        public Expression Deserialize(Stream stream)
        {
            var formatter = new BinaryFormatter();
            var dto = (ExpressionDto)formatter.Deserialize(stream);
            return Visit(dto);
        }

        public T Deserialize<T>(Stream stream) where T : Expression
        {
            var formatter = new BinaryFormatter();
            var dto = (ExpressionDto)formatter.Deserialize(stream);
            return (T)Visit(dto);
        }

        #endregion

        #region Protected Methods

        protected override Expression Visit(ExpressionDto expression)
        {
            if(this.expressions.ContainsKey(expression))
            {
                return this.expressions[expression];
            }
            var result = base.Visit(expression);
            this.expressions.Add(expression, result);
            return result;
        }

        protected override Expression Visit(BinaryExpressionDto expression)
        {
            return Expression.MakeBinary(expression.NodeType, Visit(expression.Left), Visit(expression.Right), expression.IsLiftedToNull, expression.Method, Visit((ExpressionDto)expression.Conversion) as LambdaExpression);
        }

        protected override Expression Visit(BlockExpressionDto expression)
        {
            return Expression.Block(expression.Type, ListSelect(expression.Variables, a => Visit((ExpressionDto)a) as ParameterExpression), ListSelect(expression.Expressions, Visit));
        }

        protected override Expression Visit(ConditionalExpressionDto expression)
        {
            return Expression.Condition(Visit(expression.Test), Visit(expression.IfTrue), Visit(expression.IfFalse));
        }

        protected override Expression Visit(ConstantExpressionDto expression)
        {
            return Expression.Constant(expression.Value, expression.Type);
        }

        protected override Expression Visit(DebugInfoExpressionDto expression)
        {
            return null;
        }

        protected override Expression Visit(DefaultExpressionDto expression)
        {
            return Expression.Default(expression.Type);
        }

        protected override Expression Visit(DynamicExpressionDto expression)
        {
            throw new InvalidOperationException();
        }

        protected override Expression Visit(GotoExpressionDto expression)
        {
            return Expression.Goto(GetLabelTarget(expression.Target), Visit(expression.Value), expression.Type);
        }

        protected override Expression Visit(IndexExpressionDto expression)
        {
            return Expression.MakeIndex(Visit(expression.Object), expression.Indexer, ListSelect(expression.Arguments, Visit));
        }

        protected override Expression Visit(InvocationExpressionDto expression)
        {
            return Expression.Invoke(Visit(expression.Expression), ListSelect(expression.Arguments, Visit));
        }

        protected override Expression Visit(LabelExpressionDto expression)
        {
            return Expression.Label(GetLabelTarget(expression.Target), Visit(expression.DefaultValue));
        }

        protected override Expression Visit(LambdaExpressionDto expression)
        {
            return Expression.Lambda(Visit(expression.Body), expression.TailCall, ListSelect(expression.Parameters, a => Visit((ExpressionDto)a) as ParameterExpression));
        }

        protected override Expression Visit(ListInitExpressionDto expression)
        {
            return Expression.ListInit((NewExpression)Visit((ExpressionDto)expression.NewExpression), ListSelect(expression.Initializers, GetElementInit));
        }

        protected override Expression Visit(LoopExpressionDto expression)
        {
            return Expression.Loop(Visit(expression.Body), GetLabelTarget(expression.BreakLabel), GetLabelTarget(expression.ContinueLabel));
        }

        protected override Expression Visit(MemberExpressionDto expression)
        {
            return Expression.MakeMemberAccess(Visit(expression.Expression), expression.Member);
        }

        protected override Expression Visit(MemberInitExpressionDto expression)
        {
            return Expression.MemberInit((NewExpression)Visit((ExpressionDto)expression.NewExpression), ListSelect(expression.Bindings, GetMemberBinding));
        }

        protected override Expression Visit(MethodCallExpressionDto expression)
        {
            return Expression.Call(Visit(expression.Object), expression.Method, ListSelect(expression.Arguments, Visit));
        }

        protected override Expression Visit(NewArrayExpressionDto expression)
        {
            return Expression.NewArrayInit(expression.Type, ListSelect(expression.Expressions, Visit));
        }

        protected override Expression Visit(NewExpressionDto expression)
        {
            return Expression.New(expression.Constructor, ListSelect(expression.Arguments, Visit), expression.Members);
        }

        protected override Expression Visit(ParameterExpressionDto expression)
        {
            return Expression.Parameter(expression.Type, expression.Name);
        }

        protected override Expression Visit(RuntimeVariablesExpressionDto expression)
        {
            return Expression.RuntimeVariables(ListSelect(expression.Variables.OfType<ExpressionDto>(), Visit).OfType<ParameterExpression>());
        }

        protected override Expression Visit(SwitchExpressionDto expression)
        {
            return Expression.Switch(expression.Type, Visit(expression.SwitchValue), Visit(expression.DefaultBody), expression.Comparison, ListSelect(expression.Cases, GetSwitchCase));
        }

        protected override Expression Visit(TryExpressionDto expression)
        {
            return Expression.MakeTry(expression.Type, Visit(expression.Body), Visit(expression.Finally), Visit(expression.Fault), ListSelect(expression.Handlers, GetCatchBlock));
        }

        protected override Expression Visit(TypeBinaryExpressionDto expression)
        {
            if(expression.NodeType == ExpressionType.TypeIs)
                return Expression.TypeIs(Visit(expression.Expression), expression.Type);
            if(expression.NodeType == ExpressionType.TypeEqual)
                return Expression.TypeEqual(Visit(expression.Expression), expression.Type);
            throw new InvalidOperationException();
        }

        protected override Expression Visit(UnaryExpressionDto expression)
        {
            return Expression.MakeUnary(expression.NodeType, Visit(expression.Operand), expression.Type);
        }

        #endregion

        #region Private Methods

        private SwitchCase GetSwitchCase(SwitchCaseDto obj)
        {
            if(this.switchCases.ContainsKey(obj))
                return this.switchCases[obj];

            var res = Expression.SwitchCase(Visit(obj.Body), ListSelect(obj.TestValues, Visit));
            this.switchCases.Add(obj, res);
            return res;
        }

        private LabelTarget GetLabelTarget(LabelTargetDto obj)
        {
            if(this.labelTargets.ContainsKey(obj))
                return this.labelTargets[obj];

            var res = Expression.Label(obj.Type, obj.Name);
            this.labelTargets.Add(obj, res);
            return res;
        }

        private CatchBlock GetCatchBlock(CatchBlockDto obj)
        {
            if(this.catchBlocks.ContainsKey(obj))
                return this.catchBlocks[obj];

            var res = Expression.Catch(obj.Test, Visit(obj.Body), Visit(obj.Filter));
            this.catchBlocks.Add(obj, res);
            return res;
        }

        private ElementInit GetElementInit(ElementInitDto obj)
        {
            if(this.elementInits.ContainsKey(obj))
                return this.elementInits[obj];

            var res = Expression.ElementInit(obj.AddMethod, ListSelect(obj.Arguments, Visit));
            this.elementInits.Add(obj, res);
            return res;
        }

        private MemberBinding GetMemberBinding(MemberBindingDto obj)
        {
            if(this.memberBindings.ContainsKey(obj))
                return this.memberBindings[obj];

            MemberBinding res = null;
            var memberAssignmentDto = obj as MemberAssignmentDto;
            if(memberAssignmentDto != null)
                res = Expression.Bind(memberAssignmentDto.Member, Visit(memberAssignmentDto.Expression));
            var memberListBindingDto = obj as MemberListBindingDto;
            if(memberListBindingDto != null)
                res = Expression.ListBind(memberListBindingDto.Member, ListSelect(memberListBindingDto.Initializers, GetElementInit));

            if(res == null)
                throw new InvalidOperationException();

            this.memberBindings.Add(obj, res);
            return res;
        }

        private List<TResult> ListSelect<T, TResult>(IEnumerable<T> coll, Func<T, TResult> selector)
        {
            if(coll == null) return null;
            return coll.Select(selector).ToList();
        }

        #endregion

    }
}
