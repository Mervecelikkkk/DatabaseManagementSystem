<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="VeriListeleme.aspx.cs" Inherits="VeriTabaniYonetimSistemi.VeriListeleme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Veri Listeleme</h3>
    <hr />
    <asp:DropDownList ID="ddlTables"  DataTextField="table_name"  runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
 <div>
    <asp:GridView ID="gvList"  runat="server">
    </asp:GridView>
    </div>
</asp:Content>
