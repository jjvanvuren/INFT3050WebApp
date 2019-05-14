<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminPortal.aspx.cs" Inherits="INFT3050WebApp.UL.BackEnd.BackEndEmployeePortal" %>

<%@ MasterType VirtualPath="~/UL/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Inventory Managment</h1>
    <form runat="server">
        <div class="container-flex">
            <%--Setting data source to be used for display of data in gridview --%>
            <asp:ObjectDataSource ID="bookDataSource" runat="server" SelectMethod="GetBooks" TypeName="INFT3050WebApp.DAL.BookDataAccess"></asp:ObjectDataSource>
            <asp:GridView ID="ItemManagment" runat="server" AutoGenerateColumns="false" DataSourceID="bookDataSource" AllowSorting="true" CssClass="table" GridLines="None" AllowPaging="True" PageSize="5">
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

            <div>
                <br />
                <h3>Add Book</h3>
                <br />
                <%--Table to Add Books--%>
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Title</th>
                            <th scope="col">Quantity</th>
                            <th scope="col">Image Path</th>
                            <th scope="col">Thumbnail Path</th>
                            <th scope="col">Price</th>
                            <th scope="col">Long Description</th>
                            <th scope="col">Short Description</th>
                            <th scope="col">ISBN</th>
                            <th scope="col">Date Published</th>
                            <th scope="col">Publisher</th>
                            <th scope="col">Best Seller</th>

                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <%--Add Title--%>
                                <asp:TextBox ID="tbxAddTitle" runat="server" MaxLength="45" CssClass="form-control"></asp:TextBox>
                                <%--Title Validators--%>
                                <asp:RequiredFieldValidator ID="rfvAddTitle" runat="server" CssClass="text-danger" ErrorMessage="Title is required"
                                    ControlToValidate="tbxAddTitle">Title is required</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <%--Add Quantity--%>
                                <asp:TextBox ID="tbxAddQuantity" runat="server" MaxLength="45" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <%--Add Image Path--%>
                                <asp:TextBox ID="tbxAddImagePath" runat="server" MaxLength="45" CssClass="form-control" ToolTip="Must be full file path"></asp:TextBox>
                            </td>
                            <td>
                                <%--Add Thumbnail Path--%>
                                <asp:TextBox ID="tbxAddThumbnailPath" runat="server" MaxLength="45" CssClass="form-control" ToolTip="Must be full file path"></asp:TextBox>
                            </td>
                            <td>
                                <%--Add Price--%>
                                <asp:TextBox ID="tbxAddPrice" runat="server" MaxLength="45" CssClass="form-control"></asp:TextBox>
                                <%--Price Validators--%>
                                <asp:RequiredFieldValidator ID="rfvAddPrice" runat="server" CssClass="text-danger" ErrorMessage="Price is required"
                                    ControlToValidate="tbxAddPrice">Price is required</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <%--Add Long Description--%>
                                <asp:TextBox ID="tbxAddLongDesc" runat="server" MaxLength="45" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <%--Add Short Description--%>
                                <asp:TextBox ID="tbxAddShortDesc" runat="server" MaxLength="45" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <%--Add ISBN--%>
                                <asp:TextBox ID="tbxAddISBN" runat="server" MaxLength="45" CssClass="form-control"></asp:TextBox>
                                <%--ISBN Validators--%>
                                <asp:RequiredFieldValidator ID="rfvAddISBN" runat="server" CssClass="text-danger" ErrorMessage="ISBN is required"
                                    ControlToValidate="tbxAddISBN">ISBN is required</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <%--Add Date Published--%>
                                <asp:TextBox ID="tbxAddDatePublished" runat="server" MaxLength="45" CssClass="form-control"></asp:TextBox>
                                <%--Date Published Validators--%>
                                <asp:RequiredFieldValidator ID="rfvAddDatePublised" runat="server" CssClass="text-danger" ErrorMessage="Date published is required"
                                    ControlToValidate="tbxAddDatePublished">Date published is required</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <%--Add Publisher--%>
                                <asp:TextBox ID="tbxAddPublisher" runat="server" MaxLength="45" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <%--Add Best Seller--%>
                                <asp:DropDownList ID="ddlAddBestSeller" runat="server">
                                    <asp:ListItem Text="True" Value="true" />
                                    <asp:ListItem Text="False" Value="false" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <%--Add Book Button--%>
                <asp:Button ID="btnAddBook" type="submit" CssClass="btn btn-primary" runat="server" Text="Add Book" OnClick="btnAddBook_Click" />
            </div>


            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Please correct the following errors:" ValidationGroup="Edit" CssClass="text-danger" />

        </div>
    </form>

</asp:Content>

