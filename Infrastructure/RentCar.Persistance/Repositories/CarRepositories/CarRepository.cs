﻿using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces.CarInterfaces;
using RentCar.Domain.Entities;
using RentCar.Persistance.Context;

namespace RentCar.Persistance.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly RentCarContext _context;

        public CarRepository(RentCarContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetCarsListWithBrand()
        {
            return await _context.Cars.Include(x => x.Brand).ToListAsync();
        }
    }
}