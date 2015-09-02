<%@ Page Title="" Language="C#" MasterPageFile="~/CTRLP/CTRLP.master" AutoEventWireup="true" CodeFile="MarkaEkle.aspx.cs" Inherits="CTRLP_MarkaEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 89px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Markalar</td>
                <td>
                    <asp:DropDownList ID="ddlMarka" runat="server" Width="163px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Marka Adı:</td>
                <td>
                    <asp:TextBox ID="txtMarka" runat="server" Width="153px"></asp:TextBox>
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

