using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PastryShopAPI
{
    public class ProductEntity
    {
        [Key]
        [Required]
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
