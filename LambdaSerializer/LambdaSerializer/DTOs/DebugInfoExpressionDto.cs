using System;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class DebugInfoExpressionDto : ExpressionDto
    {

        internal DebugInfoExpressionDto()
        {
            
        }

        public Int32 StartLine { get; set; } 
        
        public Int32 StartColumn { get; set; } 
        
        public Int32 EndLine { get; set; } 
        
        public Int32 EndColumn { get; set; } 
        
        public Boolean IsClear { get; set; } 

    }
}
