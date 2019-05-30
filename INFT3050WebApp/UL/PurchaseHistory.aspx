<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Customer.Master" AutoEventWireup="true" CodeBehind="PurchaseHistory.aspx.cs" Inherits="INFT3050WebApp.UL.PurchaseHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Purchase History</h1>
    <%--Use GridView to Display Purchase History--%>
    <div class="container-flex">
        <asp:GridView ID="Orders" runat="server" AutoGenerateColumns="false" AllowSorting="true" CssClass="table" GridLines="None" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="orderId" HeaderText="Order ID" SortExpression="orderId" />
                <asp:BoundField DataField="paymentId" HeaderText="Payment ID" SortExpression="paymentId" />
                <asp:BoundField DataField="Total" HeaderText="Total Cost" SortExpression="Total" />
                <asp:BoundField DataField="dateOrdered" HeaderText="Date Ordered" SortExpression="dateOrderd" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
