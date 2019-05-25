<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="INFT3050WebApp.UL.Books" %>

<%@ MasterType VirtualPath="~/UL/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>All Books</h1>
    <br />
    <div class="container-flex">
        <%-- Get Data Source --%>
        <asp:ObjectDataSource ID="bookDataSource" runat="server" SelectMethod="GetAllBooks" TypeName="INFT3050WebApp.BL.Book"></asp:ObjectDataSource>
        <%--Display all books using gridview--%>
        <asp:GridView ID="GridBooks" runat="server" AutoGenerateColumns="false" DataSourceID="bookDataSource" OnRowCommand="GridBooks_RowCommand" CssClass="table" GridLines="None" AllowPaging="True" PageSize="4">
            <Columns>
                <asp:ImageField DataImageUrlField="ThumbnailPath" HeaderText="Cover">
                </asp:ImageField>
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="ShortDescription" HeaderText="Description" SortExpression="ShortDescription" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="cmdView" CssClass="btn btn-success"
                            Text="View" CommandArgument='<%# Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>

</asp:Content>
