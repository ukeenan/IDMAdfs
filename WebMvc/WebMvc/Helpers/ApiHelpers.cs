using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebMvc.Helpers
{
    public class ApiHelpers
    {

        public static async Task<string> GetToken()
        {
             
            var tokenServiceUrl = Startup.apiUrl+"Token";
            var client = new HttpClient();  
            List<KeyValuePair<string, string>> keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("username", Startup.apiUser));
            keyValues.Add(new KeyValuePair<string, string>("password", Startup.apiPassword));
            keyValues.Add(new KeyValuePair<string, string>("grant_type", Startup.apiGrantType));
            var requestParamsFormUrlEncoded = new FormUrlEncodedContent(keyValues);

            HttpResponseMessage response = await client.PostAsync(tokenServiceUrl, requestParamsFormUrlEncoded); 
            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsAsync<TokenModel>();
                return token.access_token;
            }
            return tokenServiceUrl;
        } 

    } 
    public class TokenModel
    {
         /// <summary>
        /// 
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string expires_in { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string token_type { get; set; }
    } 
}