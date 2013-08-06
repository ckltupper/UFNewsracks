<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddEditor.aspx.cs" Inherits="UFNewsracks.AddEditor" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="firstNameLabel" runat="server" Text="First Name:"></asp:Label>
    <asp:TextBox ID="firstNameTextBox" runat="server" MaxLength="20"></asp:TextBox>
    <asp:Label ID="lastNameLabel" runat="server" Text="Last Name:"></asp:Label>
    <asp:TextBox ID="lastNameTextBox" runat="server" MaxLength="20"></asp:TextBox>
    <asp:Label ID="phoneLabel" runat="server" Text="Phone:"></asp:Label>
    <asp:TextBox ID="phoneTextBox1" runat="server" MaxLength="3" Width="48px"></asp:TextBox>
    <asp:TextBox ID="phoneTextBox2" runat="server" MaxLength="3" Width="48px"></asp:TextBox>
    <asp:TextBox ID="phoneTextBox3" runat="server" MaxLength="4" Width="48px"></asp:TextBox>
    <asp:Label ID="extensionLabel" runat="server" Text="Extension:"></asp:Label>
    <asp:TextBox ID="extensionTextBox" runat="server" MaxLength="6"></asp:TextBox>
    <asp:Label ID="emailLabel" runat="server" Text="Email:"></asp:Label>
    <asp:TextBox ID="emailTextBox" runat="server" MaxLength="40"></asp:TextBox>
    <asp:Label ID="publicationLabel" runat="server" Text="Publication"></asp:Label>
    <asp:DropDownList runat="server" ID="publicationDropDown" AutoPostBack="true"></asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="publicationDropDownDataSource" SelectCommand="PublicationName" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="publicationDropDownDataSource_Selecting">
    </asp:SqlDataSource>
    <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click"/>

</asp:Content>
