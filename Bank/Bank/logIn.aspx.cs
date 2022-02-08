using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
namespace Bank
{
    public partial class logIn : System.Web.UI.Page
    {
        private SqlConnection sqlconnection=null;
        protected async void Page_Load(object sender, EventArgs e)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            sqlconnection = new SqlConnection(connectionstring);
            await sqlconnection.OpenAsync();
        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> db = new Dictionary<string, string>();
            SqlCommand getusersCredCmd = new SqlCommand("SELECT [login], [pass] FROM [Table]", sqlconnection);
            SqlDataReader sqlReader = null;
            try
            {
                sqlReader = await getusersCredCmd.ExecuteReaderAsync(); 
                while (await sqlReader.ReadAsync())
                {
                    db.Add(Convert.ToString(sqlReader["login"]),Convert.ToString(sqlReader["pass"]));
                }
            }
            catch
            {

            }
            finally
            {
                if (sqlReader!=null)
                {
                    sqlReader.Close();
                }
            }
            if (TextBox2.Text==db[TextBox1.Text])
            {
                HttpCookie login = new HttpCookie("login",TextBox1.Text);
                HttpCookie sign = new HttpCookie("sign",SignGenerator.GetSign(TextBox1.Text+"salt"));
                Response.Cookies.Add(login);
                Response.Cookies.Add(sign);
                Response.Redirect("Userpage.aspx", false);
            }
        }
        protected void Page_Unload(object sendr ,EventArgs e)
        {
            if (sqlconnection !=null && sqlconnection.State!=System.Data.ConnectionState.Closed )
            {
                sqlconnection.Close();
            }
        }
    }
}