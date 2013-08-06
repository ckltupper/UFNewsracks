<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="EditLocation.aspx.cs" Inherits="UFNewsracks.EditLocation" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="locationLabel" runat="server" Text="Location:"></asp:Label>
    <asp:DropDownList runat="server" ID="locationDropDown" AutoPostBack="true" OnSelectedIndexChanged="locationDropDown_SelectedIndexChanged"></asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="locationDropDownDataSource" SelectCommand="LocationAlpha" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="locationDropDownDataSource_Selecting"></asp:SqlDataSource>

    <asp:Label ID="latitudeLabel" runat="server" Text="Latitude:"></asp:Label>
    <asp:TextBox ID="latitudeTextBox" runat="server"></asp:TextBox>
    <asp:Label ID="longitudeLabel" runat="server" Text="Longitude:"></asp:Label>
    <asp:TextBox ID="longitudeTextBox" runat="server"></asp:TextBox>
    <asp:Label ID="typeLabel" runat="server" Text="Type:"></asp:Label>
    <asp:RadioButtonList ID="typeRadioButtonList" runat="server">
        <asp:ListItem Value="M">Modular</asp:ListItem>
        <asp:ListItem Value="N">Non-Modular</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Button ID="updateButton" runat="server" Text="Update" OnClick="updateButton_Click" />

</asp:Content>
