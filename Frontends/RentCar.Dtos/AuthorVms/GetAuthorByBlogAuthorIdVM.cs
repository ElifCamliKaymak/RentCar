namespace RentCar.ViewModels.AuthorVms
{
    public class GetAuthorByBlogAuthorIdVM
    {
        public int BlogId { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorImageUrl { get; set; }
    }
}
