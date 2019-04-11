<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Customer.Master" AutoEventWireup="true" CodeBehind="PurchaseHistory.aspx.cs" Inherits="INFT3050WebApp.UL.PurchaseHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Purchase History</h1>

    <div>
        <!-- This table is only to show desired layout 
             Will be replaced in assignment 2-->
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">Order ID</th>
                    <th scope="col">Payment ID</th>
                    <th scope="col">Total</th>
                    <th scope="col">Date</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope="row">1</th>
                    <td>01325</td>
                    <td>02106</td>
                    <td>$50.00</td>
                    <td>04/03/2018</td>
                </tr>
                <tr>
                    <th scope="row">2</th>
                    <td>14656</td>
                    <td>45621</td>
                    <td>$121.41</td>
                    <td>05/04/2018</td>
                </tr>
                <tr>
                    <th scope="row">3</th>
                    <td>78951</td>
                    <td>56894</td>
                    <td>$501.10</td>
                    <td>20/01/2019</td>
                </tr>
                <tr>
                    <th scope="row">4</th>
                    <td>98754</td>
                    <td>95588</td>
                    <td>$3.50</td>
                    <td>04/04/2019</td>
                </tr>
            </tbody>
        </table>
    </div>

</asp:Content>
