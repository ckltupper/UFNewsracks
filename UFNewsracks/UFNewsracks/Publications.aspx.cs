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
    public partial class Publications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!Page.IsPostBack)
            {
                SqlDataSource ds = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, 
                    "Select Publication From ctupper.Publication_vw");
                PublicationsDropDown.DataTextField = "Publication";
                PublicationsDropDown.DataSource = ds;
                PublicationsDropDown.DataBind();

                if (Request.Params["PublicationName"] != null)
                {
                    GridDataSource.SelectParameters["PublicationName"].DefaultValue = Request.Params["PublicationName"];

                    PublicationsDropDown.SelectedValue = Request.Params["PublicationName"];
                }


            }

        }

        protected void PublicationsDropDown_SelectedIndexChanged (object sender, EventArgs e)
        {
            LocationsGrid.DataBind();
        }

        protected void GridDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            GridDataSource.SelectParameters["PublicationName"].DefaultValue = PublicationsDropDown.SelectedValue;
            publicationLabel.Text = PublicationsDropDown.SelectedValue;
        }

        protected void GridDataSource_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {

        }
    }
}