<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UserCenterHeader.Master"
    AutoEventWireup="true" CodeBehind="PurchaseOrderList.aspx.cs" Inherits="GoBiding.Web.UserCenter.UserCenterPage.PurchaseOrderList" %>

<%@ Import Namespace="GoBiding.BLL" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <aside class="right-side">                
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>
                已发布的采购信息
                <small>显示一年内您发布过的采购信息</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i> 首页</a></li>
                <li><a href="#">采购信息</a></li>
                <li class="active">已发布的采购信息</li>
            </ol>
        </section>
        <section class="content">
            <div class="row">
                 <div class="col-xs-12">
                            <div class="box">
                               
                                <div style="padding: 10px;">已发布 <font style="color: red;"><asp:Literal runat="server" ID="ltrSendBidsCount"></asp:Literal></font> 条采购信息，已发布生效的采购信息可以修改和删除</div>
                                <div class="box-body table-responsive no-padding">
                                    <table class="table table-hover">
                                        <tr>
                                            <th>发布时间</th>
                                            <th>采购类型</th>
                                            <th>采购标题</th>
                                            <th>操作</th>
                                        </tr>
                                    <asp:Repeater runat="server" ID="rptBidList">
                                        <ItemTemplate>
                                        
                                        <tr>
                                            <td style="width: 170px;"><%#Eval("PublishTime")%></td>
                                            <td style="width:170px;">企业采购</td>
                                            <td style="min-width: 600px;">
                                                <a href='/PurchaseOrderDetail.aspx?poId=<%#Eval("Id")%>' ><%#Eval("Title")%></a>
                                            </td>
                                            <td style="width:200px;">
                                                <a href='/PurchaseOrderDetail.aspx?poId=<%#Eval("Id")%>' >查看</a>
                                                &nbsp;&nbsp;&nbsp;
                                                <a href='/UserCenter/UserCenterPage/PublishPurchaseOrder.aspx?option=edit&poId=<%#Eval("Id")%>' >编辑</a>
                                                &nbsp;&nbsp;&nbsp;
                                                <a href='/UserCenter/UserCenterPage/PublishPurchaseOrder.aspx?option=delete&poId=<%#Eval("Id")%>' >删除</a>
                                            </td>
                                        </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    </table>
                                    <div class="pull-right">
                                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Width="100%" UrlPaging="true" CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass="active" PageSize="12" OnPageChanged="AspNetPager1_PageChanged">
                                        </webdiyer:AspNetPager>
                                    </div>
                                </div><!-- /.box-body -->
                            </div><!-- /.box -->
                        </div>
            </div>
        </section>

        </aside>
</asp:Content>
