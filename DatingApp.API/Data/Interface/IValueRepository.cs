using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data.Interface
{
    public interface IValueRepository
    {
        Task<IEnumerable<Value>> GetValues();
        Task<Value> GetValue(int id);
    }
}