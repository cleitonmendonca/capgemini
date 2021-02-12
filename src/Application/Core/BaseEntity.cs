using System;

namespace Application.Core
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual DateTime ModifiedOn { get; set; }
    }
}