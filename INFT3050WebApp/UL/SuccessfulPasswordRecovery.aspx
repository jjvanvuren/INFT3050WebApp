<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="SuccessfulPasswordRecovery.aspx.cs" Inherits="INFT3050WebApp.UL.SuccessfulPasswordRecovery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Password Reset Successful</h1>
    <p>Click on the link below to return to login screen:</p>
    <div>
        <asp:Button ID="btnLogin" type="submit" CssClass="btn btn-primary" runat="server" Text="Login" OnClick="btnLogin_Click" />
    </div>
</asp:Content>
