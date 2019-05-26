<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminAddBookComfirmation.aspx.cs" Inherits="INFT3050WebApp.UL.Admin.AdminAddBookComfirmation" %>


<%@ MasterType VirtualPath="~/UL/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Add Book</h1>
    <h4>Comfirm Details</h4>
    <br />
    <%--Title--%>
    <asp:Label ID="lblTitle" runat="server" Text="Title :"></asp:Label>
    <asp:Label ID="lblNewTitle" runat="server" Text="??"></asp:Label>
   
    <br />
    <%--SecondTitle field --%>
    <asp:Label ID="lblSecondTitle" runat="server" Text="Secondary Title :"></asp:Label>
    <asp:Label ID="lblNewSecondTitle" runat="server"></asp:Label>

    <br />
    <%--Short Description field --%>
    <asp:Label ID="lblShortDescription" runat="server" Text="Short Description :"></asp:Label>
    <asp:Label ID="lblNewShortDescription" runat="server" ></asp:Label>

    <br />
    <%--Long Description field --%>
    <asp:Label ID="lblLongDescription" runat="server" Text="Long Description :"></asp:Label>
    <asp:Label ID="lblNewLongDescription" runat="server"></asp:Label>

    <br />
    <%--ISBN field --%>
    <asp:Label ID="lblISBN" runat="server" Text="ISBN :"></asp:Label>
    <asp:Label ID="lblNewISBN" runat="server"></asp:Label>

    <br />
    <%--Publisher field --%>
    <asp:Label ID="lblPublisher" runat="server" Text="Publisher :"></asp:Label>
    <asp:Label ID="lblNewPublisher" runat="server"></asp:Label>

    <br />
    <%--Publish Date field --%>
    <asp:Label ID="lblDatePublished" runat="server" Text="Date Published :"></asp:Label>
    <asp:Label ID="lblNewDatePublished" runat="server"></asp:Label>

    <br />
    <%--Best Seller field --%>
    <asp:Label ID="lblIsBestSeller" runat="server" Text="Best Seller :"></asp:Label>
    <asp:Label ID="lblNewIsBestSeller" runat="server"></asp:Label>

    <br />
    <%--Image Path field --%>
    <asp:Label ID="lblImagePath" runat="server" Text="Image Path :"></asp:Label>
    <asp:Label ID="lblNewImagePath" runat="server"></asp:Label>

     <br />
    <%--Thumbnail field --%>
    <asp:Label ID="lblThumbnailPath" runat="server" Text="Thumbnail Path ;"></asp:Label>
    <asp:Label ID="lblNewThumbnailPath" runat="server"></asp:Label>

    <br />
    <%--Price field --%>
    <asp:Label ID="lblPrice" runat="server" Text="Price :$"></asp:Label>
    <asp:Label ID="lblNewPrice" runat="server"></asp:Label>

    <br />
    <%--Price StockonHand --%>
    <asp:Label ID="lblStockonHand" runat="server" Text="Stock on Hand :"></asp:Label>
    <asp:Label ID="lblNewStockonHand" runat="server"></asp:Label>

    <%--Display authors--%>
    <asp:GridView ID="GridAuthors" runat="server" AutoGenerateColumns="false" CssClass="table" GridLines="None" AllowPaging="True" PageSize="4">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" SortExpression="Title" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
        </Columns>
    </asp:GridView>

    <%<asp:Button ID="btnBookDetails" type="submit" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="btnSubmitBook_Click" />
</asp:Content>

