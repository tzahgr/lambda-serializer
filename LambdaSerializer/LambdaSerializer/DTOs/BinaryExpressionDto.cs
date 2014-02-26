using System;
using System.Reflection;

namespace LambdaSerializer.DTOs
{
    [Serializable]    
    public class BinaryExpressionDto : ExpressionDto
    {

        internal BinaryExpressionDto()
        {
            
        }

        public ExpressionDto Right { get; set; } 

        public ExpressionDto Left { get; set; } 

        public LambdaExpressionDto Conversion { get; set; }

        public bool IsLiftedToNull { get; set; }
        
        public MethodInfo Method { get; set; }

    }
}
