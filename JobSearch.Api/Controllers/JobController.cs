using JobSearch.Application.Services.Jobs;
using JobSearch.Application.ViewModel.Jobs;
using JobSearch.Application.ViewModel.Pagings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobSearch.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]/[action]/")]
    public class JobController : Controller
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpPost]
        public async Task<bool> Apply([FromQuery] int id)
        {
            return await _jobService.ApplyAsync(id);
        }

        [HttpPost]
        public async Task<bool> Bookmark([FromQuery] int id)
        {
            return await _jobService.BookmarkAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<string>> GetCities()
        {
            return await _jobService.GetCitiesAsync();
        }

        [HttpGet]
        public async Task<GetJobResponseModel> Get([FromQuery] int id)
        {
            return await _jobService.GetAsync(id);
        }

        [HttpPost]
        public ActionResult<PagingResponseModel<GetJobResponseModel>> GetList([FromBody] GetJobRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return _jobService.GetList(model);
        }
    }
}
