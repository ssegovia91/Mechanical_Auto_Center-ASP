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
    public partial class UserAdmin_CreateBitacora : System.Web.UI.Page
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
                cargaCliente();
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(sgsolisConnectionstring);
            command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_bitacoras";

            command.Parameters.Add("@cliente", SqlDbType.VarChar).Value = nombreCliente.SelectedItem.Text;
            command.Parameters.Add("@vehiculo", SqlDbType.VarChar).Value = VehicAsoc.SelectedItem.Text;
            command.Parameters.Add("@fecha", SqlDbType.VarChar).Value = fecha.Value;
            command.Parameters.Add("@servicio", SqlDbType.VarChar).Value = servicio.Value;
            command.Parameters.Add("@descAct", SqlDbType.VarChar).Value = DescAct.Value;
            command.Parameters.Add("@cantidadFactura", SqlDbType.VarChar).Value = factura.Value;
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
            nombreCliente.SelectedIndex = 0;
            VehicAsoc.SelectedIndex = 0;
            fecha.Value = string.Empty;
            servicio.Value = string.Empty;
            DescAct.Value = string.Empty;
            factura.Value = string.Empty;
            
        }

        public void cargaCliente()
        {
            try
            {
                SqlConnection conn = new SqlConnection(sgsolisConnectionstring);
                command = new SqlCommand();
                conn.Open();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_bitacoras";
                command.Parameters.Add("@operacion", SqlDbType.VarChar).Value = "DisplayCliente";
                SqlDataAdapter adaptador = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adaptador.Fill(ds, "clientes");
                nombreCliente.DataSource = ds;
                nombreCliente.DataTextField = "nombreCliente";
                nombreCliente.DataValueField = "idCliente";
                nombreCliente.DataBind();
                nombreCliente.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                nombreCliente.SelectedIndex = 0;
                conn.Close();
            }
            catch (Exception e)
            {

            }
        }

        protected void nombreCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idCliente = nombreCliente.SelectedValue;
            try
            {
                SqlConnection conn = new SqlConnection(sgsolisConnectionstring);
                command = new SqlCommand();
                conn.Open();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_bitacoras";
                command.Parameters.Add("@idCliente", SqlDbType.VarChar).Value = idCliente;
                command.Parameters.Add("@operacion", SqlDbType.VarChar).Value = "DisplayVehiculo";
                SqlDataAdapter adaptador = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adaptador.Fill(ds, "cliente_vehiculo");
                VehicAsoc.DataSource = ds;
                VehicAsoc.DataTextField = "vehiculo";
                VehicAsoc.DataValueField = "idVehiculo";
                VehicAsoc.DataBind();
                VehicAsoc.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                VehicAsoc.SelectedIndex = 0;
                conn.Close();
            }
            catch (Exception)
            {

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

        protected void clean_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}