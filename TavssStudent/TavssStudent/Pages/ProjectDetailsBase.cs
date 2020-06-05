using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TavssStudent.Models;
using TavssStudent.Services;

namespace TavssStudent.Pages
{
    public class ProjectDetailsBase : ComponentBase
    {
        [Inject]
        public IProjectService ProjectService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public string ProjectId { get; set; }
        public int Duration { get; set; }

        public Project Project { get; set; } = new Project()
        {
            Developer = new List<Developer>(),
            Framework = new Framework(),
            SuperVisior = new SuperVisor() { Name = "No Doctor yet." }
        };

        public IEnumerable<Project> Projects { get; set; } = new List<Project>();
        public Framework FrameworkParm { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Project = await ProjectService.GetProjectById(ProjectId);
            if (Project.SuperVisior == null)
            {
                Project.SuperVisior = new SuperVisor { Name = "No Doctor yet." };
            }
            FrameworkParm = Project.Framework;
            if (Project.Framework != null && Project.Framework.ToDos != null)
            {
                if(Project.Framework.ToDos.Count()>0)
                    Duration = Project.Framework.ToDos.LastOrDefault().EndDate.Day - Project.Framework.ToDos.LastOrDefault().StartDate.Day;
            }
            var result = await ProjectService.GetAllProjects();
            Projects = result.Where(p => p.Id != ProjectId).Take(3);
        }

        protected async Task CreateFrameworkAsync()
        {
            await ProjectService.CreateFramework(ProjectId);
            Project = await ProjectService.GetProjectById(ProjectId);
            FrameworkParm = Project.Framework;
            await ProjectService.GetAllProjects();
            StateHasChanged();
        }
        protected async Task DeleteDeveloperAsync(string developerId)
        {
            await ProjectService.RemoveDeveloperFromProject(ProjectId, developerId);
            StateHasChanged();
            NavigationManager.NavigateTo($"/projectdetails/{ProjectId}", true);

        }
        protected async Task ProjectDeleted()
        {
            Project = await ProjectService.GetProjectById(ProjectId);
            if (Project.SuperVisior == null)
            {
                Project.SuperVisior = new SuperVisor { Name = "No Doctor yet." };
            }
            FrameworkParm = Project.Framework;
            var result = await ProjectService.GetAllProjects();
            Projects = result.Where(p => p.Id != ProjectId).Take(3);
        }

        protected void HandleClick(string projectId)
        {
            NavigationManager.NavigateTo($"/projectdetails/{projectId}", true);
        }
    }
}
