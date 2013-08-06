﻿using System;
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
    public partial class AddEmergencyContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                SqlDataSource ds = new SqlDataSource(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "Select Publisher From ctupper.Publisher");
                publisherDropDown.DataTextField = "Publisher";
                publisherDropDown.DataSource = ds;
                publisherDropDown.DataBind();
            }
        }

        protected void publisherDropDownDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            publisherDropDownDataSource.SelectParameters["PublisherName"].DefaultValue = publisherDropDown.SelectedValue;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlconn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand sqlcmd = new SqlCommand() { Connection = sqlconn, CommandType = CommandType.Text };
                sqlcmd.CommandText = "Insert Into EmergencyContact (FirstName, LastName, Phone, Extension, Email, Publisher) Values (@FirstName, @LastName, @Phone, @Extension, @Email, @Publisher)";
                sqlcmd.Parameters.AddWithValue("@FirstName", firstNameTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@LastName", lastNameTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@Phone", phoneTextBox1.Text + "-" + phoneTextBox2.Text + "-" + phoneTextBox3.Text);
                sqlcmd.Parameters.AddWithValue("@Extension", extensionTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@Email", emailTextBox.Text);
                sqlcmd.Parameters.AddWithValue("@Publisher", publisherDropDown.SelectedValue);
                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
        }
    }
}