using System;
using System.Collections.Generic;
using System.Reflection;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class NewExpressionDto : ExpressionDto
    {

        internal NewExpressionDto()
        {
            
        }

        public ConstructorInfo Constructor { get; set; } 

        public List<ExpressionDto> Arguments { get; set; }

        public List<MemberInfo> Members { get; set; } 

    }
}
