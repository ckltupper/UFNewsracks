<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="EditSpace.aspx.cs" Inherits="UFNewsracks.EditSpace" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="locationLabel" runat="server" Text="Location:"></asp:Label>
    <asp:DropDownList runat="server" ID="locationDropDown" AutoPostBack="true" OnSelectedIndexChanged="locationDropDown_SelectedIndexChanged"></asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="locationDropDownDataSource" SelectCommand="LocationAlpha" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="locationDropDownDataSource_Selecting"></asp:SqlDataSource>
    <asp:Label ID="spaceLabel" runat="server" Text="Space:"></asp:Label>
    <asp:DropDownList runat="server" ID="spaceDropDown" AutoPostBack="true" OnSelectedIndexChanged="spaceDropDown_SelectedIndexChanged"></asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="spaceDropDownDataSource" SelectCommand="SpaceByLocation" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="spaceDropDownDataSource_Selecting"></asp:SqlDataSource>
    <asp:Label ID="coinMecLabel" runat="server" Text="Coin Mec:"></asp:Label>
    <asp:RadioButtonList ID="coinMecRadioButtonList" runat="server">
        <asp:ListItem Value="Y">Yes</asp:ListItem>
        <asp:ListItem Value="N">No</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Label ID="sizeLabel" runat="server" Text="Size:"></asp:Label>
    <asp:RadioButtonList ID="sizeRadioButtonList" runat="server">
        <asp:ListItem Value="H">Half</asp:ListItem>
        <asp:ListItem Value="F">Full</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Label ID="aApplicationIDLabel" runat="server" Text="Application Assignment:"></asp:Label>
    <asp:TextBox ID="aApplicationIDTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="updateButton" runat="server" OnClick="updateButton_Click" Text="Update" />
</asp:Content>
