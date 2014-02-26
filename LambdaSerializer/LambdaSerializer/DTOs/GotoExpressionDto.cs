using System;
using System.Linq.Expressions;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class GotoExpressionDto : ExpressionDto
    {
        internal GotoExpressionDto()
        {
            
        }
        
        public ExpressionDto Value { get; set; } 

        public LabelTargetDto Target { get; set; } 
        
        public GotoExpressionKind Kind { get; set; } 

    }
}
