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
    public partial class UserAdmin_ViewBitacora : System.Web.UI.Page
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
                    string idCliente = Request.QueryString["idBitacora"].ToString();
                    //despues iniciamos la conexion al BD.
                    conn.Open();
                    command = new SqlCommand();
                    command.Connection = conn;
                    //Aqui referenciamos el tipo a procedimiento
                    command.CommandType = CommandType.StoredProcedure;
                    //nombre del procedimiento almacenado
                    command.CommandText = "sp_bitacoras";
                    //# de operacion del proc almacenado
                    command.Parameters.Add("@operacion", SqlDbType.VarChar).Value = "DisplayDetails";
                    //parametros del proc, donde @idUs apunta al campo de la tabla y se iguala al valor de la variable seleccionada (get).
                    command.Parameters.Add("@idBitacora", SqlDbType.VarChar).Value = idCliente;
                    SqlDataAdapter adaptador = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    adaptador.Fill(ds);
                    idBitacora.Value = ds.Tables[0].Rows[0]["idBitacora"].ToString();
                    cliente.Value = ds.Tables[0].Rows[0]["cliente"].ToString();
                    vehiculo.Value = ds.Tables[0].Rows[0]["vehiculo"].ToString();
                    fecha.Value = ds.Tables[0].Rows[0]["fecha"].ToString();
                    servicio.Value = ds.Tables[0].Rows[0]["servicio"].ToString();
                    descAct.Value = ds.Tables[0].Rows[0]["descAct"].ToString();
                    cantidadFact.Value = ds.Tables[0].Rows[0]["cantidadFact"].ToString();

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

        protected void return_Click(object sender, EventArgs e)
        { 
            Response.Redirect("~/UserAdmin_DetailsBitacora.aspx");
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
    }
}