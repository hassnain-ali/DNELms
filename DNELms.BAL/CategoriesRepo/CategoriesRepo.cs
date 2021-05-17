using DNELms.DBContexts.Data;
using DNELms.ModelMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fyp.BAL.CategoriesRepo
{
    public class CategoriesRepo
    {
        readonly DNELmsContext context;
        readonly IModelMapper mapper;
        public CategoriesRepo(DNELmsContext _context, IModelMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        public Task<long> Save(CourseCategory model)
        {
            try
            {
                if (model.Id > 0)
                {
                    context.CourseCategories.Update(model);
                    context.SaveChangesAsync();
                    return Task.FromResult(model.Id);
                }
                else
                {
                    context.CourseCategories.AddAsync(model);
                    context.SaveChangesAsync();
                    return Task.FromResult(model.Id);
                }

            }
            catch (Exception ex)
            {
                return Task.FromResult<long>(0);
            }
        }
        public ValueTask<CourseCategory> GetById(long id)
        {
            try
            {
                return context.CourseCategories.FindAsync(id);
            }
            catch (Exception ex)
            {
                return ValueTask.FromResult(new CourseCategory());
            }
        }
        public Task<List<CourseCategory>> Fetch()
        {
            try
            {
                return Task.FromResult(context.CourseCategories.ToList());
            }
            catch (Exception ex)
            {
                return Task.FromResult(new List<CourseCategory>());
            }
        }
        public Task<int> Delete(long id)
        {
            try
            {
                context.CourseCategories.Remove(context.CourseCategories.Find(id));
                return context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Task.FromResult(0);
            }
        }
    }
}
