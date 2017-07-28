<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UserCenterHeader.master"
    AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="GoBiding.Web.UserCenter.UserCenterPage.Admin.NewsList" %>

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
                 <div class="col-xs-12" style="padding-bottom:10px;">
                   <a href="/UserCenter/UserCenterPage/Admin/NewsEdit.aspx?option=add"><div class="btn btn-primary"  style="width:200px;">发布新闻</div></a>
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
                    <th>标题</th>
                    <th>创建时间</th>
                    <th>作者</th>
                    <th>分类</th>
                    <th>Id</th>
                    <th>浏览量</th>
                    <th>操作</th>
                </tr>
                <asp:Repeater runat="server" ID="rptBidList">
                    <ItemTemplate>
                        <tr>
                            <td style="width: 70px;">
                               <a href='/BidNewsDetail.aspx?NewsId=<%#Eval("Id")%>'><%#Eval("NewsTitle")%></a><br />
                            </td>
                            <td style="width: 70px;">
                                <%#Eval("OnCreate")%>
                            </td>
                             <td style="width: 70px;">
                               <%#Eval("Author")%>
                            </td>
                            
                            <td style="width: 70px;">
                                <%#Eval("TypeName")%>
                            </td>
                               <td style="width: 100px;">
                                 <%#Eval("Id")%>
                            </td>
                               <td style="width: 100px;">
                                 <%#Eval("BrowseCount")%>
                            </td>
                         
                            <td style="width: 100px;">
                                <a href='/UserCenter/UserCenterPage/Admin/NewsEdit.aspx?option=edit&Id=<%#Eval("Id")%>'>
                                    编辑</a> <br /> <a href='/UserCenter/UserCenterPage/Admin/NewsEdit.aspx?option=Delete&Id=<%#Eval("Id")%>'>
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
