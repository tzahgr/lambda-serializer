using System;
using System.Collections.Generic;
using System.Reflection;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class SwitchExpressionDto : ExpressionDto
    {
        internal SwitchExpressionDto()
        {
            
        }
        
        public ExpressionDto SwitchValue { get; set; } 
        
        public List<SwitchCaseDto> Cases { get; set; } 
        
        public ExpressionDto DefaultBody { get; set; } 
        
        public MethodInfo Comparison { get; set; } 

    }
}
