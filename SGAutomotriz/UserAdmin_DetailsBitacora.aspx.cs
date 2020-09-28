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
    public partial class UserAdmin_DetailsBitacora : System.Web.UI.Page
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
                    cargargrid();
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
                    command.CommandText = "sp_bitacoras";
                    command.Parameters.Add("@operacion", SqlDbType.VarChar).Value = "DisplayGrid";
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

        protected void save_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            if (fechainicial.Value != "" || fechafinal.Value != "")
            {

                try
                {
                    SqlConnection conn = new SqlConnection(sgsolisConnectionstring);

                    if (conn != null && string.IsNullOrEmpty(message))
                    {
                        command = new SqlCommand();
                        conn.Open();
                        command.Connection = conn;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "sp_bitacoras";
                        command.Parameters.Add("@operacion", SqlDbType.VarChar).Value = "DisplayByFecha";
                        command.Parameters.Add("@fechainicial", SqlDbType.VarChar).Value = fechainicial.Value;
                        command.Parameters.Add("@fechafinal", SqlDbType.VarChar).Value = fechafinal.Value;
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
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:showAlert(); ", true);
                fechainicial.Value = "";
                fechafinal.Value = "";
                cargargrid();
            }

        }

        protected void clean_Click(object sender, EventArgs e)
        {
            cargargrid();
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