using System;
using System.Collections.Generic;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class NewArrayExpressionDto : ExpressionDto
    {
        internal NewArrayExpressionDto()
        {
            
        }
        
        public List<ExpressionDto> Expressions { get; set; } 

    }
}
