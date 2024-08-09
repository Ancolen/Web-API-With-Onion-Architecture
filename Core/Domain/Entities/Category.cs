using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category : EntityBase
    {
        public Category() { }
        public Category(int parentId, string name, int queueId)
        {
            ParentID = parentId;
            Name = name;
            QueueID = queueId;
        }
        public required int ParentID { get; set; }
        public required string Name { get; set; }
        public required int QueueID { get; set; }
        public ICollection<Detail> Details { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
