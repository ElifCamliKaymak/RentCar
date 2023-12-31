﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Commands.BlogCommands;
using RentCar.Application.Features.Mediator.Queries.BlogQueries;
using RentCar.Domain.Entities;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog bilgisi eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Blog bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog bilgisi güncellendi.");
        }

        [HttpGet("GetLastThreeBlogsWithAuthorsList")]
        public async Task<IActionResult> GetLastThreeBlogsWithAuthorsList()
        {
            var values = await _mediator.Send(new GetLastThreeBlogsWithAuthorsQuery());
            return Ok(values);
        }  
        
        [HttpGet("GetAllBlogsWithAuthorList")]
        public async Task<IActionResult> GetAllBlogsWithAuthorList()
        {
            var values = await _mediator.Send(new GetAllBlogsWithAuthorQuery());
            return Ok(values);
        }       
        
        [HttpGet("GetBlogByAuthorList/{id}")]
        public async Task<IActionResult> GetBlogByAuthorList(int id)
        {
            var values = await _mediator.Send(new GetBlogByAuthorIdQuery(id));
            return Ok(values);
        }

        [HttpGet("GetBlogsOfAuthors/{id}")]
        public async Task<IActionResult> GetBlogsOfAuthors(int id)
        {
            var values = await _mediator.Send(new GetBlogsOfAuthorsQuery(id));
            return Ok(values);
        }

        [HttpGet("GetBlogsOfCategorys/{id}")]
        public async Task<IActionResult> GetBlogsOfCategorys(int id)
        {
            var values = await _mediator.Send(new GetBlogsOfCategorysQuery(id));
            return Ok(values);
        }

        [HttpGet("GetBlogWithDetails/{id}")]
        public async Task<IActionResult> GetBlogWithDetails(int id)
        {
            var values = await _mediator.Send(new GetBlogWithDetailsQuery(id));
            return Ok(values);
        }
    }
}
