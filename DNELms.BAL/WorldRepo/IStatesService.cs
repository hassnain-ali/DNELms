using DNELms.Model.NoSchoolModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNELms.BAL.WorldRepo
{
    public interface IStatesService
    {
        Task<bool> Delete(long id);
        Task<List<States>> Fetch();
        Task<States> GetById(long id);
        Task<long> Save(States model);
    }
}