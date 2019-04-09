<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminPortal.aspx.cs" Inherits="INFT3050WebApp.UL.BackEnd.BackEndEmployeePortal" %>

<%@ MasterType VirtualPath="~/UL/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center">Inventory Managment</h2>
    <form runat="server">
        <div class="container-flex">
            <asp:ObjectDataSource ID="bookDataSource" runat="server" SelectMethod="GetBooks" TypeName="INFT3050WebApp.DAL.DummyDB"></asp:ObjectDataSource>
            <asp:GridView ID="ItemManagment" runat="server" AutoGenerateColumns="false" DataSourceID="bookDataSource" AllowSorting="true" CssClass="table" GridLines="None" AllowPaging="True">
                <Columns>

                    <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" SortExpression="Id">
                        <ItemStyle CssClass="col-xs-1" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Title" SortExpression="Title">
                        <EditItemTemplate>
                            <div class="col-xs-11 col-edit">
                                <asp:TextBox ID="txtGridTitle" runat="server" MaxLength="45" CssClass="form-control" Text='<%# Bind("title") %>'></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvGridTitle" runat="server" ControlToValidate="txtGridTitle" ValidationGroup="Edit" Text="*" ErrorMessage="Title is a required field" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblGridTitle" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="col-xs-3" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Stock On Hand">
                        <EditItemTemplate>
                            <div class="col-xs-11 col-edit">
                                <asp:TextBox ID="txtGridStockQuantity" runat="server" MaxLength="45" CssClass="form-control" Text='<%# Bind("StockQuantity") %>'></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvGridStockQuantity" runat="server" ControlToValidate="txtGridStockQuantity" ValidationGroup="Edit" Text="*" ErrorMessage="StockQuantity is a required field" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblGridStockQuantity" runat="server" Text='<%# Bind("StockQuantity") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:TemplateField>

                    <asp:BoundField DataField="ImagePath" HeaderText="Image Path">
                        <ItemStyle CssClass="col-xs-3" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ThumbnailPath" HeaderText="Thumbnail Image Path">
                        <ItemStyle CssClass="col-xs-3" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Price">
                        <EditItemTemplate>
                            <div class="col-xs-3 col-edit">
                                <asp:TextBox ID="txtGridPrice" runat="server" MaxLength="45" CssClass="form-control" Text='<%# Bind("Price") %>'></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvGridPrice" runat="server" ControlToValidate="txtGridPrice" ValidationGroup="Edit" Text="*" ErrorMessage="Price is a required field" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblGridPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="col-xs-1" />
                    </asp:TemplateField>

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

