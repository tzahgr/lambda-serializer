using System;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class LoopExpressionDto : ExpressionDto
    {
        internal LoopExpressionDto()
        {
            
        }
        
        public ExpressionDto Body { get; set; } 
        
        public LabelTargetDto BreakLabel { get; set; } 
        
        public LabelTargetDto ContinueLabel { get; set; } 

    }
}
