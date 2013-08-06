<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddEmergencyContact.aspx.cs" Inherits="UFNewsracks.AddEmergencyContact" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="firstNameLabel" runat="server" Text="First Name:"></asp:Label>
    <asp:TextBox ID="firstNameTextBox" runat="server" MaxLength="20"></asp:TextBox>
    <asp:Label ID="lastNameLabel" runat="server" Text="Last Name:"></asp:Label>
    <asp:TextBox ID="lastNameTextBox" runat="server" MaxLength="20"></asp:TextBox>
    <asp:Label ID="phoneLabel" runat="server" Text="Phone:"></asp:Label>
    <asp:TextBox ID="phoneTextBox1" runat="server" MaxLength="3" Width="59px"></asp:TextBox>
    <asp:TextBox ID="phoneTextBox2" runat="server" MaxLength="3" Width="59px"></asp:TextBox>
    <asp:TextBox ID="phoneTextBox3" runat="server" MaxLength="4" Width="59px"></asp:TextBox>
    <asp:Label ID="extensionLabel" runat="server" Text="Extension:"></asp:Label>
    <asp:TextBox ID="extensionTextBox" runat="server" MaxLength="6"></asp:TextBox>
    <asp:Label ID="emailLabel" runat="server" Text="Email:"></asp:Label>
    <asp:TextBox ID="emailTextBox" runat="server" MaxLength="40"></asp:TextBox>
    <asp:Label ID="publisherLabel" runat="server" Text="Publisher:"></asp:Label>
    <asp:DropDownList runat="server" ID="publisherDropDown" AutoPostBack="true">
    </asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="publisherDropDownDataSource" SelectCommand="PublisherName" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="publisherDropDownDataSource_Selecting">
    </asp:SqlDataSource>
    <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click"/>

</asp:Content>
