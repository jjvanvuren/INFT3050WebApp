<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="DefaultError.aspx.cs" Inherits="INFT3050WebApp.UL.DefaultError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alert alert-danger">
        <h1 class="alert-heading">Application Error</h1>
        <asp:Label runat="server" ID="lblErrorText"></asp:Label>
        <br />
        <asp:Label ID="lblErrorDetails" runat="server" />
    </div>

</asp:Content>
