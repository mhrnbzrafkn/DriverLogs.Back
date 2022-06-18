using DriverLog.Entities;
using DriverLog.Services.DriverLogs.Contracts;
using DriverLog.Services.DriverLogs.Contracts.Dtos;
using DriverLog.Services.DriverLogs.Contracts.Exceptions;
using DriverLog.Services.Infrastructure;
using System;
using System.Threading.Tasks;

namespace DriverLog.Services.DriverLogs
{
    public class DriverLogAppService : DriverLogService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly DriverLogRepository _driverLogRepository;

        public DriverLogAppService(
            UnitOfWork unitOfWork,
            DriverLogRepository driverLogRepository)
        {
            _unitOfWork = unitOfWork;
            _driverLogRepository = driverLogRepository;
        }

        public async Task Add(AddDriverLogDto dto)
        {
            var driverLog = new DriveLog
            {
                DriverId = dto.DriverId,
                CreationDate = DateTime.UtcNow,
            };

            var driverLogsCount = _driverLogRepository.Add(driverLog);

            await _unitOfWork.Complete();
        }

        public async Task Delete(DeleteDriverLogDto dto)
        {
            var driverLog = await _driverLogRepository.Find(dto.DriverId);
            GuardAgainstDriverLogNotFound(driverLog);
            _driverLogRepository.Delete(driverLog);

            await _unitOfWork.Complete();
        }

        private void GuardAgainstDriverLogNotFound(DriveLog driverLog)
        {
            if (driverLog == null)
                throw new DriverLogNotFoundException();
        }
    }
}
