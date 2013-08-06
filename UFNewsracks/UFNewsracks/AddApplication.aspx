<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddApplication.aspx.cs" Inherits="UFNewsracks.AddApplication" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="dateLabel" runat="server" Text="Date:"></asp:Label>
    <asp:TextBox ID="dateTextBox1" runat="server" MaxLength="2" Width="29px"></asp:TextBox>
    <asp:TextBox ID="dateTextBox2" runat="server" MaxLength="2" Width="29px"></asp:TextBox>
    <asp:TextBox ID="dateTextBox3" runat="server" MaxLength="4" Width="57px"></asp:TextBox>
    <asp:Label ID="publicationLabel" runat="server" Text="Publication:"></asp:Label>
    <asp:DropDownList runat="server" ID="publicationDropDown" AutoPostBack="true"></asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="publicationDropDownDataSource" SelectCommand="PublicationName" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="publicationDropDownDataSource_Selecting"></asp:SqlDataSource>
    <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
</asp:Content>
