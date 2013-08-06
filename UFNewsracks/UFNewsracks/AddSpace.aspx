<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddSpace.aspx.cs" Inherits="UFNewsracks.AddSpace" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="locationLabel" runat="server" Text="Location:"></asp:Label>
    <asp:DropDownList runat="server" ID="locationDropDown" AutoPostBack="true"></asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="locationDropDownDataSource" SelectCommand="LocationAlpha" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="locationDropDownDataSource_Selecting"></asp:SqlDataSource>
    <asp:Label ID="numberLabel" runat="server" Text="Number:"></asp:Label>
    <asp:TextBox ID="numberTextBox" runat="server" MaxLength="8"></asp:TextBox>
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
    
    <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
    
</asp:Content>
