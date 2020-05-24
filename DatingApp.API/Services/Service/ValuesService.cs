using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Data.Interface;
using DatingApp.API.Models;
using DatingApp.API.Services.Interface;

namespace DatingApp.API.Services.Service
{
    public class ValuesService : IValuesService
    {
        private readonly IValueRepository _valuesRepo;

        public ValuesService(IValueRepository valuesRepo)
        {
            _valuesRepo = valuesRepo;
        }

        public async Task<Value> GetValue(int id)
        {
            var value = await _valuesRepo.GetValue(id);
            return value;
        }

        public async Task<IEnumerable<Value>> GetValues()
        {
            IEnumerable<Value> values = await _valuesRepo.GetValues();
            return values;
        }
    }
}