using System;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class TypeBinaryExpressionDto : ExpressionDto
    {

        internal TypeBinaryExpressionDto()
        {
            
        }

        public ExpressionDto Expression { get; set; } 

        public Type TypeOperand { get; set; } 

    }
}
