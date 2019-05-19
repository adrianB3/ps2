using System.Threading.Tasks;

namespace server.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}