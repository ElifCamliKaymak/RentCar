﻿using RentCar.Application.Features.CQRS.Results.BannerResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBannerQueryResult>> Handle() 
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetBannerQueryResult
            {
                BannerId = x.BannerId,
                Title=x.Title,
                Description=x.Description,
                VideoDescription=x.VideoDescription,
                VideoUrl=x.VideoUrl
            }).ToList();
        }
    }
}
