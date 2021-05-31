using DNELms.Dapper;
using DNELms.DataRepository;
using DNELms.Model.NoSchoolModels;
using DNELms.ModelMappers;
using DNELms.Models;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DNELms.Services;

namespace DNELms.BAL.WorldRepo
{
    public class CitiesService : ICitiesService
    {
        readonly IRepository<Cities> context;
        readonly IModelMapper mapper;
        readonly ISQLFactory factory;
        public CitiesService(IRepository<Cities> _context, IModelMapper _mapper, ISQLFactory _factory)
        {
            context = _context;
            mapper = _mapper;
            factory = _factory;
        }
        public Task<long> Save(Cities model)
        {
            try
            {
                if (model.Id > 0)
                {
                    context.UpdateAsync(model);
                    return Task.FromResult(model.Id);
                }
                else
                {
                    context.InsertAsync(model);
                    return Task.FromResult(model.Id);
                }

            }
            catch (Exception ex)
            {
                return Task.FromResult<long>(0);
            }
        }
        public Task<Cities> GetById(long id)
        {
            try
            {
                return context.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Cities());
            }
        }
        public Task<IEnumerable<CityVM_Result>> Fetch(PagingVM paging)
        {
            try
            {
                object query = paging.ToDBQuery();
                return factory.GetAllAsync<CityVM_Result>("sp_GetCities", parms: query, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return Task.FromResult(Enumerable.Empty<CityVM_Result>());
            }
        }
        public Task<bool> Delete(long id)
        {
            try
            {
                context.Delete(s => s.Id == id);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }
}
