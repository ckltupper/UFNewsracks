<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="Locations.aspx.cs" Inherits="UFNewsracks.Locations" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList runat="server" ID="LocationsDropDown" AutoPostBack="true" OnSelectedIndexChanged="LocationsDropDown_SelectedIndexChanged"></asp:DropDownList> 
    
    <div>
    <asp:Label ID="locationLabel" runat="server" Font-Bold="true" Font-Size="Large" /> -
    <asp:Label ID="typeLabel" runat="server" Font-Bold="true" Font-Size="Large" />
    </div>
    
    <asp:DataGrid runat="server" ID="PublicationsGrid" DataSourceID="LocationGridDataSource" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger" AutoGenerateColumns="false">
        <Columns>
            <asp:HyperLinkColumn DataTextField="Publication" HeaderText="Publication" DataNavigateUrlField="Publication" DataNavigateUrlFormatString="Publications.aspx?PublicationName={0}" NavigateUrl="~/Publications.aspx"></asp:HyperLinkColumn>
            <asp:BoundColumn DataField="Space" HeaderText="Space"></asp:BoundColumn>
        </Columns>
    </asp:DataGrid>
   
    <asp:SqlDataSource runat="server" ID="LocationGridDataSource" SelectCommand="PublicationByLocation" SelectCommandType="StoredProcedure"
       ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="LocationGridDataSource_Selecting" >
       <SelectParameters>
           <asp:Parameter Name="LocationName" />
       </SelectParameters>
   </asp:SqlDataSource>
    </asp:Content>
