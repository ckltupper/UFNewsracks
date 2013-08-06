<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="EditPublisher.aspx.cs" Inherits="UFNewsracks.EditPublisher" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="publisherLabel" runat="server" Text="Publisher:"></asp:Label>
    <asp:DropDownList runat="server" ID="publisherDropDown" AutoPostBack="true" OnSelectedIndexChanged="publisherDropDown_SelectedIndexChanged"></asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="publisherDropDownDataSource" SelectCommand="PublisherName" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="publisherDropDownDataSource_Selecting"></asp:SqlDataSource>
    <asp:Label ID="mailingStreetLabel" runat="server" Text="Mailing Street:"></asp:Label>
    <asp:TextBox ID="mailingStreetTextBox" runat="server" MaxLength="45"></asp:TextBox>
    <asp:Label ID="mailingCityLabel" runat="server" Text="Mailing City:"></asp:Label>
    <asp:TextBox ID="mailingCityTextBox" runat="server" MaxLength="25"></asp:TextBox>
    <asp:Label ID="mailingStateLabel" runat="server" Text="Mailing State:"></asp:Label>
    <asp:TextBox ID="mailingStateTextBox" runat="server" MaxLength="2"></asp:TextBox>
    <asp:Label ID="mailingZipLabel" runat="server" Text="Mailing Zip:"></asp:Label>
    <asp:TextBox ID="mailingZipTextBox" runat="server" MaxLength="5"></asp:TextBox>
    <asp:Label ID="physicalStreetLabel" runat="server" Text="Physical Street:"></asp:Label>
    <asp:TextBox ID="physicalStreetTextBox" runat="server" MaxLength="45"></asp:TextBox>
    <asp:Label ID="physicalCityLabel" runat="server" Text="Physical City:"></asp:Label>
    <asp:TextBox ID="physicalCityTextBox" runat="server" MaxLength="25"></asp:TextBox>
    <asp:Label ID="physicalStateLabel" runat="server" Text="Physical State:"></asp:Label>
    <asp:TextBox ID="physicalStateTextBox" runat="server" MaxLength="2"></asp:TextBox>
    <asp:Label ID="physicalZipLabel" runat="server" Text="Physical Zip:"></asp:Label>
    <asp:TextBox ID="physicalZipTextBox" runat="server" MaxLength="5"></asp:TextBox>
    <asp:Label ID="phoneLabel" runat="server" Text="Phone:"></asp:Label>
    <asp:TextBox ID="phoneTextBox" runat="server" MaxLength="12"></asp:TextBox>
    <asp:Label ID="extensionLabel" runat="server" Text="Extension:"></asp:Label>
    <asp:TextBox ID="extensionTextBox" runat="server" MaxLength="6"></asp:TextBox>
    <asp:Button ID="updateButton" runat="server" OnClick="updateButton_Click" Text="Update" />
</asp:Content>
