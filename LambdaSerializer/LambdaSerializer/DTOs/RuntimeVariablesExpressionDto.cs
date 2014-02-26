using System;
using System.Collections.Generic;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class RuntimeVariablesExpressionDto : ExpressionDto
    {
        internal RuntimeVariablesExpressionDto()
        {
            
        }

        public List<ParameterExpressionDto> Variables { get; set; } 

    }
}
