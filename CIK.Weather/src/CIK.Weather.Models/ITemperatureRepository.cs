using System.Collections.Generic;
using System.Threading.Tasks;

namespace CIK.Weather.Models
{
    public interface ITemperatureRepository
    {
        Task<IEnumerable<TemperatureInfo>> GetTemperaturesByStationId(string id);

        Task DeleteTemperatureInfoByStationId(string id);
    }
}