using System;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class ConditionalExpressionDto : ExpressionDto
    {
        internal ConditionalExpressionDto()
        {
            
        }

        public ExpressionDto Test { get; set; } 

        public ExpressionDto IfTrue { get; set; } 
        
        public ExpressionDto IfFalse { get; set; } 

    }
}
