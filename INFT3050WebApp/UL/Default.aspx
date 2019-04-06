<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="INFT3050WebApp.Default" %>
<%@ MasterType VirtualPath="~/UL/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <h1>Welcome to Used Book Store</h1>
    <%--<asp:Image ImageUrl="Images/LightLibrary.jpg" runat="server" class="rounded" />
    <br />--%>
    <br />
    <!-- Current Offers Section -->
    <h3>Current Offers</h3>
    <div class="container-flex">
        <!-- First Row -->
        <div class="row">
            <div class="col">
                <asp:Image ImageUrl="Images/9781442533547_thumb.jpg" runat="server" />
                <p>Children, Meaning-Making and the Arts</p>
            </div>
            <div class="col">
                <asp:Image ImageUrl="Images/9780887276859_thumb.jpg" runat="server"/>
                <p>Integrated Chinese Level 2 Part 1</p>
            </div>
            <div class="col">
                <asp:Image ImageUrl="Images/9780141439846_thumb.jpg" runat="server" />
                <p>Dracula</p>
            </div>
            <div class="col">
                <asp:Image ImageUrl="Images/9780140256352_thumb.jpg" runat="server" />
                <p>This Earth of Mankind</p>
            </div>
        </div>
        <!-- Second Row -->
        <div class="row">
            <div class="col">
                <asp:Image ImageUrl="Images/9780140390032_thumb.jpg" runat="server" />
                <p>Uncle Tom's Cabin</p>
            </div>
            <div class="col">
                <asp:Image ImageUrl="Images/9780140431957_thumb.jpg" runat="server" />
                <p>Leviathan</p>
            </div>
            <div class="col">
                <asp:Image ImageUrl="Images/9780141183954_thumb.jpg" runat="server" />
                <p>Voyage in the Dark</p>
            </div>
            <div class="col">
                <asp:Image ImageUrl="Images/9780141183534_thumb.jpg" runat="server" />
                <p>A Room of One's Own</p>
            </div>
        </div>
    </div>
    
</asp:Content>