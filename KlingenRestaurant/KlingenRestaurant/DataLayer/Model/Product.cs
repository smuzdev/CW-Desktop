using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlingenRestaurant
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductCount { get; set; }
        public ProductType ProductType { get; set; }

        public Product() { }

        public Product(string productName, ProductType productType, double productCount)
        {
            ProductName = productName;
            ProductCount = productCount;
            ProductType = productType;
        }
    }
}


