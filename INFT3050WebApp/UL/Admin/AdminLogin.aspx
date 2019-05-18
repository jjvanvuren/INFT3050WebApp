<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="INFT3050WebApp.UL.BackEnd.BackEndLogin" %>

<%@ MasterType VirtualPath="~/UL/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Employee Login</h1>
    <br />
    <br />
    <%-- Validation summary --%>
    <div>
        <asp:validationsummary id="vsLogin" runat="server" cssclass="alert-danger" headertext="Please correct these issues" />
    </div>
    <div class="form-group">
        <%-- Email/username field --%>
        <asp:label id="lblEmail" runat="server" text="Email"></asp:label>
        <asp:textbox id="tbxEmail" runat="server" type="email" cssclass="form-control"></asp:textbox>

        <%-- Check if email is valid --%>
        <asp:requiredfieldvalidator id="rfvEmail" runat="server" cssclass="text-danger" errormessage="Please enter your email address"
            controltovalidate="tbxEmail">Email required</asp:requiredfieldvalidator>
        <%-- Check that its an email address --%>
        <asp:regularexpressionvalidator id="revEmail" runat="server" cssclass="text-danger" errormessage="Please provide a valid email address"
            validationexpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" controltovalidate="tbxEmail">Valid email required</asp:regularexpressionvalidator>
        <%-- Check that email domain matches required domain "usedbooks.com.au" --%>
        <asp:regularexpressionvalidator id="revEmailDomain" runat="server" cssclass="text-danger" errormessage="Please use your employee email address"
            validationexpression="^[A-Za-z0-9._%+-]+@usedbooksales.com.au$" controltovalidate="tbxEmail">Email is not an employee email address</asp:regularexpressionvalidator>

    </div>
    <div class="form-group">
        <%-- Password field --%>
        <asp:label id="lblPassword" runat="server" text="Password"></asp:label>
        <asp:textbox id="tbxPassword" runat="server" type="password" cssclass="form-control"></asp:textbox>

        <%-- Password is required --%>
        <asp:requiredfieldvalidator id="rfvPassword" runat="server" cssclass="text-danger" errormessage="Please enter your password"
            controltovalidate="tbxPassword">Password required</asp:requiredfieldvalidator>

        <%-- Check if password is correct --%>
        <asp:customvalidator id="cvPasswordCorrect" runat="server" cssclass="text-danger" errormessage="Password incorrect"
            onservervalidate="passwordCorrect"></asp:customvalidator>
    </div>
    <asp:button id="btnLogin" type="submit" cssclass="btn btn-primary" runat="server" text="Submit" onclick="btnLogin_Click" />
    <asp:button id="btnRegister" type="cancel" cssclass="btn btn-secondary" runat="server" text="Register" causesvalidation="false" onclick="btnRegister_Click" />

</asp:Content>