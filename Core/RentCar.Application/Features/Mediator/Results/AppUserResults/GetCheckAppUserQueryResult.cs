﻿namespace RentCar.Application.Features.Mediator.Results.AppUserResults
{
    public class GetCheckAppUserQueryResult
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public bool IsExist { get; set; }
    }
}
