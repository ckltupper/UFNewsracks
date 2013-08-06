<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="EditEditor.aspx.cs" Inherits="UFNewsracks.EditEditor" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="editorIDLabel" runat="server" Text="ID:"></asp:Label>
    <asp:DropDownList runat="server" ID="editorIDDropDown" AutoPostBack="true" OnSelectedIndexChanged="editorIDDropDown_SelectedIndexChanged"></asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="editorIDDropDownDataSource" SelectCommand="EditorID" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="editorIDDropDownDataSource_Selecting"></asp:SqlDataSource>
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
    <asp:Label ID="publicationLabel" runat="server" Text="Publication:"></asp:Label>
    <asp:DropDownList runat="server" ID="publicationDropDown" AutoPostBack="true"></asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="publicationDropDownDataSource" SelectCommand="PublicationName" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <asp:Button ID="updateButton" runat="server" OnClick="updateButton_Click" Text="Update" />
</asp:Content>
