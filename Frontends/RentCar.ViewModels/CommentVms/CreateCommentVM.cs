namespace RentCar.ViewModels.CommentVms
{
    public class CreateCommentVM
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Content { get; set; }
        public string Email { get; set; }
        public int BlogId { get; set; }
    }
}
