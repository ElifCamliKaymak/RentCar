﻿using MediatR;

namespace RentCar.Application.Features.Mediator.Commands.ServiceCommands
{
    public class RemoveServiceCommand :IRequest
    {
        public int Id { get; set; }

        public RemoveServiceCommand(int id)
        {
            Id = id;
        }
    }
}
