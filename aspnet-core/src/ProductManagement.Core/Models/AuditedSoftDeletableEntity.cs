using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Models
{
    public abstract class AuditedSoftDeletableEntity<TPrimaryKey> : AuditedEntity<TPrimaryKey>
    {
        public bool IsActive { get; set; }
    }
}
