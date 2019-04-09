<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="INFT3050WebApp.Search" %>

<%@ MasterType VirtualPath="~/UL/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-flex">
        <h1>Search</h1>
        <br />
        <form runat="server">
            <!-- Search Field -->
            <div class="input-group">
                    <asp:TextBox ID="tbxSearch" class="form-control" type="text" placeholder="Search" aria-label="Search" runat="server"></asp:TextBox>
                <span class="input-group-btn">
                    &nbsp;&nbsp;
                    <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" CssClass="btn btn-success"/>
                </span>    
                
            </div>
            <br />
            <div class="container-flex">
                <!-- Get Data Source -->
                <asp:ObjectDataSource ID="bookDataSource" runat="server" SelectMethod="GetBooks" TypeName="INFT3050WebApp.DAL.DummyDB"></asp:ObjectDataSource>
                <!-- Display all books using gridview -->
                <asp:GridView ID="GridBooks" runat="server" AutoGenerateColumns="false" DataSourceID="bookDataSource" OnRowCommand="GridSearch_RowCommand" CssClass="table" GridLines="None" AllowPaging="True" PageSize="4">
                    <Columns>
                        <asp:ImageField DataImageUrlField="ThumbnailPath" HeaderText="Cover">
                        </asp:ImageField>
                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                        <asp:BoundField DataField="ShortDescription" HeaderText="Description" SortExpression="ShortDescription" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        <asp:ButtonField ButtonType="Button" CommandName="cmdView" Text="View" ControlStyle-CssClass="btn btn-success" />
                    </Columns>
                </asp:GridView>

            </div>
        </form>


    </div>
</asp:Content>
