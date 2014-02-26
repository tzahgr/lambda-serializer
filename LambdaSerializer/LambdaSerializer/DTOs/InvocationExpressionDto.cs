using System;
using System.Collections.Generic;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class InvocationExpressionDto : ExpressionDto
    {
        internal InvocationExpressionDto()
        {
            
        }

        public ExpressionDto Expression { get; set; } 
        
        public List<ExpressionDto> Arguments { get; set; } 

    }
}
