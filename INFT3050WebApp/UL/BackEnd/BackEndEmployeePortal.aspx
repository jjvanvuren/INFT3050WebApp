<%@ Page Title="" Language="C#" MasterPageFile="~/UL/BackEnd/BackEnd.Master" AutoEventWireup="true" CodeBehind="BackEndEmployeePortal.aspx.cs" Inherits="INFT3050WebApp.UL.BackEnd.BackEndEmployeePortal" %>

<%@ MasterType VirtualPath="~/UL/BackEnd/BackEnd.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1 class="text-center">Welcome Joe!</h1>
    <%-- <asp:GridView ID="GridView1" runat="server"
        AutoGenerateColumns="False"
        DataSourceID="~/BL/StoreItem.cs"
        DataKeyNames="CategoryID">
        <Columns>
            <asp:BoundField DataField="Id"
                HeaderText="ID" ReadOnly="True"
                SortExpression="CategoryID">
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="ShortName"
                HeaderText="Short Name"
                SortExpression="ShortName">
                <ItemStyle Width="150px" />
            </asp:BoundField>
            <asp:BoundField DataField="LongName"
                HeaderText="Long Name"
                SortExpression="LongName">
                <ItemStyle Width="200px" />
            </asp:BoundField>
 <asp:CommandField ButtonType="Button"
     ShowEditButton="True"
     CausesValidation="False" />
            <asp:CommandField ButtonType="Button"
                ShowDeleteButton="True"
                CausesValidation="False" />
        </Columns>

        <%--Id { get; set; }
        public float Price { get; set; }
        public int StockQuantity { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImagePath { get; set; }
        public string ThumbnailPath { get; set; }
    </asp:GridView> --%>
</asp:Content>

