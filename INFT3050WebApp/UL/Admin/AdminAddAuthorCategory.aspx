<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminAddAuthorCategory.aspx.cs" Inherits="INFT3050WebApp.UL.Admin.AdminAddAuthorCategory" %>

<%@ MasterType VirtualPath="~/UL/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Add Book</h1>
    <h2>Author</h2>

    <h2>Category</h2>


   

    <asp:Button ID="btnBookDetails" type="submit" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="btnBookDetails_Click" />

</asp:Content>
