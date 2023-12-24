namespace RentCar.ViewModels.BlogVms
{
    public class ResultLastThreeBlogsWithAuthorsVM
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int CategoryId { get; set; }
    }
}
