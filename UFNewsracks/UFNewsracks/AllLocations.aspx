<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="AllLocations.aspx.cs" Inherits="UFNewsracks.AllLocations" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DataGrid runat="server" ID="AllLocationsGrid" DataSourceID="GridDataSource" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger" AutoGenerateColumns="false">
        <Columns>
            <asp:HyperLinkColumn DataTextField="Location" HeaderText="Location" DataNavigateUrlFormatString="Locations.aspx?Location={0}" NavigateUrl="~/Locations.aspx"></asp:HyperLinkColumn>
            <asp:BoundColumn DataField="Type" HeaderText="Type"></asp:BoundColumn>
            <asp:HyperLinkColumn Text="Newsrack Image" DataNavigateUrlField="ShortLocation" DataNavigateUrlFormatString="/modularPics/{0}Close.JPG"></asp:HyperLinkColumn>
            <asp:HyperLinkColumn Text="Area Image" DataNavigateUrlField="ShortLocation" DataNavigateUrlFormatString="/modularPics/{0}Far.JPG"></asp:HyperLinkColumn>
        </Columns>
    </asp:DataGrid>
    
    <asp:SqlDataSource runat="server" ID="GridDataSource" SelectCommand="AllLocations" SelectCommandType="StoredProcedure" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>">
     
    </asp:SqlDataSource> 





    </asp:Content>
