using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForm.Models;

namespace WebForm
{
    public partial class ApiAccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(GetValues));
        }

        private async Task GetValues()
        { 
            string Token = Request.QueryString["Token"];  
            GroupUserModel model = new GroupUserModel(); 
            var ApiModel = new ApiServices(); 
            Response.Write(await ApiModel.GetValues(Token));   
            
        }
    }
}