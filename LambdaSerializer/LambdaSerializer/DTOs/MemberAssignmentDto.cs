using System;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class MemberAssignmentDto : MemberBindingDto
    {
        internal MemberAssignmentDto()
        {
            
        }

        public ExpressionDto Expression { get; set; }

    }
}
