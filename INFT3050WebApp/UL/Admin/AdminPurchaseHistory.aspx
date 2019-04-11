<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminPurchaseHistory.aspx.cs" Inherits="INFT3050WebApp.UL.Admin.AdminPurchaseHistory" %>
<%@ MasterType VirtualPath="~/UL/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center">Purchase History</h2>
    <form runat="server">
        <div class="container-flex">
            <asp:ObjectDataSource ID="OrderDataSource" runat="server" SelectMethod="GetOrders" TypeName="INFT3050WebApp.DAL.DummyDB"></asp:ObjectDataSource>
            <asp:GridView ID="Orders" runat="server" AutoGenerateColumns="false" DataSourceID="OrderDataSource" AllowSorting="true" CssClass="table" GridLines="None" AllowPaging="True">
                <Columns>
                <asp:BoundField DataField="orderId" HeaderText="Order ID" SortExpression="orderId"/>
                <asp:BoundField DataField="purchaseId" HeaderText="Purchase ID" SortExpression="purchaseId"/>
                <asp:BoundField DataField="Total" HeaderText="Total Cost" SortExpression="Total"/>
                <asp:BoundField DataField="dateOrdered" HeaderText="Date Ordered" SortExpression="dateOrderd"/>
                </Columns>

            </asp:GridView>

        </div>
    </form>

</asp:Content>
