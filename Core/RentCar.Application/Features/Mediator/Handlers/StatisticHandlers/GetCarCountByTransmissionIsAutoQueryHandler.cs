﻿using MediatR;
using RentCar.Application.Features.Mediator.Queries.StatisticQueries;
using RentCar.Application.Features.Mediator.Results.StatisticResults;
using RentCar.Application.Interfaces.StatisticInterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarCountByTransmissionIsAutoQueryHandler : IRequestHandler<GetCarCountByTransmissionIsAutoQuery, GetCarCountByTransmissionIsAutoQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetCarCountByTransmissionIsAutoQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByTransmissionIsAutoQueryResult> Handle(GetCarCountByTransmissionIsAutoQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetCarCountByTransmissionIsAuto();
            return new GetCarCountByTransmissionIsAutoQueryResult
            {
                CarCountByTransmissionIsAuto = value
            };
        }
    }
}
