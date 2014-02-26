using System;
using System.Reflection;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class MemberExpressionDto : ExpressionDto
    {
        internal MemberExpressionDto()
        {
            
        }

        public MemberInfo Member { get; set; } 

        public ExpressionDto Expression { get; set; } 

    }
}
