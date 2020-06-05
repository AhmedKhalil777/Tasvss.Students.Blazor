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
    public class ModuleDetailsBase:ComponentBase
    {
        [Inject]
        public ICourseService CourseService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public string CourseId { get; set; }
        public CourseDto Course { get; set; } = new CourseDto()
        {
            Doctors=new List<Doctor>(),
            Modules=new List<Module>(),
            Students=new List<Student>()
        };

        [Parameter]
        public string ModeuleId { get; set; }
        public Module Module { get; set; } = new Module()
        {
            Topics=new List<Topic>()
        };

        protected async override Task OnInitializedAsync()
        {
            Module = await CourseService.GetModuleById(CourseId, ModeuleId);
            Course = await CourseService.GetCourseById(CourseId);
        }
        protected void HandleClick(string moduleId)
        {
            NavigationManager.NavigateTo($"/moduledetails/{CourseId}/{moduleId}",true);
        }
    }
}
