<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="INFT3050WebApp.UL.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Shopping Cart</h1>
    <br />
    <!-- This table is only to show desired layout 
             Will be replaced in assignment 2-->
            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">ISBN</th>
                        <th scope="col">Title</th>
                        <th scope="col">Quantity</th>
                        <th scope="col">Price</th>
                        <th scope="col">Remove Items</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th scope="row">1</th>
                        <td>9780813056173</td>
                        <td>Picturing Apollo 11</td>
                        <td>1</td>
                        <td> &#36;45.92</td>
                        <td><button class="btn btn-warning">Remove</button></td>
                    </tr>
                    <tr>
                        <th scope="row">2</th>
                        <td>9781786812445</td>
                        <td>The Mistake</td>
                        <td>1</td>
                        <td> &#36;16.49</td>
                        <td><button class="btn btn-warning">Remove</button></td>
                    </tr>
                    <tr>
                        <th scope="row">3</th>
                        <td>9781503903265</td>
                        <td>One Word Kill</td>
                        <td>2</td>
                        <td> &#36;22.99</td>
                        <td><button class="btn btn-warning">Remove</button></td>
                    </tr>
                    <tr>
                        <th scope="row"></th>
                        <td></td>
                        <td></td>
                        <td class="font-weight-bold">Total:</td>
                        <td class="font-weight-bold"> &#36;108.39</td>
                        <td><button class="btn btn-warning">Clear</button></td>
                    </tr>
                </tbody>
            </table>
    <br />

    <form runat="server">
        <asp:Button ID="btnCheckout" CssClass="btn btn-success" runat="server" Text="Checkout" OnClick="btnCheckout_Click" />
    </form>
    


</asp:Content>
