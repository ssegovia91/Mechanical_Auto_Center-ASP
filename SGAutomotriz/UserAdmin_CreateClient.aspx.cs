using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Data.EntityClient;
using System.Data.Entity;


namespace SGAutomotriz
{
    public partial class UserAdmin_CreateClient : System.Web.UI.Page
    {
        //TextBox tb;
        //static int i = 0;
        string sgsolisConnectionstring = ConfigurationManager.ConnectionStrings["sgsolisConnectionstring"].ConnectionString;
        SqlCommand command;
        //SqlCommand command1;
        //SqlCommand command2;


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
                else if (rol != "Administrador")
                {
                    Response.Redirect("~/UserInvitado_Home.aspx");
                }
                Label1.Text = usuario;
                //cargaVehiculo();
            }
            
        }

        protected void save_Click(object sender, EventArgs e)
        {
            //almacenamiento de cliente
            SqlConnection conn = new SqlConnection(sgsolisConnectionstring);
            command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_clientes";
            command.Parameters.Add("@nombreCliente", SqlDbType.VarChar).Value = nombrecliente.Value;
            command.Parameters.Add("@calle", SqlDbType.VarChar).Value = calle.Value;
            command.Parameters.Add("@colonia", SqlDbType.VarChar).Value = colonia.Value;
            command.Parameters.Add("@telcel", SqlDbType.VarChar).Value = telcel.Value;
            command.Parameters.Add("@telcasa", SqlDbType.VarChar).Value = telcasa.Value;
            command.Parameters.Add("@notas", SqlDbType.VarChar).Value = notas.Value;
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

        public void limpiar()
        {
            nombrecliente.Value = string.Empty;
            calle.Value = string.Empty;
            colonia.Value = string.Empty;
            telcel.Value = string.Empty;
            telcasa.Value = string.Empty;
            notas.Value = string.Empty;
            //tipoUsuario.SelectedIndex = 0;

        }

        protected void modal_Click(object sender, EventArgs e)
        {
            if (pass.Value == "" || pass1.Value == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:showEmpty(); ", true);
            }
            else if (pass.Value != pass1.Value)
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:showError2(); ", true);
            }
            else
            {
                string message = string.Empty;

                try
                {
                    SqlConnection conn = new SqlConnection(sgsolisConnectionstring);

                    if (conn != null && string.IsNullOrEmpty(message))
                    {
                        //primero obtenemos el parametro get enviado por el webform2 (resultado de la seleccion del row)
                        //string idCliente = Request.QueryString["idCliente"].ToString();
                        //despues iniciamos la conexion al BD.
                        conn.Open();
                        command = new SqlCommand();
                        command.Connection = conn;
                        //Aqui referenciamos el tipo a procedimiento
                        command.CommandType = CommandType.StoredProcedure;
                        //nombre del procedimiento almacenado
                        command.CommandText = "sp_usuarios";
                        //# de operacion del proc almacenado
                        command.Parameters.Add("@operacion", SqlDbType.VarChar).Value = "UpdatePass";
                        //parametros del proc, donde @idUs apunta al campo de la tabla y se iguala al valor de la variable seleccionada (get).
                        command.Parameters.Add("@password", SqlDbType.VarChar).Value = pass.Value;
                        command.Parameters.Add("@nombreUsuario", SqlDbType.VarChar).Value = Label1.Text;
                        command.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:showAlert2(); ", true);

                    }


                }

                catch (Exception ex)
                {

                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:showError(); ", true);
                    pass.Value = string.Empty;
                    pass1.Value = string.Empty;

                }

                finally
                {

                    SqlConnection conn = new SqlConnection(sgsolisConnectionstring);
                    conn.Close();
                }
            }
        }

        protected void clean_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}