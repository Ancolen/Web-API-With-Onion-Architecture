using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Detail : EntityBase
    {
        public Detail() { }
        public Detail(string title, string description, int categoryId)
        {
            Title = title;
            Description = description;
            CategoryID = categoryId;
        }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
