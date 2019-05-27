<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="DefaultError.aspx.cs" Inherits="INFT3050WebApp.UL.DefaultError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alert alert-danger">
        <h1 class="alert-heading">Application Error</h1>
        <asp:Label runat="server" ID="lblErrorText"></asp:Label>
        <br />

        <asp:Panel ID="panErrorDetails" runat="server" Visible="false">

            <h4>Error Handler:</h4>
            <p>
                <asp:Label ID="lblErrorHandler" runat="server" /><br />
            </p>
            <br />
            <h4 class="alert-heading">Detailed Error</h4>
            <p>
                <asp:Label ID="lblErrorDetails" runat="server" />
            </p>
            <h4>Detailed Error Message</h4>
            <p>
                <asp:Label ID="lblInnerMessage" runat="server" /><br />
            </p>
            <p>
                <asp:Label ID="lblInnerTrace" runat="server" />
            </p>

        </asp:Panel>


    </div>

</asp:Content>
