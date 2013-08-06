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
    public partial class Locations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!Page.IsPostBack)
            {

                SqlDataSource ds = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "Select Location From ctupper.AllLocations_vw");
                LocationsDropDown.DataTextField = "Location";
                LocationsDropDown.DataSource = ds;
                LocationsDropDown.DataBind();

                if (Request.Params["LocationName"] != null)
                {
                    LocationGridDataSource.SelectParameters["LocationName"].DefaultValue = Request.Params["LocationName"];

                    LocationsDropDown.SelectedValue = Request.Params["LocationName"];
                }
            }

            
        }

        protected void LocationsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            PublicationsGrid.DataBind();

            DataSourceSelectArguments args = new DataSourceSelectArguments();
            DataView view = (DataView)LocationGridDataSource.Select(args);
            DataTable dt = view.ToTable();

            locationLabel.Text = dt.Rows[0]["Location"].ToString();
            typeLabel.Text = dt.Rows[0]["Type"].ToString();
        }

        protected void LocationGridDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
             LocationGridDataSource.SelectParameters["LocationName"].DefaultValue = LocationsDropDown.SelectedValue;
            
        }

        
    }
}