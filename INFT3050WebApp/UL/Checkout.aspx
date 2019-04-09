<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Customer.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="INFT3050WebApp.UL.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Checkout</h1>
    <br />
    <hr>
    <h2>Select delivery or pick up</h2>
    <br />
    <form runat="server">
        <div class="form-group">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem>&nbsp;&nbsp; Pick up in store</asp:ListItem>
                <asp:ListItem>&nbsp;&nbsp; I would like to have my order delivered</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <hr>
        <h2>Enter your billing details</h2>
        <div>
            <asp:ValidationSummary ID="vsBilling" runat="server" CssClass="alert-danger" HeaderText="Please correct these issues" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblAddress1" runat="server" Text="Address Line 1"></asp:Label>
            <asp:TextBox ID="tbxAddress1" class="form-control" type="text" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblAddress2" runat="server" Text="Address Line 2"></asp:Label>
            <asp:TextBox ID="tbxAddress2" class="form-control" type="text" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" ErrorMessage="Please enter your address"
                ControlToValidate="tbxAddress1">Address line 1 required</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="lblPostCode" runat="server" Text="Post Code"></asp:Label>
            <asp:TextBox ID="tbxPostCode" class="form-control" type="text" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="rfvPostCode" runat="server" ErrorMessage="Please enter your post code"
                ControlToValidate="tbxPostCode">Post code required</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="lblSuburb" runat="server" Text="Suburb"></asp:Label>
            <asp:TextBox ID="tbxSuburb" class="form-control" type="text" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="rfvSuburb" runat="server" ErrorMessage="Please enter your suburb"
                ControlToValidate="tbxSuburb">Suburb is required</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
            <asp:TextBox ID="tbxState" class="form-control" type="text" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Please enter your state"
                ControlToValidate="tbxState">State is required</asp:RequiredFieldValidator>
        </div>

        <hr>

        <h2>Enter your shipping details</h2>

        <p class="text-danger font-weight-bold" >If you do not enter shipping details below, the order will be shipped to the billing address.</p>

        <asp:Label ID="lblAdress1Ship" runat="server" Text="Address Line 1"></asp:Label>

        <asp:TextBox ID="tbxAddress1Ship" class="form-control" type="text" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblAdress2Ship" runat="server" Text="Address Line 2"></asp:Label>

        <asp:TextBox ID="tbxAddress2Ship" class="form-control" type="text" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblPostCodeShip" runat="server" Text="Post Code"></asp:Label>

        <asp:TextBox ID="tbxPostCodeShip" class="form-control" type="text" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblSuburbShip" runat="server" Text="Suburb"></asp:Label>

        <asp:TextBox ID="tbxSuburbShip" class="form-control" type="text" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblStateShip" runat="server" Text="State"></asp:Label>

        <asp:TextBox ID="tbxStateShip" class="form-control" type="text" runat="server"></asp:TextBox>
        <hr />

        <h2>Select a shipping method</h2>

        <div class="form-group">
            <asp:RadioButtonList ID="rblShippingMethod" runat="server">
                <asp:ListItem Selected="True">&nbsp;&nbsp; Auspost &#36;5.99</asp:ListItem>
                <asp:ListItem>&nbsp;&nbsp; Auspost Express &#36;9.99</asp:ListItem>
                <asp:ListItem>&nbsp;&nbsp; StarTrack &#36;3.99</asp:ListItem>
                <asp:ListItem>&nbsp;&nbsp; StarTrack Express &#36;7.99</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <hr />

        <h2>Select a payment method</h2>
        <br />
        <div class="form-group">
            <asp:RadioButtonList ID="rblPaymentMethod" runat="server">
                <asp:ListItem Selected="True">&nbsp;&nbsp; Paypal</asp:ListItem>
                <asp:ListItem>&nbsp;&nbsp; Credit Card</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <br />

        <div class="form-group">
            <asp:Button ID="btnPlaceOrder" CssClass="btn btn-success" runat="server" Text="Confirm" OnClick="btnPlaceOrder_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="btnCancelOrder" CssClass="btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancelOrder_Click" />
        </div>
        

        <br />
        <br />
    </form>
</asp:Content>
