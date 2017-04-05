using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace WebForm.Models
{
    public class TokenApiService
    {
        public async Task<string> GetTokenService()
        {
            var tokenServiceUrl = Startup.apiUrl + "Token";
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
            return null;
        }
    }
}