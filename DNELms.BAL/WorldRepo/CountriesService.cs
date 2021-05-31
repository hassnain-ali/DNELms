using DNELms.DataRepository;
using DNELms.Model.NoSchoolModels;
using DNELms.ModelMappers;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNELms.BAL.WorldRepo
{
    public class CountriesService : ICountriesService
    {
        readonly IRepository<Countries> context;
        readonly IModelMapper mapper;
        public CountriesService(IRepository<Countries> _context, IModelMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        public Task<long> Save(Countries model)
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
        public Task<Countries> GetById(long id)
        {
            try
            {
                return context.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Countries());
            }
        }
        public Task<List<Countries>> Fetch()
        {
            try
            {
                return context.Table.ToListAsync();
            }
            catch (Exception ex)
            {
                return Task.FromResult(new List<Countries>());
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
