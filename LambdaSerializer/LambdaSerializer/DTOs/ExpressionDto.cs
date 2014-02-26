using System;
using System.Linq.Expressions;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class ExpressionDto 
    {

        internal ExpressionDto()
        {
            
        }
        
        public ExpressionType NodeType { get; set; } 
        
        public Type Type { get; set; } 

    }
}
