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
    public partial class EditPublication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlDataSource ds1 = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "Select Publication From ctupper.Publication");
                publicationDropDown.DataTextField = "Publication";
                publicationDropDown.DataSource = ds1;
                publicationDropDown.DataBind();

                SqlDataSource ds2 = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "Select Publisher From ctupper.Publisher");
                publisherDropDown.DataTextField = "Publisher";
                publisherDropDown.DataSource = ds2;
                publisherDropDown.DataBind();
            }
        }

        protected void publicationDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
            sqlcmd.CommandText = "Select * From Publication Where Publication = @Publication";
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcmd);

            sqlcmd.Parameters.AddWithValue("@Publication", publicationDropDown.SelectedValue);
            sqlda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                frequencyTextBox.Text = dt.Rows[0]["Frequency"].ToString();
                pagesTextBox.Text = dt.Rows[0]["Pages"].ToString();
                widthTextBox.Text = dt.Rows[0]["Width"].ToString();
                lengthTextBox.Text = dt.Rows[0]["Length"].ToString();
                publisherDropDown.SelectedValue = dt.Rows[0]["Publisher"].ToString();
            }

            sqlconn.Close();
        }

        protected void publicationDropDownDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            publicationDropDownDataSource.SelectParameters["PublicationName"].DefaultValue = publicationDropDown.SelectedValue;
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
                sqlcmd.CommandText = "UPDATE Publication SET Frequency='" + frequencyTextBox.Text + "'" + ",  Pages='" + pagesTextBox.Text + "'"
                    + ", Width='" + widthTextBox.Text + "'" + ", Length='" + lengthTextBox.Text + "'" + ", Publisher='" +
                    publisherDropDown.SelectedValue + "' WHERE Publication='" + publicationDropDown.SelectedValue + "'";

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }
    }
}