using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace UFNewsracks
{
    public partial class EditApplicationSpace : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlDataSource ds1 = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "Select ApplicationID From ctupper.ApplicationSpace");
                locationDropDown.DataTextField = "ApplicationID";
                locationDropDown.DataSource = ds1;
                locationDropDown.DataBind();

            }
        }

        protected void applicationIDDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataSource ds2 = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "LocationByApplicationID");
            ds2.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            ds2.SelectParameters.Add("ApplicationID", applicationIDDropDown.SelectedValue);
            applicationIDDropDown.DataTextField = "Application";
            applicationIDDropDown.DataSource = ds2;
            applicationIDDropDown.DataBind();
        }

        protected void applicationIDDropDownDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            applicationIDDropDownDataSource.SelectParameters["ApplicationID"].DefaultValue = applicationIDDropDown.SelectedValue;
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
                sqlcmd.CommandText = "UPDATE ApplicationSpace SET Location='" + locationDropDown.SelectedValue + "'" + ",  SizeRequest='" + sizeRequestRadioButtonList.SelectedValue + "'"
                     + ", CoinMecRequest='" + coinMecRequestRadioButtonList.SelectedValue + "'" + ", Status='" + statusRadioButtonList.SelectedValue + "'" + ", Comment='" + commentTextBox.Text + 
                     "' WHERE ApplicationID='" + applicationIDDropDown.SelectedValue + "'";

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }

        protected void locationDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
            sqlcmd.CommandText = "Select * From ApplicationSpace Where Location = @Location";
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcmd);

            sqlcmd.Parameters.AddWithValue("@Location", locationDropDown.SelectedValue);
            sqlda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                coinMecRequestRadioButtonList.SelectedValue = dt.Rows[0]["CoinMecRequest"].ToString();
                sizeRequestRadioButtonList.SelectedValue = dt.Rows[0]["SizeRequest"].ToString();
                statusRadioButtonList.SelectedValue = dt.Rows[0]["Status"].ToString();
            }

            sqlconn.Close();
        }

        protected void locationDropDownDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            locationDropDownDataSource.SelectParameters["Location"].DefaultValue = locationDropDown.SelectedValue;
        }
    }
}