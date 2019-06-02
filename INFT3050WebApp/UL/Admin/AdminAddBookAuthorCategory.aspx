<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminAddBookAuthorCategory.aspx.cs" Inherits="INFT3050WebApp.UL.Admin.AdminAddBookAuthorCategory" %>


<%@ MasterType VirtualPath="~/UL/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Add Book</h1>
    <h4>Author & Category for new book</h4>
    <div>
        <asp:ValidationSummary ID="vsAddBookAuthorCategory" runat="server" CssClass="alert-danger" HeaderText="Please correct these issues" />
    </div>
    <br />
    <asp:Label ID="lblCurrentAuthors" runat="server" Text="Current Authors"></asp:Label>
    <br />
    <div class="container-flex">
        <%--Display all Authors that are added to the book using gridview--%>
        <asp:GridView ID="GridAddedAuthors" runat="server" AutoGenerateColumns="false" CssClass="table" GridLines="None" AllowPaging="True" AllowSorting="false">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="Title" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            </Columns>
        </asp:GridView>
    </div>


    <br />
    <%--//Search Bar--%>
    <div class="input-group">
        <asp:TextBox ID="tbxFirstName" class="form-control" type="text" placeholder="First Name" aria-label="First Name" runat="server"></asp:TextBox>
        <asp:TextBox ID="tbxLastName" class="form-control" type="text" placeholder="Last Name" aria-label="Last Name" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearchAuthor_Click" CssClass="btn btn-success" />
    </div>
    <div class="container-flex">
        <%-- Get Data Source --%>
        <asp:ObjectDataSource ID="authorDataSource" runat="server" SelectMethod="SearchAuthorByName" TypeName="INFT3050WebApp.BL.Author">
            <SelectParameters>
                <asp:Parameter Name="SearchFirstName" Type="String" />
                <asp:Parameter Name="SearchLastName" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <%--Display all Authors using gridview--%>
        <asp:GridView ID="GridAuthors" runat="server" AutoGenerateColumns="false" DataSourceID="authorDataSource" AllowSorting="false" OnRowCommand="GridSearch_RowCommand" CssClass="table" GridLines="None" AllowPaging="True" PageSize="4">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Title" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnAdd" runat="server" CausesValidation="false" CommandName="cmdAdd" CssClass="btn btn-success"
                            Text="Add" CommandArgument='<%# Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <%-- If no author is returned --%>
    <asp:Label ID="lblNoAuthor" runat="server" Text="No Author Found" Visible="false"></asp:Label>
    <br />
    <asp:Button ID="btnNewAuthor" type="submit" CssClass="btn btn-primary" runat="server" Text="Add Author" OnClick="btnNewAuthor_Click" Visible="false"/>





    <br />

    <%--Categoies display and select--%>
    <asp:Label ID="lblCategory" runat="server" Text="Categories"></asp:Label>
    <div class="container-flex">
        <asp:ObjectDataSource ID="CategoryDataSource" runat="server" SelectMethod="getCategories" TypeName="INFT3050WebApp.BL.Category">
        </asp:ObjectDataSource>
        <%--Display all Categories using gridview--%>
        <asp:GridView ID="gvCategory" runat="server" AutoGenerateColumns="false" DataSourceID="categoryDataSource" CssClass="table" GridLines="None" AllowPaging="True">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="Select" runat="server"></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="Category" SortExpression="Name" />
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id"/>
            </Columns>
        </asp:GridView>
    </div>

    <asp:Button ID="btnBookDetails" type="submit" CssClass="btn btn-primary" runat="server" Text="Continue" OnClick="btnComfirmToContiue_Click" />
</asp:Content>
