<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UserCenterHeader.master"
    AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="GoBiding.Web.UserCenter.UserCenterPage.Admin.UserList" %>

<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <aside class="right-side">                
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>
                注册用户列表
                <small>显示所有注册过的用户信息</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i> 首页</a></li>
                <li><a href="#">用户管理</a></li>
                <li class="active">用户列表</li>
            </ol>
        </section>
        <section class="content">
           <div class="row">
                 <div class="col-xs-12" style="padding-bottom:10px;">
                 <asp:Button runat="server" ID="btnDefault" Text="默认排序" 
                         onclick="btnDefault_Click"  />
                    &nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnSortByLastLoginTime" Text="按最晚登录时间倒序" 
                         onclick="btnSortByLastLoginTime_Click" />
                    &nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnSortByScore" Text="按分数倒序" 
                         onclick="btnSortByScore_Click" />
                          &nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnLoginTimes" Text="按登录次数倒序" 
                         onclick="btnLoginTimes_Click"  />
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
                    <th>用户名</th>
                    <%--<th  style="width: 70px;">头像</th>--%>
                    <th>Email</th>
                    <th>分值</th>
                    <th>创建时间</th>
                    <th>最近登录</th>
                    <th>企业名称</th>
                    <th>用户类型</th>
                    <th>企业审核</th>
                    <th>企业审核时间</th>
                    <th>登陆平台</th>
                    <th>操作</th>
                </tr>
                <asp:Repeater runat="server" ID="rptBidList">
                    <ItemTemplate>
                        <tr>
                            <td style="width: 70px;">
                                <a href="/UserCenter/UserCenterPage/offlineLogin.aspx?Id=<%#Eval("Sys_UserId")%>"><%#Eval("UserName")%></a><br />
                                <%#Eval("UserNickName")%><br />
                                <%#Eval("Description")%><br />
                                <%#Eval("ContacterName")%><br />
                                <%#Eval("TelephonePhone")%>
                            </td>
<%--                            <td style="width: 70px; word-break:break-all"">
                                <%#Eval("UserProfile")%>
                            </td>--%>
                             
                             <td style="width: 100px;">
                                Email:<%#Eval("Email")%><br />QQ:<%#Eval("QQ")%><br />openId:<%#Eval("OpenId")%></td>
                            
                            <td style="width: 70px;">
                                <%#Eval("Scores")%>
                            </td>
                               <td style="width: 100px;">
                                 <%#Eval("OnCreate")%>
                            </td>
                               <td style="width: 70px;">
                               登录次数：<%#Eval("LoginTimes")%><br />
                               登录IP：<%#Eval("LastLoginIp")%><br />
                               最近登录时间：<%#Eval("LastLoginTime")%></td>
                             <td style="width: 170px;">
                             用户ID：<%#Eval("Sys_UserId")%><Br />企业ID：<%#Eval("CompanyId")%><br />公司名：<%#Eval("CompanyName")%></td>
                             <td style="width: 70px;">
                                <%# GetUserLoginTypeName(int.Parse(Eval("UserLoginType").ToString()))%>
                            </td>
                              <td style="width: 60px;">
                                <%# GetCompanyAuditStatusName(Eval("CompanyAuditStatus").ToString())%>
                            </td>
                          <td style="width: 90px;">
                                <%#Eval("CompanyAuditApplyTime")%><br />
                                <%#Eval("CompanyAuditTime")%>
                            </td>
                            <td style="width: 100px;">
                                <%#Eval("ThirdLoginPartyName")%>
                            </td>
                            <td style="width: 70px;">
                            <a href='/UserCenter/UserCenterPage/Admin/UserEdit.aspx?option=Auth&userId=<%#Eval("Sys_UserId")%>'>
                                        认证</a><br />
                                <a href='/UserCenter/UserCenterPage/Profile.aspx?userid=<%#Eval("Sys_UserId")%>'>
                                    编辑</a> <br /> <a href='/UserCenter/UserCenterPage/Admin/UserEdit.aspx?option=Delete&userId=<%#Eval("Sys_UserId")%>'>
                                        删除</a>
                                        <BR />
                                        <a href='/UserCenter/UserCenterPage/Admin/UserEdit.aspx?option=DeleteData&userId=<%#Eval("Sys_UserId")%>'>
                                        物理删除</a>
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
