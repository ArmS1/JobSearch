using AutoMapper;
using JobSearch.Application.ViewModel.Jobs;
using JobSearch.Domain.Entities;
using System.Linq;

namespace JobSearch.Application.Mappers.Jobs
{
    public class JobMapper : Profile
    {
        public JobMapper()
        {
            CreateMap<Job, GetJobResponseModel>()
                .ForMember(dest => dest.IsApply, opt => opt.MapFrom(src =>
                    src.UserJobs.Select(uj => uj.IsApply).FirstOrDefault()))
                .ForMember(dest => dest.IsBookMark, opt => opt.MapFrom(src =>
                    src.UserJobs.Select(uj => uj.IsBookMark).FirstOrDefault()))
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => "https://localhost:44344/" + src.Photo));
        }
    }
}