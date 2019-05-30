<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="INFT3050WebApp.UL.Book" %>

<%@ MasterType VirtualPath="~/UL/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <div class="row">
        <%--First Column--%>
        <div class="col-md-6">
            <%--Display Book Image--%>
            <asp:Image CssClass="rounded" ID="imgBook" runat="server" />
        </div>
        <br />
        <div class="jumbotron col-md-6">
            <%--Second Column--%>
            <h1>
                <%--Display Book Title--%>
                <asp:Label ID="lblTitle" runat="server"></asp:Label>
            </h1>
            <%--Display Book Author--%>
            <h5>
                <asp:Label ID="lblAuthor" runat="server" />
            </h5>
            <%--Display Publisher and Date Published--%>
            <p>
                <asp:Label ID="lblPublisher" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblDatePublished" runat="server"></asp:Label>
            </p>
            <%--Display Book Description--%>
            <p>
                <asp:Label ID="lblDescription" runat="server"></asp:Label>
            </p>
            <%--Display Amount of Books in stock--%>
            <p>
                <asp:Label ID="lblQuantity" runat="server"></asp:Label>
            </p>
            <p>
                <%--Display Book Price--%>
                <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
            </p>
            <%--Button to add book to cart--%>
            <asp:Button Text="Add To Cart" runat="server" CssClass="btn btn-success" />

        </div>
    </div>
</asp:Content>
