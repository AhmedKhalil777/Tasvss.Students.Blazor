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
    public class CommunityDetailsBase:ComponentBase
    {
        [Inject]
        public ICommunityService CommunityService{ get; set; }
        [Inject]
        public ICourseService CourseService{ get; set; }

        [Parameter]
        public string CommunityId { get; set; }

        public CommunitiesDto Community { get; set; }

        public Post Post { get; set; }
        public Developer Developer { get; set; }
        public List<Developer> Developers { get; set; }

        public IEnumerable<MinCourseViewModel> Courses{ get; set; }

        protected override async Task OnInitializedAsync()
        {
            Community = await CommunityService.GetCommunity(CommunityId);
            LoadDeveloper();
            if (Community.Posts.Count()!=0)
            {
                Post = Community.Posts.FirstOrDefault();
                Developer = Developers.FirstOrDefault();

            }
            Courses   = await CourseService.GetCourses();
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
