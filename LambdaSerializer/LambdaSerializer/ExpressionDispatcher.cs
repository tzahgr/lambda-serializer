using System.Linq.Expressions;

namespace LambdaSerializer
{
    public abstract class ExpressionDispatcher<T>
    {

        protected virtual T Visit(Expression expression)
        {
            var result = default(T);
            if (expression == null) return result;
            // ReSharper disable CanBeReplacedWithTryCastAndCheckForNull
            if (expression is BinaryExpression) 
                result = Visit((BinaryExpression)expression); 
            else if (expression is BlockExpression) 
                result = Visit((BlockExpression)expression); 
            else if (expression is ConditionalExpression) 
                result = Visit((ConditionalExpression)expression); 
            else if (expression is ConstantExpression) 
                result = Visit((ConstantExpression)expression); 
            else if (expression is DebugInfoExpression) 
                result = Visit((DebugInfoExpression)expression); 
            else if (expression is DefaultExpression) 
                result = Visit((DefaultExpression)expression); 
            else if (expression is DynamicExpression) 
                result = Visit((DynamicExpression)expression); 
            else if (expression is GotoExpression) 
                result = Visit((GotoExpression)expression); 
            else if (expression is IndexExpression) 
                result = Visit((IndexExpression)expression); 
            else if (expression is InvocationExpression) 
                result = Visit((InvocationExpression)expression); 
            else if (expression is LabelExpression) 
                result = Visit((LabelExpression)expression);
            else if (expression is LambdaExpression) 
                result = Visit((LambdaExpression)expression); 
            else if (expression is ListInitExpression) 
                result = Visit((ListInitExpression)expression); 
            else if (expression is LoopExpression) 
                result = Visit((LoopExpression)expression); 
            else if (expression is MemberExpression) 
                result = Visit((MemberExpression)expression); 
            else if (expression is MemberInitExpression) 
                result = Visit((MemberInitExpression)expression); 
            else if (expression is MethodCallExpression) 
                result = Visit((MethodCallExpression)expression); 
            else if (expression is NewArrayExpression) 
                result = Visit((NewArrayExpression)expression); 
            else if (expression is NewExpression) 
                result = Visit((NewExpression)expression); 
            else if (expression is ParameterExpression) 
                result = Visit((ParameterExpression)expression); 
            else if (expression is RuntimeVariablesExpression) 
                result = Visit((RuntimeVariablesExpression)expression); 
            else if (expression is SwitchExpression) 
                result = Visit((SwitchExpression)expression); 
            else if (expression is TryExpression) 
                result = Visit((TryExpression)expression); 
            else if (expression is TypeBinaryExpression) 
                result = Visit((TypeBinaryExpression)expression); 
            else if (expression is UnaryExpression) 
                result = Visit((UnaryExpression)expression);

            // ReSharper restore CanBeReplacedWithTryCastAndCheckForNull
            return result;
        }

        protected abstract T Visit(BinaryExpression expression); 

        protected abstract T Visit(BlockExpression expression); 

        protected abstract T Visit(ConditionalExpression expression); 

        protected abstract T Visit(ConstantExpression expression); 

        protected abstract T Visit(DebugInfoExpression expression); 

        protected abstract T Visit(DefaultExpression expression); 

        protected abstract T Visit(DynamicExpression expression); 

        protected abstract T Visit(GotoExpression expression); 

        protected abstract T Visit(IndexExpression expression); 

        protected abstract T Visit(InvocationExpression expression); 

        protected abstract T Visit(LabelExpression expression); 

        protected abstract T Visit(LambdaExpression expression); 

        protected abstract T Visit(ListInitExpression expression); 

        protected abstract T Visit(LoopExpression expression); 

        protected abstract T Visit(MemberExpression expression); 

        protected abstract T Visit(MemberInitExpression expression); 

        protected abstract T Visit(MethodCallExpression expression); 

        protected abstract T Visit(NewArrayExpression expression); 

        protected abstract T Visit(NewExpression expression); 

        protected abstract T Visit(ParameterExpression expression); 

        protected abstract T Visit(RuntimeVariablesExpression expression); 

        protected abstract T Visit(SwitchExpression expression); 

        protected abstract T Visit(TryExpression expression); 

        protected abstract T Visit(TypeBinaryExpression expression); 

        protected abstract T Visit(UnaryExpression expression); 

    }
}
