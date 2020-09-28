using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SGAutomotriz
{
    public partial class UserSys_Edit : System.Web.UI.Page
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
                cargardatos();
            }
        }

        public void cargardatos()
        {

            string message = string.Empty;

            try
            {
                SqlConnection conn = new SqlConnection(sgsolisConnectionstring);

                if (conn != null && string.IsNullOrEmpty(message))
                {
                    //primero obtenemos el parametro get enviado por el webform2 (resultado de la seleccion del row)
                    string idUs = Request.QueryString["idUs"].ToString();
                    //despues iniciamos la conexion al BD.
                    conn.Open();
                    command = new SqlCommand();
                    command.Connection = conn;
                    //Aqui referenciamos el tipo a procedimiento
                    command.CommandType = CommandType.StoredProcedure;
                    //nombre del procedimiento almacenado
                    command.CommandText = "sp_usuarios";
                    //# de operacion del proc almacenado
                    command.Parameters.Add("@operacion", SqlDbType.VarChar).Value = "Display_1";
                    //parametros del proc, donde @idUs apunta al campo de la tabla y se iguala al valor de la variable seleccionada (get).
                    command.Parameters.Add("@idUs", SqlDbType.VarChar).Value = idUs;
                    SqlDataAdapter adaptador = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    adaptador.Fill(ds);
                    userName.Value = ds.Tables[0].Rows[0]["nombreUsuario"].ToString();
                    tipoUsuario.Value = ds.Tables[0].Rows[0]["tipoUsuario"].ToString();


                }


            }

            catch (Exception ex)
            {

                message = ex.Message;

            }

            finally
            {

                SqlConnection conn = new SqlConnection(sgsolisConnectionstring);
                conn.Close();
            }
        }
    }
}