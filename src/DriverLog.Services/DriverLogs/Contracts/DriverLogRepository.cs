using DriverLog.Entities;
using DriverLog.Services.Infrastructure;
using System;
using System.Threading.Tasks;

namespace DriverLog.Services.DriverLogs.Contracts
{
    public interface DriverLogRepository : Repository
    {
        int Add(DriveLog driverLog);
        Task<DriveLog> Find(Guid driverId);
        void Delete(DriveLog driverLog);
        int GetDriverLogsCount(Guid driverId);
    }
}
