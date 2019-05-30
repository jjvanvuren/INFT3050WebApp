<%@ Page Title="Registration Successful" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="SuccessfulRegistration.aspx.cs" Inherits="INFT3050WebApp.SuccessfulRegistration" %>

<%@ MasterType VirtualPath="~/UL/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Registration Successful</h1>
    <br />
    <br />
    <asp:Label ID="thanksMessageLabel" runat="server" Text=""></asp:Label>

</asp:Content>
