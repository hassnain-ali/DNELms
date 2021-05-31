using DNELms.Model.NoSchoolModels;
using DNELms.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNELms.BAL.WorldRepo
{
    public interface ICitiesService
    {
        Task<bool> Delete(long id);
        Task<IEnumerable<CityVM_Result>> Fetch(PagingVM paging);
        Task<Cities> GetById(long id);
        Task<long> Save(Cities model);
    }
}