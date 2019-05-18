<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Customer.Master" AutoEventWireup="true" CodeBehind="CardPayment.aspx.cs" Inherits="INFT3050WebApp.UL.CardPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Pay with Credit Card</h1>
    <%--Validation summary for Card payment--%>
    <div>
        <asp:ValidationSummary ID="vsCardPayment" runat="server" CssClass="alert-danger" HeaderText="Please correct these issues" />
    </div>
    <br />

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
            <asp:ListItem>01</asp:ListItem>
            <asp:ListItem>02</asp:ListItem>
            <asp:ListItem>03</asp:ListItem>
            <asp:ListItem>04</asp:ListItem>
            <asp:ListItem>05</asp:ListItem>
            <asp:ListItem>06</asp:ListItem>
            <asp:ListItem>07</asp:ListItem>
            <asp:ListItem>08</asp:ListItem>
            <asp:ListItem>09</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
        </asp:DropDownList>

        <%-- Dropdown list for selecting card expiry year --%>
        <asp:DropDownList ID="ddlYear" runat="server">
            <asp:ListItem>--Year--</asp:ListItem>
            <asp:ListItem>2019</asp:ListItem>
            <asp:ListItem>2020</asp:ListItem>
            <asp:ListItem>2021</asp:ListItem>
            <asp:ListItem>2022</asp:ListItem>
            <asp:ListItem>2023</asp:ListItem>
            <asp:ListItem>2024</asp:ListItem>
            <asp:ListItem>2025</asp:ListItem>
            <asp:ListItem>2026</asp:ListItem>
            <asp:ListItem>2027</asp:ListItem>
            <asp:ListItem>2028</asp:ListItem>
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
        <%-- Buttons to pay or cancel --%>
        <asp:Button ID="btnPay" CssClass="btn btn-success" runat="server" Text="Pay" OnClick="btnPay_Click" />
        &nbsp;&nbsp;
            <asp:Button ID="btnCancel" type="cancel" CssClass="btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False" />
    </div>
</asp:Content>
