using DNELms.DataRepository;
using DNELms.Model.NoSchoolModels;
using DNELms.ModelMappers;
using LinqToDB;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNELms.BAL.CoursesRepo
{
    public class CourseService : ICourseService
    {
        readonly IRepository<Courses> context;
        readonly IModelMapper mapper;
        public CourseService(IRepository<Courses> _context, IModelMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        public Task<Courses> Save(Courses model, IFormFile smallImage, IFormFile largeImage)
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
                return Task.FromResult<Courses>(new());
            }
        }
        public Task<Courses> GetById(long id)
        {
            try
            {
                return context.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Courses());
            }
        }
        public Task<List<Courses>> Fetch()
        {
            try
            {
                return context.Table.ToListAsync();
            }
            catch (Exception ex)
            {
                return Task.FromResult(new List<Courses>());
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