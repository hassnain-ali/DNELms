using DNELms.DataRepository;
using DNELms.Model.NoSchoolModels;
using DNELms.ModelMappers;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNELms.BAL.CourseExtRepo
{
    public class CourseTypeService : ICourseTypeService
    {
        readonly IRepository<CourseTypes> context;
        readonly IModelMapper mapper;
        public CourseTypeService(IRepository<CourseTypes> _context, IModelMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        public Task<CourseTypes> Save(CourseTypes model)
        {
            try
            {
                if (model.Id > 0)
                {
                    context.UpdateAsync(model);
                    return Task.FromResult(model);
                }
                else
                {
                    context.InsertAsync(model);
                    return Task.FromResult(model);
                }

            }
            catch (Exception ex)
            {
                return Task.FromResult<CourseTypes>(new());
            }
        }
        public Task<CourseTypes> GetById(long id)
        {
            try
            {
                return context.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new CourseTypes());
            }
        }
        public Task<List<CourseTypes>> Fetch()
        {
            try
            {
                //var cources =
                return (from c in context.Table where c.IsActive == true select c).ToListAsync();
                // return context.Table.ToListAsync();
            }
            catch (Exception ex)
            {
                return Task.FromResult(new List<CourseTypes>());
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
