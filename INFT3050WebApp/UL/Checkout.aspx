<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Customer.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="INFT3050WebApp.UL.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- Customer Checkout page --%>
    <h1>Checkout</h1>

    <%--Validation summary for checkout--%>
    <div>
        <asp:ValidationSummary ID="vsBilling" runat="server" CssClass="alert-danger" HeaderText="Please correct these issues" />
    </div>
    <br />

    <h3>1. Select delivery or pick up</h3>

    <div class="form-group">

        <%--Radio button list for selecting pick up or delivery--%>
        <asp:RadioButtonList ID="rblPostage" runat="server">
            <asp:ListItem Selected="True">&nbsp;&nbsp; Pick up in store</asp:ListItem>
            <asp:ListItem>&nbsp;&nbsp; I would like to have my order delivered</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <hr>

    <%--Area for customer to provide billing details--%>
    <h3>2. Enter your billing details</h3>

    <div class="form-group">
        <%--Street Number field--%>
        <asp:Label ID="lblStreetNumber" runat="server" Text="Street Number"></asp:Label>
        <asp:TextBox ID="tbxStreetNumber" class="form-control" type="text" runat="server"></asp:TextBox>

        <%--Street Number is required--%>
        <asp:RequiredFieldValidator ID="rfvStreetNumber" runat="server" CssClass="text-danger" ErrorMessage="Please enter your Street Number"
            ControlToValidate="tbxStreetNumber">Street Number required</asp:RequiredFieldValidator>

        <%--Checks for invalid symbols in Street Number--%>
        <asp:RegularExpressionValidator ID="revStreetNumber" runat="server" CssClass="text-danger" ErrorMessage="Please provide a valid Street Number"
            ValidationExpression="^[A-Za-z0-9'\.\-\s\,]+$"
            ControlToValidate="tbxStreetNumber">Illegal characters included in field</asp:RegularExpressionValidator>
    </div>

    <div class="form-group">
        <%--Street Name field--%>
        <asp:Label ID="lblStreetName" runat="server" Text="Street Name"></asp:Label>
        <asp:TextBox ID="tbxStreetName" class="form-control" type="text" runat="server"></asp:TextBox>

        <%--Street Name is required--%>
        <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" CssClass="text-danger" ErrorMessage="Please enter your address"
            ControlToValidate="tbxStreetName">Street Name required</asp:RequiredFieldValidator>

        <%--Checks for invalid symbols in Street Name--%>
        <asp:RegularExpressionValidator ID="revAddress1" runat="server" CssClass="text-danger" ErrorMessage="Please provide a valid StreetName"
            ValidationExpression="^[A-Za-z0-9'\.\-\s\,]+$"
            ControlToValidate="tbxStreetName">Illegal characters included in field</asp:RegularExpressionValidator>
    </div>


    <div class="form-group">
        <%--City/Suburb field--%>
        <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
        <asp:TextBox ID="tbxCity" class="form-control" type="text" runat="server"></asp:TextBox>

        <%--City/Suburb is required--%>
        <asp:RequiredFieldValidator ID="rfvCity" runat="server" CssClass="text-danger" ErrorMessage="Please enter your city"
            ControlToValidate="tbxCity">City is required</asp:RequiredFieldValidator>

        <%--Checks that City/Suburb only contains either upper/lower case letters, spaces or "-"--%>
        <asp:RegularExpressionValidator ID="revCity" runat="server" CssClass="text-danger" ErrorMessage="Please provide a valid city or suburb"
            ValidationExpression="^[A-Za-z\-\s]+$"
            ControlToValidate="tbxCity">Valid city or suburb required</asp:RegularExpressionValidator>
    </div>

    <div class="form-group">
        <%--Post Code field--%>
        <asp:Label ID="lblPostCode" runat="server" Text="Post Code"></asp:Label>
        <asp:TextBox ID="tbxPostCode" class="form-control" type="text" runat="server"></asp:TextBox>

        <%--Post Code is required--%>
        <asp:RequiredFieldValidator ID="rfvPostCode" runat="server" CssClass="text-danger" ErrorMessage="Please enter your post code"
            ControlToValidate="tbxPostCode">Post code required</asp:RequiredFieldValidator>

        <%--Checks for a valid Australian post code--%>
        <asp:RegularExpressionValidator ID="revPostCode" runat="server" CssClass="text-danger" ErrorMessage="Please provide a valid Australian post code"
            ValidationExpression="/^(0[289][0-9]{2})|([1345689][0-9]{3})|(2[0-8][0-9]{2})|(290[0-9])|(291[0-4])|(7[0-4][0-9]{2})|(7[8-9][0-9]{2})$/"
            ControlToValidate="tbxPostCode">Valid post code required</asp:RegularExpressionValidator>
    </div>

    <div class="form-group">
        <%--Dropdown to select a state--%>
        <asp:Label ID="lblState" runat="server" Text="Select State:"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlState" runat="server">
            <asp:ListItem>--Select--</asp:ListItem>
            <asp:ListItem>NSW</asp:ListItem>
            <asp:ListItem>VIC</asp:ListItem>
            <asp:ListItem>QLD</asp:ListItem>
            <asp:ListItem>WA</asp:ListItem>
            <asp:ListItem>SA</asp:ListItem>
            <asp:ListItem>TAS</asp:ListItem>
            <asp:ListItem>NT</asp:ListItem>
            <asp:ListItem>ACT</asp:ListItem>
        </asp:DropDownList>

        <%--Check if user selected a state--%>
        <asp:RequiredFieldValidator ID="rfvState" runat="server" CssClass="text-danger" ControlToValidate="ddlState" ErrorMessage="Please select a state from the dropdown"
            InitialValue="--Select--"></asp:RequiredFieldValidator>
    </div>
    <hr>

    <%--Area for customer to provide shipping details--%>
    <h3>3. Enter your shipping details</h3>

    <p class="text-danger font-weight-bold">If you do not enter shipping details below, the order will be shipped to the billing address.</p>

    <div class="form-group">
        <%--Shipping Street Number field--%>
        <asp:Label ID="lblStreetNumberShip" runat="server" Text="Street Number"></asp:Label>
        <asp:TextBox ID="tbxStreetNumberShip" class="form-control" type="text" runat="server"></asp:TextBox>

        <%--Checks for invalid symbols in Address Line 1--%>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="text-danger" ErrorMessage="Please provide a valid Street Number"
            ValidationExpression="^[A-Za-z0-9'\.\-\s\,]+$"
            ControlToValidate="tbxStreetNumberShip">Illegal characters included in field</asp:RegularExpressionValidator>
    </div>

    <div class="form-group">
        <%--Shipping Street Name field--%>
        <asp:Label ID="lblStreetNameShip" runat="server" Text="Street Name"></asp:Label>
        <asp:TextBox ID="tbxStreetNameShip" class="form-control" type="text" runat="server"></asp:TextBox>

        <%--Checks for invalid symbols in Name field--%>
        <asp:RegularExpressionValidator ID="revStreetNameShip" runat="server" CssClass="text-danger" ErrorMessage="Please provide a valid shipping Street Name"
            ValidationExpression="^[A-Za-z0-9'\.\-\s\,]+$"
            ControlToValidate="tbxStreetNameShip">Illegal characters included in field</asp:RegularExpressionValidator>
    </div>

    <div class="form-group">
        <%--Shipping City/Suburb field--%>
        <asp:Label ID="lblCityShip" runat="server" Text="City"></asp:Label>
        <asp:TextBox ID="tbxCityShip" class="form-control" type="text" runat="server"></asp:TextBox>

        <%--Checks that City/Suburb only contains either upper/lower case letters, spaces or "-"--%>
        <asp:RegularExpressionValidator ID="revCityShip" runat="server" CssClass="text-danger" ErrorMessage="Please provide a valid city or suburb"
            ValidationExpression="^[A-Za-z\-\s]+$"
            ControlToValidate="tbxCityShip">Valid city or suburb required</asp:RegularExpressionValidator>
    </div>

    <div class="form-group">
        <%--Shipping Post Code field--%>
        <asp:Label ID="lblPostCodeShip" runat="server" Text="Post Code"></asp:Label>
        <asp:TextBox ID="tbxPostCodeShip" class="form-control" type="text" runat="server"></asp:TextBox>

        <%--Checks for a valid Australian post code--%>
        <asp:RegularExpressionValidator ID="revPostCodeShip" runat="server" CssClass="text-danger" ErrorMessage="Please provide a valid Australian post code"
            ValidationExpression="/^(0[289][0-9]{2})|([1345689][0-9]{3})|(2[0-8][0-9]{2})|(290[0-9])|(291[0-4])|(7[0-4][0-9]{2})|(7[8-9][0-9]{2})$/"
            ControlToValidate="tbxPostCodeShip">Valid post code required</asp:RegularExpressionValidator>
    </div>

    <div class="form-group">
        <%--Dropdown to select a shipping state--%>
        <asp:Label ID="lblStateShip" runat="server" Text="Select State:"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlStateShip" runat="server">
            <asp:ListItem>--Select--</asp:ListItem>
            <asp:ListItem>NSW</asp:ListItem>
            <asp:ListItem>VIC</asp:ListItem>
            <asp:ListItem>QLD</asp:ListItem>
            <asp:ListItem>WA</asp:ListItem>
            <asp:ListItem>SA</asp:ListItem>
            <asp:ListItem>TAS</asp:ListItem>
            <asp:ListItem>NT</asp:ListItem>
            <asp:ListItem>ACT</asp:ListItem>
        </asp:DropDownList>
    </div>
    <hr />

    <%--Area for customer to select a shipping method--%>
    <h3>4. Select a shipping method</h3>

    <div class="form-group">
        <%--Dropdown list of shipping options--%>
        <asp:Label ID="lblShippingMethod" runat="server" Text="Shipping Method:"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlShippingMethod" runat="server">
            <asp:ListItem>--Select--</asp:ListItem>
            <asp:ListItem Value ="8">Auspost &#36;5.99</asp:ListItem>
            <asp:ListItem Value ="9">Auspost Express &#36;9.99</asp:ListItem>
            <asp:ListItem Value ="10">StarTrack &#36;3.99</asp:ListItem>
            <asp:ListItem Value ="11">StarTrack Express &#36;7.99</asp:ListItem>
        </asp:DropDownList>

        <%--Check if user selected a shipping method--%>
        <asp:RequiredFieldValidator ID="rfvShippingMethod" runat="server" CssClass="text-danger" ControlToValidate="ddlShippingMethod" ErrorMessage="Please select a shipping method from the dropdown"
            InitialValue="--Select--"></asp:RequiredFieldValidator>
    </div>
    <hr />

    <%-- Area for customer to select a payment method --%>
    <h3>5. Proceed to payment</h3>

    <div class="form-group">
        <%-- Buttons to place or cancel order --%>
        <asp:Button ID="btnPlaceOrder" CssClass="btn btn-success" runat="server" Text="Confirm" OnClick="btnPlaceOrder_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="btnCancelOrder" CssClass="btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancelOrder_Click" CausesValidation="False" />
    </div>
    <br />
</asp:Content>
