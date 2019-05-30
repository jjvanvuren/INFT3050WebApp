<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminUserAccounts.aspx.cs" Inherits="INFT3050WebApp.UL.Admin.AdminUserAccounts" %>

<%@ MasterType VirtualPath="~/UL/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>User Accounts</h1>
    <div class="container-flex">
        <%--Setting data source to be used for display of data in gridview --%>
        <asp:ObjectDataSource ID="UserDataSource" runat="server" SelectMethod="GetAllUsers" TypeName="INFT3050WebApp.BL.User"></asp:ObjectDataSource>
        <asp:GridView ID="UserManagement" runat="server" AutoGenerateColumns="false" DataSourceID="UserDataSource" AllowSorting="true" CssClass="table" GridLines="None" AllowPaging="True" OnRowCommand="UserManagement_RowCommand" PageSize="10">
            <Columns>
                <%--User ID displayed--%>
                <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" SortExpression="Id">
                    <ItemStyle CssClass="col-xs-1" />
                </asp:BoundField>

                <%--User Email displayed--%>
                <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="true" SortExpression="Email">
                    <ItemStyle CssClass="col-xs-1" />
                </asp:BoundField>

                <%--User First Name displayed--%>
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" ReadOnly="true" SortExpression="FirstName">
                    <ItemStyle CssClass="col-xs-1" />
                </asp:BoundField>

                <%--User Last Name displayed--%>
                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName">
                    <ItemStyle CssClass="col-xs-1" />
                </asp:BoundField>

                <%--User Email displayed--%>
                <asp:BoundField DataField="IsAdmin" HeaderText="Admin Account" ReadOnly="true">
                    <ItemStyle CssClass="col-xs-1" />
                </asp:BoundField>

                <%--Account active field displayed--%>
                <asp:BoundField DataField="IsActive" HeaderText="Account Active">
                    <ItemStyle CssClass="col-xs-1" />
                </asp:BoundField>

                <%--view Purchases Buttons--%>
                <asp:ButtonField ButtonType="Button" CommandName="cmdView" Text="View Transactions" ControlStyle-CssClass="btn btn-success" />

                <%--Activate Button--%>
                <asp:ButtonField ButtonType="Button" CommandName="cmdActivate" Text="Activate" ControlStyle-CssClass="btn btn-success" />

                <%--Deactivate Button--%>
                <asp:ButtonField ButtonType="Button" CommandName="cmdDeactivate" Text="Deactivate" ControlStyle-CssClass="btn btn-danger" />


            </Columns>
            <EditRowStyle CssClass="warning" />
        </asp:GridView>

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Please correct the following errors:" ValidationGroup="Edit" CssClass="text-danger" />
    </div>

</asp:Content>
