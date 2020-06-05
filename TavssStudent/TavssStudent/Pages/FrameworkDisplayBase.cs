using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using TavssStudent.Models;
using TavssStudent.Services;

namespace TavssStudent.Pages
{
    public class FrameworkDisplayBase : ComponentBase
    {
        [Parameter]
        public string ProjectId { get; set; }

        [Parameter]
        public Framework FrameworkParm { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public EventCallback<string> OnProjectDeleted { get; set; }
        public Framework Framework { get; set; } = new Framework()
        {
            ToDos = new List<ToDo>(),
            Dones = new List<Done>(),
            InProgress = new List<InProgress>()
        };
        [Inject]
        public IProjectService ProjectService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (ProjectId != null)
            {
                Framework = await ProjectService.GetFramework(ProjectId);
            }
        }
        
        protected async Task DeleteToDoAsync(string todoId)
        {
            await ProjectService.RemoveToDOFromProject(ProjectId, todoId);
            StateHasChanged();
            await OnProjectDeleted.InvokeAsync(ProjectId);
            //NavigationManager.NavigateTo($"/projectdetails/{ProjectId}", true);
        }
        protected async Task DeleteInProgressAsync(string inprogressId)
        {
            await ProjectService.RemoveInProgressFromProject(ProjectId, inprogressId);
            StateHasChanged();
            await OnProjectDeleted.InvokeAsync(ProjectId);
        }
        protected async Task DeleteDoneAsync(string doneId)
        {
            await ProjectService.RemoveDoneFromProject(ProjectId, doneId);
            StateHasChanged();
            await OnProjectDeleted.InvokeAsync(ProjectId);
        }
    }
}
