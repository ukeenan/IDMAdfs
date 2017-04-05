using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        /// <summary>
        /// Get All Return Login
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                var principal = (User as System.Security.Claims.ClaimsPrincipal).Claims;
                ViewBag.Principal = principal;
                return View("Principal");
            }
            return View();
        }
        /// <summary>
        /// Get Token
        /// </summary>
        /// <returns></returns>
        public async Task<string> getToken()
        {
            return await Helpers.ApiHelpers.GetToken();
        }
        /// <summary>
        /// Get Detail User By Upn
        /// </summary>
        /// <param name="Upn"></param>
        /// <param name="Token"></param>
        /// <returns></returns>
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
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public class GroupUserModel
    {
        public string userDn { get; set; }
        public string groupDn { get; set; }
    }
}