using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Data.Interface;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data.Repository
{
    public class ValueRepository : IValueRepository
    {
        private readonly DataContext _context;

        public ValueRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Value> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(v => v.Id == id);
            return value;
        }

        public async Task<IEnumerable<Value>> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return values;
        }
    }
}