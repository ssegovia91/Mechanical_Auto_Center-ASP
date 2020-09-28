using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SGAutomotriz
{
    public partial class UserAdmin_DetailsClient : System.Web.UI.Page
    {
        public string codigo;
        string sgsolisConnectionstring = ConfigurationManager.ConnectionStrings["sgsolisConnectionstring"].ConnectionString;
        SqlCommand command;
        DataSet ds;

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
                   
                }
                


        }

        public void cargargrid()
        {

            string message = string.Empty;

            try
            {
                SqlConnection conn = new SqlConnection(sgsolisConnectionstring);

                if (conn != null && string.IsNullOrEmpty(message))
                {
                    command = new SqlCommand();
                    conn.Open();
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_clientes";
                    command.Parameters.Add("@operacion", SqlDbType.VarChar).Value = "Display";
                    SqlDataAdapter adaptador = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    adaptador.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    //Attribute to show the Plus Minus Button.
                    GridView1.HeaderRow.Cells[1].Attributes["data-class"] = "expand";
                    //Attribute to hide column in Phone.
                    GridView1.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                    GridView1.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                    GridView1.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                    GridView1.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
                    GridView1.HeaderRow.Cells[6].Attributes["data-hide"] = "phone";
                    GridView1.HeaderRow.Cells[7].Attributes["data-hide"] = "phone";
                    GridView1.HeaderRow.Cells[8].Attributes["data-hide"] = "phone";

                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

                    
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            cargargrid();
        }

        protected void Button2_Click2(object sender, EventArgs e)
        {
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            string idrow = GridView1.DataKeys[rowIndex].Values[0].ToString();


            string message = string.Empty;


            try
            {
                SqlConnection conn = new SqlConnection(sgsolisConnectionstring);

                if (conn != null && string.IsNullOrEmpty(message))
                {
                    command = new SqlCommand();
                    conn.Open();
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_clientes";
                    command.Parameters.Add(new SqlParameter("@operacion", SqlDbType.VarChar));
                    //parametros del proc, donde @idUs apunta al campo de la tabla y se iguala al valor de la variable seleccionada (get).
                    command.Parameters.Add(new SqlParameter("@idCliente", SqlDbType.VarChar));
                    command.Parameters["@operacion"].Value = "Delete";
                    command.Parameters["@idCliente"].Value = idrow;
                    SqlDataAdapter adaptador = new SqlDataAdapter(command);
                    ds = new DataSet();
                    adaptador.Fill(ds);
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:showDelete(); ", true);
                    cargargrid();
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

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            cargargrid();
            Timer1.Enabled = false;
        }
    }
}