﻿namespace RentCar.Dtos.Dtos.CommentDtos
{
    public class CreateCommentDto
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public string Email { get; set; }

        public int BlogId { get; set; }
    }
}
