<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="INFT3050WebApp.UL.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Shopping Cart</h1>
    <br />
    <%--This table is only to show desired layout 
            Will be replaced in assignment 2--%>
        <asp:GridView ID="gridCart" runat="server" AutoGenerateColumns="false" AllowSorting="true" CssClass="table" 
            GridLines="None" AllowPaging="True" OnRowDeleting="gridCart_RowDeleting" ShowHeaderWhenEmpty="true" DataKeyNames="ID"  OnRowCommand="gridCart_RowCommand1">
            <Columns>
                <%--Item ID--%>
                <asp:BoundField DataField="ID"  ReadOnly="True" Visible="false" >
                    <ItemStyle CssClass="col-xs-1" />
                </asp:BoundField>
                <%--Item ISBN displayed--%>
                <asp:BoundField DataField="ISBN" HeaderText="ISBN">
                    <ItemStyle CssClass="col-xs-1" />
                </asp:BoundField>
                <%--Item Title displayed--%>
                <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="True">
                    <ItemStyle CssClass="col-xs-1" />
                </asp:BoundField>

                <%--Quantity of item--%>

                    <%-- Quantity field during Edit--%>    

<%--                <asp:BoundField DataField="Quantity" HeaderText="Quantity"  SortExpression="Quantity">
                    <ItemStyle CssClass="col-xs-1" />
                </asp:BoundField>--%>
                <asp:TemplateField HeaderText ="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQuantity" runat="server" MaxLength="5" CssClass="form-control" Text='<%# Bind("Quantity") %>'><ItemStyle CssClass="col-xs-1" /></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True">
                    <ItemStyle CssClass="col-xs-1" />
                </asp:BoundField>


                <%-- Edit Quantity --%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnUpdateQuantity" Text="Update Quantity" runat="server" CommandName="cmdUpdate" CommandArgument='<%# Eval("ID") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>

                <%--Delete Buttons--%>
                <asp:CommandField ShowDeleteButton="True" DeleteText="Remove Item" >
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
