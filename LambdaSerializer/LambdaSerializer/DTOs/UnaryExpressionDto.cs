using System;
using System.Reflection;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class UnaryExpressionDto : ExpressionDto
    {

        internal UnaryExpressionDto()
        {
            
        }

        public ExpressionDto Operand { get; set; } 
        
        public MethodInfo Method { get; set; } 

    }
}
