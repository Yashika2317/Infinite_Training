using System;
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
                string name = txtname.Text;
                string familyName = txtFamilyName.Text;
                string address = txtAddress.Text;
                string city = txtCity.Text;
                string zipCode = txtZipCode.Text;
                string phone = txtPhone.Text;
                string email = txtemail.Text;

                string queryString = $"?name={name}&familyName={familyName}&address={address}&city={city}&zipCode={zipCode}&phone={phone}&email={email}";

                Response.Redirect("Welcome.html" + queryString);
                lblSuccess.Visible = true;
            }
            else
            {
                lblSuccess.Visible = false;
            }
        }
    
    }
}
