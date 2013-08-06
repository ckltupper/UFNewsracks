<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="EditPublication.aspx.cs" Inherits="UFNewsracks.EditPublication" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="publicationLabel" runat="server" Text="Publication:"></asp:Label>
    <asp:DropDownList runat="server" ID="publicationDropDown" AutoPostBack="true" OnSelectedIndexChanged="publicationDropDown_SelectedIndexChanged"></asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="publicationDropDownDataSource" SelectCommand="PublicationName" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="publicationDropDownDataSource_Selecting"></asp:SqlDataSource>
    <asp:Label ID="frequencyLabel" runat="server" Text="Frequency:"></asp:Label>
    <asp:TextBox ID="frequencyTextBox" runat="server" MaxLength="10"></asp:TextBox>
    <asp:Label ID="pagesLabel" runat="server" Text="Pages:"></asp:Label>
    <asp:TextBox ID="pagesTextBox" runat="server" MaxLength="6"></asp:TextBox>
    <asp:Label ID="widthLabel" runat="server" Text="Width (inches):"></asp:Label>
    <asp:TextBox ID="widthTextBox" runat="server" MaxLength="5"></asp:TextBox>
    <asp:Label ID="lengthLabel" runat="server" Text="Length (inches):"></asp:Label>
    <asp:TextBox ID="lengthTextBox" runat="server" MaxLength="5"></asp:TextBox>
    <asp:Label ID="publisherLabel" runat="server" Text="Publisher:"></asp:Label>
    <asp:DropDownList runat="server" ID="publisherDropDown" AutoPostBack="true"></asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="publisherDropDownDataSource" SelectCommand="PublisherName" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <asp:Button ID="updateButton" runat="server" OnClick="updateButton_Click" Text="Update" />
</asp:Content>
