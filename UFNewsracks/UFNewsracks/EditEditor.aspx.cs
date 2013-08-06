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
    public partial class EditEditor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlDataSource ds1 = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "Select EditorID From ctupper.Editor");
                editorIDDropDown.DataTextField = "EditorID";
                editorIDDropDown.DataSource = ds1;
                editorIDDropDown.DataBind();

                SqlDataSource ds2 = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "Select Publication From ctupper.Publication");
                publicationDropDown.DataTextField = "Publication";
                publicationDropDown.DataSource = ds2;
                publicationDropDown.DataBind();
            }
        }

        protected void editorIDDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
            sqlcmd.CommandText = "Select * From Editor Where EditorID = @EditorID";
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcmd);

            sqlcmd.Parameters.AddWithValue("@EditorID", editorIDDropDown.SelectedValue);
            sqlda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                firstNameTextBox.Text = dt.Rows[0]["FirstName"].ToString();
                lastNameTextBox.Text = dt.Rows[0]["LastName"].ToString();
                phoneTextBox.Text = dt.Rows[0]["Phone"].ToString();
                extensionTextBox.Text = dt.Rows[0]["Extension"].ToString();
                emailTextBox.Text = dt.Rows[0]["Email"].ToString();
                publicationDropDown.SelectedValue = dt.Rows[0]["Publication"].ToString();
            }

            sqlconn.Close();
        }

        protected void editorIDDropDownDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            editorIDDropDownDataSource.SelectParameters["EditorID"].DefaultValue = editorIDDropDown.SelectedValue;
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
                sqlcmd.CommandText = "UPDATE Editor SET FirstName='" + firstNameTextBox.Text + "'" + ",  LastName='" + lastNameTextBox.Text + "'"
                     + ", Phone='" + phoneTextBox.Text + "'" + ", Extension='" + extensionTextBox.Text + "'" + ", Email='" + emailTextBox.Text + "'" + ", Publication='"
                     + publicationDropDown.SelectedValue + "' WHERE EditorID='" + editorIDDropDown.SelectedValue + "'";

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }
    }
}