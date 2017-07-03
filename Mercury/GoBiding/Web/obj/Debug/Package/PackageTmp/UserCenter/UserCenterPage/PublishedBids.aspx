﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UserCenterHeader.Master"
    AutoEventWireup="true" CodeBehind="PublishedBids.aspx.cs" Inherits="GoBiding.Web.UserCenter.UserCenterPage.PublishedBids" %>

<%@ Import Namespace="GoBiding.BLL" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <aside class="right-side">                
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>
                已发布的招标信息
                <small>显示一年内您发布过的招标信息</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i> 首页</a></li>
                <li><a href="#">招标信息</a></li>
                <li class="active">已发布的招标信息</li>
            </ol>
        </section>
        <section class="content">
            <div class="row">
                 <div class="col-xs-12">
                            <div class="box">
                               
                                <div style="padding: 10px;">已发布 <font style="color: red;"><asp:Literal runat="server" ID="ltrSendBidsCount"></asp:Literal></font> 条招标信息，已发布生效的招标信息不允许修改和删除</div>
                                <div class="box-body table-responsive no-padding">
                                    <table class="table table-hover">
                                        <tr>
                                            <th style="width:50px;"></th>
                                            <th>招标方式</th>
                                            <th>招标类型</th>
                                            <th>发布时间</th>
                                            <th>招标编号</th>
                                            <th>招标标题</th>
                                            <th>操作</th>
                                        </tr>
                                    <asp:Repeater runat="server" ID="rptBidList">
                                        <ItemTemplate>
                                        <tr>
                                            <td></td>
                                            <td style="width: 120px;"><%# CommonUtility.GetBidTypeValue(Eval("BidType").ToString())%></td>
                                            <td style="width: 100px;"><%# CommonUtility.GetCategoryTypeName(Eval("BidCategoryType").ToString())%></td>
                                            <td style="width: 170px;"><%#Eval("CreateTime")%></td>
                                            <td style="width: 200px;"><%#Eval("BidNumber")%></td>
                                            <td style="min-width: 500px;">
                                                <a href='/BidDetail.aspx?bId=<%#Eval("BidId")%>' ><%#Eval("BidTitle")%></a>
                                            </td>
                                            <td style="width: 180px;">
                                                <a href='/UserCenter/UserCenterPage/PublishBid.aspx?option=delete&BidId='<%#Eval("BidId") %>>删除</a>
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
