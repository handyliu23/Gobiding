<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UserCenterHeader.master"
    AutoEventWireup="true" CodeBehind="LogList.aspx.cs" Inherits="GoBiding.Web.UserCenter.UserCenterPage.SystemInfo.LogList" %>

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
                <li class="active">日志</li>
            </ol>
        </section>
        <section class="content">
            <div class="row" style="margin-bottom:10px;">
                 <div class="col-xs-12">
                    <asp:DropDownList runat="server" ID="ddlAppName">
                        <asp:ListItem Text="GoBiding" Value="GoBiding"></asp:ListItem>
                        <asp:ListItem Text="GoBidingJob" Value="GoBidingJob"></asp:ListItem>
                    </asp:DropDownList>
                        <asp:DropDownList runat="server" ID="ddlLogType">
                        <asp:ListItem Text="Info" Value="Info"></asp:ListItem>
                        <asp:ListItem Text="Warn" Value="Warn"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button runat="server" ID="btnSearch" Text="查询" onclick="btnSearch_Click" />
                 </div>
                 
                 </div>
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
                    <th>信息 </th>
                    <th>时间</th>
                    <th>类型</th>
                    <th>平台</th>
                    <th>应用</th>
                </tr>
                <asp:Repeater runat="server" ID="rptBidList">
                    <ItemTemplate>
                        <tr>
                             <td style="width: 70px;">
                             <%#Eval("SystemLogId")%>
                            </td>
                             <td style="width: 70px;">
                                <%# Eval("Title").ToString()%>
                            </td>
                              <td style="width: 60px;">
                                <%# Eval("Message").ToString()%>
                            </td>
                          <td style="width: 90px;">
                                <%#Eval("CreateTime")%>
                            </td>
                         <td style="width: 70px;"> <%#Eval("LogType")%>
                         </td>
                          <td style="width: 70px;"> <%#Eval("Platform")%>
                         </td>
                          <td style="width: 70px;"> <%#Eval("AppName")%>
                         </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <div class="pull-right">
                <webdiyer:aspnetpager id="AspNetPager1" runat="server" width="100%" urlpaging="true"
                    cssclass="pagination" layouttype="Ul" pagingbuttonlayouttype="UnorderedList"
                    pagingbuttonspacing="0" currentpagebuttonclass="active" pagesize="12" onpagechanged="AspNetPager1_PageChanged">
                                        </webdiyer:aspnetpager>
            </div>
        </div>
        
    </div>

     </div><!-- /.box -->
                        </div>
            </div>
        </section>

        </aside>
</asp:Content>
