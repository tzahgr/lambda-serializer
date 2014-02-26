using System;
using System.Collections.Generic;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class MemberListBindingDto : MemberBindingDto
    {
        internal MemberListBindingDto()
        {
            
        }

        public List<ElementInitDto> Initializers { get; set; }

    }
}
