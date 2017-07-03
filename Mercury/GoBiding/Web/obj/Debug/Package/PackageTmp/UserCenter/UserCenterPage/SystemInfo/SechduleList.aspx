<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UserCenterHeader.master"
    AutoEventWireup="true" CodeBehind="SechduleList.aspx.cs" Inherits="GoBiding.Web.UserCenter.UserCenterPage.SystemInfo.SechduleList" %>

<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <aside class="right-side">                
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>
                日志
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i> 首页</a></li>
                <li><a href="#">系统信息</a></li>
                <li class="active">任务调度</li>
            </ol>
        </section>
        <section class="content">
            <div class="row">
                 <div class="col-xs-12">
                            <div class="box">
    <div runat="server" id="mainContent">
        <div style="padding: 10px;">
            已发布 <font style="color: red;">
                <asp:Literal runat="server" ID="ltrTotalUserCount"></asp:Literal></font> 条记录</div>
        <div class="box-body table-responsive no-padding">
            <table class="table table-hover">
                <tr>
                    <th>序号</th>
                    <th>标题</th>
                    <th>执行状态</th>
                    <th>上次执行时间</th>
                    <th>执行策略</th>
                    <th>执行路径</th>
                    <th>操作</th>
                </tr>
                <tr>
                <td>1</td>
                <td>招标爬虫抓取</td>
                <td>未执行</td>
                <td>-</td>
                <td>每隔5分钟执行</td>
                <td></td>
                <td>暂停 启动</td>
                </tr>
                 <tr>
                <td>2</td>
                <td>更新招标城市</td>
                <td>未执行</td>
                <td>-</td>
                <td>每隔30分钟执行</td>
                <td></td>
                <td>暂停 启动</td>
                </tr>
                   <tr>
                <td>3</td>
                <td>客人订阅提醒邮件</td>
                <td>未执行</td>
                <td>-</td>
                <td>每隔60分钟执行</td>
                <td></td>
                <td>暂停 启动</td>
                </tr>
                 <tr>
                <td>4</td>
                <td>招标智能分类</td>
                <td>未执行</td>
                <td>-</td>
                <td>每隔30分钟执行</td>
                <td></td>
                <td>暂停 启动</td>
                </tr>
            </table>
         
        </div>
        
    </div>

     </div><!-- /.box -->
                        </div>
            </div>
        </section>

        </aside>
</asp:Content>
