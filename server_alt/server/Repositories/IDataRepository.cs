using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;

namespace server.Repositories
{
    public interface IDataRepository
    {
        Task<IEnumerable<Data>> ListAsync();
        Task AddAsync(Data data);
    }
}