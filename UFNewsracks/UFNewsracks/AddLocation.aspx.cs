using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data.Common;

namespace UFNewsracks
{
    public partial class AddLocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
                sqlcmd.CommandText = "Insert Into Location (Location, Longitude, Latitude, Type) Values (@Location, @Latitude, @Longitude, @Type)";
                sqlcmd.Parameters.AddWithValue("@Location", locationTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@Latitude", latitudeTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@Longitude", longitudeTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@Type", typeRadioButtonList.SelectedValue);
                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }
    }
}