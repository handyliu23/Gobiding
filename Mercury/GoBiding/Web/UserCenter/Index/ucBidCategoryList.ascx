<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBidCategoryList.ascx.cs"
    Inherits="GoBiding.Web.UserCenter.Index.ucBidCategoryList" %>
<%@ Register Src="ucSubCategoryList.ascx" TagName="ucSubCategoryList" TagPrefix="uc1" %>
<style>
    .tblCategoryList
    {
        font-size: 12px;
        color: #666;
        line-height: 24px;
    }
</style>
<asp:ListView runat="server" GroupItemCount="2" ID="lstCategoryList">
    <LayoutTemplate>
        <table class="tblCategoryList">
            <asp:PlaceHolder runat="server" ID="groupPlaceholder" />
        </table>
    </LayoutTemplate>
    <GroupTemplate>
        <tr>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
        </tr>
    </GroupTemplate>
    <ItemTemplate>
        <td>
            <table class="tblCategoryList">
                <tr>
                    <th style="line-height: 22px; text-align: center; width: 70px;">
                        <a href='/BidList.aspx?industry=<%# Eval("BidCategoryId")%>'  target="_blank" style="text-decoration: none;
                            color: #666;">
                            <%# Eval("BidCategoryName")%>
                        </a>
                    </th>
                    <td style="line-height: 18px;">
                        <uc1:ucSubCategoryList ID="ucSubCategoryList1" parentCategoryId='<%#Eval("BidCategoryId") %>'
                            runat="server" />
                    </td>
                </tr>
            </table>
        </td>
    </ItemTemplate>
</asp:ListView>
