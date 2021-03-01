using JobSearch.Web.Application.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace JobSearch.Web.Application.Queries
{
    public class GetJobsQuery
    {

        public async Task<GetJobResponseModelPagingResponseModel> Execute(GetJobRequestModel requestModel)
        {
            var responseModel = await StaticApiClient.Client.GetListAsync(requestModel);
            return responseModel;
        }

        public async Task<IEnumerable<string>> GetCities() => await StaticApiClient.Client.GetCitiesAsync();

        public async Task<bool> Bookmark(int id)
        {
            return await StaticApiClient.Client.BookmarkAsync(id);
        }

        public async Task<bool> Apply(int id)
        {
            return await StaticApiClient.Client.ApplyAsync(id);
        }
    }
}
