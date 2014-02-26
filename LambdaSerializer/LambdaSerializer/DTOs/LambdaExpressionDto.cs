using System;
using System.Collections.Generic;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class LambdaExpressionDto : ExpressionDto
    {
        internal LambdaExpressionDto()
        {
            
        }
        
        public List<ParameterExpressionDto> Parameters { get; set; } 
        
        public String Name { get; set; } 
        
        public ExpressionDto Body { get; set; } 
        
        public Type ReturnType { get; set; } 

        public Boolean TailCall { get; set; } 

    }
}
