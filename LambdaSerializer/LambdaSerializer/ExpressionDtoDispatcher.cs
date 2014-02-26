using LambdaSerializer.DTOs;

namespace LambdaSerializer
{
    public abstract class ExpressionDtoDispatcher<T>
    {

        protected virtual T Visit(ExpressionDto expression)
        {
            var result = default(T);
            if (expression == null) return result;
            // ReSharper disable CanBeReplacedWithTryCastAndCheckForNull
            if (expression is BinaryExpressionDto) 
                result = Visit((BinaryExpressionDto)expression);
            else if (expression is BlockExpressionDto) 
                result = Visit((BlockExpressionDto)expression);
            else if (expression is ConditionalExpressionDto) 
                result = Visit((ConditionalExpressionDto)expression);
            else if (expression is ConstantExpressionDto) 
                result = Visit((ConstantExpressionDto)expression);
            else if (expression is DebugInfoExpressionDto) 
                result = Visit((DebugInfoExpressionDto)expression);
            else if (expression is DefaultExpressionDto) 
                result = Visit((DefaultExpressionDto)expression);
            else if (expression is DynamicExpressionDto) 
                result = Visit((DynamicExpressionDto)expression);
            else if (expression is GotoExpressionDto) 
                result = Visit((GotoExpressionDto)expression);
            else if (expression is IndexExpressionDto) 
                result = Visit((IndexExpressionDto)expression);
            else if (expression is InvocationExpressionDto) 
                result = Visit((InvocationExpressionDto)expression);
            else if (expression is LabelExpressionDto) 
                result = Visit((LabelExpressionDto)expression);
            else if (expression is LambdaExpressionDto) 
                result = Visit((LambdaExpressionDto)expression);
            else if (expression is ListInitExpressionDto) 
                result = Visit((ListInitExpressionDto)expression);
            else if (expression is LoopExpressionDto) 
                result = Visit((LoopExpressionDto)expression);
            else if (expression is MemberExpressionDto) 
                result = Visit((MemberExpressionDto)expression);
            else if (expression is MemberInitExpressionDto) 
                result = Visit((MemberInitExpressionDto)expression);
            else if (expression is MethodCallExpressionDto) 
                result = Visit((MethodCallExpressionDto)expression);
            else if (expression is NewArrayExpressionDto) 
                result = Visit((NewArrayExpressionDto)expression);
            else if (expression is NewExpressionDto) 
                result = Visit((NewExpressionDto)expression);
            else if (expression is ParameterExpressionDto) 
                result = Visit((ParameterExpressionDto)expression);
            else if (expression is RuntimeVariablesExpressionDto) 
                result = Visit((RuntimeVariablesExpressionDto)expression);
            else if (expression is SwitchExpressionDto) 
                result = Visit((SwitchExpressionDto)expression);
            else if (expression is TryExpressionDto) 
                result = Visit((TryExpressionDto)expression);
            else if (expression is TypeBinaryExpressionDto) 
                result = Visit((TypeBinaryExpressionDto)expression);
            else if (expression is UnaryExpressionDto) 
                result = Visit((UnaryExpressionDto)expression);
            // ReSharper restore CanBeReplacedWithTryCastAndCheckForNull
            return result;
        }

        protected abstract T Visit(BinaryExpressionDto expression);

        protected abstract T Visit(BlockExpressionDto expression);

        protected abstract T Visit(ConditionalExpressionDto expression);

        protected abstract T Visit(ConstantExpressionDto expression);

        protected abstract T Visit(DebugInfoExpressionDto expression);

        protected abstract T Visit(DefaultExpressionDto expression);

        protected abstract T Visit(DynamicExpressionDto expression);

        protected abstract T Visit(GotoExpressionDto expression);

        protected abstract T Visit(IndexExpressionDto expression);

        protected abstract T Visit(InvocationExpressionDto expression);

        protected abstract T Visit(LabelExpressionDto expression);

        protected abstract T Visit(LambdaExpressionDto expression);

        protected abstract T Visit(ListInitExpressionDto expression);

        protected abstract T Visit(LoopExpressionDto expression);

        protected abstract T Visit(MemberExpressionDto expression);

        protected abstract T Visit(MemberInitExpressionDto expression);

        protected abstract T Visit(MethodCallExpressionDto expression);

        protected abstract T Visit(NewArrayExpressionDto expression);

        protected abstract T Visit(NewExpressionDto expression);

        protected abstract T Visit(ParameterExpressionDto expression);

        protected abstract T Visit(RuntimeVariablesExpressionDto expression);

        protected abstract T Visit(SwitchExpressionDto expression);

        protected abstract T Visit(TryExpressionDto expression);

        protected abstract T Visit(TypeBinaryExpressionDto expression);

        protected abstract T Visit(UnaryExpressionDto expression); 

    }
}
