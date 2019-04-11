<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminUserAccounts.aspx.cs" Inherits="INFT3050WebApp.UL.Admin.AdminUserAccounts" %>

<%@ MasterType VirtualPath="~/UL/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center">User Accounts</h2>
    <form runat="server">
        <div class="container-flex">
            <%--Setting data source to be used for display of data in gridview --%>
            <asp:ObjectDataSource ID="UserDataSource" runat="server" SelectMethod="GetUsers" TypeName="INFT3050WebApp.DAL.DummyDB"></asp:ObjectDataSource>
            <asp:GridView ID="UserManagment" runat="server" AutoGenerateColumns="false" DataSourceID="UserDataSource" AllowSorting="true" CssClass="table" GridLines="None" AllowPaging="True" OnRowCommand=" GridBooks_RowCommand" OnRowUpdated="ItemManagment_RowUpdated">
                <Columns>
                    <%--User iD displayed--%>
                    <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" SortExpression="Id">
                        <ItemStyle CssClass="col-xs-1" />
                    </asp:BoundField>

                    <%--User Email displayed--%>
                    <asp:TemplateField HeaderText="Email" SortExpression="Email">
                        <%-- Email field during Edit--%>
                        <EditItemTemplate>
                            <div class="col-xs-11 col-edit">
                                <asp:TextBox ID="txtGridEmail" runat="server" MaxLength="45" CssClass="form-control" Text='<%# Bind("Email") %>'></asp:TextBox>
                            </div>
                            <%-- Email field Validation--%>
                            <asp:RequiredFieldValidator ID="rfvGridEmail" runat="server" ControlToValidate="txtGridEmail" ValidationGroup="Edit" Text="*" ErrorMessage="Email is a required field" CssClass="text-danger"></asp:RequiredFieldValidator>
                            <%-- Check that its an email address --%>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" CssClass="text-danger" ErrorMessage="Please provide a valid email address"
                             ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtGridEmail">Valid email required</asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <%-- Email field normal--%>
                        <ItemTemplate>
                            <asp:Label ID="lblGridEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="col-xs-3" />
                    </asp:TemplateField>

                    <%--User Password displayed--%>
                    <asp:TemplateField HeaderText="Password">
                        <%-- Password field during Edit--%>
                        <EditItemTemplate>
                            <div class="col-xs-11 col-edit">
                                <asp:TextBox ID="txtGridPassword" runat="server" MaxLength="45" CssClass="form-control" Text='<%# Bind("Password") %>'></asp:TextBox>
                            </div>
                            <%-- Password field Validation--%>
                            <asp:RequiredFieldValidator ID="rfvGridPassword" runat="server" ControlToValidate="txtGridPassword" ValidationGroup="Edit" Text="*" ErrorMessage="Password is a required field" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <%-- password field normal--%>
                        <ItemTemplate>
                            <asp:Label ID="lblGridPassword" runat="server" Text='<%# Bind("Password") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:TemplateField>

                     <%--User First Name displayed--%>
                    <asp:TemplateField HeaderText="FirstName" SortExpression="FirstName">
                        <%-- First Name field during Edit--%>
                        <EditItemTemplate>
                            <div class="col-xs-3 col-edit">
                                <asp:TextBox ID="txtGridFirstName" runat="server" MaxLength="45" CssClass="form-control" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                            </div>
                            <%-- First Name field Validation Required Field--%>
                            <asp:RequiredFieldValidator ID="rfvGridFirstName" runat="server" ControlToValidate="txtGridFirstName" ValidationGroup="Edit" Text="*" ErrorMessage="First Name is a required field" CssClass="text-danger"></asp:RequiredFieldValidator>
                            <%-- First Name field Validation is a valid Name--%>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" CssClass="text-danger" ErrorMessage="Please provide a valid Last Name"
                             ValidationExpression="^[A-Za-z]+$" ControlToValidate="txtGridFirstName">Valid Last name required</asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <%-- password field normal--%>
                        <ItemTemplate>
                            <asp:Label ID="lblGridFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="col-xs-1" />
                    </asp:TemplateField>

                    <%--User First Name displayed--%>
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName">
                        <ItemStyle CssClass="col-xs-1" />
                    </asp:BoundField>

                    <%--IsAdmin displayed--%>
                    <asp:TemplateField HeaderText="Admin Account">
                        <%-- IsAdmin field during Edit--%>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtGridIsAdmin" runat="server" MaxLength="45" CssClass="form-control" Text='# Bind("IsAdmin") %>'></asp:TextBox>
                            </div>
                            <%-- Isadmin field Validation--%>
                           <asp:RequiredFieldValidator ID="rfvGridIsAdmin" runat="server" ControlToValidate="txtGridIsAdmin" ValidationGroup="Edit" Text="*" ErrorMessage="IsAdmin is a required field" CssClass="text-danger"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revIsAdmin" runat="server" CssClass="text-danger" ErrorMessage="Please provide true or false"
                            ValidationExpression="/^true$/" ControlToValidate="txtGridIsAdmin">Valid email required</asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <%-- Isadmin field normal--%>
                        <ItemTemplate>
                            <asp:Label ID="lblGridIsAdmin" runat="server" Text='<%# Bind("IsAdmin") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="col-xs-1" />
                    </asp:TemplateField>

 
                    <%--Status field displayed--%>
                    <asp:BoundField DataField="Status" HeaderText="Acccount Status">
                        <ItemStyle CssClass="col-xs-1" />
                    </asp:BoundField>

                    <%--view Purchases Buttons--%>
                    <asp:ButtonField ButtonType="Button" CommandName="cmdView" Text="View Transactions" ControlStyle-CssClass="btn btn-success" />
                    <%--Edit Buttons--%>
                    <asp:CommandField CausesValidation="True" ShowEditButton="True" ValidationGroup="Edit">
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:CommandField>

                </Columns>
                <EditRowStyle CssClass="warning" />
            </asp:GridView>

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Please correct the following errors:" ValidationGroup="Edit" CssClass="text-danger" />

        </div>
    </form>

</asp:Content>
