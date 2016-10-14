using System;
using System.Collections.Generic;
using System.Linq;

namespace WF_Chapter19.ProductDetail
{
    public class ProductDetailService
    {
        public static ProductDetail ReadItem(int productID)
        {
            AdventureWorksDataContext dc = new AdventureWorksDataContext();

            Product p = dc.Products.SingleOrDefault(x => x.ProductID == productID);

            if (p != null)
                return ExtractProduct(p);
            else
                return null;
        }

        public static IEnumerable<ProductDetail> ReadList()
        {
            AdventureWorksDataContext dc = new AdventureWorksDataContext();

            List<ProductDetail> list = new List<ProductDetail>();

            IEnumerable<Product> q = dc.Products;
            foreach (Product p in q)
            {
                list.Add(ExtractProduct(p));
            }

            return list.AsEnumerable<ProductDetail>();
        }

        internal static ProductDetail ExtractProduct(Product product)
        {
            ProductDetail d = new ProductDetail();

            d.Class = product.Class;
            d.Color = product.Color;
            d.FinishedGoodsFlag = product.FinishedGoodsFlag;
            d.ListPrice = product.ListPrice;
            d.MakeFlag = product.MakeFlag;
            d.Name = product.Name;
            d.ProductID = product.ProductID;
            d.ProductLine = product.ProductLine;
            d.ProductNumber = product.ProductNumber;
            d.Size = product.Size;
            d.StandardCost = product.StandardCost;
            d.Style = product.Style;

            if (product.ProductModel != null)
                d.ProductModel = product.ProductModel.Name;

            if (product.ProductSubcategory != null)
            {
                d.Subcategory = product.ProductSubcategory.Name;
                if (product.ProductSubcategory.ProductCategory != null)
                    d.Category = product.ProductSubcategory.ProductCategory.Name;
            }

            if (product.Weight.HasValue)
                d.Weight = product.Weight.Value;

            if (product.UnitMeasure != null)
                d.SizeUOM = product.UnitMeasure.Name;
            if (product.UnitMeasure1 != null)
                d.WeightUOM = product.UnitMeasure1.Name;

            return d;
        }

        public static IEnumerable<Review> ProductDetailToReview(int productID)
        {
            AdventureWorksDataContext dc = new AdventureWorksDataContext();

            IEnumerable<ProductReview> q = dc.ProductReviews.Where(x => x.ProductID == productID);


            List<Review> list = new List<Review>();
            foreach (ProductReview pr in q)
            {
                list.Add(ReviewService.ExtractReview(pr));
            }

            return list.AsEnumerable<Review>();
        }
    }
}
