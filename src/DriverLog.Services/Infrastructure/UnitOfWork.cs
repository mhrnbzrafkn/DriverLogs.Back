using System.Threading.Tasks;

namespace DriverLog.Services.Infrastructure
{
    public interface UnitOfWork
    {
        Task Complete();
    }
}
