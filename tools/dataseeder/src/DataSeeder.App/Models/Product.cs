using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSeeder.App.Models
{
    internal class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ImgUri { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
