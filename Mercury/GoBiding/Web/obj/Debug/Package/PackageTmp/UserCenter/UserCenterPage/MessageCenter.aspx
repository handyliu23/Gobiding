<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UserCenterHeader.Master"
    AutoEventWireup="true" CodeBehind="MessageCenter.aspx.cs" Inherits="GoBiding.Web.UserCenter.UserCenterPage.MessageCenter" %>

<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .hrefmsgtitle {
            font-size: 13px;
            color: #666;
        }
        .messagetable th {
            font-size: 13px;
        }
        .messagetable td {
            font-size: 13px;
        }
    </style>
    <aside class="right-side">                
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>
                消息中心
                <small>显示去投标网系统和其他用户发送给您的消息</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="/UserCenter/Index.aspx"><i class="fa fa-dashboard"></i> 首页</a></li>
                <li><a href="/UserCenter/UserCenterPage/MessageCenter.aspx">消息中心</a></li>
                <li class="active">收到的消息列表</li>
            </ol>
        </section>
        <section class="content">
            <div class="row">
                 <div class="col-xs-12">
                            <div class="box">
                                <div class="box-header">
                                    <h3 class="box-title">消息中心</h3>
                                </div><!-- /.box-header -->
                                <div class="box-body table-responsive no-padding">
                                    <table class="table table-hover messagetable">
                                        <tr>
                                            <th style="width: 150px; text-align: center;">消息类型</th>
                                            <th style="width: 150px; text-align: center;">发件方</th>
                                            <th style="width: 650px;">招标标题</th>
                                            <th>发布时间</th>
                                        </tr>
                                    <asp:Repeater runat="server" ID="rptBidList">
                                        <ItemTemplate>
                                        <tr>
                                            <td style="width: 150px; text-align: center;"><%#Eval("MessageType").ToString() == "1" ? "系统消息":"用户消息"%></td>
                                            <td style="width: 150px; text-align: center;"><%# GetSenderName(Eval("SenderId").ToString())%></td>
                                             <td style="min-width: 500px;">
                                                <a href='/UserCenter/UserCenterPage/MessageDetail.aspx?mId=<%#Eval("Id")%>' class="hrefmsgtitle" style='font-weight:<%#Eval("IsRead").ToString() == "True" ? "":"bold" %>'><%#Eval("Title")%></a>
                                            </td>
                                            <td style="width: 200px;"><%#Eval("MessageTime","{0:D}")%></td>
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
