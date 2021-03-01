using JobSearch.Domain.Entities;
using JobSearch.Domain.Enums;
using JobSearch.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JobSearch.Api
{
    public static class SeedData
    {
        public static void Migrate(this IApplicationBuilder application, bool acsess = true)
        {
            using (var scope = application.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                if (!acsess) return;

                var context = scope.ServiceProvider.GetRequiredService<JobSearchContext>();

                //context.Database.EnsureCreated();

                context.Database.Migrate();

                Seed(context);
            }
        }

        private static void Seed(JobSearchContext context)
        {
            if (!context.Users.Any())
            {
                context.Add(new User
                {
                    Name = "Adam",
                    Surname = "Smith",
                    Email = "adam@gmail.com",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                });
                context.SaveChanges();
            }

            if (!context.Jobs.Any())
            {
                List<Job> jobs = new List<Job>();
                jobs.Add(new Job
                {
                    Title = "Benivo",
                    City = "Yerevan",
                    Country = "Armenia",
                    EmploymentType = EmploymentType.FullTime,
                    Category = Category.SoftwareDevelopment,
                    Photo = "Benivo.jfif",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                });
                jobs.Add(new Job
                {
                    Title = "Google",
                    City = "Mountain View",
                    Country = "California",
                    EmploymentType = EmploymentType.FullTime,
                    Category = Category.SoftwareDevelopment,
                    Photo = "image-20150902-6700-t2axrz.jpg",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                });
                jobs.Add(new Job
                {
                    Title = "Facebook",
                    City = "Menlo Park",
                    Country = "California",
                    EmploymentType = EmploymentType.Remote,
                    Category = Category.QualityAssurance,
                    Photo = "facebook.jpg",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                });
                jobs.Add(new Job
                {
                    Title = "Amazon",
                    City = "Seattle",
                    Country = "Washington",
                    EmploymentType = EmploymentType.Remote,
                    Category = Category.QualityAssurance,
                    Photo = "20200909150701-7913.jpg",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                });
                jobs.Add(new Job
                {
                    Title = "Samsung",
                    City = "Seoul",
                    Country = "South Korea",
                    EmploymentType = EmploymentType.Contractor,
                    Category = Category.Product_ProjectManagement,
                    Photo = "samsung.png",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                });
                jobs.Add(new Job
                {
                    Title = "Apple",
                    City = "Cupertino",
                    Country = "California",
                    EmploymentType = EmploymentType.Internship,
                    Category = Category.Product_ProjectManagement,
                    Photo = "apple.jpg",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                });
                jobs.Add(new Job
                {
                    Title = "Mercedes",
                    City = "Stuttgart",
                    Country = "Germani",
                    EmploymentType = EmploymentType.PartTime,
                    Category = Category.OtherIT,
                    Photo = "OWUS_Careers_Internships-1.jpg",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                });

                jobs.Add(new Job
                {
                    Title = "CNN",
                    City = "Atlanta",
                    Country = "Georgia",
                    EmploymentType = EmploymentType.Internship,
                    Category = Category.Web_GraphicDesign,
                    Photo = "cnn.jpg",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                });
                jobs.Add(new Job
                {
                    Title = "Microsoft",
                    City = "Redmond",
                    Country = "Washington",
                    EmploymentType = EmploymentType.FullTime,
                    Category = Category.SoftwareDevelopment,
                    Photo = "Microsoft.jfif",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                });

                context.AddRange(jobs);
                context.SaveChanges();
            }
        }
    }
}
