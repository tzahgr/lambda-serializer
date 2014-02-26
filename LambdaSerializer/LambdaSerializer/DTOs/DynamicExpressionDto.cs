using System;
using System.Collections.Generic;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class DynamicExpressionDto : ExpressionDto
    {
        internal DynamicExpressionDto()
        {
            
        }

        public Type DelegateType { get; set; } 

        public List<ExpressionDto> Arguments { get; set; } 

    }
}
