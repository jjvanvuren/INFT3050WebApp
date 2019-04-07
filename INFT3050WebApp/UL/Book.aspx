<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="INFT3050WebApp.UL.Book" %>

<%@ MasterType VirtualPath="~/UL/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <form runat="server">
        <div class="row">
            <!-- First Column -->
            <div class="col-md-6">
                <!-- Display Book Image -->
                <asp:Image CssClass="rounded" ID="imgBook" runat="server" />
            </div>
            <br />
            <div class="col-md-6">
                <!-- Second Column -->
                <h1>
                    <!-- Display Book Title -->
                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                </h1>
                <!-- Display Book Author -->
                <h5>
                    <asp:Label ID="lblAuthor" runat="server" />
                </h5>
                <!-- Display Book Description -->
                <p>
                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                </p>
                <!-- Display Amount of Books in stock -->
                <h5>
                    <asp:Label ID="lblQuantity" runat="server"></asp:Label>
                </h5>
                <br />
                <h5>
                    <!-- Display Book Price -->
                    <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
                    <!-- Button to add book to cart -->
                    <asp:Button Text="Add To Cart" runat="server"  />
                </h5>
                
            </div>
        </div>
    </form>






</asp:Content>
