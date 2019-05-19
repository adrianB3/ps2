using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;

namespace server.Services
{
    public interface IDataService
    {
        Task<IEnumerable<Data>> ListAsync();
        Task<SaveDataResponse> SaveAsync(Data data);
    }
}