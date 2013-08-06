<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddPublisher.aspx.cs" Inherits="UFNewsracks.Publisher" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="publisherLabel" runat="server" Text="Publisher Name:"></asp:Label>
    <asp:TextBox ID="publisherTextBox" runat="server" MaxLength="60"></asp:TextBox>
    <asp:Label ID="mailingStreetLabel" runat="server" Text="Mailing Street:"></asp:Label>
    <asp:TextBox ID="mailingStreetTextBox" runat="server" MaxLength="45"></asp:TextBox>
    <asp:Label ID="mailingCityLabel" runat="server" Text="Mailing City:"></asp:Label>
    <asp:TextBox ID="mailingCityTextBox" runat="server" MaxLength="25">Gainesville</asp:TextBox>
    <asp:Label ID="mailingStateLabel" runat="server" Text="Mailing State:"></asp:Label>
    <asp:TextBox ID="mailingStateTextBox" runat="server" MaxLength="2">FL</asp:TextBox>
    <asp:Label ID="mailingZipLabel" runat="server" Text="Mailing Zip:"></asp:Label>
    <asp:TextBox ID="mailingZipTextBox" runat="server" MaxLength="5"></asp:TextBox>
    <asp:Label ID="physicalStreetLabel" runat="server" Text="Physical Street:"></asp:Label>
    <asp:TextBox ID="physicalStreetTextBox" runat="server" MaxLength="45"></asp:TextBox>
    <asp:Label ID="physicalCityLabel" runat="server" Text="Physical City:"></asp:Label>
    <asp:TextBox ID="physicalCityTextBox" runat="server" MaxLength="25">Gainesville</asp:TextBox>
    <asp:Label ID="physicalStateLabel" runat="server" Text="Physical State:"></asp:Label>
    <asp:TextBox ID="physicalStateTextBox" runat="server" MaxLength="2">FL</asp:TextBox>
    <asp:Label ID="physicalZipLabel" runat="server" Text="Physical Zip:"></asp:Label>
    <asp:TextBox ID="physicalZipTextBox" runat="server" MaxLength="5"></asp:TextBox>
    <asp:Label ID="phoneLabel" runat="server" Text="Phone:"></asp:Label>
    <asp:TextBox ID="phoneTextBox1" runat="server" MaxLength="3" TextMode="Number" Width="58px"></asp:TextBox>
    <asp:TextBox ID="phoneTextBox2" runat="server" MaxLength="3" TextMode="Number" Width="69px"></asp:TextBox>
    <asp:TextBox ID="phoneTextBox3" runat="server" MaxLength="4" TextMode="Number" Width="76px"></asp:TextBox>
    <asp:Label ID="extensionLabel" runat="server" Text="Extension:"></asp:Label>
    <asp:TextBox ID="extensionTextBox" runat="server" MaxLength="6"></asp:TextBox>
    <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click"/>

</asp:Content>
