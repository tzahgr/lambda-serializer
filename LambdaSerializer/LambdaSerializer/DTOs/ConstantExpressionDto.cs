using System;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class ConstantExpressionDto : ExpressionDto
    {

        internal ConstantExpressionDto()
        {
            
        }

        public Object Value { get; set; } 

    }
}
