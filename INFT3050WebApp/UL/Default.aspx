<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="INFT3050WebApp.Default" %>
<%@ MasterType VirtualPath="~/UL/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <h1>Welcome to Used Book Store</h1>
    <br />
    <%--Current Offers Section--%>
    <h3>Best Sellers</h3>
    <form runat="server">
        <%--Splash Page which displays all the best selling books--%>
        <div class="container-flex">
            <div class="row">
                <asp:Repeater ID="ImageRepeater" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-4 col-md-3 col-lg-3 col-xl-3">
                            <div class="img-thumbnail border-0">
                                <asp:ImageButton ID="imgBestSeller" CssClass="mx-auto d-block" runat="server" ImageUrl='<%# Eval("ThumbnailPath") %>' OnCommand="imgBestSeller_Command" CommandArgument='<%# Eval("Id") %>' />
                                <div class="figure-caption text-center">
                                    <p><%# Eval("Title")%></p>
                                </div>
                            </div>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</asp:Content>