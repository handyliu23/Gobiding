<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UserCenterHeader.master"
    AutoEventWireup="true" CodeBehind="CompanyList.aspx.cs" Inherits="GoBiding.Web.UserCenter.UserCenterPage.Admin.CompanyList" %>

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
                    <asp:Button runat="server" ID="btnSortByLastLoginTime" Text="按OnCreated倒序" 
                         onclick="btnSortByLastLoginTime_Click" />
                    &nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnLoginTimes" Text="按ProvinceId倒序" 
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
                    <th>企业名称</th>
                    <th>联系人</th>
                    <th>联系方式</th>
                    <th>所在地区</th>
                    <th>创建时间</th>
                    <th>行业</th>
                    <th>是否代理招标公司</th>
                    <th>操作</th>
                </tr>
                <asp:Repeater runat="server" ID="rptBidList">
                    <ItemTemplate>
                        <tr>
                            <td style="width: 120px;">
                                <a href="/UserCenter/UserCenterPage/offlineLogin.aspx?Id=<%#Eval("Id")%>"><%#Eval("Id")%></a><br />
                                <%#Eval("VendorName")%><br />
                                <%#Eval("CompanyType")%><br />
                            </td>
                              <td style="width: 100px;">
                                <%#Eval("ContacterName")%><br />
                                <%#Eval("ContacterTelephone")%><br />
                                <%#Eval("ContacterPosition")%><br />
                                </td>
                             <td style="width: 100px;">
                                Email:<%#Eval("Email")%><br />
                                QQ:<%#Eval("QQ")%><br />
                                Add:<%#Eval("Address")%>
                                </td>
                            <td style="width: 70px;">
                                <%#Eval("ProvinceId")%> <%#Eval("CityId")%>
                            </td>
                               <td style="width: 100px;">
                                 <%#Eval("OnCreated")%>
                                 <%#Eval("CreatedDate")%>
                            </td>
                               <td style="width: 70px;">
                               <%#Eval("Industry")%>
                            </td>
                                <td style="width: 70px; text-align:center;">
                               <%#Eval("IsBidAgent").ToString() == "1" ? "是":"否" %>
                            </td>
                            <td style="width: 70px;">
                                <a href='/UserCenter/UserCenterPage/PublishPurchaseOrder.aspx?option=edit&poId=<%#Eval("Id")%>'>
                                    编辑</a>
                                      <br /><br /> <a href='/UserCenter/UserCenterPage/Admin/UserEdit.aspx?option=Delete&userId=<%#Eval("Id")%>'>
                                        删除</a>
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
