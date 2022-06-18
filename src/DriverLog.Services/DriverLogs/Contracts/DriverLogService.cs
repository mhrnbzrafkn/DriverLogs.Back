using DriverLog.Services.DriverLogs.Contracts.Dtos;
using DriverLog.Services.Infrastructure;
using System.Threading.Tasks;

namespace DriverLog.Services.DriverLogs.Contracts
{
    public interface DriverLogService : Service
    {
        Task Add(AddDriverLogDto dto);
        Task Delete(DeleteDriverLogDto dto);
    }
}
