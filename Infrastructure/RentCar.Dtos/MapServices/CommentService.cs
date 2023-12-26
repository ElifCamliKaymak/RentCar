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
            await _repository.CreateAsync(_mapper.Map<Comment>(commentDto));
            await _repository.SaveAsync();
        }

        public async Task RemoveCommentAsync(int id)
        {
            _repository.RemoveAsync(await _repository.GetByIdAsync(id));
            await _repository.SaveAsync();
        }

        public async Task UpdateCommentAsync(GetCommentDto commentDto)
        {
            _repository.UpdateAsync(_mapper.Map<Comment>(commentDto));
            await _repository.SaveAsync();
        }
    }
}