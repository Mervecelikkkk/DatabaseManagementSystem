<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="VeriGirisi.aspx.cs" Inherits="VeriTabaniYonetimSistemi.VeriGirisi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 >Veri Girişi</h3>
     <hr />

 
            <asp:DropDownList ID="ddlTables" DataTextField="table_name"  AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged"></asp:DropDownList>
            
            <div>
        <asp:gridview ID="gvDataInput"  AutoGenerateColumns="true"  runat="server" ShowFooter="True" Width="296px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
          
    
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
     <%--       <Columns>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:TextBox ID="txtVeri" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>--%>

        </asp:GridView>

      

                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

      

                <asp:Literal ID="lt1" runat="server"></asp:Literal>
                 
                <asp:Button ID="Button1" runat="server"  Text="Button" OnClick="Button1_Click" />
                 
    </div>
</asp:Content>
