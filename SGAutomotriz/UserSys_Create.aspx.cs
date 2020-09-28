using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SGAutomotriz
{
    public partial class UserSys_Create : System.Web.UI.Page
    {
        string sgsolisConnectionstring = ConfigurationManager.ConnectionStrings["sgsolisConnectionstring"].ConnectionString;
        SqlCommand command;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string usuario = Session["User"] as string;
                //Label1.Text = usuario;
                string rol = Session["Role"] as string;

                if (usuario == "" || usuario == null)
                {
                    Response.Redirect("~/Index.aspx");
                }
                else if (rol != "Sysadmin")
                {
                    Response.Redirect("~/Index.aspx");
                }
                
            }
        }

        protected void save_Click1(object sender, EventArgs e)
        {
            if (pass.Value == pass1.Value)
            {
                SqlConnection conn = new SqlConnection(sgsolisConnectionstring);
                command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_usuarios";

                command.Parameters.Add("@nombreUsuario", SqlDbType.VarChar).Value = userName.Value;
                command.Parameters.Add("@password", SqlDbType.VarChar).Value = pass.Value;
                command.Parameters.Add("@tipoUsuario", SqlDbType.VarChar).Value = tipoUsuario.Value;
                command.Parameters.Add("@fechaCreacion", SqlDbType.VarChar).Value = "";
                command.Parameters.Add("@status", SqlDbType.Bit).Value = 1;
                command.Parameters.Add("@operacion", SqlDbType.VarChar).Value = "Add";

                command.Connection = conn;

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    limpiar();
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:showAlert(); ", true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:showError(); ", true);
                limpiar();
            }
        }
        public void limpiar()
        {
            userName.Value = string.Empty;
            pass.Value = string.Empty;
            pass1.Value = string.Empty;
            tipoUsuario.SelectedIndex = 0;

        }

        protected void clean_Click1(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}