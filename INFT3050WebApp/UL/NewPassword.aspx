<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="NewPassword.aspx.cs" Inherits="INFT3050WebApp.UL.NewPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Password Reset</h1>
    <p>Please enter your new password below:</p>
    
    <%-- Key Validation Error Message --%>
    <asp:Label ID="lblError" cssclass="text-danger" runat="server" Text="" Visible="False"></asp:Label>

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
    <%-- Reset Password and Cancel buttons--%>
    <asp:Button ID="btnReset" type="submit" CssClass="btn btn-primary" runat="server" Text="Reset Password" OnClick="btnReset_Click" />
    <asp:Button ID="btnCancel" type="cancel" CssClass="btn btn-secondary" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />
</asp:Content>
