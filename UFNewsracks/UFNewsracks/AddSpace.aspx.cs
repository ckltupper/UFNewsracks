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
    public partial class AddSpace : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                SqlDataSource ds = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "Select Location From ctupper.Location");
                locationDropDown.DataTextField = "Location";
                locationDropDown.DataSource = ds;
                locationDropDown.DataBind();
            }
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
                sqlcmd.CommandText = "Insert Into Space (Location, Number, CoinMec, Size) Values (@Location, @Number, @CoinMec, @Size)";
                sqlcmd.Parameters.AddWithValue("@Location", locationDropDown.SelectedValue);
                sqlcmd.Parameters.AddWithValue("@Number", numberTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@CoinMec", coinMecRadioButtonList.SelectedValue);
                sqlcmd.Parameters.AddWithValue("@Size", sizeRadioButtonList.SelectedValue);
                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }
    }
}