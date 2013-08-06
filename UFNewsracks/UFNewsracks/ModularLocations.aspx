<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="ModularLocations.aspx.cs" Inherits="UFNewsracks.ModularLocations1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList runat="server" ID="ModularLocationsDropDown" AutoPostBack="true" OnSelectedIndexChanged="ModularLocationsDropDown_SelectedIndexChanged" >

    </asp:DropDownList> 
    <asp:DataGrid runat="server" ID="ModularPublicationsGrid" DataSourceID="ModularGridDataSource">

    </asp:DataGrid>
   <asp:SqlDataSource runat="server" ID="ModularGridDataSource" SelectCommand="PublicationsByLocation" SelectCommandType="StoredProcedure"
       ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="ModularGridDataSource_Selecting">
       <SelectParameters>
           <asp:Parameter Name="LocationName" />
       </SelectParameters>
   </asp:SqlDataSource>
</asp:Content>
