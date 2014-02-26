using System;
using System.Collections.Generic;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class MemberInitExpressionDto : ExpressionDto
    {
        internal MemberInitExpressionDto()
        {
            
        }

        public NewExpressionDto NewExpression { get; set; } 
        
        public List<MemberBindingDto> Bindings { get; set; } 

    }
}
