<%@ Page Title="" Language="C#" MasterPageFile="~/CTRLP/CTRLP.master" AutoEventWireup="true" CodeFile="KategoriMarka.aspx.cs" Inherits="CTRLP_KategoriMarka" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 186px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Kategoriler</td>
                <td>
                    <asp:DropDownList ID="ddlKategori" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="ddlKategori_SelectedIndexChanged" Width="240px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Markalar</td>
                <td>
                    <asp:DropDownList ID="ddlMarka" runat="server" Height="16px" Width="240px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnEslestir" runat="server" OnClick="btnEslestir_Click" Text="Eşleştir" />
                </td>
            </tr>
        </table>
    </form>

</asp:Content>

