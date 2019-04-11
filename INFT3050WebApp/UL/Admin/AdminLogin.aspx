




<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="INFT3050WebApp.UL.BackEnd.BackEndLogin" %>
<%@ MasterType VirtualPath="~/UL/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1 class="text-center">Employee Login</h1>
    <br />
    <br />
    <form runat="server">
        <%-- Validation summary --%>
            <div>
                <asp:ValidationSummary ID="vsLogin" runat="server" CssClass="alert-danger" HeaderText="Please correct these issues"/>
            </div>
        <div class="form-group">
            <%-- Email/username field --%>
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="tbxEmail" runat="server" type="email" CssClass="form-control"></asp:TextBox>

            <%-- Check if email is valid --%>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" CssClass="text-danger" ErrorMessage="Please enter your email address"
                ControlToValidate="tbxEmail">Email required</asp:RequiredFieldValidator>
            <%-- Check that its an email address --%>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" CssClass="text-danger" ErrorMessage="Please provide a valid email address"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="tbxEmail">Valid email required</asp:RegularExpressionValidator>
            <%-- Check that email domain matches required domain "usedbooks.com.au" --%>
            <asp:RegularExpressionValidator ID="revEmailDomain" runat="server" CssClass="text-danger" ErrorMessage="Please use your employee email address"
                ValidationExpression="^[A-Za-z0-9._%+-]+@usedbooksales.com.au$" ControlToValidate="tbxEmail">Email is not an employee email address</asp:RegularExpressionValidator>

        </div>
        <div class="form-group">
            <%-- Password field --%>
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="tbxPassword" runat="server" type="password" CssClass="form-control"></asp:TextBox>

            <%-- Password is required --%>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" CssClass="text-danger" ErrorMessage="Please enter your password"
                ControlToValidate="tbxPassword">Password required</asp:RequiredFieldValidator>

            <%-- Check if password is correct --%>
            <asp:CustomValidator ID="cvPasswordCorrect" runat="server" CssClass="text-danger" ErrorMessage="Password incorrect"
                OnServerValidate="passwordCorrect"></asp:CustomValidator>
        </div>
        <asp:Button ID="btnLogin" type="submit" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="btnLogin_Click" />
        <asp:Button ID="btnRegister" type="cancel" CssClass="btn btn-secondary" runat="server" Text="Register" CausesValidation="false" OnClick="btnRegister_Click" />
    </form>
</asp:Content>