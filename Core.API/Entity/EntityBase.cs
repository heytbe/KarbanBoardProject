﻿namespace Core.API.Entity
{
    public class EntityBase : IEntityBase
    {
        public virtual Guid Id { get; set; } = Guid.NewGuid();
        public virtual string CreatedBy { get; set; } = "Undefined";
        public virtual string? ModifiedBy { get; set; }
        public virtual string? DeletedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime? ModifieldDate { get; set; }
        public virtual DateTime? DeletedDate { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
    }
}
