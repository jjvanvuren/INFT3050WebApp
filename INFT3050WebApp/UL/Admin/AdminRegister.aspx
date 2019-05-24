<%@ Page Title="Employee Register" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminRegister.aspx.cs" Inherits="INFT3050WebApp.UL.BackEnd.BackEndRegister" %>

<%@ MasterType VirtualPath="~/UL/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Register New Account</h1>
    <br />
    <br />
    <div>
        <asp:ValidationSummary ID="vsRegister" runat="server" CssClass="alert-danger" HeaderText="Please correct these issues" />
    </div>

    <%-- First Name --%>
    <div class="form-group">
        <%-- First Name field --%>
        <asp:Label ID="lblFirstName" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="tbxFirstName" runat="server" type="text" CssClass="form-control"></asp:TextBox>

        <%-- First Name field Validation is Reuired--%>
        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="tbxFirstName" Text="Please enter your name" ErrorMessage="Name is a required field" CssClass="text-danger"></asp:RequiredFieldValidator>
        <%-- First Name field Validation is a valid Name--%>
        <asp:RegularExpressionValidator ID="revFirstName" runat="server" CssClass="text-danger" ErrorMessage="Please provide a valid First Name" ValidationExpression="^[a-zA-Z]+( [a-zA-Z]+)*$" ControlToValidate="tbxFirstName">Valid First name required</asp:RegularExpressionValidator>
    </div>

    <%-- Last Name --%>
    <div class="form-group">
        <%-- Last Name field --%>
        <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
        <asp:TextBox ID="tbxLastName" runat="server" type="text" CssClass="form-control"></asp:TextBox>
        <%-- Last Name field Validation is a valid Name--%>
        <asp:RegularExpressionValidator ID="revLastName" runat="server" CssClass="text-danger" ErrorMessage="Please provide a valid Last Name" ValidationExpression="^[a-zA-Z]+( [a-zA-Z]+)*$" ControlToValidate="tbxLastName">Valid Last name required</asp:RegularExpressionValidator>
    </div>



    <%-- Email --%>
    <div class="form-group">
        <%-- Email entry field --%>
        <asp:Label ID="lblEmail" runat="server" Text="Email address"></asp:Label>
        <asp:TextBox ID="tbxEmail" runat="server" type="email" CssClass="form-control"></asp:TextBox>

        <%-- Check if email already exists on DB --%>
        <asp:Label ID="lblEmailExists" CssClass="text-danger" runat="server" Text="" Visible="False"></asp:Label>

        <%-- Email entry field validation --%>
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" CssClass="text-danger" ErrorMessage="Please enter your email address"
            ControlToValidate="tbxEmail">Email required</asp:RequiredFieldValidator>
        <%-- Check that its an email address --%>
        <asp:RegularExpressionValidator ID="revEmail" runat="server" CssClass="text-danger" ErrorMessage="Please provide a valid email address"
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="tbxEmail">Valid email required</asp:RegularExpressionValidator>
        <%-- Check that email domain matches required domain "usedbooks.com.au" --%>
        <asp:RegularExpressionValidator ID="revEmailDomain" runat="server" CssClass="text-danger" ErrorMessage="Please use your employee email address"
            ValidationExpression="^[A-Za-z0-9._%+-]+@usedbooksales.com.au$" ControlToValidate="tbxEmail">Email is not an employee email address</asp:RegularExpressionValidator>
    </div>
    <%-- Email Confirmation--%>
    <div class="form-group">
        <%-- Email confirmation field --%>
        <asp:Label ID="lblEmailConfirm" runat="server" Text="Confirm email address"></asp:Label>
        <asp:TextBox ID="tbxEmailConfirm" runat="server" type="email" CssClass="form-control"></asp:TextBox>


        <%-- Email confirmation field validation --%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="Please reenter your email address"
            ControlToValidate="tbxEmailConfirm">Email required</asp:RequiredFieldValidator>
        <%-- Check that its an email address --%>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="text-danger" ErrorMessage="Please provide a valid email address"
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="tbxEmailConfirm">Valid email required</asp:RegularExpressionValidator>
        <%-- Check that its an email address that matches the first email entered --%>
        <asp:CompareValidator ID="emailCompareValidator" runat="server" CssClass="text-danger" ErrorMessage="Email addresses must match"
            Operator="Equal" ControlToCompare="tbxEmail" ControlToValidate="tbxEmailConfirm"></asp:CompareValidator>
    </div>
    <%-- Password --%>
    <div class="form-group">
        <%-- Password field --%>
        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
        <%--Includes ToolTip for password creation--%>
        <asp:TextBox ID="tbxPassword" runat="server" type="password" CssClass="form-control"
            ToolTip="Password must contain at least: 
                8 characters at least
                1 uppercase 
                1 lowercase
                1 number
                1 special character"></asp:TextBox>

        <%-- Password Validation --%>
        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" CssClass="text-danger" ErrorMessage="Please enter a password"
            ControlToValidate="tbxPassword">Password required</asp:RequiredFieldValidator>

        <%-- Check that password meets complexity requirements --%>
        <asp:RegularExpressionValidator ID="revPasswordComplex" runat="server" ControlToValidate="tbxPassword" CssClass="text-danger"
            ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@!%*?&_#^])[A-Za-z\d$@!%*?&_#^]{8,}"
            ErrorMessage="Password must meet complexity requirements">
                Password must contain at least 8 characters at least 1 uppercase, 1 lowercase, 1 number and 1 special character</asp:RegularExpressionValidator>

        <%-- Password field BL Validation --%>
        <asp:Label ID="lblInvalidPassword" CssClass="text-danger" runat="server" Text="" Visible="False"></asp:Label>

    </div>
    <%-- Password Confirmation--%>
    <div class="form-group">
        <%-- Password Confirmation field --%>
        <asp:Label ID="lblPasswordConfirm" runat="server" Text="Confirm password"></asp:Label>
        <asp:TextBox ID="tbxPasswordConfirm" runat="server" type="password" CssClass="form-control"></asp:TextBox>

        <%-- Password Confirmation Validation --%>
        <asp:RequiredFieldValidator ID="rfvPasswordConfirm" runat="server" CssClass="text-danger" ErrorMessage="Please reenter your password"
            ControlToValidate="tbxPasswordConfirm">Password required</asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cvPasswordConfirm" runat="server" CssClass="text-danger" ErrorMessage="Passwords must match"
            Operator="Equal" ControlToCompare="tbxPassword" ControlToValidate="tbxPasswordConfirm"></asp:CompareValidator>
    </div>

    <%-- Register and Cancel buttons--%>
    <asp:Button ID="btnRegister" type="submit" CssClass="btn btn-primary" runat="server" Text="Register" OnClick="btnRegister_Click" />
    <asp:Button ID="btnCancel" type="cancel" CssClass="btn btn-secondary" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />

</asp:Content>
