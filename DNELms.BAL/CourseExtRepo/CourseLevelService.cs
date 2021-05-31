using DNELms.DataRepository;
using DNELms.Model.NoSchoolModels;
using DNELms.ModelMappers;
using LinqToDB;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNELms.BAL.CourseExtRepo
{
    public class CourseLevelService : ICourseLevelService
    {
        readonly IRepository<CourseLevel> context;
        readonly IModelMapper mapper;
        public CourseLevelService(IRepository<CourseLevel> _context, IModelMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        public Task<CourseLevel> Save(CourseLevel model)
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
                return Task.FromResult<CourseLevel>(new());
            }
        }
        public Task<CourseLevel> GetById(long id)
        {
            try
            {
                return context.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new CourseLevel());
            }
        }
        public Task<List<CourseLevel>> Fetch()
        {
            try
            {
                return context.Table.ToListAsync();
            }
            catch (Exception ex)
            {
                return Task.FromResult(new List<CourseLevel>());
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
