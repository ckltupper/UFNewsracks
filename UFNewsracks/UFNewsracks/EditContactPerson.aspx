<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="EditContactPerson.aspx.cs" Inherits="UFNewsracks.EditContactPerson" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="cPIDLabel" runat="server" Text="ID:"></asp:Label>
    <asp:DropDownList runat="server" ID="cPIDDropDown" AutoPostBack="true" OnSelectedIndexChanged="cPIDDropDown_SelectedIndexChanged"></asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="cPIDDropDownDataSource" SelectCommand="ContactPersonID" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="cPIDDropDownDataSource_Selecting"></asp:SqlDataSource>
    <asp:Label ID="firstNameLabel" runat="server" Text="First Name:"></asp:Label>
    <asp:TextBox ID="firstNameTextBox" runat="server" MaxLength="20"></asp:TextBox>
    <asp:Label ID="lastNameLabel" runat="server" Text="Last Name:"></asp:Label>
    <asp:TextBox ID="lastNameTextBox" runat="server" MaxLength="20"></asp:TextBox>
    <asp:Label ID="phoneLabel" runat="server" Text="Phone:"></asp:Label>
    <asp:TextBox ID="phoneTextBox" runat="server" MaxLength="12"></asp:TextBox>
    <asp:Label ID="extensionLabel" runat="server" Text="Extension:"></asp:Label>
    <asp:TextBox ID="extensionTextBox" runat="server" MaxLength="6"></asp:TextBox>
    <asp:Label ID="emailLabel" runat="server" Text="Email:"></asp:Label>
    <asp:TextBox ID="emailTextBox" runat="server" MaxLength="40"></asp:TextBox>
    <asp:Label ID="publisherLabel" runat="server" Text="Publisher:"></asp:Label>
    <asp:DropDownList runat="server" ID="publisherDropDown" AutoPostBack="true"></asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="publisherDropDownDataSource" SelectCommand="PublisherName" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <asp:Button ID="updateButton" runat="server" OnClick="updateButton_Click" Text="Update" />
</asp:Content>
