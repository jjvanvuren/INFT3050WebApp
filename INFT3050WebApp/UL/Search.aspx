<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="INFT3050WebApp.Search" %>
<%@ MasterType VirtualPath="~/UL/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container-flex">

        <!-- Search form -->
        <div class="md-form mt-0">
            <form runat="server">
                <asp:TextBox ID="tbxSearch" class="form-control" type="text" placeholder="Search" aria-label="Search" runat="server" MaxLength="250"></asp:TextBox>
            </form>
        </div>

        <div>
            <br />
            <h1>Results</h1>
            <br />

            <!-- This table is only to show desired layout 
             Will be replaced in assignment 2-->
            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Title</th>
                        <th scope="col">Series</th>
                        <th scope="col">Author(s)</th>
                        <th scope="col">Published</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th scope="row">1</th>
                        <td>Title 1</td>
                        <td>Series 1</td>
                        <td>Author 1</td>
                        <td>Date 1</td>
                    </tr>
                    <tr>
                        <th scope="row">2</th>
                        <td>Title 2</td>
                        <td>Series 2</td>
                        <td>Author 2</td>
                        <td>Date 2</td>
                    </tr>
                    <tr>
                        <th scope="row">3</th>
                        <td>Title 3</td>
                        <td>Series 3</td>
                        <td>Author 3</td>
                        <td>Date 3</td>
                    </tr>
                    <tr>
                        <th scope="row">4</th>
                        <td>Title 4</td>
                        <td>Series 4</td>
                        <td>Author 4</td>
                        <td>Date 4</td>
                    </tr>
                </tbody>
            </table>
        </div>

    </div>
</asp:Content>
