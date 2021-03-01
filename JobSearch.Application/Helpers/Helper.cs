using JobSearch.Application.ViewModel.Pagings;
using System.Collections.Generic;

namespace JobSearch.Application.Helpers
{
    public static class Helper
    {
        public static PagingResponseModel<TView> PagingResponse<TView>
            (this IEnumerable<TView> result, int itemsCount, int pagesCount) where TView : class
        {
            return new PagingResponseModel<TView>
            {
                Data = result,
                ItemCount = itemsCount,
                PageCount = pagesCount
            };
        }
    }
}
