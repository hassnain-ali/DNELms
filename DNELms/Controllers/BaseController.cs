using DNELms.Areas.Api.Models;
using DNELms.Models;
using DNELms.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;

namespace Microsoft.AspNetCore.Mvc
{
    public abstract class BaseController : ControllerBase
    {
        protected MatTable<T> MaterialTable<T>(IEnumerable<T> list) where T : DTModel
        {
            return new(list);
        }
        protected MatTable<T> MaterialTable<T>(IEnumerable<T> list, int total) where T : DTModel
        {
            return new(list, total);
        }
        protected PagingVM FetchPaging()
        {
            return Request.FetchPaging();
        }
        protected IActionResult FetchOrOkApiResponse<T>(T data)
        {
            return Ok(new ApiResponseResult(data));
        }
        protected IActionResult CreatedApiResponse<T>(T data)
        {
            return StatusCode(StatusCodes.Status201Created, new ApiResponseResult(data, StatusCodes.Status201Created));
        }
        protected IActionResult UpdatedApiResponse<T>(T data)
        {
            return Ok(new ApiResponseResult(data, StatusCodes.Status200OK, "Entity Updated Successfully."));
        }
        protected IActionResult DeletedApiResponse<T>(T data)
        {
            return Ok(new ApiResponseResult(data, StatusCodes.Status200OK, "Entity Deleted Successfully."));
        }
        protected IActionResult ExceptionApiResponse(Exception ex)
        {
            return Ok(new ApiResponseResult(ex, StatusCodes.Status500InternalServerError, ex.Message));
        }
        protected T GetFormByKey<T>(string key)
        {
            return JsonSerializer.Deserialize<T>(Request.Form[key]);
        }
        protected IFormFile GetFileByKey(int key)
        {
            return Request.Form.Files[key];
        }
        protected IFormFile GetFileByKey(string key)
        {
            return Request.Form.Files[key];
        }
        protected IActionResult RawSqlResult(string query, IDataReader table)
        {
            string result = string.Empty;
            DataTable dt = new();
            List<string> columns = new();
            if (table.RecordsAffected == -1)
            {
                dt.Load(table);
                foreach (DataColumn item in dt.Columns)
                {
                    columns.Add(item.ColumnName);
                }
                result = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            }
            return Ok(new { Result = result, Query = query, table.RecordsAffected, Columns = columns });
        }
    }
}
