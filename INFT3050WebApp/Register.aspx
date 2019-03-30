<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="INFT3050WebApp.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <form runat="server">
        <div>
            <asp:ValidationSummary ID="vsRegister" runat="server" CssClass="alert-danger" HeaderText="Please correct these issues" />
        </div>

        <div class="form-group">
            <%-- Email/username field --%>
            <asp:Label ID="lblEmail" runat="server" Text="Email address"></asp:Label>
            <asp:TextBox ID="tbxEmail" runat="server" type="email" CssClass="form-control"></asp:TextBox>

            <asp:Label ID="lblEmailConfirm" runat="server" Text="Confirm email address"></asp:Label>
            <asp:TextBox ID="tbxEmailConfirm" runat="server" type="email" CssClass="form-control"></asp:TextBox>

            <%-- Check if email is valid --%>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" CssClass="text-danger" ErrorMessage="Please enter your email address"
                ControlToValidate="tbxEmail">Email required</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" CssClass="text-danger" ErrorMessage="Please provide a valid email address"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="tbxEmail">Valid email required</asp:RegularExpressionValidator>
        </div>
    </form>
</asp:Content>
