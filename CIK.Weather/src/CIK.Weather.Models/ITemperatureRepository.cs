using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace CIK.Weather.Models
{
    public interface ITemperatureRepository
    {
        Task<IEnumerable<TemperatureInfo>> GetTemperaturesByStationId(string id);

        void DeleteTemperatureInfoByStationId(string id);
    }
}