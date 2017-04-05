using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace WebForm.Models
{
    public class ApiServices
    {
        public async Task<string> GetValues(string Token)
        {
            var tokenServiceUrl = Startup.apiUrl + "api/Values";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage response = await client.GetAsync(tokenServiceUrl);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "Error";
        }
    }
    public class GroupUserModel
    {
        public string userDn { get; set; }
        public string groupDn { get; set; }
    }
}