<%@ Page Title="" Language="C#" MasterPageFile="~/CTRLP/CTRLP.master" AutoEventWireup="true" CodeFile="KategoriEkle.aspx.cs" Inherits="CTRLP_KategoriEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 112px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Kategoriler</td>
                <td>
                    <asp:DropDownList ID="ddlKategori" runat="server" Height="22px" Width="293px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Kategori Adı</td>
                <td>
                    <asp:TextBox ID="txtKategori" runat="server" Width="286px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnEkle" runat="server" OnClick="btnEkle_Click" Text="Ekle" />
                </td>
            </tr>
        </table>
    </form>
   
</asp:Content>

