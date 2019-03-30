<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="INFT3050WebApp.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="text-center">Sign up</h1>
    <br />
    <br />
    <form runat="server">
        <div>
            <asp:ValidationSummary ID="vsRegister" runat="server" CssClass="alert-danger" HeaderText="Please correct these issues" />
        </div>
        <%-- Email --%>
        <div class="form-group">
            <%-- Email entry field --%>
            <asp:Label ID="lblEmail" runat="server" Text="Email address"></asp:Label>
            <asp:TextBox ID="tbxEmail" runat="server" type="email" CssClass="form-control"></asp:TextBox>

            <%-- Email entry field validation --%>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" CssClass="text-danger" ErrorMessage="Please enter your email address"
                ControlToValidate="tbxEmail">Email required</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" CssClass="text-danger" ErrorMessage="Please provide a valid email address"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="tbxEmail">Valid email required</asp:RegularExpressionValidator>
        </div>
        <%-- Email Confirmation--%>
        <div class="form-group">
            <%-- Email confirmation field --%>
            <asp:Label ID="lblEmailConfirm" runat="server" Text="Confirm email address"></asp:Label>
            <asp:TextBox ID="tbxEmailConfirm" runat="server" type="email" CssClass="form-control"></asp:TextBox>


            <%-- Email confirmation field validation --%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="Please reenter your email address"
                ControlToValidate="tbxEmailConfirm">Email required</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="text-danger" ErrorMessage="Please provide a valid email address"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="tbxEmailConfirm">Valid email required</asp:RegularExpressionValidator>
            <asp:CompareValidator ID="emailCompareValidator" runat="server" CssClass="text-danger" ErrorMessage="Email addresses must match"
                Operator="Equal" ControlToCompare="tbxEmail" ControlToValidate="tbxEmailConfirm"></asp:CompareValidator>
        </div>
        <%-- Password --%>
        <div class="form-group">
            <%-- Password field --%>
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="tbxPassword" runat="server" type="password" CssClass="form-control"></asp:TextBox>

            <%-- Password Validation --%>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" CssClass="text-danger" ErrorMessage="Please enter a password"
                ControlToValidate="tbxPassword">Password required</asp:RequiredFieldValidator>
        </div>
        <%-- Password Confirmation--%>
        <div class="form-group">
            <%-- Password Confirmation field --%>
            <asp:Label ID="lblPasswordConfirm" runat="server" Text="Confirm password"></asp:Label>
            <asp:TextBox ID="tbxPasswordConfirm" runat="server" type="password" CssClass="form-control"></asp:TextBox>

            <%-- Password Confirmation Validation --%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ErrorMessage="Please reenter your password"
                ControlToValidate="tbxPasswordConfirm">Password required</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="text-danger" ErrorMessage="Passwords must match"
                Operator="Equal" ControlToCompare="tbxPassword" ControlToValidate="tbxPasswordConfirm"></asp:CompareValidator>
        </div>
        <%-- Register and Cancel buttons--%>
        <asp:Button ID="btnRegister" type="submit" CssClass="btn btn-primary" runat="server" Text="Register" OnClick="btnRegister_Click" />
        <asp:Button ID="btnCancel" type="cancel" CssClass="btn btn-secondary" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />
    </form>
</asp:Content>
