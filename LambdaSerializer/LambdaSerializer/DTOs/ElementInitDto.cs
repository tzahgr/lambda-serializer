using System;
using System.Collections.Generic;
using System.Reflection;

namespace LambdaSerializer.DTOs
{
    
    [Serializable]
    public class ElementInitDto
    {
        internal ElementInitDto()
        {
            
        }

        public MethodInfo AddMethod { get; set; }

        public List<ExpressionDto> Arguments { get; set; }

    }
}
