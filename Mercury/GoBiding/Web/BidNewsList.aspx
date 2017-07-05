<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BidNewsList.aspx.cs" Inherits="GoBiding.Web.BidNewsList" %>

<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<%@ Register src="UserCenter/Index/Bottom.ascx" tagname="Bottom" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>去投标网_法律法规_招投标法规_中华人民共和国招标投标法</title>
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <meta name="keywords" content="招标资讯,招标师,招标行业,招标论坛" />
    <meta name="Description" content="去投标网_招标资讯_免费招标采购信息_免费招标_采购信息_公开招标_工程招标_上海商麓网络科技有限公司官网" />
    <link rel="shortcut icon" type="image/x-icon" href="/imgs/system/logo_16_16.png"
        media="screen" />
    <script src="/UserCenter/js/jquery.min.js" type="text/javascript"></script>
    <script src="/js/thirdplugin.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ztbfg").addClass("navchoose");
        });
    </script>
    <style>
        *
        {
            margin: 0;
            padding: 0;
            font-family: "微软雅黑";
            font-size: 14px;
            line-height: 2em;
            color: #333;
        }
        .breadcrumb a
        {
            color: #fff;
        }
        .breadcrumb li.active
        {
            color: #fff;
        }
        
        #tblNewsList a:hover
        {
            text-decoration: none;
        }
        .pagination li span.active
        {
            color: #fff;
            cursor: default;
            background-color: #428bca;
            border-color: #428bca;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:Top ID="Top1" runat="server" />
    <div style="background-color: #22252A;">
        <div class="container" style="padding: 0px; height: 44px;">
            <ol class="breadcrumb" style="background-color: #22252A;">
                <li><a href="/Default.html">去投标网</a></li>
                <li><a href="/BidNewsList.html">招标资讯</a></li>
            </ol>
        </div>
    </div>
    <div class="container" style="padding: 0px; background-color: #F8F8F8; font-family: simhei;
        width: 100%;">
        <div class="container" style="padding: 0px; color: #000; font-family: simhei;">
            <div class="col-lg-8" style="padding: 20px; padding-left: 0px;">
                <div style="border-bottom: 1px dashed #dcdcdc; margin-left: 10px; padding: 20px;
                    background-color: #FFF; line-height: 50px; font-weight: bold; font-size: 24px;
                    text-align: center;">
                    <table style="width: 100%;" id="tblNewsList">
                        <asp:Repeater runat="server" ID="rptNewsList">
                            <ItemTemplate>
                                <tr>
                                    <td style="border-bottom: 1px dashed #eee; padding: 10px;">
                                        <table>
                                            <tr>
                                                <td style="width: 160px; height: 110px; padding-left: 10px;">
                                                    <a href='/BidNewsDetail/<%#Eval("Id") %>.html' style="color: #000; font-size: 14px;
                                                        font-weight: normal;">
                                                        <img src="/imgs/news/<%#Eval("ProfileImage") %>" style="width: 140px; height: 90px;"
                                                            alt="" /></a>
                                                </td>
                                                <td style="text-align: left; height: 30px; line-height: 30px; padding-left: 15px;
                                                    padding-top: 2px; vertical-align: top; font-size: 16px; font-weight: normal;">
                                                    【<%# Eval("TypeName").ToString()%>】<a href='/BidNewsDetail/<%#Eval("Id") %>.html'
                                                        style="color: #000; font-size: 16px; font-weight: normal;"><%#Eval("NewsTitle")%></a><br /><span style="font-size: 10px; color: Orange;"><%#Eval("OnCreate","{0:yyyy-MM}")%>[查看详细]</span>
                                                    <br />
                                                    <span style="color: #666; font-size: 10px;">发布：去投标网</span> <span style="color: #666;
                                                        font-size: 10px;">关键词：<%#Eval("Keywords")%></span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div class="pull-right" style="margin-top: 20px; font-weight: normal; color: #000;">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Width="100%" UrlPaging="true"
                            FirstPageText="第一页" LastPageText="尾页" ShowPageIndexBox="Never" ShowNavigationToolTip="False"
                            ShowCustomInfoSection="Never" PrevPageText="上一页" NextPageText="下一页" CssClass="pagination"
                            LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0"
                            ForeColor="Black" CurrentPageButtonClass="active" PageSize="10" OnPageChanged="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
                <div style="margin-top: 20px; padding: 10px;">
                    <script src="http://www.9lianmeng.com/page/s.php?s=231776&w=760&h=90"></script>
                </div>
                <br />
                <div style="margin-left: 50px;">
                </div>
            </div>
            <div class="col-lg-4" style="padding: 0px; padding-top: 20px;">
                <div style="height: 44px; line-height: 44px; margin-left: 10px; padding-left: 20px;
                    border: 1px solid #eee; background-color: #fff; border-bottom: 0px;">
                    相关招标法规
                </div>
                <div style="border-bottom: 1px dashed #dcdcdc; margin-left: 10px; padding: 20px;
                    padding-top: 0px; background-color: #fff; border: 1px solid #eee; line-height: 50px;
                    font-weight: bold; font-size: 24px; text-align: center;">
                    <table style="width: 100%;" id="tblNewsList2">
                        <asp:Repeater runat="server" ID="rptLawList">
                            <ItemTemplate>
                                <tr>
                                    <td style="border-bottom: 1px dashed #eee; padding: 10px 5px 10px 0px;">
                                        <table>
                                            <tr>
                                                <td style="text-align: left; height: 24px; line-height: 24px; padding-left: 5px;
                                                    padding-top: 2px; vertical-align: top; font-size: 14px; font-weight: normal;">
                                                    【<%# Eval("TypeName").ToString()%>】<a href='/BidNewsDetail/<%#Eval("Id") %>.html'
                                                        style="color: #000; font-size: 14px; font-weight: normal;"><%#Eval("NewsTitle")%></a></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
                <br />
                <div style="margin-left: 50px;">
                </div>
            </div>
        </div>
    </div>
    <uc2:Bottom ID="Bottom1" runat="server" />
    </form>
</body>
</html>
