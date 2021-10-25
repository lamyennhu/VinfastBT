using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinfast.models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        public version version { get; set; }
        public Int64 Price { get; set; }
        public string PhotoPath { get; set; }
        
    }
}
