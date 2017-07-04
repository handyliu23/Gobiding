<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBidCategoryList.ascx.cs"
    Inherits="GoBiding.Web.UserCenter.Index.ucBidCategoryList" %>
<%@ Register Src="ucSubCategoryList.ascx" TagName="ucSubCategoryList" TagPrefix="uc1" %>
<style>
    .tblCategoryList
    {
        font-size: 12px;
        color: #666;
    }
</style>
<asp:ListView runat="server" GroupItemCount="1" ID="lstCategoryList">
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
            <table class="tblCategoryList" cellpadding="0" cellspacing="0">
                <tr>
                    <th style="width:100px; height:34px; line-height:34px; vertical-align:top;">
                        <a href='/BidList.aspx?industry=<%# Eval("BidCategoryId")%>'  target="_blank" style="text-decoration: none;
                            color: #666;">
                            <%# Eval("BidCategoryName")%>
                        </a>
                    </th>
                    <td style="padding:0px; height:34px; line-height:34px;">
                        <uc1:ucSubCategoryList ID="ucSubCategoryList1" parentCategoryId='<%#Eval("BidCategoryId") %>'
                            runat="server" />
                    </td>
                </tr>
            </table>
        </td>
    </ItemTemplate>
</asp:ListView>
