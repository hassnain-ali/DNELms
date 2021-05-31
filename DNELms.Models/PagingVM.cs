using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNELms.Models
{
    public record PagingVM
    {
        public PagingVM(int displayStart, int displayLength = 20, string sortColumn = "id", string sortOrder = "desc", string query = "")
        {
            DisplayLength = displayLength;
            DisplayStart = displayStart;
            SortCol = sortColumn;
            SortOrder = sortOrder;
            Query = query;
        }
        public int DisplayStart { get; set; }
        public int DisplayLength { get; set; }
        public string SortCol { get; set; }
        public string SortOrder { get; set; }
        public string Query { get; set; }
    }
    public record MatTable<T> where T : DTModel
    {
        public int total_count { get; set; }
        public dynamic items { get; set; }
        public MatTable(IEnumerable<T> list)
        {
            items = list;
            total_count = list?.FirstOrDefault()?.Total ?? 0;
        }
        public MatTable(IEnumerable<T> list, int total)
        {
            items = list;
            total_count = total;
        }
    }
}
