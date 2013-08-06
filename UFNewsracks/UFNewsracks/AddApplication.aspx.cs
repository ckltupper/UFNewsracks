using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Web.Configuration;

namespace UFNewsracks
{
    public partial class AddApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                SqlDataSource ds = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "Select Publication From ctupper.Publication");
                publicationDropDown.DataTextField = "Publication";
                publicationDropDown.DataSource = ds;
                publicationDropDown.DataBind();
            }
        }

        protected void publicationDropDownDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            publicationDropDownDataSource.SelectParameters["PublicationName"].DefaultValue = publicationDropDown.SelectedValue;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
                sqlcmd.CommandText = "Insert Into Application (Date, Publication) Values (@Date, @Publication)";
                sqlcmd.Parameters.AddWithValue("@Date", dateTextBox1.Text + "/" + dateTextBox2.Text + "/" + dateTextBox3.Text);
                sqlcmd.Parameters.AddWithValue("@Publication", publicationDropDown.SelectedValue);
                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }
    }
}