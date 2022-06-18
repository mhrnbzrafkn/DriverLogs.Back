using DriverLog.Entities;
using DriverLog.Services.DriverLogs.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DriverLog.Persistence.EF.DriverLogs
{
    public class EFDriverLogRepository : DriverLogRepository
    {
        private readonly DbSet<DriveLog> _driverLogs;

        public EFDriverLogRepository(EFDataContext DbContext)
        {
            _driverLogs = DbContext.Set<DriveLog>();
        }

        public int Add(DriveLog driverLog)
        {
            _driverLogs.Add(driverLog);

            return _driverLogs
                .Where(_ => _.DriverId == driverLog.DriverId).Count();
        }

        public void Delete(DriveLog driverLog)
        {
            _driverLogs.Remove(driverLog);
        }

        public async Task<DriveLog> Find(Guid driverId)
        {
            return await _driverLogs
                .OrderByDescending(_ => _.CreationDate)
                .FirstOrDefaultAsync(_ => _.DriverId == driverId);
        }

        public int GetDriverLogsCount(Guid driverId)
        {
            return _driverLogs
                .Where(_ => _.DriverId == driverId).Count();
        }
    }
}
