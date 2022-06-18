using DriverLog.Services.Drivers.Contracts.Dtos;
using DriverLog.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DriverLog.Services.Drivers.Contracts
{
    public interface DriverService : Service
    {
        Task<Guid> Add(AddDriverDto dto);
        Task Delete(DeleteDriverDto dto);
        int GetDriverLogsCount(Guid Id);
        Task<List<GetDriverDto>> GetAll();
    }
}
