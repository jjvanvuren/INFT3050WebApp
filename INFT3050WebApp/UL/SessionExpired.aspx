<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="SessionExpired.aspx.cs" Inherits="INFT3050WebApp.UL.SessionExpired" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Session Expired</h1>
        <asp:Label runat="server" ID="lblExpiredMessage"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnLogIn" Text="Log In" runat="server" CssClass="btn btn-primary" OnClick="btnLogIn_Click"/>
    </div>
</asp:Content>
