using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _username = null;
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void GetHello()
        {
            string authorizationHeader = GetAuthorizationHeader();

            if (authorizationHeader == null)
            {
                return;
            }
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://webapi.publicsector.id/api/Hello");
                request.Headers.TryAddWithoutValidation("Authorization", authorizationHeader);
                HttpResponseMessage response = await client.SendAsync(request);
                string responseString = await response.Content.ReadAsStringAsync();

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                List<ToDoItem> toDoArray = serializer.Deserialize<List<ToDoItem>>(responseString);

                dgToDoItems.AutoGenerateColumns = true;
                dgToDoItems.ItemsSource = toDoArray;
            }
            catch (WebException ex)
            {
                DisplayError(((HttpWebResponse)(ex.Response)).StatusCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.Message));
            }
        }
        private async void GetToDoList()
        {
            string authorizationHeader = GetAuthorizationHeader();

            if (authorizationHeader == null)
            {
                return;
            }
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://webapi.publicsector.id/api/ToDoList");
                request.Headers.TryAddWithoutValidation("Authorization", authorizationHeader);
                HttpResponseMessage response = await client.SendAsync(request);
                string responseString = await response.Content.ReadAsStringAsync();


                JavaScriptSerializer serializer = new JavaScriptSerializer();
                List<ToDoItem> toDoArray = serializer.Deserialize<List<ToDoItem>>(responseString);

                dgToDoItems.AutoGenerateColumns = true;
                dgToDoItems.ItemsSource = toDoArray;




            }
            catch (WebException ex)
            {
                DisplayError(((HttpWebResponse)(ex.Response)).StatusCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.Message));
            }
        }

        HttpWebResponse GetResponseFromService(string authorizationHeader, ToDoItem item)
        {
            string httpRequestMethod = "POST";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://webapi.publicsector.id/api/ToDoList");
            request.Method = httpRequestMethod;
            request.ContentType = "application/json";

            // add the access token to the http authorization header on the call to access the resource.                      
            request.Headers["Authorization"] = authorizationHeader;


            JavaScriptSerializer serializer = new JavaScriptSerializer();
            if (item != null)
            {
                string content = serializer.Serialize(item);

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(Encoding.UTF8.GetBytes(content), 0, content.Length);
                }
            }

            // Call the TodoListService
            return (HttpWebResponse)request.GetResponse();
        }

        string GetAuthorizationHeader()
        {
            string authority = "https://login.publicsector.id/adfs";
            string resourceURI = "urn:webapi:ps";
            //a64ebc47-0b15-490f-8fe7-abfb2d640e9e
            //string clientID = "4BD0D3C2-97DF-408B-A6D4-A8FCF84030C0";
            string clientID = "a64ebc47-0b15-490f-8fe7-abfb2d640e9e";
            string clientReturnURI = "http://wpfapp/";

            try
            {
                AuthenticationContext ac = new AuthenticationContext(authority, false);
                AuthenticationResult ar = ac.AcquireToken(resourceURI, clientID, new Uri(clientReturnURI));
                string authHeader = ar.CreateAuthorizationHeader();

                return authHeader;
            }
            catch (Exception ex)
            {
                string message = ex.Message;

                if (ex.InnerException != null)
                {
                    message += "InnerException : " + ex.InnerException.Message;
                }

                MessageBox.Show(message);
            }

            return null;
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

        private void Button_Get(object sender, RoutedEventArgs e)
        {
            GetToDoList();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtToDoItem.Text))
            {
                MessageBox.Show("Please enter a value for the to-do item name");
                return;
            }

            string authorizationHeader = GetAuthorizationHeader();

            if (authorizationHeader == null)
            {
                return;
            }

            try
            {
                ToDoItem item = new ToDoItem();
                item.Title = txtToDoItem.Text;

                // Call the ToDoListService
                GetResponseFromService(authorizationHeader, item);


                txtToDoItem.Text = "";
                GetToDoList();
            }
            catch (WebException ex)
            {
                DisplayError(((HttpWebResponse)(ex.Response)).StatusCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.Message));
            }
        }
    }

    public class ToDoItem
    {
        public string Title { get; set; }
    }
}
