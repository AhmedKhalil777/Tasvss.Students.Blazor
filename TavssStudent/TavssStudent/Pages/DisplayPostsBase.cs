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
    public class DisplayPostsBase : ComponentBase
    {

        [Inject]
        public ICommunityService CommunityService { get; set; }

        [Parameter]
        public string CommunityId { get; set; }

        public IEnumerable<Post> Posts { get; set; }
        public List<Developer> Developers { get; set; }

        public Developer Developer { get; set; }

        protected async override Task OnInitializedAsync()
        {
            LoadDeveloper();
            Posts = await CommunityService.GetAllPosts();
        }

        private void LoadDeveloper()
        {
            Developers = new List<Developer>()
            {
                new Developer()
                {
                     Id="mohamed",
                     Name="Mohamed"
                },
                new Developer()
                {
                     Id="ahmed",
                     Name="Ahmed"
                }
            };
        }
    }
}
