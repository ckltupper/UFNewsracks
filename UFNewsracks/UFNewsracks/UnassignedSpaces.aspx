<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="UnassignedSpaces.aspx.cs" Inherits="UFNewsracks.UnassignedSpaces" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DataGrid runat="server" ID="UnassignedSpacesGrid" DataSourceID="GridDataSource"></asp:DataGrid>
    <asp:SqlDataSource runat="server" ID="GridDataSource" SelectCommand="UnassignedSpaces" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
</asp:Content>
