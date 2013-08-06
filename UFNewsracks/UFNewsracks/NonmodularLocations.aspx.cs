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
    public partial class NonmodularLocations1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                SqlDataSource ds = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "Select Location From ctupper.AllLocations_vw Where Type = 'N'");
                NonmodularLocationsDropDown.DataTextField = "Location";
                NonmodularLocationsDropDown.DataSource = ds;
                NonmodularLocationsDropDown.DataBind();
            }
        }

        protected void NonmodularLocationsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            NonmodularPublicationsGrid.DataBind();
        }

        protected void NonmodularGridDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            NonmodularGridDataSource.SelectParameters["LocationName"].DefaultValue = NonmodularLocationsDropDown.SelectedValue;

        }
    }
}