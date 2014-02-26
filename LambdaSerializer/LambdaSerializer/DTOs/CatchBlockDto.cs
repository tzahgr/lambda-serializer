using System;

namespace LambdaSerializer.DTOs
{

    [Serializable]
    public class CatchBlockDto
    {
        internal CatchBlockDto()
        {
            
        }
        
        public ExpressionDto Body { get; set; }
        
        public ExpressionDto Filter { get; set; }
        
        public Type Test { get; set; }
        
        public ParameterExpressionDto Variable { get; set; }

    }
}
