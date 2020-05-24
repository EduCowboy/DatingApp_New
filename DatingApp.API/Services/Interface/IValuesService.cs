using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Services.Interface
{
    public interface IValuesService
    {
         Task<IEnumerable<Value>> GetValues();
         Task<Value> GetValue(int id);
    }
}