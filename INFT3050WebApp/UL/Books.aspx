<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="INFT3050WebApp.UL.Books" %>
<%@ MasterType VirtualPath="~/UL/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <h1>All Books</h1>
    <br />
    <form runat="server">
            <div class="container-flex">
        <!-- Get Data Source -->
        <asp:ObjectDataSource ID="bookDataSource" runat="server" SelectMethod="GetBooks" TypeName="INFT3050WebApp.DAL.DummyDB"></asp:ObjectDataSource>
        <!-- Display all books using gridview -->
        <asp:GridView ID="GridBooks" runat="server" AutoGenerateColumns="false" DataSourceID="bookDataSource">
            <Columns>
                <asp:ImageField DataImageUrlField="ThumbnailPath" >
                </asp:ImageField>
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"/>
                <asp:BoundField DataField="ShortDescription" HeaderText="Description" SortExpression="ShortDescription"/>
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"/>
            </Columns>
        </asp:GridView>

    </div>
    </form>

</asp:Content>
