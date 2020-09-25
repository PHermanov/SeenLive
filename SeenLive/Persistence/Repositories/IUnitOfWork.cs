using System.Threading.Tasks;

namespace SeenLive.Persistence.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
