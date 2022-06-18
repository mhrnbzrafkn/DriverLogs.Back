using DriverLog.Entities;
using DriverLog.Services.Drivers.Contracts;
using DriverLog.Services.Drivers.Contracts.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverLog.Persistence.EF.Drivers
{
    public class EFDriverRepository : DriverRepository
    {
        private readonly DbSet<Driver> _drivers;
        private readonly DbSet<DriveLog> _driverLogs;

        public EFDriverRepository(EFDataContext DbContext)
        {
            _drivers = DbContext.Set<Driver>();
            _driverLogs = DbContext.Set<DriveLog>();
        }

        public void Add(Driver driver)
        {
            _drivers.Add(driver);
        }

        public void Delete(Driver driver)
        {
            _drivers.Remove(driver);
        }

        public async Task<Driver> Find(Guid id)
        {
            return await _drivers
                .FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<List<GetDriverDto>> GetAll()
        {
            return await _drivers.Select(_ => new GetDriverDto
            {
                Id = _.Id,
                FullName = _.FullName,
                LogsCount = _driverLogs
                    .Where(__ => __.DriverId == _.Id).Count()
            }).ToListAsync();
        }
    }
}
