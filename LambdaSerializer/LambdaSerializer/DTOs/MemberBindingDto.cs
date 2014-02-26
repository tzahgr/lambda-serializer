using System;
using System.Linq.Expressions;
using System.Reflection;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class MemberBindingDto
    {
        internal MemberBindingDto()
        {
            
        }

        public MemberBindingType BindingType { get; set; }

        public MemberInfo Member { get; set; }

    }
}
