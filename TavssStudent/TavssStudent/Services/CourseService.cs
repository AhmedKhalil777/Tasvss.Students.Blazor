using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TavssStudent.Models;

namespace TavssStudent.Services
{
    public class CourseService : ICourseService
    {
        private readonly HttpClient httpClient;

        public CourseService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<MinCourseViewModel>> GetCourses()
        {
            return await httpClient.GetJsonAsync<List<MinCourseViewModel>>("api/v1/supercourse/getcourses");

            //return await JsonSerializer.DeserializeAsync<IEnumerable<MinCourseViewModel>>
            //(await httpClient.GetStreamAsync($"api/v1/supercourse/getcourses"),
            //    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<MinCourseViewModel>> GetCoursesForStudent(string SID)
        {
            return await httpClient.GetJsonAsync<List<MinCourseViewModel>>($"api/v1/supercourse/getcourses/{SID}");

        }

        public async Task<CourseDto> GetCourseById(string CID)
        {
            return await httpClient.GetJsonAsync<CourseDto>($"api/v1/studentcourse/getcourse/{CID}");

        }

        public async Task<Module> GetModuleById(string CID, string MID)
        {
            return await httpClient.GetJsonAsync<Module>($"api/v1/studentcourse/getmodulebyid/{CID}/{MID}");

        }
    }
}
