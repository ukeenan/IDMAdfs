using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks; 
using System.Windows;

namespace TestWPFApp
{
    /// <summary>
    /// Interaction logic for Sample.xaml
    /// </summary>
    public partial class Sample : Window
    {  
         string _upn = null;

        public async Task<string> GetWebApi(string url, string authorizationHeader)
        {  
            var client = new HttpClient(); 
            try
            {
                var jwtEncodedString = authorizationHeader.Substring(7); // trim 'Bearer ' from the start since its just a prefix for the token string
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtEncodedString); 
                var tokenServiceResponse = await client.GetAsync(url); 
                var responseString = await tokenServiceResponse.Content.ReadAsStringAsync(); 
                return responseString;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        private async void GetInfo()
        {
            string authorizationHeader = GetAuthorizationHeader();

            if (authorizationHeader == null)
            {
                return;
            }
            try
            {
                var jwtEncodedString = authorizationHeader.Substring(7); // trim 'Bearer ' from the start since its just a prefix for the token string
                var token = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);
                _upn = token.Claims.First(c => c.Type == "upn").Value;
                UPN.Text = _upn; 
                Token.Text = authorizationHeader;
                string apiUrl = "https://localhost:44331/api/Values";
                string result = await GetWebApi(apiUrl, authorizationHeader); 
                Result.Text = result;
            }
            catch (WebException)
            {
                 
            }
            catch (Exception)
            {
                 
            }
        }
        string GetAuthorizationHeader()
        {
            string authority = "https://login.publicsector.id/adfs";
            string resourceURI = "urn:webapi:idm"; 
            string clientID = "2bf3280d-1c3e-4f57-875c-254b28b283bb"; 
            string clientReturnURI = "http://WebIdmAdfs2016"; 

            AuthenticationContext ac = new AuthenticationContext(authority, false); 
            try {
                AuthenticationResult ar = ac.AcquireToken(resourceURI, clientID, new Uri(clientReturnURI));
                string authHeader = ar.CreateAuthorizationHeader(); 
                return authHeader;
            }
            catch(Exception ) {
                return "";
            }
        }
        public Sample()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            GetInfo();
        }
        void DisplayError(HttpStatusCode statusCode)
        {
            switch (statusCode)
            {
                case HttpStatusCode.Unauthorized:
                    {
                        // An unauthorized error occurred, indicating the security token provided did not satisfy the service requirements
                        // acquiring a new token may fix the issue.   
                        MessageBox.Show("You are not authorized to access the ToDoListService");



                    }
                    break;
                default:
                    MessageBox.Show("Sorry, accessing your ToDo list has hit a problem.");
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Token_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}