<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CitysControl.ascx.cs"
    Inherits="Mercury.Web.Controls.CitysControl1" %>
<asp:ListView runat="server" GroupItemCount="10" ID="lstCitys">
    <LayoutTemplate>
        <table>
            <asp:PlaceHolder ID="groupPlaceholder" runat="server" />
        </table>
    </LayoutTemplate>
    <GroupTemplate>
        <tr>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
        </tr>
    </GroupTemplate>
    <ItemTemplate>
        <td  style="width: 120px; color: <%# IsCoverd(int.Parse(Eval("CityID").ToString())) ? "red" : "" %>">
            <asp:Label ID="cityName" runat="server" Text='<%# Eval("CityName") %>' />
        </td>
    </ItemTemplate>
</asp:ListView>
