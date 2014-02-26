using System;
using System.Collections.Generic;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class TryExpressionDto : ExpressionDto
    {
        internal TryExpressionDto()
        {
            
        }
        
        public ExpressionDto Body { get; set; } 

        public List<CatchBlockDto> Handlers { get; set; } 
        
        public ExpressionDto Finally { get; set; } 

        public ExpressionDto Fault { get; set; } 

    }
}
