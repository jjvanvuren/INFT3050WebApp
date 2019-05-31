<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="INFT3050WebApp.UL.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Shopping Cart</h1>
    <br />
    <%--This table is only to show desired layout 
            Will be replaced in assignment 2--%>

        <asp:GridView ID="gridCart" runat="server" AutoGenerateColumns="false" AllowSorting="true" CssClass="table" 
            GridLines="None" AllowPaging="True" OnRowUpdating="ItemManagment_RowUpdating" OnRowDeleting="ItemManagment_RowDeleting" ShowHeaderWhenEmpty="true">
            <Columns>
                <%--Item ISBN displayed--%>
                <asp:BoundField DataField="ISBN" HeaderText="ISBN" ReadOnly="True" SortExpression="ISBN">
                    <ItemStyle CssClass="col-xs-1" />
                </asp:BoundField>
                <%--Item Title displayed--%>
                <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="True" SortExpression="Title">
                    <ItemStyle CssClass="col-xs-1" />
                </asp:BoundField>

                <%--Quantity of item--%>

                    <%-- Quantity field during Edit--%>    

                <asp:BoundField DataField="Quantity" HeaderText="Quantity"  SortExpression="Quantity">
                    <ItemStyle CssClass="col-xs-1" />
                </asp:BoundField>
<%--                            <asp:regular ID="revStockonHand" runat="server" CssClass="text-danger" ErrorMessage="Please enter a valid quantity"
                                        ValidationExpression="^\d+$"
                                        ControlToValidate="txtGridQuantity">Please enter a valid quantity</asp:regular>--%>
                        <%-- Quantity field validation--%>




                <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" SortExpression="Price">
                    <ItemStyle CssClass="col-xs-1" />
                </asp:BoundField>

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





    <asp:Label ID="lblTotalPrice" runat="server" Text="Total Price : $"></asp:Label>
    <asp:Label ID="lblTheTotalPrice" runat="server"></asp:Label>


    <br />

    <%-- Button for customer to proceed to checkout --%>
    <asp:Button ID="btnCheckout" CssClass="btn btn-success" runat="server" Text="Checkout" OnClick="btnCheckout_Click" />

</asp:Content>
