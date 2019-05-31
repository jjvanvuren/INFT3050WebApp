<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminPortal.aspx.cs" Inherits="INFT3050WebApp.UL.BackEnd.BackEndEmployeePortal" %>

<%@ MasterType VirtualPath="~/UL/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Inventory Managment</h1>
    <div class="container-flex">
        <%--Setting data source to be used for display of data in gridview --%>
        <asp:ObjectDataSource ID="bookDataSource" runat="server" SelectMethod="GetAdminBooks" TypeName="INFT3050WebApp.DAL.BookDataAccess"></asp:ObjectDataSource>
        <asp:GridView ID="ItemManagment" runat="server" AutoGenerateColumns="false" DataSourceID="bookDataSource" AllowSorting="true" CssClass="table" GridLines="None"
            AllowPaging="True" PageSize="5" OnRowUpdating="ItemManagment_RowUpdating" OnRowDeleting="ItemManagment_RowDeleting">
            <Columns>
                <%--Item iD displayed--%>
                <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" >
                    <ItemStyle CssClass="col-xs-1" />
                </asp:BoundField>
                <%--Item iD displayed--%>
                <asp:BoundField DataField="IsActive" HeaderText="Active" ReadOnly="True" >
                    <ItemStyle CssClass="col-xs-1" />
                </asp:BoundField>

                <%--Title of item--%>
                <asp:TemplateField HeaderText="Title">
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
                    <ItemStyle CssClass="col-xs-5" />
                </asp:TemplateField>

                 <%--ImagePath of item--%>
                <asp:TemplateField HeaderText="Image Path">
                    <%-- ImagePath field during Edit--%>
                    <EditItemTemplate>
                        <div class="col-xs-11 col-edit">
                            <asp:TextBox ID="txtGridImagePath" runat="server" MaxLength="45" CssClass="form-control" Text='<%# Bind("ImagePath") %>'></asp:TextBox>
                        </div>
                        <%-- ImagePath field validation--%>
                    </EditItemTemplate>
                    <%-- ImagePath field normal--%>
                    <ItemTemplate>
                        <asp:Label ID="lblImagePath" runat="server" Text='<%# Bind("ImagePath") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="col-xs-5" />
                </asp:TemplateField>

                
                 <%--ThumbnailPath of item--%>
                <asp:TemplateField HeaderText="Thumbnail Path">
                    <%-- ImagePath field during Edit--%>
                    <EditItemTemplate>
                        <div class="col-xs-11 col-edit">
                            <asp:TextBox ID="txtGridThumbnailPath" runat="server" MaxLength="45" CssClass="form-control" Text='<%# Bind("ThumbnailPath") %>'></asp:TextBox>
                        </div>
                        <%-- ThumbnailPath field validation--%>
                    </EditItemTemplate>
                    <%-- ThumbnailPath field normal--%>
                    <ItemTemplate>
                        <asp:Label ID="lblThumbnailPath" runat="server" Text='<%# Bind("ThumbnailPath") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="col-xs-2" />
                </asp:TemplateField>



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
                <asp:CommandField ShowDeleteButton="True" DeleteText="Change Status" >
                    <ItemStyle CssClass="col-xs-2" />
                </asp:CommandField>

            </Columns>
            <EditRowStyle CssClass="warning" />
        </asp:GridView>

            <%--Add Book Button--%>
            <asp:Button ID="btnAddBook" type="submit" CssClass="btn btn-primary" runat="server" Text="Add Book" OnClick="btnAddBook_Click" />
        </div>

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Please correct the following errors:" ValidationGroup="Edit" CssClass="text-danger" />
    </div>

</asp:Content>

