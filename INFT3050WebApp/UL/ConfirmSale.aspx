<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Customer.Master" AutoEventWireup="true" CodeBehind="ConfirmSale.aspx.cs" Inherits="INFT3050WebApp.UL.ConfirmSale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- Page displays if purchase was successful --%>
    <h1>Payment Successful</h1>

    <%-- Custom Confirmation message using session data --%>
    <asp:Label ID="confirmSaleMessageLabel" runat="server" Text=""></asp:Label>
</asp:Content>
