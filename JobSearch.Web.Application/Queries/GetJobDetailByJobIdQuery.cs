using JobSearch.Web.Application.Client;
using System.Threading.Tasks;

namespace JobSearch.Web.Application.Queries
{
    public class GetJobDetailByJobIdQuery
    {
        public async Task<GetJobResponseModel> Execute(int id)
            => await StaticApiClient.Client.GetAsync(id);
    }
}
