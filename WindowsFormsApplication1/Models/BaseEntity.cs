

using System;

namespace  Models
{
    class BaseEntity
    {
    

        public BaseEntity()
        {
            ID = System.Guid.NewGuid();
        }

        public System.Guid ID { get; set; }
    }
}
