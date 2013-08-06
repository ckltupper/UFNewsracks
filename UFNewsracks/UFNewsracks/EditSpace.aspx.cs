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
    public partial class EditSpace : System.Web.UI.Page
    {
        


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlDataSource ds1 = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "Select Location From ctupper.Location");
                locationDropDown.DataTextField = "Location";
                locationDropDown.DataSource = ds1;
                locationDropDown.DataBind();

            }
        }

        protected void locationDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataSource ds2 = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "SpaceByLocation");
            ds2.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            ds2.SelectParameters.Add("LocationName", locationDropDown.SelectedValue);
            spaceDropDown.DataTextField = "Number";
            spaceDropDown.DataSource = ds2;
            spaceDropDown.DataBind();

        }

        protected void locationDropDownDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            locationDropDownDataSource.SelectParameters["Location"].DefaultValue = locationDropDown.SelectedValue;
            
        }

        protected void spaceDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
            sqlcmd.CommandText = "Select * From Space Where Number = @Number";
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcmd);

            sqlcmd.Parameters.AddWithValue("@Number", spaceDropDown.SelectedValue);
            sqlda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                coinMecRadioButtonList.SelectedValue = dt.Rows[0]["CoinMec"].ToString();
                sizeRadioButtonList.SelectedValue = dt.Rows[0]["Size"].ToString();
                aApplicationIDTextBox.Text = dt.Rows[0]["AApplicationID"].ToString();
            }

            sqlconn.Close();
        }

        protected void spaceDropDownDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            spaceDropDownDataSource.SelectParameters["Number"].DefaultValue = spaceDropDown.SelectedValue;
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
                sqlcmd.CommandText = "UPDATE Space SET CoinMec='" + coinMecRadioButtonList.SelectedValue + "'" + ",  Size='" + sizeRadioButtonList.SelectedValue + "'"
                     + ", AApplicationID='" + aApplicationIDTextBox.Text + "' WHERE spaceID='" + spaceDropDown.SelectedValue + "'";

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }
    }
}