<%@ Page Title="Logout" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="INFT3050WebApp.Logout" %>
<%@ MasterType VirtualPath="~/UL/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Logout Successful</h1>
    <br />
    <br />
    <asp:Label ID="lblLogoutMessage" runat="server" Text=""></asp:Label>
</asp:Content>
