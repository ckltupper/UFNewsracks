<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddLocation.aspx.cs" Inherits="UFNewsracks.AddLocation" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="locationLabel" runat="server" Text="Location Name:"></asp:Label>
    <asp:TextBox ID="locationTextBox" runat="server" MaxLength="40"></asp:TextBox>
    <asp:Label ID="latitudeLabel" runat="server" Text="Latitude:"></asp:Label>
    <asp:TextBox ID="latitudeTextBox" runat="server"></asp:TextBox>
    <asp:Label ID="longitudeLabel" runat="server" Text="Longitude:"></asp:Label>
    <asp:TextBox ID="longitudeTextBox" runat="server"></asp:TextBox>
    <asp:Label ID="typeLabel" runat="server" Text="Type:"></asp:Label>
    <asp:RadioButtonList ID="typeRadioButtonList" runat="server">
        <asp:ListItem Value="M">Modular</asp:ListItem>
        <asp:ListItem Value="N">Non-Modular</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click"/>

</asp:Content>
