<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminAddBookDetails.aspx.cs" Inherits="INFT3050WebApp.UL.Admin.AdminAddBookDetails" %>

<%@ MasterType VirtualPath="~/UL/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Add Book</h1>
    <h4>Book Details</h4>
    <br />
    <br />
    <%-- Validation summary --%>
    <div>
        <asp:ValidationSummary ID="vsAddBook" runat="server" CssClass="alert-danger" HeaderText="Please correct these issues" />
    </div>
    <div class="form-group">
        <%--Title field --%>
        <asp:Label ID="lblTitle" runat="server" Text="Title"></asp:Label>
        <asp:TextBox ID="tbxTitle" runat="server" type="title" CssClass="form-control"></asp:TextBox>

        <%-- Check if title is presented --%>
        <asp:RequiredFieldValidator ID="rfvTitle" runat="server" CssClass="text-danger" ErrorMessage="Please enter a Title"
            ControlToValidate="tbxTitle">Title Reuired</asp:RequiredFieldValidator>
        <br />
        <%--Title field --%>
        <asp:Label ID="lblSecondTitle" runat="server" Text="Secondary Title"></asp:Label>
        <asp:TextBox ID="tbxSecondaryTitle" runat="server" type="SecondaryTitle" CssClass="form-control"></asp:TextBox>

        <br />
        <%--Short Description field --%>
        <asp:Label ID="lblShortDescription" runat="server" Text="Short Description"></asp:Label>
        <asp:TextBox ID="tbxShortDescription" runat="server" type="Short Description" CssClass="form-control"></asp:TextBox>

        <%-- Check if Short is presented --%>
        <asp:RequiredFieldValidator ID="rfvtbxShortDescription" runat="server" CssClass="text-danger" ErrorMessage="Please enter a Short Description"
            ControlToValidate="tbxShortDescription">Short Description Reuired</asp:RequiredFieldValidator>


        <br />
        <%--Long Description field --%>
        <asp:Label ID="lblLongDescription" runat="server" Text="Long Description"></asp:Label>
        <asp:TextBox ID="tbxLongDescription" runat="server" type="Long Description" CssClass="form-control"></asp:TextBox>


        <br />
        <%--ISBN field --%>
        <asp:Label ID="lblISBN" runat="server" Text="ISBN"></asp:Label>
        <asp:TextBox ID="tbxISBN" runat="server" type="ISBN" CssClass="form-control"></asp:TextBox>

        <%-- Check if ISBN is presented --%>
        <asp:RequiredFieldValidator ID="rfvISBN" runat="server" CssClass="text-danger" ErrorMessage="Please enter a Title"
            ControlToValidate="tbxISBN">Title Reuired</asp:RequiredFieldValidator>

        <br />
        <%--Publisher field --%>
        <asp:Label ID="lblPublisher" runat="server" Text="Publisher"></asp:Label>
        <asp:TextBox ID="tbxPublisher" runat="server" type="Publisher" CssClass="form-control"></asp:TextBox>

        <%-- Check if Publisher is presented --%>
        <asp:RequiredFieldValidator ID="rfvPublisher" runat="server" CssClass="text-danger" ErrorMessage="Please enter a Publisher"
            ControlToValidate="tbxPublisher">Publisher Required</asp:RequiredFieldValidator>

        <br />
        <%--Publish Date field --%>
        <asp:Label ID="lblDatePublished" runat="server" Text="Date Published -Format - 00/00/0000"></asp:Label>
        <asp:TextBox ID="tbxDatePublished" runat="server" type="Publisher" CssClass="form-control"></asp:TextBox>

        <%-- Check if Publish Date is presented --%>
        <asp:RequiredFieldValidator ID="rfvDatePublished" runat="server" CssClass="text-danger" ErrorMessage="Please a Publisher"
            ControlToValidate="tbxDatePublished">Publisher Required</asp:RequiredFieldValidator>

        <%-- Check that Date Published is a date" --%>
        <%--https://stackoverflow.com/questions/15491894/regex-to-validate-date-format-dd-mm-yyyy direct copy of regular expression--%>
        <asp:RegularExpressionValidator ID="revDatePunlished" runat="server" CssClass="text-danger" ErrorMessage="Please enter a valid date"
            ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"
            ControlToValidate="tbxDatePublished">Please enter a valid Date</asp:RegularExpressionValidator>

        <br />
        <asp:Label ID="lblIsBestSeller" runat="server" Text="Best Seller"></asp:Label>
        <asp:DropDownList ID="ddlIsBestSeller"
            runat="server">
            <asp:ListItem Selected="True" Value="False"> False </asp:ListItem>
            <asp:ListItem Value="True"> True </asp:ListItem>
        </asp:DropDownList>
        <br />

        <br />
        <%--Image Path field --%>
        <asp:Label ID="lblImagePath" runat="server" Text="Image Path"></asp:Label>
        <asp:TextBox ID="tbxImagePath" runat="server" type="Image Path" CssClass="form-control"></asp:TextBox>


        <br />
        <%--Thumbnail field --%>
        <asp:Label ID="lblThumbnailPath" runat="server" Text="Thumbnail Path"></asp:Label>
        <asp:TextBox ID="tbxThumbnailPath" runat="server" type="Thumbnail Path" CssClass="form-control"></asp:TextBox>



        <br />
        <%--Price field --%>
        <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="tbxPrice" runat="server" type="Price" CssClass="form-control"></asp:TextBox>

        <%-- Check if Price is presented --%>
        <asp:RequiredFieldValidator ID="rfvprice" runat="server" CssClass="text-danger" ErrorMessage="Please enter a price"
            ControlToValidate="tbxPrice">Price is Required</asp:RequiredFieldValidator>

        <%-- Check that Price is valid" --%>
        <asp:RegularExpressionValidator ID="revPrice" runat="server" CssClass="text-danger" ErrorMessage="Please enter a valid date"
            ValidationExpression="^\d*\.?\d*$"
            ControlToValidate="tbxPrice">Please enter a valid Price</asp:RegularExpressionValidator>


        <br />
        <%--Price StockonHand --%>
        <asp:Label ID="lblStockonHand" runat="server" Text="Stock on Hand"></asp:Label>
        <asp:TextBox ID="tbxStockonHand" runat="server" type="Stock on Hand" CssClass="form-control"></asp:TextBox>

        <%-- Check if StockonHand is presented --%>
        <asp:RequiredFieldValidator ID="rfvStockonHand" runat="server" CssClass="text-danger" ErrorMessage="Please enter a Stock on Hand"
            ControlToValidate="tbxStockonHand">Stock on Hand is Required</asp:RequiredFieldValidator>

        <%-- Check that StockonHand is valid" --%>
        <asp:RegularExpressionValidator ID="revStockonHand" runat="server" CssClass="text-danger" ErrorMessage="Please enter a valid Stock on Hand Quantity"
            ValidationExpression="^\d+$"
            ControlToValidate="tbxStockonHand">Please enter a Stock on Hand Quantity</asp:RegularExpressionValidator>

    </div>

    <asp:Button ID="btnBookDetails" type="submit" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="btnBookDetails_Click" />

</asp:Content>
