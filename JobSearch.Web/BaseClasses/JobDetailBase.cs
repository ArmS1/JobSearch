using JobSearch.Web.Application;
using JobSearch.Web.Application.Queries;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace JobSearch.Web.BaseClasses
{
    public class JobDetailBase : ComponentBase
    {
        private readonly GetJobDetailByJobIdQuery _getJobDetail;
        public JobDetailBase() => _getJobDetail = new GetJobDetailByJobIdQuery();

        public int Id { get; set; }

        public async Task<GetJobResponseModel> Execute(int id) =>
            await _getJobDetail.Execute(id);


        protected override async Task OnInitializedAsync()
        {

            await Execute(Id);
        }
    }
}
