﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminPostageOptions.aspx.cs" Inherits="INFT3050WebApp.UL.Admin.AdminPostageOptions" %>

<%@ MasterType VirtualPath="~/UL/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Postage Options</h1>
            <%-- Validation Summary --%>
        <asp:ValidationSummary ID="ValidationSummaryAdd" runat="server" HeaderText="Please correct the following errors:" ValidationGroup="Add" CssClass="text-danger" />
    <h4>Update/Delete</h4>
    <div class="container-flex">
        <asp:ObjectDataSource ID="PostageOptionDataSource" runat="server" SelectMethod="GetPostageOptions" TypeName="INFT3050WebApp.BL.PostageOption"></asp:ObjectDataSource>
        <asp:GridView ID="PostageOptionManagement" runat="server" AutoGenerateColumns="false" DataSourceID="PostageOptionDataSource" AllowSorting="false" 
            CssClass="table" GridLines="None" AllowPaging="True" OnRowCommand="PostageOptionManagement_RowCommand" OnRowUpdating="PostageOptionManagement_RowUpdating">
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

                        <asp:RegularExpressionValidator ID="revGridPrice" runat="server" ControlToValidate="txtGridPrice" ValidationGroup="Edit" Text="*" ErrorMessage="Price has to be a number" ValidationExpression="[-+]?[0-9]*\.?[0-9]+" CssClass="text-danger"></asp:RegularExpressionValidator>
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
               
                <%-- Delete button Field --%>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" Text="Delete" runat="server" CssClass="btn btn-danger" CommandName="cmdDelete" CommandArgument='<%# Eval("id") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>
            <EditRowStyle CssClass="warning" />
        </asp:GridView>

        <h4>Add New</h4>
        <%-- Add Name Field --%>
        <asp:Label ID="lblAddName" Text="Name:" runat="server" />
        <asp:TextBox ID="txtAddName" runat="server" />
        <asp:RequiredFieldValidator ID="rfvAddName" runat="server" ControlToValidate="txtAddName" Text="*" ValidationGroup="Add" ErrorMessage="Name is a required field" CssClass="text-danger"></asp:RequiredFieldValidator>
        <br />
        <br />
        <%-- Add Price Field --%>
        <asp:Label ID="lblAddPrice" Text="Price:" runat="server" />
        <asp:TextBox ID="txtAddPrice" runat="server" />
        <asp:RegularExpressionValidator ID="revAddPrice" runat="server" ControlToValidate="txtAddPrice" ValidationGroup="Add" Text="*" ErrorMessage="Price has to be a number" ValidationExpression="[-+]?[0-9]*\.?[0-9]+" CssClass="text-danger"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="rfvAddPrice" runat="server" ControlToValidate="txtAddPrice" Text="*" ValidationGroup="Add" ErrorMessage="Price is a required field" CssClass="text-danger"></asp:RequiredFieldValidator>
        <br />
        <br />
        <%-- Add Button Field --%>
        <asp:Button ID="btnAdd" Text="Add" runat="server" CssClass="btn btn-success" CausesValidation="true" ValidationGroup="Add" OnClick="btnAdd_Click"/>

        <%-- Validation Summary --%>
        <asp:ValidationSummary ID="ValidationEdit" runat="server" HeaderText="Please correct the following errors:" ValidationGroup="Edit" CssClass="text-danger" />
    </div>

</asp:Content>
