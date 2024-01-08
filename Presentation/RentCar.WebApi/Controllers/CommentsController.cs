using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Interfaces.RepositoryPattern.CommentRepositories;
using RentCar.Bussiness.Dtos.CommentDtos;
using RentCar.Bussiness.MapServices;
using RentCar.Dtos.Dtos.CommentDtos;
using RentCar.Persistance.Repositories.CommentRepositories;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentService _service;

        public CommentsController(CommentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var values = await _service.GetAllCommentAsync();
            return Ok(values);
        }   
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var value = await _service.GetCommentAsync(id);
            return Ok(value);
        }
        
        [HttpGet("CommentListByBlog/{id}")]
        public async Task<IActionResult> CommentListByBlog(int id)
        {
            var value = await _service.CommentListByBlogAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto commentDto)
        {
            await _service.CreateCommantAsync(commentDto);
            return Ok("Yorumunuz gönderilmiştir.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveComment(int id)
        {
            await _service.RemoveCommentAsync(id);
            return Ok("Yorumunuz silinmiştir.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(GetCommentDto commentDto)
        {
            await _service.UpdateCommentAsync(commentDto);
            return Ok("Yorumunuz güncellenmiştir.");
        }
    }
}
