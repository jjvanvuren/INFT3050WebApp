<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminPostageOptions.aspx.cs" Inherits="INFT3050WebApp.UL.Admin.AdminPostageOptions" %>

<%@ MasterType VirtualPath="~/UL/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Postage Options</h1>
    <form runat="server">
        <div class="container-flex">
            <asp:ObjectDataSource ID="PostageOptionDataSource" runat="server" SelectMethod="GetPostageOptions" TypeName="INFT3050WebApp.DAL.DummyDB"></asp:ObjectDataSource>
            <asp:GridView ID="PostageOptionManagement" runat="server" AutoGenerateColumns="false" DataSourceID="PostageOptionDataSource" AllowSorting="true" CssClass="table" GridLines="None" AllowPaging="True">
                <Columns>

                    <%-- ID Field --%>
                    <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" SortExpression="Id">
                        <ItemStyle CssClass="col-xs-1" />
                    </asp:BoundField>
                    
                    <%-- Name Field --%>
                    <asp:TemplateField HeaderText="Name" SortExpression="Name">
                        <EditItemTemplate>
                            <div class="col-xs-11 col-edit">
                                <asp:TextBox ID="txtGridName" runat="server" MaxLength="45" CssClass="form-control" Text='<%# Bind("Name") %>'></asp:TextBox>
                            </div>
                            <%-- Name Validator/s --%>
                            <asp:RequiredFieldValidator ID="rfvGridName" runat="server" ControlToValidate="txtGridName" ValidationGroup="Edit" Text="*" ErrorMessage="Name is a required field" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblGridName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="col-xs-3" />
                    </asp:TemplateField>
                    
                    <%-- Price Field --%>
                    <asp:TemplateField HeaderText="Price">
                        <EditItemTemplate>
                            <div class="col-xs-3 col-edit">
                                <asp:TextBox ID="txtGridPrice" runat="server" MaxLength="45" CssClass="form-control" Text='<%# Bind("Price") %>'></asp:TextBox>
                            </div>
                            <%-- Price Validator/s --%>
                            <asp:RequiredFieldValidator ID="rfvGridPrice" runat="server" ControlToValidate="txtGridPrice" ValidationGroup="Edit" Text="*" ErrorMessage="Price is a required field" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblGridPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="col-xs-1" />
                    </asp:TemplateField>

                    <%-- Edit Command Field --%>
                    <asp:CommandField CausesValidation="True" ShowEditButton="True" ValidationGroup="Edit" HeaderText="Edit">
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:CommandField>

                </Columns>
                <EditRowStyle CssClass="warning" />
            </asp:GridView>
            <%-- Validation Summary --%>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Please correct the following errors:" ValidationGroup="Edit" CssClass="text-danger" />

        </div>
    </form>

</asp:Content>
