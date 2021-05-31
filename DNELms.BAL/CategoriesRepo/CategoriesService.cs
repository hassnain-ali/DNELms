using DNELms.Dapper;
using DNELms.DataRepository;
using DNELms.Model.NoSchoolModels;
using DNELms.ModelMappers;
using DNELms.Models;
using LinqToDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Fyp.BAL.CategoriesRepo
{
    public class CategoriesService : ICategoriesService
    {
        readonly IRepository<CourseCategory> context;
        readonly ISQLFactory factory;
        public CategoriesService(IRepository<CourseCategory> _context, ISQLFactory sQLFactory)
        {
            context = _context;
            factory = sQLFactory;
        }
        public Task<CourseCategory> Save(CourseCategory model, IFormFile smallImage, IFormFile largeImage)
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
                    return context.InsertAsync(model);
                }
            }
            catch (Exception ex)
            {
                return Task.FromException<CourseCategory>(ex);
            }
        }
        public Task<CourseCategory> GetById(long id)
        {
            try
            {
                return context.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                return Task.FromException<CourseCategory>(ex);
            }
        }
        public Task<IEnumerable<CourseCategoryVM>> Fetch(PagingVM paging)
        {
            try
            {
                return factory.SelectAsync<CourseCategoryVM>("CourseCategoryFetch", paging);
            }
            catch (Exception ex)
            {
                return Task.FromException<IEnumerable<CourseCategoryVM>>(ex);
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
                return Task.FromException<bool>(ex);
            }
        }
        public async Task<List<SelectListItem>> GetSelectListAsync(long? selected)
        {
            var courseCategories = await Fetch(new(0));
            List<SelectListItem> list = new();
            foreach (var item in courseCategories)
            {
                list.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name,
                    Selected = item.Id == selected
                });
            }
            return list;
        }
    }
}
