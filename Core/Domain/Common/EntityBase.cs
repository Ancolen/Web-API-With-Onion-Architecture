using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class EntityBase : IEntityBase
    {
        public int      ID          { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool     IsDeleted   { get; set; } = false;
    }
}
