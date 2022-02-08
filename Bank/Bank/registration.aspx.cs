using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bank
{
    public partial class registration : System.Web.UI.Page
    {
        private SqlConnection sqlconnection = null;
        protected async void Page_Load(object sender, EventArgs e)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            sqlconnection = new SqlConnection(connectionstring);
            await sqlconnection.OpenAsync();
        }

        protected async System.Threading.Tasks.Task Button1_Click(object sender, EventArgs e)
        {
           
        }
        protected void Page_Unload(object sendr, EventArgs e)
        {
            if (sqlconnection != null && sqlconnection.State != System.Data.ConnectionState.Closed)
            {
                sqlconnection.Close();
            }
        }

        protected async void Button1_Click1(object sender, EventArgs e)
        {
            Dictionary<string, string> db = new Dictionary<string, string>();
            SqlCommand getusersCredCmd = new SqlCommand("SELECT [login], [pass] FROM [Table]", sqlconnection);
            SqlDataReader sqlReader = null;
            try
            {
                sqlReader = await getusersCredCmd.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    db.Add(Convert.ToString(sqlReader["login"]), Convert.ToString(sqlReader["pass"]));
                }
            }
            catch
            {

            }
            finally
            {
                if (sqlReader != null)
                {
                    sqlReader.Close();
                }
            }
            if (!db.Keys.Contains(TextBox1.Text))
            {
                SqlCommand regUser = new SqlCommand("INSERT INTO [Table] (login, pass)VAlUES(@login,@pass)", sqlconnection);
                regUser.Parameters.AddWithValue("login", TextBox1.Text);
                regUser.Parameters.AddWithValue("pass", TextBox2.Text);
                await regUser.ExecuteNonQueryAsync();
                Response.Redirect("login.aspx", false);
            }
            else
            {
                string script = "alert(\"такое пользователь уже зарегистрирован\")";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "MessageBox", script, true);

            }
        }
    }
}