using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace UFNewsracks
{
    public partial class EditContactPerson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlDataSource ds1 = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "Select CPID From ctupper.ContactPerson");
                cPIDDropDown.DataTextField = "CPID";
                cPIDDropDown.DataSource = ds1;
                cPIDDropDown.DataBind();

                SqlDataSource ds2 = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "Select Publisher From ctupper.Publisher");
                publisherDropDown.DataTextField = "Publisher";
                publisherDropDown.DataSource = ds2;
                publisherDropDown.DataBind();
            }
        }

        protected void cPIDDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
            sqlcmd.CommandText = "Select * From ContactPerson Where CPID = @CPID";
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcmd);

            sqlcmd.Parameters.AddWithValue("@CPID", cPIDDropDown.SelectedValue);
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

        protected void cPIDDropDownDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            cPIDDropDownDataSource.SelectParameters["CPID"].DefaultValue = cPIDDropDown.SelectedValue;
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
                sqlcmd.CommandText = "UPDATE ContactPerson SET FirstName='" + firstNameTextBox.Text + "'" + ",  LastName='" + lastNameTextBox.Text + "'"
                     + ", Phone='" + phoneTextBox.Text + "'" + ", Extension='" + extensionTextBox.Text + "'" + ", Email='" + emailTextBox.Text + "'" + ", Publisher='"
                     + publisherDropDown.SelectedValue + "' WHERE CPID='" + cPIDDropDown.SelectedValue + "'";

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }
    }
}