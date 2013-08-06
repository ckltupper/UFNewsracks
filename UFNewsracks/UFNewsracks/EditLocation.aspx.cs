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
    public partial class EditLocation : System.Web.UI.Page
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

        protected void updateButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
                sqlcmd.CommandText = "UPDATE Location SET Latitude='" + latitudeTextBox.Text + "'" + ",  Longitude='" + longitudeTextBox.Text + "'" + ", Type='" + typeRadioButtonList.SelectedValue + "' WHERE Location='" + locationDropDown.SelectedValue + "'";
                
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
            sqlcmd.CommandText = "Select * From Location Where Location = @Location";
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcmd);

            sqlcmd.Parameters.AddWithValue("@Location", locationDropDown.SelectedValue);
            sqlda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                latitudeTextBox.Text = dt.Rows[0]["Latitude"].ToString();
                longitudeTextBox.Text = dt.Rows[0]["Longitude"].ToString();
                typeRadioButtonList.SelectedValue = dt.Rows[0]["Type"].ToString();
            }

            sqlconn.Close();
        }
    }
}