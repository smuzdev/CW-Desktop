namespace KlingenRestaurant
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCount { get; set; }
        public ProductType ProductType { get; set; }

        public Product() { }

        public Product(string productName, ProductType productType, int productCount)
        {
            ProductName = productName;
            ProductCount = productCount;
            ProductType = productType;
        }
    }
}


