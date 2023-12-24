namespace RentCar.Bussiness.Dtos.CommentDtos
{
    public class GetCommentDto
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
    }
}
