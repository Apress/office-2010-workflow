using System;

namespace WF_Chapter19.ProductDetail
{
    public partial class Review
    {
        public int ProductReviewID { get; set; }
        public int ProductID { get; set; }
        public string ReviewerName { get; set; }
        public string EmailAddress { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime ReviewDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
