<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddApplicationSpace.aspx.cs" Inherits="UFNewsracks.AddApplicationSpace" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="applicationIDLabel" runat="server" Text="Application ID:"></asp:Label>
    <asp:DropDownList runat="server" ID="applicationIDDropDown" AutoPostBack="true"></asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="applicationIDDropDownDataSource" SelectCommand="ApplicationID" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="applicationIDDropDownDataSource_Selecting"></asp:SqlDataSource>
    <asp:Label ID="locationLabel" runat="server" Text="Location:"></asp:Label>
    <asp:DropDownList runat="server" ID="locationDropDown" AutoPostBack="true"></asp:DropDownList>
    <asp:SqlDataSource runat="server" ID="locationDropDownDataSource" SelectCommand="LocationAlpha" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="locationDropDownDataSource_Selecting"></asp:SqlDataSource>

    <asp:Label ID="sizeLabel" runat="server" Text="Size:"></asp:Label>
    <asp:RadioButtonList ID="sizeRadioButtonList" runat="server">
        <asp:ListItem Value="H">Half</asp:ListItem>
        <asp:ListItem Value="F">Full</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Label ID="coinMecLabel" runat="server" Text="Coin Mec:"></asp:Label>
    <asp:RadioButtonList ID="coinMecRadioButtonList" runat="server">
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
    <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />

</asp:Content>
