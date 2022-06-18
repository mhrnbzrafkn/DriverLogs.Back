using DriverLog.Services.Drivers.Contracts;
using DriverLog.Services.Drivers.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DriverLog.Api.Controllers.Drivers
{
    [ApiVersion("1.0")]
    [ApiController, Route("api/v1/drivers")]
    public class DriversController : ControllerBase
    {
        private readonly DriverService _driverService;

        public DriversController(
            DriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpPost]
        public async Task<Guid> Add(AddDriverDto dto)
        {
            return await _driverService.Add(dto);
        }

        [HttpDelete]
        public async Task Delete(DeleteDriverDto dto)
        {
            await _driverService.Delete(dto);
        }

        [HttpGet]
        public async Task<List<GetDriverDto>> GetDriverLogsCount()
        {
            return await _driverService.GetAll();
        }

        [HttpGet("{id}/logs-count")]
        public int GetDriverLogsCount(Guid id)
        {
            return _driverService.GetDriverLogsCount(id);
        }
    }
}
