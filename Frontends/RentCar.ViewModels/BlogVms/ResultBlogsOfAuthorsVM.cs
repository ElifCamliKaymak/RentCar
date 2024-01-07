namespace RentCar.ViewModels.BlogVms
{
    public class ResultBlogsOfAuthorsVM
    {
        public int blogId { get; set; }
        public string title { get; set; }
        public string coverImageUrl { get; set; }
        public DateTime createdDate { get; set; }
        public string description { get; set; }
        public string authorName { get; set; }
        public string categoryName { get; set; }
    }
}
