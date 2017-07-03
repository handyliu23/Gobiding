<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UserCenterHeader.Master"
    AutoEventWireup="true" CodeBehind="MessageDetail.aspx.cs" Inherits="GoBiding.Web.UserCenter.UserCenterPage.MessageDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <aside class="right-side">                
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>
                <small>显示去投标网系统和其他用户发送给您的消息</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="/UserCenter/Index.aspx"><i class="fa fa-dashboard"></i> 首页</a></li>
                <li><a href="/UserCenter/UserCenterPage/MessageCenter.aspx">消息中心</a></li>
                <li class="active"></li>
            </ol>
        </section>
        <section class="content">
            <div class="row">
                 <div class="col-xs-12">
                     <div class="box">
                         <div class="box-body table-responsive" style="text-align:center; line-height: 40px; font-weight: bold; font-size: 16px;">
                            <asp:Literal runat="server" ID="ltrMsgTitle"></asp:Literal>
                         </div><!-- /.box-body -->
                         <div style="width:100%; text-align: center; font-size: 12px;">
                             &nbsp;&nbsp;发件人：<asp:Literal runat="server" ID="ltrSender"></asp:Literal>
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;发送时间：<asp:Literal runat="server" ID="ltrSendTime"></asp:Literal>
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;消息类型：<asp:Literal runat="server" ID="ltrMsgType"></asp:Literal>
                         </div>
                         <div style="width:80%; text-align: center; padding: 50px;">
                            <asp:Literal runat="server" ID="ltrMsgContent"></asp:Literal>
                         </div>
                     </div><!-- /.box -->
                 </div>
            </div>
        </section>

        </aside>
</asp:Content>
