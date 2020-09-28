using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Specialized;
using System.Text;

namespace SGAutomotriz
{
    public partial class UserAdmin_CreateClientVehicle : System.Web.UI.Page
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
                cargaVehiculo();
            }
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
                command.CommandText = "sp_clientes";
                command.Parameters.Add("@operacion", SqlDbType.VarChar).Value = "List";
                SqlDataAdapter adaptador = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adaptador.Fill(ds, "clientes");
                cliente.DataSource = ds;
                cliente.DataTextField = "nombreCliente";
                cliente.DataValueField = "idCliente";
                cliente.DataBind();
            }
            catch (Exception e)
            {

            }
        }

        public void cargaVehiculo()
        {
            try
            {
                SqlConnection conn = new SqlConnection(sgsolisConnectionstring);
                command = new SqlCommand();
                conn.Open();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_vehiculos";
                command.Parameters.Add("@operacion", SqlDbType.VarChar).Value = "Display";
                SqlDataAdapter adaptador = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adaptador.Fill(ds, "vehiculos");
                vehiculos.DataSource = ds;
                vehiculos.DataTextField = "lista";
                vehiculos.DataValueField = "idVehiculo";
                vehiculos.DataBind();
            }
            catch (Exception e)
            {

            }
        }

        private string GetConnectionString()
        {
            //Where DBConnection is the connetion string that was set up in the web config file
            return System.Configuration.ConfigurationManager.ConnectionStrings["sgsolisConnectionstring"].ConnectionString;
        }

        private void InsertRecords(StringCollection sc, string idclient)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            StringBuilder sb = new StringBuilder(string.Empty);
            foreach (string item in sc)
            {
                const string sqlStatement = "INSERT INTO cliente_vehiculo (idCliente, idVehiculo) VALUES";
                const string sqlStatement2 = "UPDATE vehiculos SET  asignacion = '1' WHERE idVehiculo =";
                sb.AppendFormat("{0}('{1}','{2}'); ", sqlStatement, idclient, item);
                sb.AppendFormat("{0}'{1}'; ", sqlStatement2, item);
            }

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:showAlert(); ", true);
                cargaVehiculo();
            }

            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            StringCollection sc = new StringCollection();
            string idClient = cliente.Value;

            foreach (ListItem item in vehiculos.Items)
            {
                if (item.Selected)
                {
                    sc.Add(item.Value);
                }

            }
            //foreach (ListItem item in ListBox1.Items)
            //{
            //    if (item.Selected)
            //    {
            //        sc.Add(item.Text);
            //    }

            //}
            InsertRecords(sc, idClient);
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