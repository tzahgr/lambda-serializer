using System;

namespace LambdaSerializer.DTOs
{
    [Serializable]
    public class LabelTargetDto
    {

        internal LabelTargetDto()
        {
            
        }

        public String Name { get; set; }

        public Type Type { get; set; }

    }
}
