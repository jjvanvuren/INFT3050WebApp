<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminPortal.aspx.cs" Inherits="INFT3050WebApp.UL.BackEnd.BackEndEmployeePortal" %>

<%@ MasterType VirtualPath="~/UL/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Inventory Managment</h1>
    <form runat="server">
        <div class="container-flex">
             <%--Setting data source to be used for display of data in gridview --%>
            <asp:ObjectDataSource ID="bookDataSource" runat="server" SelectMethod="GetBooks" TypeName="INFT3050WebApp.DAL.DummyDB"></asp:ObjectDataSource>
            <asp:GridView ID="ItemManagment" runat="server" AutoGenerateColumns="false" DataSourceID="bookDataSource" AllowSorting="true" CssClass="table" GridLines="None" AllowPaging="True">
                <Columns>
                    <%--Item iD displayed--%>
                    <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" SortExpression="Id">
                        <ItemStyle CssClass="col-xs-1" />
                    </asp:BoundField>

                    <%--Title of item--%>
                    <asp:TemplateField HeaderText="Title" SortExpression="Title">
                        <%-- Title field during Edit--%>
                        <EditItemTemplate>
                            <div class="col-xs-11 col-edit">
                                <asp:TextBox ID="txtGridTitle" runat="server" MaxLength="45" CssClass="form-control" Text='<%# Bind("title") %>'></asp:TextBox>
                            </div>
                            <%-- Title field validation--%>
                            <asp:RequiredFieldValidator ID="rfvGridTitle" runat="server" ControlToValidate="txtGridTitle" ValidationGroup="Edit" Text="*" ErrorMessage="Title is a required field" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                         <%-- Title field normal--%>
                        <ItemTemplate>
                            <asp:Label ID="lblGridTitle" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="col-xs-3" />
                    </asp:TemplateField>

                    <%--Stock Quantity of item--%>
                    <asp:TemplateField HeaderText="Stock On Hand">
                        <%-- Stock Quantity field during Edit--%>
                        <EditItemTemplate>
                            <div class="col-xs-11 col-edit">
                                <asp:TextBox ID="txtGridStockQuantity" runat="server" MaxLength="45" CssClass="form-control" Text='<%# Bind("StockQuantity") %>'></asp:TextBox>
                            </div>
                            <%-- Stock Quantity field validation--%>
                            <asp:RequiredFieldValidator ID="rfvGridStockQuantity" runat="server" ControlToValidate="txtGridStockQuantity" ValidationGroup="Edit" Text="*" ErrorMessage="StockQuantity is a required field" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <%-- Stock Quantity field normal--%>
                        <ItemTemplate>
                            <asp:Label ID="lblGridStockQuantity" runat="server" Text='<%# Bind("StockQuantity") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:TemplateField>

                     <%--Item imagePath displayed--%>
                    <asp:BoundField DataField="ImagePath" HeaderText="Image Path">
                        <ItemStyle CssClass="col-xs-3" />
                    </asp:BoundField>
                     <%--Item ThambnailPath displayed--%>
                    <asp:BoundField DataField="ThumbnailPath" HeaderText="Thumbnail Image Path">
                        <ItemStyle CssClass="col-xs-3" />
                    </asp:BoundField>

                    <%--Item Price displayed--%>
                    <asp:TemplateField HeaderText="Price">
                        <%-- Price field during Edit--%>
                        <EditItemTemplate>
                            <div class="col-xs-3 col-edit">
                                <asp:TextBox ID="txtGridPrice" runat="server" MaxLength="45" CssClass="form-control" Text='<%# Bind("Price") %>'></asp:TextBox>
                            </div>
                            <%-- Price field validation--%>
                            <asp:RequiredFieldValidator ID="rfvGridPrice" runat="server" ControlToValidate="txtGridPrice" ValidationGroup="Edit" Text="*" ErrorMessage="Price is a required field" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <%-- Price field normal--%>
                        <ItemTemplate>
                            <asp:Label ID="lblGridPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="col-xs-1" />
                    </asp:TemplateField>

                    <%--Edit Buttons--%>
                    <asp:CommandField CausesValidation="True" ShowEditButton="True" ValidationGroup="Edit">
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:CommandField>

                    <%--Delete Buttons--%>
                    <asp:CommandField ShowDeleteButton="True">
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:CommandField>

                </Columns>
                <EditRowStyle CssClass="warning" />
            </asp:GridView>

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Please correct the following errors:" ValidationGroup="Edit" CssClass="text-danger" />

        </div>
    </form>

</asp:Content>

