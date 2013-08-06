<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="EditApplicationSpace.aspx.cs" Inherits="UFNewsracks.EditApplicationSpace" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="applicationIDLabel" runat="server" Text="ID:"></asp:Label>
    <asp:DropDownList runat="server" ID="applicationIDDropDown" AutoPostBack="true" OnSelectedIndexChanged="applicationIDDropDown_SelectedIndexChanged"></asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="applicationIDDropDownDataSource" SelectCommand="ApplicationID" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="applicationIDDropDownDataSource_Selecting"></asp:SqlDataSource>
    <asp:Label ID="locationLabel" runat="server" Text="Location:"></asp:Label>
    <asp:DropDownList runat="server" ID="locationDropDown" AutoPostBack="true" OnSelectedIndexChanged="locationDropDown_SelectedIndexChanged"></asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="locationDropDownDataSource" SelectCommand="LocationAlpha" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="locationDropDownDataSource_Selecting"></asp:SqlDataSource>
    <asp:Label ID="sizeRequestLabel" runat="server" Text="Size Request:"></asp:Label>
    <asp:RadioButtonList ID="sizeRequestRadioButtonList" runat="server">
        <asp:ListItem Value="H">Half</asp:ListItem>
        <asp:ListItem Value="F">Full</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Label ID="coinMecRequestLabel" runat="server" Text="Coin Mec Request:"></asp:Label>
    <asp:RadioButtonList ID="coinMecRequestRadioButtonList" runat="server">
        <asp:ListItem Value="Y">Yes</asp:ListItem>
        <asp:ListItem Value="N">No</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Label ID="statusLabel" runat="server" Text="Status:"></asp:Label>
    <asp:RadioButtonList ID="statusRadioButtonList" runat="server">
        <asp:ListItem Value="A">Approved</asp:ListItem>
        <asp:ListItem Value="D">Denied</asp:ListItem>
        <asp:ListItem Value="P">Pending</asp:ListItem>
        <asp:ListItem Value="W">Waitlisted</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Label ID="commentLabel" runat="server" Text="Comment:"></asp:Label>
    <asp:TextBox ID="commentTextBox" runat="server" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
    <asp:Button ID="updateButton" runat="server" OnClick="updateButton_Click" Text="Update" />
</asp:Content>
