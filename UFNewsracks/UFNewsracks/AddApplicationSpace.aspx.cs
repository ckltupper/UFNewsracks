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
    public partial class AddApplicationSpace : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlDataSource ds1 = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "Select ApplicationID From ctupper.Application");
                applicationIDDropDown.DataTextField = "ApplicationID";
                applicationIDDropDown.DataSource = ds1;
                applicationIDDropDown.DataBind();
                
                SqlDataSource ds2 = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "Select Location From ctupper.Location");
                locationDropDown.DataTextField = "Location";
                locationDropDown.DataSource = ds2;
                locationDropDown.DataBind();
            }
        }

        protected void applicationIDDropDownDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            applicationIDDropDownDataSource.SelectParameters["ApplicationID"].DefaultValue = applicationIDDropDown.SelectedValue;
        }

        protected void locationDropDownDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            locationDropDownDataSource.SelectParameters["LocationName"].DefaultValue = locationDropDown.SelectedValue;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
                sqlcmd.CommandText = "Insert Into ApplicationSpace (ApplicationID, Location, SizeRequest, CoinMecRequest, Status, Comment) Values (@ApplicationID, @Location, @SizeRequest, @CoinMecRequest, @Status, @Comment)";
                sqlcmd.Parameters.AddWithValue("@ApplicationId", applicationIDDropDown.SelectedValue);
                sqlcmd.Parameters.AddWithValue("@Location", locationDropDown.SelectedValue);
                sqlcmd.Parameters.AddWithValue("@SizeRequest", sizeRadioButtonList.SelectedValue);
                sqlcmd.Parameters.AddWithValue("@CoinMecRequest", coinMecRadioButtonList.SelectedValue);
                sqlcmd.Parameters.AddWithValue("@Status", statusRadioButtonList.SelectedValue);
                sqlcmd.Parameters.AddWithValue("@Comment", commentTextBox.Text);
                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }
    }
}