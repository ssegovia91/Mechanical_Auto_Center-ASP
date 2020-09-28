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
    public partial class UserAdmin_EditVehicle : System.Web.UI.Page
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
                else if (rol != "Administrador")
                {
                    Response.Redirect("~/UserInvitado_Home.aspx");
                }
                Label1.Text = usuario;
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
                    string idVehiculo = Request.QueryString["idVehiculo"].ToString();
                    //despues iniciamos la conexion al BD.
                    conn.Open();
                    command = new SqlCommand();
                    command.Connection = conn;
                    //Aqui referenciamos el tipo a procedimiento
                    command.CommandType = CommandType.StoredProcedure;
                    //nombre del procedimiento almacenado
                    command.CommandText = "sp_vehiculos";
                    //# de operacion del proc almacenado
                    command.Parameters.Add("@operacion", SqlDbType.VarChar).Value = "Display_1";
                    //parametros del proc, donde @idUs apunta al campo de la tabla y se iguala al valor de la variable seleccionada (get).
                    command.Parameters.Add("@idVehiculo", SqlDbType.VarChar).Value = idVehiculo;
                    SqlDataAdapter adaptador = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    adaptador.Fill(ds);
                    idVehicle.Value = ds.Tables[0].Rows[0]["idVehiculo"].ToString();
                    marca.Value = ds.Tables[0].Rows[0]["marca"].ToString();
                    nombre.Value = ds.Tables[0].Rows[0]["nombre"].ToString();
                    modelo.Value = ds.Tables[0].Rows[0]["modelo"].ToString();
                    color.Value = ds.Tables[0].Rows[0]["color"].ToString();
                    cilindros.Value = ds.Tables[0].Rows[0]["cilindros"].ToString();
                    otrodetalle.Value = ds.Tables[0].Rows[0]["otrodetalle"].ToString();

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

        protected void save_Click(object sender, EventArgs e)
        {
            //actualizacion de clientes
            SqlConnection conn = new SqlConnection(sgsolisConnectionstring);
            command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_vehiculos";
            command.Parameters.Add("@idVehiculo", SqlDbType.VarChar).Value = idVehicle.Value;
            command.Parameters.Add("@marca", SqlDbType.VarChar).Value = marca.Value;
            command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre.Value;
            command.Parameters.Add("@modelo", SqlDbType.VarChar).Value = modelo.Value;
            command.Parameters.Add("@color", SqlDbType.VarChar).Value = color.Value;
            command.Parameters.Add("@cilindros", SqlDbType.VarChar).Value = cilindros.Value;
            command.Parameters.Add("@otrodetalle", SqlDbType.VarChar).Value = otrodetalle.Value;
            command.Parameters.Add("@operacion", SqlDbType.VarChar).Value = "Update";
            command.Connection = conn;

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:showAlert(); ", true);
                Response.Redirect("~/UserAdmin_DetailsVehicle.aspx");
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

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserAdmin_DetailsVehicle.aspx");
        }
    }
}