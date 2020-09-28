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

    public partial class UserSys_Details : System.Web.UI.Page
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
                    else if (rol != "Sysadmin")
                    {
                        Response.Redirect("~/Index.aspx");
                    }
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
                    command.CommandText = "sp_usuarios";
                    command.Parameters.Add("@operacion", SqlDbType.VarChar).Value = "Display";
                    SqlDataAdapter adaptador = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    adaptador.Fill(ds);
                    //ASPxGridView1.DataSource = ds;
                    //ASPxGridView1.DataBind();
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    //GridView1.FooterRow.TableSection = TableRowSection.TableFooter;

                    //Attribute to show the Plus Minus Button.
                    GridView1.HeaderRow.Cells[1].Attributes["data-class"] = "expand";

                    //Attribute to hide column in Phone.
                    GridView1.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                    GridView1.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                    GridView1.HeaderRow.Cells[6].Attributes["data-hide"] = "phone";
                    GridView1.HeaderRow.Cells[7].Attributes["data-hide"] = "phone";

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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label a = (Label)GridView1.Rows[e.RowIndex].FindControl("id");
            string eid = a.Text;
            DeleteEmployee(eid);
            GridView1.EditIndex = -1;
            cargargrid();
        }
        protected void DeleteEmployee(string empid)
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
                    command.CommandText = "sp_usuarios";
                    command.Parameters.Add("@operacion", SqlDbType.VarChar).Value = "Delete";
                    command.Parameters.Add("@idUs", SqlDbType.VarChar).Value = empid;
                    SqlDataAdapter adaptador = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    adaptador.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
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

        protected void Button2_Click2(object sender, EventArgs e)
        {
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

            //string idrow = GridView1.DataKeys[rowIndex].Values[0].ToString();


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
                    command.CommandText = "sp_usuarios";
                    command.Parameters.Add(new SqlParameter("@operacion", SqlDbType.VarChar));
                    //parametros del proc, donde @idUs apunta al campo de la tabla y se iguala al valor de la variable seleccionada (get).
                    command.Parameters.Add(new SqlParameter("@idUs", SqlDbType.VarChar));
                    command.Parameters["@operacion"].Value = "Delete";
                    //command.Parameters["@idUs"].Value = idrow;
                    SqlDataAdapter adaptador = new SqlDataAdapter(command);
                    ds = new DataSet();
                    adaptador.Fill(ds);
                    //cargargrid();
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