<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="INFT3050WebApp.UL.Book" %>

<%@ MasterType VirtualPath="~/UL/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <form runat="server">
        <div class="row">
            <div class="col-md-6">
                <asp:Image CssClass="rounded" ID="imgBook" runat="server" />
            </div>
            <br />
            <div class="col-md-6">
                <h1>
                    <asp:Label ID="lblTitle" runat="server"></asp:Label></h1>
                <p>
                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                </p>
                <h5>
                    <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
                    <asp:Button Text="Add To Cart" runat="server"  />
                </h5>
                
            </div>
        </div>
    </form>






</asp:Content>
