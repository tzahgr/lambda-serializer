using System;
using System.Collections.Generic;
using System.Reflection;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class MethodCallExpressionDto : ExpressionDto
    {
        internal MethodCallExpressionDto()
        {
            
        }
        
        public MethodInfo Method { get; set; } 

        public ExpressionDto Object { get; set; } 
        
        public List<ExpressionDto> Arguments { get; set; } 

    }
}
