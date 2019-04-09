<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminUserAccounts.aspx.cs" Inherits="INFT3050WebApp.UL.Admin.AdminUserAccounts" %>

<%@ MasterType VirtualPath="~/UL/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center">User Accounts</h2>
    <form runat="server">
        <div class="container-flex">
            <asp:ObjectDataSource ID="UserDataSource" runat="server" SelectMethod="GetUsers" TypeName="INFT3050WebApp.DAL.DummyDB"></asp:ObjectDataSource>
            <asp:GridView ID="ItemManagment" runat="server" AutoGenerateColumns="false" DataSourceID="UserDataSource" AllowSorting="true" CssClass="table" GridLines="None" AllowPaging="True" OnRowCommand=" GridBooks_RowCommand">
                <Columns>

                    <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" SortExpression="Id">
                        <ItemStyle CssClass="col-xs-1" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Email" SortExpression="Email">
                        <EditItemTemplate>
                            <div class="col-xs-11 col-edit">
                                <asp:TextBox ID="txtGridEmail" runat="server" MaxLength="45" CssClass="form-control" Text='<%# Bind("Email") %>'></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvGridEmail" runat="server" ControlToValidate="txtGridEmail" ValidationGroup="Edit" Text="*" ErrorMessage="Email is a required field" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblGridEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="col-xs-3" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Password">
                        <EditItemTemplate>
                            <div class="col-xs-11 col-edit">
                                <asp:TextBox ID="txtGridPassword" runat="server" MaxLength="45" CssClass="form-control" Text='<%# Bind("Password") %>'></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvGridPassword" runat="server" ControlToValidate="txtGridPassword" ValidationGroup="Edit" Text="*" ErrorMessage="Password is a required field" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblGridPassword" runat="server" Text='<%# Bind("Password") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="FirstName" SortExpression="FirstName">
                        <EditItemTemplate>
                            <div class="col-xs-3 col-edit">
                                <asp:TextBox ID="txtGridFirstName" runat="server" MaxLength="45" CssClass="form-control" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvGridFirstName" runat="server" ControlToValidate="txtGridFirstName" ValidationGroup="Edit" Text="*" ErrorMessage="First Name is a required field" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblGridFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="col-xs-1" />
                    </asp:TemplateField>

                    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName">
                        <ItemStyle CssClass="col-xs-1" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="IsAdmin">
                        <EditItemTemplate>

                            <asp:TextBox ID="txtGridIsAdmin" runat="server" MaxLength="45" CssClass="form-control" Text='# Bind("IsAdmin") %>'></asp:TextBox>
                            </div>
                           <asp:RequiredFieldValidator ID="rfvGridIsAdmin" runat="server" ControlToValidate="ddlIsAdmin" ValidationGroup="Edit" Text="*" ErrorMessage="IsAdmin is a required field" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblGridIsAdmin" runat="server" Text='<%# Bind("IsAdmin") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="col-xs-1" />
                    </asp:TemplateField>


                    <asp:BoundField DataField="IsAdmin" HeaderText="Admin Account">
                        <ItemStyle CssClass="col-xs-1" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Status" HeaderText="Acccount Status">
                        <ItemStyle CssClass="col-xs-1" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Button" CommandName="cmdView" Text="View Transactions" ControlStyle-CssClass="btn btn-success" />
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
