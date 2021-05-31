using DNELms.Model.NoSchoolModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNELms.BAL.WorldRepo
{
    public interface ICountriesService
    {
        Task<bool> Delete(long id);
        Task<List<Countries>> Fetch();
        Task<Countries> GetById(long id);
        Task<long> Save(Countries model);
    }
}