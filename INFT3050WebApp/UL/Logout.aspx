<%@ Page Title="Logout" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="INFT3050WebApp.Logout" %>

<%@ MasterType VirtualPath="~/UL/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- Customer logout page --%>
    <h1>Logout Successful</h1>
    <br />

    <%-- Displays logout message using session state --%>
    <asp:Label ID="lblLogoutMessage" runat="server" Text=""></asp:Label>
</asp:Content>
