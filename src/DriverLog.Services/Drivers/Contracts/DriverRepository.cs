using DriverLog.Entities;
using DriverLog.Services.Drivers.Contracts.Dtos;
using DriverLog.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DriverLog.Services.Drivers.Contracts
{
    public interface DriverRepository : Repository
    {
        void Add(Driver driver);
        Task<Driver> Find(Guid id);
        void Delete(Driver driver);
        Task<List<GetDriverDto>> GetAll();
    }
}
