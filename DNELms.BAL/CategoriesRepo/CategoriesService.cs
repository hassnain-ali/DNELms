using DNELms.Core;
using DNELms.Dapper;
using DNELms.DataRepository;
using DNELms.Model.NoSchoolModels;
using DNELms.Models;
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

                    return factory.UpdateEntityAsync($"update{nameof(CourseCategory)}", model);
                    //Task<int> count = context.UpdateAsync(model);
                    //model);
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
        public async Task<IEnumerable<CourseCategoryVM>> Fetch(PagingVM paging)
        {
            try
            {
                var result = await factory.SelectAsync<CourseCategoryVM>("CourseCategoryFetch", paging);
                paging.DisplayLength = 5000;
                paging.DisplayStart = 0;
                var all = await factory.SelectAsync<CourseCategoryVM>("CourseCategoryFetch", paging);
                foreach (var item in result)
                {
                    item.Name = item.GetFormattedBreadCrumb(all);
                }
                return result;
            }
            catch
            {
                throw;
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
            var courseCategories = (await Fetch(new(0, 2000))).Where(s => s.Id != selected);
            //    IEnumerable<CourseCategoryVM> allParents = courseCategories.Where(s => s.ParentId is null or 0);
            //  IEnumerable<CourseCategoryVM> allChilds = courseCategories.Where(s => s.ParentId > 0);
            foreach (var item in courseCategories)
            {
                item.Name = item.GetFormattedBreadCrumb(courseCategories); //= allChilds.Where(s => s.ParentId == item.Id);
            }
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
