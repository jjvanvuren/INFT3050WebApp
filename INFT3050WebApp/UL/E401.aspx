<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="E401.aspx.cs" Inherits="INFT3050WebApp.UL.E401" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alert alert-danger">
        <h1 class="alert-heading">Error 401: Unauthorized Request</h1>
        <asp:Label runat="server" ID="lblErrorText"></asp:Label>
    </div>

</asp:Content>
