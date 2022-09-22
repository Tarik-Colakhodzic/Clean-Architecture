using System;

namespace Domain
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}