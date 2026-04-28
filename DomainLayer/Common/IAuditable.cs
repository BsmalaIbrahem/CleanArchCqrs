using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Common
{
    public interface IAuditable
    {
        DateTime CreatedAt { get; set; }
        string CreatedBy { get; set; }           // هيبقى UserId في المستقبل
        DateTime? UpdatedAt { get; set; }
        string? UpdatedBy { get; set; }
    }
}
