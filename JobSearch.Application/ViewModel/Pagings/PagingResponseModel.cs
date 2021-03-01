using System.Collections.Generic;

namespace JobSearch.Application.ViewModel.Pagings
{
    public class PagingResponseModel<T> where T : class
    {
        public int ItemCount { get; set; }
        public int PageCount { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
