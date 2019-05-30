<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="INFT3050WebApp.Login" %>

<%@ MasterType VirtualPath="~/UL/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- Customer login page --%>
    <h1>Customer Login</h1>
    <br />
    <br />
    <%-- Validation summary --%>
    <div>
        <asp:ValidationSummary ID="vsLogin" runat="server" CssClass="alert-danger" HeaderText="Please correct these issues" />
    </div>
    <div class="form-group">

        <%-- Email/username field --%>
        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="tbxEmail" runat="server" type="email" CssClass="form-control"></asp:TextBox>

        <%-- Email/username field BL Validation --%>
        <asp:Label ID="lblUserExists" CssClass="text-danger" runat="server" Text="" Visible="False"></asp:Label>

        <%-- Check if email is valid --%>
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" CssClass="text-danger" ErrorMessage="Please enter your email address"
            ControlToValidate="tbxEmail">Email required</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revEmail" runat="server" CssClass="text-danger" ErrorMessage="Please provide a valid email address"
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="tbxEmail">Valid email required</asp:RegularExpressionValidator>
    </div>

    <div class="form-group">

        <%-- Password field --%>
        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="tbxPassword" runat="server" type="password" CssClass="form-control"></asp:TextBox>

        <%-- Password field BL Validation --%>
        <asp:Label ID="lblInvalidPassword" CssClass="text-danger" runat="server" Text="" Visible="False"></asp:Label>

        <%-- Password is required --%>
        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" CssClass="text-danger" ErrorMessage="Please enter your password"
            ControlToValidate="tbxPassword">Password required</asp:RequiredFieldValidator>
    </div>

    <%-- Buttons to login or cancel --%>
    <asp:Button ID="btnLogin" type="submit" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="btnLogin_Click" />
    <asp:Button ID="btnReset" type="submit" CssClass="btn btn-primary" runat="server" Text="Forgot Password" CausesValidation="false" OnClick="btnReset_Click" />
    <asp:Button ID="btnCancel" type="cancel" CssClass="btn btn-secondary" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />
    
</asp:Content>
