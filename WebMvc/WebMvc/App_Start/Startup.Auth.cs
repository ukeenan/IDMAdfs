using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.WsFederation;
using Owin;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Selectors;

namespace WebMvc
{
    public partial class Startup
    {
        private static string realm = ConfigurationManager.AppSettings["ida:Wtrealm"];
        private static string adfsMetadata = ConfigurationManager.AppSettings["ida:ADFSMetadata"];
        public static string application = ConfigurationManager.AppSettings["ida:Application"];
        public static string apiUser = ConfigurationManager.AppSettings["ida:ApiUser"];
        public static string apiPassword = ConfigurationManager.AppSettings["ida:ApiPassword"];
        public static string apiGrantType = ConfigurationManager.AppSettings["ida:ApiGrantType"];
        public static string apiUrl = ConfigurationManager.AppSettings["ida:ApiUrl"]; 

        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseWsFederationAuthentication(
                new WsFederationAuthenticationOptions
                {
                    Wtrealm = realm,
                    MetadataAddress = adfsMetadata
                }); 
        }
    }
}