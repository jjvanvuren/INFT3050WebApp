<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminVerified.aspx.cs" Inherits="INFT3050WebApp.UL.Admin.AdminVerified" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><asp:Label ID="lblHeader" runat="server" Text=""></asp:Label></h1>
    
    <p><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></p>
    <asp:Button ID="btnLogin" CssClass="btn btn-primary" runat="server" Text="Login" OnClick="btnLogin_Click" />
</asp:Content>
