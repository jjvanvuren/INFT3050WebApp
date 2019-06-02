<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminPurchaseHistory.aspx.cs" Inherits="INFT3050WebApp.UL.Admin.AdminPurchaseHistory" %>

<%@ MasterType VirtualPath="~/UL/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Purchase History</h1>
    <div class="container-flex">
        <%--Setting data source to be used for display of data in gridview --%>
        <asp:GridView ID="Orders" runat="server" AutoGenerateColumns="false" AllowSorting="false" CssClass="table" GridLines="None" AllowPaging="True" OnPageIndexChanging="Orders_PageIndexChanging">
            <%--Display of selected attributes of a order - no validation --%>
            <Columns>
                <asp:BoundField DataField="orderId" HeaderText="Order ID" SortExpression="orderId" />
                <asp:BoundField DataField="paymentId" HeaderText="Payment ID" SortExpression="paymentId" />
                <asp:BoundField DataField="Total" HeaderText="Total Cost" SortExpression="Total" />
                <asp:BoundField DataField="dateOrdered" HeaderText="Date Ordered" SortExpression="dateOrdered" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
