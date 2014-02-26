using System;
using System.Collections.Generic;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class ListInitExpressionDto : ExpressionDto
    {
        internal ListInitExpressionDto()
        {
            
        }

        public NewExpressionDto NewExpression { get; set; }

        public List<ElementInitDto> Initializers { get; set; } 

    }
}
