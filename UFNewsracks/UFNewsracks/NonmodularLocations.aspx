<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="NonmodularLocations.aspx.cs" Inherits="UFNewsracks.NonmodularLocations1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 <asp:DropDownList runat="server" ID="NonmodularLocationsDropDown" AutoPostBack="true" OnSelectedIndexChanged="NonmodularLocationsDropDown_SelectedIndexChanged" >

    </asp:DropDownList> 
    <asp:DataGrid runat="server" ID="NonmodularPublicationsGrid" DataSourceID="NonmodularGridDataSource">

    </asp:DataGrid>
   <asp:SqlDataSource runat="server" ID="NonmodularGridDataSource" SelectCommand="PublicationsByLocation" SelectCommandType="StoredProcedure"
       ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="NonmodularGridDataSource_Selecting">
       <SelectParameters>
           <asp:Parameter Name="LocationName" />
       </SelectParameters>
   </asp:SqlDataSource>
</asp:Content>
