using System.Threading.Tasks;
using Scheduler.Common.Types;

namespace Scheduler.Common.Repository
{
    public interface IRepository
    {
        Task<int> Insert(IPersistable data);
    }
}