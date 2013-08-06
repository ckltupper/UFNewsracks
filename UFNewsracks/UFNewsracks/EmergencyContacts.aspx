<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="EmergencyContacts.aspx.cs" Inherits="UFNewsracks.EmergencyContacts" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DataGrid runat="server" ID="EmergencyContactsGrid" DataSourceID="GridDataSource">
    </asp:DataGrid>
    <asp:SqlDataSource runat="server" ID="GridDataSource" SelectCommand="EmergencyContacts" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>">
    </asp:SqlDataSource>
</asp:Content>
