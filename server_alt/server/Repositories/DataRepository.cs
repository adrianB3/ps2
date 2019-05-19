using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Contexts;
using server.Models;

namespace server.Repositories
{
    public class DataRepository : BaseRepository, IDataRepository
    {
        public DataRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Data>> ListAsync()
        {
            return await _context.Data.ToListAsync();
        }

        public async Task AddAsync(Data data)
        {
            await _context.Data.AddAsync(data);
        }
    }
}