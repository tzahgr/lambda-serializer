using System;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class LabelExpressionDto : ExpressionDto
    {

        internal LabelExpressionDto()
        {
            
        }

        public LabelTargetDto Target { get; set; } 
        
        public ExpressionDto DefaultValue { get; set; } 

    }
}
