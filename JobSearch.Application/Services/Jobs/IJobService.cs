using JobSearch.Application.ViewModel.Jobs;
using JobSearch.Application.ViewModel.Pagings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobSearch.Application.Services.Jobs
{
    public interface IJobService
    {
        Task<GetJobResponseModel> GetAsync(int id);
        PagingResponseModel<GetJobResponseModel> GetList(GetJobRequestModel model);
        Task<IEnumerable<string>> GetCitiesAsync();
        Task<bool> ApplyAsync(int id);
        Task<bool> BookmarkAsync(int id);
    }
}
