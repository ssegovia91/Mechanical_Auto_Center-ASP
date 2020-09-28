using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGAutomotriz
{
    public partial class Index : System.Web.UI.Page
    {


        loginDataContext lgn = new loginDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void loginbutton_Click1(object sender, EventArgs e)
        {
            try
            {
                if (user.Value == "" && password.Value == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:showAlert(); ", true);
                }
                else if (user.Value == "Sysadmin" && password.Value == "$oli$")
                {
                    Session["User"] = "Sysadmin";
                    Session["Role"] = "Sysadmin";
                    Response.Redirect("~/UserSys_Create.aspx");
                }
                else
                {

                    var resultado = (from x in lgn.usuarios
                                     where x.nombreUsuario.Equals(user.Value) & x.password.Equals(password.Value)
                                     select x).FirstOrDefault();

                    if (resultado != null)
                    {
                        Session["User"] = user.Value;
                        Session["Role"] = resultado.tipoUsuario;
                        Response.Redirect("~/UserAdmin_Home.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:showAlert(); ", true);
                    }
                }
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:showAlert2(); ", true);
            }
        }
    }
}