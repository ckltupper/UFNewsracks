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
    public partial class ModularLocations1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                SqlDataSource ds = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "Select Location From ctupper.AllLocations_vw Where Type = 'M'");
                ModularLocationsDropDown.DataTextField = "Location";
                ModularLocationsDropDown.DataSource = ds;
                ModularLocationsDropDown.DataBind();
            }
        }

        protected void ModularLocationsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModularPublicationsGrid.DataBind();
        }

        protected void ModularGridDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            ModularGridDataSource.SelectParameters["LocationName"].DefaultValue = ModularLocationsDropDown.SelectedValue;

        }
    }
}