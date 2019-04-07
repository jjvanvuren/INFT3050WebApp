<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="BackEndLogin.aspx.cs" Inherits="INFT3050WebApp.UL.BackEnd.BackEndLogin" %>
<%@ MasterType VirtualPath="~/UL/Site.Master" %>
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
            <asp:RegularExpressionValidator ID="revEmail" runat="server" CssClass="text-danger" ErrorMessage="Please provide a valid email address"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="tbxEmail">Valid email required</asp:RegularExpressionValidator>

            <%-- Check if Employee exists --%>
            <asp:CustomValidator ID="cvEmailExists" runat="server" CssClass="text-danger" ErrorMessage="Email not registered"
                OnServerValidate="EmployeeRegistered"></asp:CustomValidator>
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
        <asp:Button ID="btnCancel" type="cancel" CssClass="btn btn-secondary" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />
    </form>
</asp:Content>