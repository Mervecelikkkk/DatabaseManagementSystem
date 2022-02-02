<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="TabloOlustur.aspx.cs" Inherits="VeriTabaniYonetimSistemi.TabloOlustur" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
   

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
 
            <h3>Tablo Oluştur</h3>
          <hr />
          <asp:Label ID="lblTblAd" runat="server" Font-Bold="true" Text="Tablo Adı"></asp:Label>
          <asp:TextBox ID="txtTblAd" runat="server"></asp:TextBox>

          <br />

              <div>
        <asp:gridview ID="gvCreateTable" runat="server" ShowFooter="true" AutoGenerateColumns="false">
            <Columns>
            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />
            <asp:TemplateField HeaderText="Kolon Adı">
                <ItemTemplate>
                    <asp:TextBox ID="txtKolonAdi" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Veri Tipi">
                <ItemTemplate>
                    <asp:ListBox ID="lstVeriTipi" Rows="1" runat="server">
                           <asp:ListItem >Veri Tipi Seçiniz</asp:ListItem>
                           <asp:ListItem Value="Varchar(max)">Metin</asp:ListItem>
                           <asp:ListItem Value="int">Tam Sayı</asp:ListItem>
                           <asp:ListItem Value="Decimal(18,3)">Ondalık Sayı</asp:ListItem>
                           <asp:ListItem Value="Date">Tarih</asp:ListItem>
                           <asp:ListItem Value="Datetime">Tarih ve Saat</asp:ListItem>
                    </asp:ListBox>
                 
          
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Boş Değer Girilebilsin">
                <ItemTemplate>
                    <asp:ListBox ID="lstisNull" Rows="1" runat="server">
                           <asp:ListItem Value=" " >Seçim Yapınız</asp:ListItem>
                           <asp:ListItem Value=" " >Evet</asp:ListItem>
                           <asp:ListItem Value="Not Null" >Hayır</asp:ListItem>
                    </asp:ListBox>    
                </ItemTemplate>
                <FooterStyle HorizontalAlign="Right" />
                <FooterTemplate>
                 <asp:Button ID="ButtonAdd" runat="server"  Text="Add New Row" 
                        onclick="ButtonAdd_Click" />
                </FooterTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:gridview>
                 
     <asp:Button ID="tblOlustur" style="margin-right:440px; background-color:#1b1b1b; color:white;  margin-top:10px; float:right"  runat="server" Text="Tablo Oluştur" OnClick="tblOlustur_Click" />
    </div>
   

</asp:Content>
