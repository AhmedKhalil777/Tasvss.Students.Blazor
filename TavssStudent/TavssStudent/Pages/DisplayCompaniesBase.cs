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
    public class DisplayCompaniesBase:ComponentBase
    {
        [Inject]
        public ICommunityService CommunityService{ get; set; }

        [Parameter]
        public string CommunityId { get; set; }

        public IEnumerable<Company> Companies{ get; set; }

        protected override async Task OnInitializedAsync()
        {
            Companies = await CommunityService.GetCommunityCompanies(CommunityId);
        }

    }
}
