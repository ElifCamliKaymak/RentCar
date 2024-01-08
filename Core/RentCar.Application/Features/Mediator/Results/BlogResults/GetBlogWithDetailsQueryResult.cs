namespace RentCar.Application.Features.Mediator.Results.BlogResults
{
    public class GetBlogWithDetailsQueryResult
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
    }
}
