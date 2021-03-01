using AutoMapper;
using JobSearch.Application.Helpers;
using JobSearch.Application.ViewModel.Jobs;
using JobSearch.Application.ViewModel.Pagings;
using JobSearch.Domain.Entities;
using JobSearch.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearch.Application.Services.Jobs
{
    public class JobService : IJobService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public JobService(IRepository repository,
            IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<bool> ApplyAsync(int id)
        {
            var user = await _repository.FilterAsNoTracking<User>(u => !u.IsDeleted).FirstOrDefaultAsync();
            var job = await _repository.Filter<Job>(j => j.Id == id).FirstOrDefaultAsync();
            if (job == null)
                throw new Exception("Job not found");

            var userJob = await _repository.Filter<UserJob>(uj => uj.JobId == job.Id && uj.UserId == id).FirstOrDefaultAsync();
            if (userJob != null)
            {
                userJob.IsApply = true;
                _repository.Update(userJob);
            }
            else
                await _repository.AddAsync(new UserJob
                {
                    JobId = job.Id,
                    UserId = user.Id,
                    IsApply = true,
                    IsBookMark = false
                });

            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> BookmarkAsync(int id)
        {
            var user = await _repository.FilterAsNoTracking<User>(u => !u.IsDeleted).FirstOrDefaultAsync();
            var job = await _repository.Filter<Job>(j => j.Id == id).FirstOrDefaultAsync();
            if (job == null)
                throw new Exception("Job not found");

            var userJob = await _repository.Filter<UserJob>(uj => uj.JobId == job.Id && uj.UserId == id).FirstOrDefaultAsync();
            if (userJob != null)
            {
                userJob.IsBookMark = true;
                _repository.Update(userJob);
            }
            else
                await _repository.AddAsync(new UserJob
                {
                    JobId = job.Id,
                    UserId = user.Id,
                    IsApply = false,
                    IsBookMark = true
                });

            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<string>> GetCitiesAsync()
        {
            return await _repository.FilterAsNoTracking<Job>(j => !j.IsDeleted)
                .Select(j => j.City).Distinct().ToArrayAsync();
        }

        public async Task<GetJobResponseModel> GetAsync(int id)
        {
            var user = _repository.FilterAsNoTracking<User>(u => !u.IsDeleted).FirstOrDefault();
            var job = await _repository.FilterAsNoTracking<Job>(j => j.Id == id)
                .Include(uj => uj.UserJobs.Where(uj => uj.UserId == user.Id)).FirstOrDefaultAsync();
            return _mapper.Map<Job, GetJobResponseModel>(job);
        }

        public PagingResponseModel<GetJobResponseModel> GetList(GetJobRequestModel model)
        {
            var user = _repository.FilterAsNoTracking<User>(u => !u.IsDeleted).FirstOrDefault();
            var query = _repository.FilterAsNoTracking<Job>(j => !j.IsDeleted);

            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(j => j.Title.Contains(model.Title));
            if (!string.IsNullOrEmpty(model.City))
                query = query.Where(j => j.City.Contains(model.City));
            if (model.EmploymentType != null)
                query = query.Where(j => j.EmploymentType == model.EmploymentType);
            if (model.Category != null)
                query = query.Where(j => j.Category == model.Category);

            var pagingResult = _repository.GetListByPaging(query, model.Count, model.Page);

            if (model.IsSort != null)
                pagingResult.query = pagingResult.query.OrderByDescending(j => j.Id);


            var jobsMap = _mapper.Map<IEnumerable<GetJobResponseModel>>
                (pagingResult.query.Include(j => j.UserJobs.Where(uj => uj.UserId == user.Id)));

            return Helper.PagingResponse(jobsMap, pagingResult.itemsCount, pagingResult.pagesCount);
        }
    }
}
