<%@ Page Language="C#" MasterPageFile="~/UserCenter/UserCenterHeader.master" AutoEventWireup="true" CodeBehind="SmartCategoryList.aspx.cs" Inherits="GoBiding.Web.UserCenter.UserCenterPage.SystemInfo.SmartCategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <aside class="right-side">                
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>
                MercurySpiders
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i> 首页</a></li>
                <li><a href="#">系统信息</a></li>
                <li class="active">分类匹配</li>
            </ol>
        </section>
        <section class="content">
    <div　 runat="server" id="mainContent">
           <asp:ListView runat="server" ID="lstSmartCategorys" 
               onitemcommand="lstSmartCategorys_ItemCommand">
            <LayoutTemplate>
                <table>
                   <asp:PlaceHolder ID="itemPlaceholder" runat="server" />  
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td style="width: 120px;">
                    <a href="/UserCenter/UserCenterPage/SystemInfo/SmartCategoryList.aspx?cId=<%#Eval("BidCategoryId") %>">
                        <asp:Label ID="lblBidCategoryName" runat="server" Text='<%# Eval("BidCategoryName") %>' /></a>
                    </td>
                    <td style="width: 600px;">
                        <asp:TextBox runat="server" TextMode="MultiLine" Text='<%# Eval("Keywords") %>' Width="1000" Height="160" ID="txtKeywords"></asp:TextBox>
                    </td>
                    <td>
                        <asp:HiddenField runat="server" ID="hdfKeyId" Value='<%# Eval("SmartCategoryId") %>' />
                        <asp:LinkButton runat="server" CommandName="SAVE" Text="保存"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        
    </div>

       </section>

        </aside>
</asp:Content>