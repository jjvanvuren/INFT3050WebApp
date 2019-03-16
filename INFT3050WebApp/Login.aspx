<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="INFT3050WebApp.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <form runat="server">
        <div class="form-group">
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="tbxEmail" runat="server" type="email" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="tbxPassword" runat="server" type="password" class="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="btnLogin" type="submit" class="btn btn-primary" runat="server" Text="Submit" OnClick="btnLogin_Click" />
    </form>
</asp:Content>
