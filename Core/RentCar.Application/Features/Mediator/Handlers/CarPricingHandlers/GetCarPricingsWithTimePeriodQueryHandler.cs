using MediatR;
using RentCar.Application.Features.Mediator.Queries.CarPricingQueries;
using RentCar.Application.Features.Mediator.Results.CarPricingResults;
using RentCar.Application.Interfaces.CarPricingInterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingsWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingsWithTimePeriodQuery, List<GetCarPricingsWithTimePeriodQueryResult>>
	{
		private readonly ICarPricingRepository _repository;

		public GetCarPricingsWithTimePeriodQueryHandler(ICarPricingRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarPricingsWithTimePeriodQueryResult>> Handle(GetCarPricingsWithTimePeriodQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetCarPricingsWithTimePeriodAsync();
			return values.Select(x=> new GetCarPricingsWithTimePeriodQueryResult
			{
				ModelBrandName = x.ModelBrandName,
				CoverImageUrl = x.CoverImageUrl,
				DailyAmount = x.DailyAmount,
                WeeklyAmount =  x.WeeklyAmount,
				MonthlyAmount = x.MonthlyAmount
			}).ToList();
		}
	}
}
