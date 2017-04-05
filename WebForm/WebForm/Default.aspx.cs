using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace WebForm
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                var principal = (User as System.Security.Claims.ClaimsPrincipal).Claims;
                this.ClaimsGridView.DataSource = principal.Select(x => new { Type = x.Type, Value = x.Value });
                this.ClaimsGridView.DataBind();
            }
        }

    }
}