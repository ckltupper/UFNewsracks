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
    public partial class EditEmergencyContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlDataSource ds1 = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "Select ECID From ctupper.EmergencyContact");
                eCIDDropDown.DataTextField = "ECID";
                eCIDDropDown.DataSource = ds1;
                eCIDDropDown.DataBind();

                SqlDataSource ds2 = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "Select Publisher From ctupper.Publisher");
                publisherDropDown.DataTextField = "Publisher";
                publisherDropDown.DataSource = ds2;
                publisherDropDown.DataBind();
            }
        }

        protected void eCIDDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
            sqlcmd.CommandText = "Select * From EmergencyContact Where ECID = @ECID";
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcmd);

            sqlcmd.Parameters.AddWithValue("@ECID", eCIDDropDown.SelectedValue);
            sqlda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                firstNameTextBox.Text = dt.Rows[0]["FirstName"].ToString();
                lastNameTextBox.Text = dt.Rows[0]["LastName"].ToString();
                phoneTextBox.Text = dt.Rows[0]["Phone"].ToString();
                extensionTextBox.Text = dt.Rows[0]["Extension"].ToString();
                emailTextBox.Text = dt.Rows[0]["Email"].ToString();
                publisherDropDown.SelectedValue = dt.Rows[0]["Publisher"].ToString();
            }

            sqlconn.Close();
        }

        protected void eCIDDropDownDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            eCIDDropDownDataSource.SelectParameters["ECID"].DefaultValue = eCIDDropDown.SelectedValue;
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
                sqlcmd.CommandText = "UPDATE EmergencyContact SET FirstName='" + firstNameTextBox.Text + "'" + ",  LastName='" + lastNameTextBox.Text + "'"
                     + ", Phone='" + phoneTextBox.Text + "'" + ", Extension='" + extensionTextBox.Text + "'" + ", Email='" + emailTextBox.Text + "'" + ", Publisher='"
                     + publisherDropDown.SelectedValue + "' WHERE ECID='" + eCIDDropDown.SelectedValue + "'";

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }
    }
}