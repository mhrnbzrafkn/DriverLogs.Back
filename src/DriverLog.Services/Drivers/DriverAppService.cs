using DriverLog.Entities;
using DriverLog.Services.DriverLogs.Contracts;
using DriverLog.Services.Drivers.Contracts;
using DriverLog.Services.Drivers.Contracts.Dtos;
using DriverLog.Services.Drivers.Contracts.Exceptions;
using DriverLog.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DriverLog.Services.Drivers
{
    public class DriverAppService : DriverService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly DriverRepository _driverRepository;
        private readonly DriverLogRepository _driverLogRepository;

        public DriverAppService(
            UnitOfWork unitOfWork,
            DriverRepository driverRepository, 
            DriverLogRepository driverLogRepository)
        {
            _unitOfWork = unitOfWork;
            _driverRepository = driverRepository;
            _driverLogRepository = driverLogRepository;
        }

        public async Task<Guid> Add(AddDriverDto dto)
        {
            var driver = new Driver
            {
                Id = Guid.NewGuid(),
                FullName = dto.FullName,
                CreationDate = DateTime.UtcNow
            };

            _driverRepository.Add(driver);

            await _unitOfWork.Complete();

            return driver.Id;
        }

        public async Task Delete(DeleteDriverDto dto)
        {
            var driver = await _driverRepository.Find(dto.Id);
            GuardAgainstDriverNotFound(driver);
            _driverRepository.Delete(driver);

            await _unitOfWork.Complete();
        }

        public int GetDriverLogsCount(Guid Id)
        {
            return _driverLogRepository.GetDriverLogsCount(Id);
        }

        public async Task<List<GetDriverDto>> GetAll()
        {
            return await _driverRepository.GetAll();
        }

        private void GuardAgainstDriverNotFound(Driver driver)
        {
            if (driver == null)
                throw new DriverNotFoundException();
        }
    }
}
