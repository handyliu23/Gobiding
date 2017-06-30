<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BidNewsDetail.aspx.cs"
    Inherits="GoBiding.Web.BidNewsDetail" %>

<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>去投标网_法律法规_招投标法规_中华人民共和国招标投标法</title>
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
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
        <div class="container" style="padding-left: 0px;">
            <div class="col-lg-8" style="padding-top: 20px; padding-left: 0px;">
                <div style="width: 100%; border: 1px solid #eee; background-color: #fff; padding: 30px;">
                    <span style="font-size: 20px;">
                        <asp:Literal runat="server" ID="ltrTitle"></asp:Literal></span>
                    <br />
                    <img src="/imgs/system/smalllogo.png" width="20" height="20" />
                    <asp:Literal runat="server" ID="ltrAuthor"></asp:Literal>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal runat="server" ID="ltrPublishTime"></asp:Literal>
                    &nbsp;&nbsp;&nbsp;&nbsp;关键词：<asp:Literal runat="server" ID="ltrKeys"></asp:Literal>
                    <div style="height: 36px; line-height: 36px; font-size: 14px; color: #999; padding-top: 10px;">
                        <div class="bdsharebuttonbox" data-tag="share_1">
                            <a class="bds_more" data-cmd="more"></a><a class="bds_mshare" data-cmd="mshare">
                            </a><a class="bds_qzone" data-cmd="qzone" href="#"></a><a class="bds_tsina" data-cmd="tsina">
                            </a><a class="bds_baidu" data-cmd="baidu"></a><a class="bds_renren" data-cmd="renren">
                            </a><a class="bds_tqq" data-cmd="tqq"></a><a class="bds_weixin" data-cmd="weixin">
                            </a>
                        </div>
                    </div>
                    <br />
                    <asp:Literal runat="server" ID="ltrContent"></asp:Literal>
                    <br />
                    文章由<a href="http://www.gobiding.com">去投标网</a>编辑发布，转载请注明出处。
                </div>
                <div style="width: 100%; border: 1px solid #eee; background-color: #fff; margin-top: 20px;
                    padding: 20px;">
                    <table border="0">
                        <tr>
                            <td style="width: 130px; padding: 10px;">
                                <img src="/imgs/system/wx300_300.png" width="110" /><br />
                            </td>
                            <td valign="top" style="padding: 10px;">
                                <div style="font-size: 12px; font-family: '微软雅黑'; padding-left: 10px;">
                                    <font style="font-size: 18px; line-height: 30px; font-weight: bolder;">去投标网微信公众号</font><br />
                                    <div style="line-height: 25px;">
                                        · 扫一扫微信公众服务号<br />
                                        · 随时随地手机也能在线投标<br />
                                        · 免安装，免升级，更便捷
                                    </div>
                                </div>
                            </td>
                            <td>
                                <div style="padding-left: 70px;">
                                    <img src="/imgs/ad/ad_xiecheng.jpg" style="width: 270px; height: 100px;" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="col-lg-4" style="padding: 0px; padding-top: 20px;">
                <div style="height: 44px; line-height: 44px; margin-left: 10px; padding-left: 20px;
                    border: 1px solid #eee; background-color: #fff; border-bottom: 0px;">
                    相关推荐
                </div>
                <div style="border-bottom: 1px dashed #dcdcdc; margin-left: 10px; padding: 20px;
                    padding-top: 0px; background-color: #fff; border: 1px solid #eee; line-height: 50px;
                    font-weight: bold; font-size: 24px; text-align: center;">
                    <table style="width: 100%;" id="tblNewsList">
                        <asp:Repeater runat="server" ID="rptNewsList">
                            <ItemTemplate>
                                <tr>
                                    <td style="border-bottom: 1px dashed #eee; padding: 10px 5px 10px 0px;">
                                        <table>
                                            <tr>
                                                <td style="width: 110px; height: 70px;">
                                                    <a href='/BidNewsDetail/<%#Eval("Id") %>.html' style="color: #000; font-size: 14px;
                                                        font-weight: normal;">
                                                        <img src="/imgs/news/<%#Eval("ProfileImage") %>" style="width: 90px; height: 60px;"
                                                            alt="" /></a>
                                                </td>
                                                <td style="text-align: left; height: 24px; line-height: 24px; padding-left: 15px;
                                                    padding-top: 2px; vertical-align: top; font-size: 12px; font-weight: normal;">
                                                    【<%# Eval("TypeName").ToString()%>】<a href='/BidNewsDetail/<%#Eval("Id") %>.html'
                                                        style="color: #000; font-size: 12px; font-weight: normal;"><%#Eval("NewsTitle")%></a>
                                                    <br />
                                                    <span style="color: #666; font-size: 10px;">去投标网</span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
                <div style=" margin-left:10px; padding-left:30px; margin-top:20px; border:1px solid #ececec;">
                    <script src="http://www.9lianmeng.com/page/s.php?s=231775&w=300&h=300"></script>
                </div>
                <br />
                <div style="margin-left: 50px;">
                </div>
            </div>
        </div>
    </div>
    <script>
        window._bd_share_config = {
            share: [{
                "bdSize": 16
            }],
            slide: [{
                bdImg: 0,
                bdPos: "right",
                bdTop: 100
            }],
            image: [{
                viewType: 'list',
                viewPos: 'top',
                viewColor: 'black',
                viewSize: '16',
                viewList: ['more', 'qzone', 'tsina', 'huaban', 'tqq', 'renren', 'tqq', 'weixin']
            }],
            selectShare: [{
                "bdselectMiniList": ['qzone', 'tqq', 'kaixin001', 'bdxc', 'tqf']
            }]
        }
        with (document) 0[(getElementsByTagName('head')[0] || body).appendChild(createElement('script')).src = 'http://bdimg.share.baidu.com/static/api/js/share.js?cdnversion=' + ~(-new Date() / 36e5)];
    </script>
    </form>
</body>
</html>
