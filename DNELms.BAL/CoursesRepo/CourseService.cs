using DNELms.Dapper;
using DNELms.DataRepository;
using DNELms.Model.NoSchoolModels;
using DNELms.ModelMappers;
using DNELms.Models;
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
        readonly ISQLFactory factory;
        readonly IModelMapper mapper;
        public CourseService(IRepository<Courses> _context, ISQLFactory _factory, IModelMapper _mapper)
        {
            context = _context;
            factory = _factory;
            _mapper = mapper;
        }
        public async Task<CoursesVM> SaveSteps(CoursesVM model, IFormFile smallImage, IFormFile largeImage)
        {
            try
            {
                if (model.Id > 0)
                {
                    Courses mapped = mapper.Map<CoursesVM, Courses>(model);
                    Courses cc = await factory.UpdateEntityAsync("updateCourses", mapped);
                    model.Id = cc.Id;
                    return model;
                }
                else
                {
                    Courses mapped = mapper.Map<CoursesVM, Courses>(model);
                    Courses cc = await factory.Insert("InsertCourses", mapped);
                    model.Id = cc.Id;
                    return model;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Task<CoursesVM> GetById(long id)
        {
            try
            {
                return factory.GetByIdAsync<CoursesVM>(id, "Courses");
            }
            catch (Exception ex)
            {
                return Task.FromException<CoursesVM>(ex);
            }
        }
        public Task<IEnumerable<CoursesVM>> Fetch(PagingVM paging)
        {
            try
            {
                return factory.SelectAsync<CoursesVM>("sp_GetCourses", paging);
            }
            catch (Exception ex)
            {
                return Task.FromException<IEnumerable<CoursesVM>>(ex);
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