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
    public class DisplayProjectsBase:ComponentBase
    {
        [Inject]
        public IProjectService ProjectService{ get; set; }
        public IEnumerable<Project> Projects { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Projects = await ProjectService.GetAllProjects();
        }
    }
}
