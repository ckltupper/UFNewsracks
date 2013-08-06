<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="Publications.aspx.cs" Inherits="UFNewsracks.Publications" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList runat="server" ID="PublicationsDropDown" AutoPostBack="true" OnSelectedIndexChanged="PublicationsDropDown_SelectedIndexChanged"></asp:DropDownList>
    
    <div>
    <asp:Label ID="publicationLabel" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
    </div>

    <asp:DataGrid runat="server" ID="LocationsGrid" DataSourceID="GridDataSource" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger" AutoGenerateColumns="false">
        <Columns>
            <asp:HyperLinkColumn DataTextField="Location" DataNavigateUrlField="Location" DataNavigateUrlFormatString="Locations.aspx?LocationName={0}" NavigateUrl="~/Locations.aspx" HeaderText="Location"></asp:HyperLinkColumn>
            <asp:BoundColumn DataField="Space" HeaderText="Space"></asp:BoundColumn>
            <asp:BoundColumn DataField="Type" HeaderText="Type"></asp:BoundColumn>

        </Columns>
    </asp:DataGrid>
    
    <asp:SqlDataSource runat="server" ID="GridDataSource" SelectCommand="LocationByPublication" SelectCommandType="StoredProcedure"
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="GridDataSource_Selecting">
        <SelectParameters>
            <asp:Parameter Name="PublicationName" />
        </SelectParameters>
    </asp:SqlDataSource>
    </asp:Content>
