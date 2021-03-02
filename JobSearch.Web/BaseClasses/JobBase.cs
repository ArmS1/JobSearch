using JobSearch.Web.Application;
using JobSearch.Web.Application.Queries;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace JobSearch.Web.BaseClasses
{
    public class JobBase : ComponentBase
    {

        #region Fields
        private readonly GetJobsQuery _getJobsQuery;
        public GetJobResponseModelPagingResponseModel Jobs;
        public IEnumerable<string> Cities;
        #endregion

        #region Properties

        public SearchAttributes SearchModel = new SearchAttributes();

        #endregion

        #region Constructor

        public JobBase()
        {
            _getJobsQuery = new GetJobsQuery();
        }

        #endregion

        #region Methods

        public async Task Execute()
        {
            var request = new JobSearch.Web.Application.GetJobRequestModel
            {
                Page = 1,
                Count = 20,
                Category = SearchModel.Category,
                City = null,
                EmploymentType = SearchModel.Employmenttype,
                IsSort = null,
                Title = SearchModel.Title
            };

            Jobs = await _getJobsQuery.Execute(request);
        }

        private async Task GetCities()
        {
            Cities = await _getJobsQuery.GetCities();
        }

        public async Task Bookmark(int id)
        {
            await _getJobsQuery.Bookmark(id);
        }

        public async Task Apply(int id)
        {
            await _getJobsQuery.Apply(id);
        }

        protected override async Task OnInitializedAsync()
        {
            await Execute();
        }

        protected List<EmploymentType> employments = new List<EmploymentType>()
        {
            EmploymentType._1,
            EmploymentType._2,
            EmploymentType._3,
            EmploymentType._4,
            EmploymentType._5,
        };

        protected List<Category> categories = new List<Category>()
        {
            Category._1,
            Category._2,
            Category._3,
            Category._4,
            Category._5,
        };

        protected string GetNameFromValue(string value)
        {
            string v = "Full Time";

            switch (value)
            {
                case "_2":
                    v = "Part Time";
                    break;
                case "_3":
                    v = "Contractor";
                    break;
                case "_4":
                    v = "Internship";
                    break;
                case "_5":
                    v = "Remote";
                    break;
            }

            return v;
        }

        protected string GetNameFromCategories(string value)
        {
            string v = "Software Development";

            switch (value)
            {
                case "_2":
                    v = "Quality Assurance";
                    break;
                case "_3":
                    v = "Web/Graphic Design";
                    break;
                case "_4":
                    v = "Product/Project Management";
                    break;
                case "_5":
                    v = "Other IT";
                    break;
            }

            return v;
        }

        public void CategoryToEnum(string category)
        {
            switch (category)
            {
                case "Software Development":
                    SearchModel.Category = Category._1;
                    break;
                case "Quality Assurance":
                    SearchModel.Category = Category._2;
                    break;
                case "Web/Graphic Design":
                    SearchModel.Category = Category._3;
                    break;
                case "Product/Project Management":
                    SearchModel.Category = Category._4;
                    break;
                case "Other IT":
                    SearchModel.Category = Category._5;
                    break;
            }

        }

        public void EmploymentTypeToEnum(string employmentType)
        {
            switch (employmentType)
            {
                case "Full Time":
                    SearchModel.Employmenttype = EmploymentType._1;
                    break;
                case "Part Time":
                    SearchModel.Employmenttype = EmploymentType._2;
                    break;
                case "Contractor":
                    SearchModel.Employmenttype = EmploymentType._3;
                    break;
                case "Internship":
                    SearchModel.Employmenttype = EmploymentType._4;
                    break;
                case "Remote ":
                    SearchModel.Employmenttype = EmploymentType._5;
                    break;
            }
        }
        public void CheckboxClicked(string id, object value, bool isCategory)
        {
            if ((bool)value)
            {

                if (isCategory)
                {
                    CategoryToEnum(id);
                }
                else
                    EmploymentTypeToEnum(id);
            }
            else
            {
                if (isCategory)
                    SearchModel.Category = null;
                else
                    SearchModel.Employmenttype = null;
            }

            Task.Run(() => Execute()).GetAwaiter().GetResult();
            this.StateHasChanged();
        }

        #endregion

    }


    public class SearchAttributes
    {
        public string Title { get; set; } = null;
        public Category? Category { get; set; } = null;
        public EmploymentType? Employmenttype { get; set; } = null;

    }
}

