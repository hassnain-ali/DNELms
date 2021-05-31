using DNELms.DataRepository;
using DNELms.Model.NoSchoolModels;
using DNELms.ModelMappers;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNELms.BAL.WorldRepo
{
    public class StatesService : IStatesService
    {
        readonly IRepository<States> context;
        readonly IModelMapper mapper;
        public StatesService(IRepository<States> _context, IModelMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        public Task<long> Save(States model)
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
        public Task<States> GetById(long id)
        {
            try
            {
                return context.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new States());
            }
        }
        public Task<List<States>> Fetch()
        {
            try
            {
                return context.Table.ToListAsync();
            }
            catch (Exception ex)
            {
                return Task.FromResult(new List<States>());
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
