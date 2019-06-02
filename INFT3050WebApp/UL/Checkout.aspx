<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Customer.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="INFT3050WebApp.UL.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- Customer Checkout page --%>
    <h1>Checkout</h1>

    <%--Validation summary for checkout--%>
    <div>
        <asp:ValidationSummary ID="vsBilling" runat="server" CssClass="alert-danger" HeaderText="Please correct these issues" />

        <%-- Payment transaction information --%>
        <asp:Label ID="lblProcessing" runat="server" Text="" Visible="false"></asp:Label>
    </div>
    <br />
    <%--Area for customer to provide Shipping/Bills details--%>
    <h3>1. Enter your billing details</h3>

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


    <%--Area for customer to select a shipping method--%>
    <h3>2. Select a shipping method</h3>

    <div class="form-group">
        <%--Dropdown list of shipping options--%>
        <asp:Label ID="lblShippingMethod" runat="server" Text="Shipping Method:"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlShippingMethod" runat="server">
            <asp:ListItem>--Select--</asp:ListItem>
            <asp:ListItem Value="8">Auspost &#36;5.99</asp:ListItem>
            <asp:ListItem Value="9">Auspost Express &#36;9.99</asp:ListItem>
            <asp:ListItem Value="10">StarTrack &#36;3.99</asp:ListItem>
            <asp:ListItem Value="11">StarTrack Express &#36;7.99</asp:ListItem>
        </asp:DropDownList>

        <%--Check if user selected a shipping method--%>
        <asp:RequiredFieldValidator ID="rfvShippingMethod" runat="server" CssClass="text-danger" ControlToValidate="ddlShippingMethod" ErrorMessage="Please select a shipping method from the dropdown"
            InitialValue="--Select--"></asp:RequiredFieldValidator>
    </div>
    <hr />

    <%-- Area for customer to enter payment details --%>
    <h3>3. Enter Payment Details</h3>

    <%--Validation summary for Card payment--%>
    <div>
        <asp:ValidationSummary ID="vsCardPayment" runat="server" CssClass="alert-danger" HeaderText="Please correct these issues" />
    </div>
    <br />

    <div class="form-group">
        <%-- Card Name field --%>
        <asp:TextBox ID="tbxCardName" class="form-control" type="text" placeholder="Card Name" runat="server" Width="200"></asp:TextBox>

        <%-- Card Name is required --%>
        <asp:RequiredFieldValidator ID="rfvCardName" runat="server" CssClass="text-danger" ErrorMessage="Card name required"
            ControlToValidate="tbxCardName">Please enter the name on card</asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <%-- Card Number field --%>
        <asp:TextBox ID="tbxCardNumber" class="form-control" type="text" placeholder="Card Number" runat="server" Width="200"></asp:TextBox>

        <%-- Card Number is required --%>
        <asp:RequiredFieldValidator ID="rfvCardNumber" runat="server" CssClass="text-danger" ErrorMessage="Card number required"
            ControlToValidate="tbxCardNumber">Please enter your card number</asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <%-- Security Code field --%>
        <asp:TextBox ID="tbxSecurityCode" class="form-control" type="text" placeholder="CVV" runat="server" Width="60"></asp:TextBox>

        <%-- Security Code is required --%>
        <asp:RequiredFieldValidator ID="rfvSecurityCode" runat="server" CssClass="text-danger" ErrorMessage="Security Code required"
            ControlToValidate="tbxSecurityCode">Please enter the security code located on the back of your card</asp:RequiredFieldValidator>

        <%-- Check if CVV is 3 digits long --%>
        <asp:RegularExpressionValidator ID="revSecurityCode" runat="server" CssClass="text-danger" ErrorMessage="Valid security code required"
            ValidationExpression="^[0-9]{3}$"
            ControlToValidate="tbxSecurityCode">Please provide a valid security code</asp:RegularExpressionValidator>
    </div>

    <div class="form-group">
        <%-- Dropdown list for selecting card expiry month --%>
        <asp:Label ID="lblExpiry" runat="server" Text="Expiry Date:&nbsp;&nbsp;"></asp:Label>
        <asp:DropDownList ID="ddlMonth" runat="server">
            <asp:ListItem>--Month--</asp:ListItem>
            <asp:ListItem Value="01">01</asp:ListItem>
            <asp:ListItem Value="02">02</asp:ListItem>
            <asp:ListItem Value="03">03</asp:ListItem>
            <asp:ListItem Value="04">04</asp:ListItem>
            <asp:ListItem Value="05">05</asp:ListItem>
            <asp:ListItem Value="06">06</asp:ListItem>
            <asp:ListItem Value="07">07</asp:ListItem>
            <asp:ListItem Value="08">08</asp:ListItem>
            <asp:ListItem Value="09">09</asp:ListItem>
            <asp:ListItem Value="10">10</asp:ListItem>
            <asp:ListItem Value="11">11</asp:ListItem>
            <asp:ListItem Value="12">12</asp:ListItem>
        </asp:DropDownList>

        <%-- Dropdown list for selecting card expiry year --%>
        <asp:DropDownList ID="ddlYear" runat="server">
            <asp:ListItem>--Year--</asp:ListItem>
            <asp:ListItem Value="2019">2019</asp:ListItem>
            <asp:ListItem Value="2020">2020</asp:ListItem>
            <asp:ListItem Value="2021">2021</asp:ListItem>
            <asp:ListItem Value="2022">2022</asp:ListItem>
            <asp:ListItem Value="2023">2023</asp:ListItem>
            <asp:ListItem Value="2024">2024</asp:ListItem>
            <asp:ListItem Value="2025">2025</asp:ListItem>
            <asp:ListItem Value="2026">2026</asp:ListItem>
            <asp:ListItem Value="2027">2027</asp:ListItem>
            <asp:ListItem Value="2028">2028</asp:ListItem>
        </asp:DropDownList>
        <br />

        <%-- Expiry month is required --%>
        <asp:RequiredFieldValidator ID="rfvMonth" runat="server" CssClass="text-danger" ControlToValidate="ddlMonth" ErrorMessage="Expiry month is required"
            InitialValue="--Month--">Please select a month from the dropdown&nbsp;&nbsp;</asp:RequiredFieldValidator>
        <br />
        <%-- Expiry year is required --%>
        <asp:RequiredFieldValidator ID="rfvYear" runat="server" CssClass="text-danger" ControlToValidate="ddlYear" ErrorMessage="Expiry year is required"
            InitialValue="--Year--">Please select a year from the dropdown</asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <%-- Buttons to place or cancel order --%>
        <asp:Button ID="btnPlaceOrder" CssClass="btn btn-success" runat="server" Text="Confirm" OnClick="btnPlaceOrder_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="btnCancelOrder" CssClass="btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancelOrder_Click" CausesValidation="False" />
    </div>
    <br />
</asp:Content>
