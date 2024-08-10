using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : EntityBase
    {
        public Product() { }
        public Product(string title, string description, int brandId, decimal price, decimal discount)
        {
            Title       = title;
            Description = description;
            BrandID     = brandId;
            Price       = price;
            Discount    = discount;
        }
        public required string       Title       { get; set; }
        public required string       Description { get; set; }
        public required int          BrandID     { get; set; }
        public required decimal      Price       { get; set; }
        public required decimal      Discount    { get; set; }
        public Brand                 Brand       { get; set; }
        public ICollection<Category> Categories  { get; set; }
    }
}
