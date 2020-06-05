using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TavssStudent.Models;

namespace TavssStudent.Services
{
    public class CommunityService : ICommunityService
    {
        private readonly HttpClient httpClient;
        public CommunityService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<bool> CreatePost(string CID, InsertPostViewModel model)
        {
           await httpClient.PutJsonAsync<InsertPostViewModel>($"", model);
            return true;
        }

        public Task<bool> DeEmo(string CID, string PID, string EID)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeletePost(string CID, string PID)
        {
            await httpClient.DeleteAsync("");
            return true;

        }

        public Task<bool> Emo(string CID, string PID, Emotion emotion)
        {
            throw new NotImplementedException();
        }
        
        public async Task<IEnumerable<MinCommunityListViewModel>> GetCommunities()
        {
            return await httpClient.GetJsonAsync<IEnumerable<MinCommunityListViewModel>>("api/v1/Community/GetCommunities");
        }

        public async Task<CommunitiesDto> GetCommunity(string CID)
        {
            return await httpClient.GetJsonAsync<CommunitiesDto>($"api/v1/Community/GetCommunity/{CID}");
        }

        public async Task<IEnumerable<Company>> GetCommunityCompanies(string CID)
        {
             return await httpClient.GetJsonAsync<IEnumerable<Company>>($"api/v1/Community/GetCommunityCompanies/{CID}");
             
        }
        
        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await httpClient.GetJsonAsync<IEnumerable<Company>>("api/v1/Community/GetCompanies");
        }

        public async Task<Company> GetCompany(string CoID)
        {
            return await httpClient.GetJsonAsync<Company>($"api/v1/Community/GetCompany/{CoID}");

        }

        public async Task<Company> SearchCompany(string Name)
        {
            return await httpClient.GetJsonAsync<Company>($"api/v1/Community/SearchCompany/{Name}");
        }

        public async Task<IEnumerable<MinCommunityListViewModel>> GetDeveloperCommunities(string DID)
        {
            return await httpClient.GetJsonAsync<IEnumerable<MinCommunityListViewModel>>($"api/v1/Community/GetDeveloperCommunities/{DID}");
        }
        
        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return await httpClient.GetJsonAsync<IEnumerable<Post>>("api/v1/Community/GetAllPosts");
        }

        public async Task<IEnumerable<Post>> GetIssuerPosts(string IID)
        {
            return await httpClient.GetJsonAsync<IEnumerable<Post>>($"api/v1/Community/GetIssuerPosts/{IID}");
        }

        public async Task<Post> GetPost(string PID)
        {
            return await httpClient.GetJsonAsync<Post>($"api/v1/Community/GetPost/{PID}");

        }

        public async Task<bool> ModifyPost(string CID, string PID, UpdatePostViewModel model)
        {
            await httpClient.PutJsonAsync<UpdatePostViewModel>($"api/v1/Community/ModifyPost/{CID}/{PID}",model);
            return true;
        }

        public async Task<bool> ModifyPostImage(string CID, string PID, IFormFile file)
        {
            await httpClient.PutJsonAsync<UpdatePostViewModel>($"api/v1/Community/ModifyPostPic/{CID}/{PID}", file);
            return true;
        }

       
    }
}
