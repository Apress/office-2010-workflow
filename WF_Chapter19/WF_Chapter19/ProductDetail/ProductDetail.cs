using System;

namespace WF_Chapter19.ProductDetail
{
    public partial class ProductDetail
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public decimal Weight { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string ProductModel { get; set; }
        public string SizeUOM { get; set; }
        public string WeightUOM { get; set; }
    }
}
