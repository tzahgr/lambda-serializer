using System;
using System.Collections.Generic;
using System.Reflection;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class IndexExpressionDto : ExpressionDto
    {
        internal IndexExpressionDto()
        {
            
        }
        public ExpressionDto Object { get; set; } 

        public PropertyInfo Indexer { get; set; } 

        public List<ExpressionDto> Arguments { get; set; } 

    }
}
