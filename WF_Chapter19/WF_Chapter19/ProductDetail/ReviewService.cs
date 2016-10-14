using System;
using System.Collections.Generic;
using System.Linq;

namespace WF_Chapter19.ProductDetail
{
    public partial class ReviewService
    {
        public static Review ReadItem(int productReviewID)
        {
            AdventureWorksDataContext dc = new AdventureWorksDataContext();

            ProductReview pr = dc.ProductReviews
                .SingleOrDefault(x => x.ProductReviewID == productReviewID);

            if (pr != null)
                return ExtractReview(pr);
            else
                return null;
        }

        public static IEnumerable<Review> ReadList()
        {
            AdventureWorksDataContext dc = new AdventureWorksDataContext();

            List<Review> list = new List<Review>();

            IEnumerable<ProductReview> q = dc.ProductReviews;
            foreach (ProductReview pr in q)
            {
                list.Add(ExtractReview(pr));
            }

            return list.AsEnumerable<Review>();
        }

        public static Review Create(Review newReview)
        {
            AdventureWorksDataContext dc = new AdventureWorksDataContext();

            // Create and initialize a ProductReview
            ProductReview pr = new ProductReview();

            pr.Comments = newReview.Comments;
            pr.EmailAddress = newReview.EmailAddress;
            pr.ProductID = newReview.ProductID;
            pr.Rating = newReview.Rating;
            pr.ReviewerName = newReview.ReviewerName;

            pr.ReviewDate = DateTime.UtcNow;
            pr.ModifiedDate = DateTime.UtcNow;

            // Insert the record
            dc.ProductReviews.InsertOnSubmit(pr);
            dc.SubmitChanges();

            // Now read it back
            ProductReview pr1 = dc.ProductReviews
                .SingleOrDefault(x => x.ProductReviewID == pr.ProductReviewID);

            if (pr1 != null)
                return ExtractReview(pr1);
            else
                return null;
        }

        public static void Delete(int productReviewID)
        {
            AdventureWorksDataContext dc = new AdventureWorksDataContext();

            ProductReview pr = dc.ProductReviews
                .SingleOrDefault(x => x.ProductReviewID == productReviewID);

            if (pr != null)
            {
                try
                {
                    dc.ProductReviews.DeleteOnSubmit(pr);
                    dc.SubmitChanges();
                }
                catch (Exception e)
                {
                    string s = e.Message;
                }
            }
        }

        public static void Update(Review review)
        {
            AdventureWorksDataContext dc = new AdventureWorksDataContext();

            ProductReview pr = dc.ProductReviews
                .SingleOrDefault(x => x.ProductReviewID == review.ProductReviewID);

            pr.Comments = review.Comments;
            pr.EmailAddress = review.EmailAddress;
            pr.Rating = review.Rating;
            pr.ReviewerName = review.ReviewerName;

            pr.ModifiedDate = DateTime.UtcNow;

            // Update the record
            dc.SubmitChanges();
        }

        internal static Review ExtractReview(ProductReview review)
        {
            Review r = new Review();

            r.Comments = review.Comments;
            r.EmailAddress = review.EmailAddress;
            r.ProductID = review.ProductID;
            r.ProductReviewID = review.ProductReviewID;
            r.Rating = review.Rating;
            r.ReviewDate = review.ReviewDate;
            r.ReviewerName = review.ReviewerName;
            r.ModifiedDate = review.ModifiedDate;

            return r;
        }

        public static IEnumerable<ProductDetail> ReviewToProductDetail(int productReviewID)
        {
            AdventureWorksDataContext dc = new AdventureWorksDataContext();

            ProductReview pr = dc.ProductReviews.Single(x => x.ProductReviewID == productReviewID);

            List<ProductDetail> list = new List<ProductDetail>();

            IEnumerable<Product> q = dc.Products.Where(x => x.ProductID == pr.ProductID);
            foreach (Product p in q)
            {
                list.Add(ProductDetailService.ExtractProduct(p));
            }

            return list.AsEnumerable<ProductDetail>();
        }
    }
}
