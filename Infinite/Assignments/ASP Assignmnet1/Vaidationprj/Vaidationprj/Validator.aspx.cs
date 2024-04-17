using System;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace YourNamespace
{
    public partial class Validator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnvalidate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Response.Redirect("Welcome.html");
                lblSuccess.Visible = true;
            }
            else
            {
                lblSuccess.Visible = false;
            }
        }

       

    }
}
