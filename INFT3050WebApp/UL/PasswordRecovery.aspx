<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="PasswordRecovery.aspx.cs" Inherits="INFT3050WebApp.UL.PasswordRecovery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Password Recovery</h1>

    <div class="form-group">
        <%-- Email/username field --%>
        <asp:label id="lblEmail" runat="server" text="Email"></asp:label>
        <asp:textbox id="tbxEmail" runat="server" type="email" cssclass="form-control"></asp:textbox>

        <%-- Email/username field BL Validation --%>
        <asp:label id="lblUserExists" cssclass="text-danger" runat="server" text="" visible="False"></asp:label>

        <%-- Check if email is valid --%>
        <asp:requiredfieldvalidator id="rfvEmail" runat="server" cssclass="text-danger" errormessage="Please enter your email address"
            controltovalidate="tbxEmail">Email required</asp:requiredfieldvalidator>
        <asp:regularexpressionvalidator id="revEmail" runat="server" cssclass="text-danger" errormessage="Please provide a valid email address"
            validationexpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" controltovalidate="tbxEmail">Valid email required</asp:regularexpressionvalidator>
    </div>
    <div>
        <asp:Button ID="btnReset" type="cancel" CssClass="btn btn-primary" runat="server" Text="Reset Password" OnClick="btnReset_Click" />
    </div>
</asp:Content>
