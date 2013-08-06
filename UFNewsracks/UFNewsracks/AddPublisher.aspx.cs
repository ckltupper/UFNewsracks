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
    public partial class Publisher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {

            using (SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
                sqlcmd.CommandText = "Insert Into Publisher Values (@Publisher, @MailingStreet, @MailingCity, @MailingState, @MailingZip, @PhysicalStreet, @PhysicalCity, @PhysicalState, @PhysicalZip, @Phone, @Extension)";
                sqlcmd.Parameters.AddWithValue("@Publisher", publisherTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@MailingStreet", mailingStreetTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@MailingCity", mailingCityTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@MailingState", mailingStateTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@MailingZip", mailingZipTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@PhysicalStreet", physicalStreetTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@PhysicalCity", physicalCityTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@PhysicalState", physicalStateTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@PhysicalZip", physicalZipTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@Phone", (phoneTextBox1.Text + "-" + phoneTextBox2.Text + "-" + phoneTextBox3.Text));
                sqlcmd.Parameters.AddWithValue("@Extension", extensionTextBox.Text);
                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }
    }
}