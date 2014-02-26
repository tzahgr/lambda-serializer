using System;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class ParameterExpressionDto : ExpressionDto
    {
        internal ParameterExpressionDto()
        {
            
        }
        
        public String Name { get; set; } 
        
        public Boolean IsByRef { get; set; } 

    }
}
