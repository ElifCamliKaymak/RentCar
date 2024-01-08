namespace RentCar.ViewModels.BlogVms
{
    public class CreateBlogVM
    {
        public string title { get; set; }
        public string coverImageUrl { get; set; }
        public DateTime createdDate { get; set; }
        public string description { get; set; }
        public int authorId { get; set; }
        public int categoryId { get; set; }
        public string authorName { get; set; }
        public string categoryName { get; set; }
        public string authorDescription { get; set; }
        public string authorImageUrl { get; set; }
    }
}
