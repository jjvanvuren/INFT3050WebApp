<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="INFT3050WebApp.UL.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Shopping Cart</h1>
    <br />

       <asp:GridView ID="gridCart" runat="server" AutoGenerateColumns="false" AllowSorting="true" CssClass="table" 
        GridLines="None" AllowPaging="True" OnRowDeleting="gridCart_RowDeleting" ShowHeaderWhenEmpty="true" DataKeyNames="ID"  >
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

                <asp:BoundField DataField="Quantity" HeaderText="Quantity"  SortExpression="Quantity">
                    <ItemStyle CssClass="col-xs-1" />
                </asp:BoundField>


<%--                <asp:TemplateField HeaderText ="Quantity Up">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQuantity" runat="server" ></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>--%>


                <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True">
                    <ItemStyle CssClass="col-xs-1" />
                </asp:BoundField>


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
<%--    <asp:Button ID="UpdateQuantity" CssClass="btn btn-success" runat="server" Text="Update Quantity" OnClick="UpdateQuantity_Click" />--%>
    <asp:Button ID="btnCheckout" CssClass="btn btn-success" runat="server" Text="Checkout" OnClick="btnCheckout_Click" />

</asp:Content>
