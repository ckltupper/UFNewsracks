<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddPublication.aspx.cs" Inherits="UFNewsracks.AddPublication" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="publicationLabel" runat="server" Text="Publication:"></asp:Label>
    <asp:TextBox ID="publicationTextBox" runat="server" MaxLength="60"></asp:TextBox>
    <asp:Label ID="frequencyLabel" runat="server" Text="Frequency:"></asp:Label>
    <asp:TextBox ID="frequencyTextBox" runat="server" MaxLength="10"></asp:TextBox>
    <asp:Label ID="pagesLabel" runat="server" Text="Pages:"></asp:Label>
    <asp:TextBox ID="pagesTextBox" runat="server" MaxLength="6"></asp:TextBox>
    <asp:Label ID="widthLabel" runat="server" Text="Width (inches):"></asp:Label>
    <asp:TextBox ID="widthTextBox" runat="server" TextMode="Number" MaxLength="5"></asp:TextBox>
    <asp:Label ID="lengthLabel" runat="server" Text="Length (inches):"></asp:Label>
    <asp:TextBox ID="lengthTextBox" runat="server" MaxLength="5"></asp:TextBox>
    <asp:Label ID="publisherLabel" runat="server" Text="Publisher:"></asp:Label>
    <asp:DropDownList ID="publisherDropDown" runat="server" AutoPostBack="true">
    </asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="publisherDropDownDataSource" SelectCommand="PublisherName" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="publisherDropDownDataSource_Selecting">
    </asp:SqlDataSource>
    <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click"/>
    
</asp:Content>
