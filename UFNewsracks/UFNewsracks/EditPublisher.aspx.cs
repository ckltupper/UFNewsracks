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
    public partial class EditPublisher : System.Web.UI.Page
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

        protected void publisherDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
            sqlcmd.CommandText = "Select * From Publisher Where Publisher = @Publisher";
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcmd);

            sqlcmd.Parameters.AddWithValue("@Publisher", publisherDropDown.SelectedValue);
            sqlda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                mailingStreetTextBox.Text = dt.Rows[0]["MailingStreet"].ToString();
                mailingCityTextBox.Text = dt.Rows[0]["MailingCity"].ToString();
                mailingStateTextBox.Text = dt.Rows[0]["MailingState"].ToString();
                mailingZipTextBox.Text = dt.Rows[0]["MailingZip"].ToString();
                physicalStreetTextBox.Text = dt.Rows[0]["PhysicalStreet"].ToString();
                physicalCityTextBox.Text = dt.Rows[0]["PhysicalCity"].ToString();
                physicalStateTextBox.Text = dt.Rows[0]["PhysicalState"].ToString();
                physicalZipTextBox.Text = dt.Rows[0]["PhysicalZip"].ToString();
                phoneTextBox.Text = dt.Rows[0]["Phone"].ToString();
                extensionTextBox.Text = dt.Rows[0]["Extension"].ToString();
            }

            sqlconn.Close();
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
                sqlcmd.CommandText = "UPDATE Publisher SET MailingStreet='" + mailingStreetTextBox.Text + "'" + ",  MailingCity='" + mailingCityTextBox.Text + "'" 
                    + ", MailingState='" + mailingStateTextBox.Text + "'" + ", MailingZip='" + mailingZipTextBox.Text + "'" + ", PhysicalStreet='" + 
                    physicalStreetTextBox.Text + "'" + ", PhysicalCity='" + physicalCityTextBox.Text + "'" + ", PhysicalState='" + physicalStateTextBox.Text + "'" 
                    + ", PhysicalZip='" + physicalZipTextBox.Text + "'" + ", Phone='" + phoneTextBox.Text + "'" + ", Extension='" + extensionTextBox.Text + "' WHERE Publisher='" + publisherDropDown.SelectedValue + "'";

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