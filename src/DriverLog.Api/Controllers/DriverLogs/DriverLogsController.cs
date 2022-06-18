using DriverLog.Services.DriverLogs.Contracts;
using DriverLog.Services.DriverLogs.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DriverLog.Api.Controllers.DriverLogs
{
    [ApiVersion("1.0")]
    [ApiController, Route("api/v1/driver-logs")]
    public class DriverLogsController : ControllerBase
    {
        private readonly DriverLogService _driverLogService;

        public DriverLogsController(
            DriverLogService driverLogService)
        {
            _driverLogService = driverLogService;
        }

        [HttpPost]
        public async Task Add(AddDriverLogDto dto)
        {
            await _driverLogService.Add(dto);
        }

        [HttpDelete]
        public async Task Delete(DeleteDriverLogDto dto)
        {
            await _driverLogService.Delete(dto);
        }
    }
}
