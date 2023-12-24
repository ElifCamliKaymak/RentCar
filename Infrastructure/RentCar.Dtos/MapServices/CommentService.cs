using AutoMapper;
using RentCar.Application.Interfaces.RepositoryPattern.CommentRepositories;
using RentCar.Bussiness.Dtos.CommentDtos;
using RentCar.Domain.Entities;
using RentCar.Dtos.Dtos.CommentDtos;

namespace RentCar.Bussiness.MapServices
{
    public class CommentService
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _repository;

        public CommentService(IMapper mapper, ICommentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<GetCommentDto>> GetAllCommentAsync()
        {
            var comments = await _repository.GetAllAsync();
            return _mapper.Map<List<GetCommentDto>>(comments);
        }

        public async Task<GetCommentDto> GetCommentAsync(int id)
        {
            var comment = await _repository.GetByIdAsync(id);
            return _mapper.Map<GetCommentDto>(comment);
        }
                
        public async Task CreateCommantAsync(CreateCommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            await _repository.CreateAsync(comment);
            await _repository.SaveAsync();
        }

        public async Task RemoveCommentAsync(int id)
        {
            var comment = await _repository.GetByIdAsync(id);
            _repository.RemoveAsync(comment);
            await _repository.SaveAsync();
        }

        public async Task UpdateCommentAsync(GetCommentDto commentDto)
        {
            var comment = await _repository.GetByIdAsync(commentDto.CommentId);
            var updatedComment = _mapper.Map(commentDto, comment);
            _repository.UpdateAsync(updatedComment);
            await _repository.SaveAsync();
        }
    }
}