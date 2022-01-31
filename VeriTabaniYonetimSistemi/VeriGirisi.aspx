<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="VeriGirisi.aspx.cs" Inherits="VeriTabaniYonetimSistemi.VeriGirisi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 >Veri Girişi</h3>
     <hr />

 
            <asp:DropDownList ID="ddlTables" DataTextField="table_name"  AutoPostBack="true" runat="server"></asp:DropDownList>
            
            <div>
        <asp:gridview ID="gvDataInput" runat="server" ShowFooter="True" AutoGenerateColumns="False" Width="296px">
       
        </asp:gridview>
                 
    </div>
</asp:Content>
