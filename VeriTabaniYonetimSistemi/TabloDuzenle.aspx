<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="TabloDuzenle.aspx.cs" Inherits="VeriTabaniYonetimSistemi.TabloDuzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Tablo Düzenle</h3>
     <hr />
     <asp:DropDownList ID="ddlTables"  DataTextField="table_name" DataValueField="table_name"  runat="server" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged" AutoPostBack="true">
    </asp:DropDownList>
    <br />
    <asp:GridView ID="gvEdit" runat="server" AutoGenerateColumns="true" DataKeyNames="COLUMN_NAME" OnRowEditing="gvEdit_RowEditing" OnRowUpdating="gvEdit_RowUpdating" OnPageIndexChanging="gvEdit_PageIndexChanging" OnRowCancelingEdit="gvEdit_RowCancelingEdit" OnRowDeleting="gvEdit_RowDeleting" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" >
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
        <Columns>
            <asp:CommandField ShowEditButton="true" />
            <asp:CommandField ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
    <div>
        <asp:Label ID="lblresult" runat="server"></asp:Label>
    </div>
</asp:Content>
