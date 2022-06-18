using DriverLog.Services.Infrastructure;
using System.Threading.Tasks;

namespace DriverLog.Persistence.EF
{
    public class EFUnitOfWork : UnitOfWork
    {
        private readonly EFDataContext _dataContext;

        public EFUnitOfWork(EFDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Complete()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
