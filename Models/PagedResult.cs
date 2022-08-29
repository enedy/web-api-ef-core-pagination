using System;
namespace WebApiEfCorePagination.Models
{
    public class PagedResult<T> where T : class
    {
        public PagedResult(IEnumerable<T> list, int totalResults, int pageIndex, int pageSize)
        {
            List = list;
            TotalResults = totalResults;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public IEnumerable<T> List { get; private set; }
        public int TotalResults { get; private set; }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
    }
}

