using System;
using System.Collections.Generic;

namespace LambdaSerializer.DTOs
{

    [Serializable]
    public class SwitchCaseDto
    {
        internal SwitchCaseDto()
        {
            
        }
        
        public ExpressionDto Body { get; set; }
        
        public List<ExpressionDto> TestValues { get; set; }

    }
}
