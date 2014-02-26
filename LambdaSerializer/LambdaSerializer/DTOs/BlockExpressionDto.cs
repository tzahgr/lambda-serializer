using System;
using System.Collections.Generic;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class BlockExpressionDto : ExpressionDto
    {

        internal BlockExpressionDto()
        {
            
        }

        public List<ExpressionDto> Expressions { get; set; } 

        public List<ParameterExpressionDto> Variables { get; set; } 

        public ExpressionDto Result { get; set; } 

    }
}
