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
    public partial class AddPublication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                SqlDataSource ds = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "Select Publisher From ctupper.Publisher");
                publisherDropDown.DataTextField = "Publisher";
                publisherDropDown.DataSource = ds;
                publisherDropDown.DataBind();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
                sqlcmd.CommandText = "Insert Into Publication Values (@Publication, @Frequency, @Pages, @Width, @Length, @Publisher)";
                sqlcmd.Parameters.AddWithValue("@Publication", publicationTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@Frequency", frequencyTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@Pages", pagesTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@Width", widthTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@Length", lengthTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@Publisher", publisherDropDown.SelectedValue);
                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }

        protected void publisherDropDownDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            publisherDropDownDataSource.SelectParameters["PublisherName"].DefaultValue = publisherDropDown.SelectedValue;
        }

        
        
    }
}