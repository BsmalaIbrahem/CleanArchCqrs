using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Entities
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; protected set; }
        protected BaseEntity() { 
        }
        protected BaseEntity(TId id) 
        {
            Id = id;
        }
    }
}
