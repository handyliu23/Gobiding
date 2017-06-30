<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aspx.html.cs" Inherits="GoBiding.Web.BidDetail" %>

<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">

    <link rel="shortcut icon" type="image/x-icon" href="/imgs/system/logo_16_16.png"
        media="screen" />
    <script src="/js/thirdplugin.js" type="text/javascript"></script>
    <style>
        #divlogin a
        {
            font-size: 10px;
        }
        .row
        {
            margin-top: 15px;
        }
    </style>
    <script language="javascript">
        function printdiv() {
            var newstr = document.getElementById('iframeContent').contentWindow.document.all.item('form1').innerHTML;
            var oPop = window.open('', 'oPop');
            var str = '<!DOCTYPE html>'
            str += '<html>'
            str += '<head>'
            str += '<meta charset="utf-8">'
            str += '<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">'
            str += '</head>'
            str += '<body>招标信息来自去投标网 http://www.gobiding.com <hr/>'
            str += newstr;
            str += '</body>'
            str += '</html>'

            oPop.document.write(str);
            oPop.print();
            oPop.close();
            return false;
        } 
    </script>
</head>
<body>
    <uc1:Top ID="Top1" runat="server" />
    <form id="form1" runat="server" clientidmode="Static">
    <div style="background-color: #22252A;">
        <div class="container" style="padding: 0px; height: 44px;">
            <ol class="breadcrumb" style="background-color: #22252A;">
                <li><a href="/Default.html">去投标网</a></li>
                <li><a href="/BidList.html">招标列表</a></li>
                <li class="active">
                    <asp:Literal runat="server" ID="lblTitle2"></asp:Literal></li>
            </ol>
        </div>
    </div>
    <div class="container" style="padding: 0px; background-color: #F8F8F8; font-family: simhei;
        width: 100%;">
        <div style="width: 1160px; margin: 0px auto;">
            <%--            <div style="width:100%; margin-top:10px;">
                <table cellpadding="0" cellspacing="0" style="padding:0px; border:0px;">
                    <tr>
                        <td  style="padding:0px; border:0px;"><script src="http://www.9lianmeng.com/page/s.php?s=231772&w=950&h=90"></script></td>
                        <td  style="padding:0px; border:0px;" rowspan="2">
                            <script src="http://www.9lianmeng.com/page/s.php?s=231773&w=200&h=200"></script>
                        </td>
                    </tr>
                    <tr>
                        <td  style="padding:0px; border:0px;">
                        <script src="http://www.9lianmeng.com/page/s.php?s=231774&w=950&h=90"></script>
                        </td>
                    </tr>
                </table>
            </div>--%>
            <div style="width: 780px; float: left; background-color: #fff; margin-top: 20px;
                padding: 20px;" id="printarea">
                <div style="font-size: 14px;">
                    <div style="text-align: center;">
                        <h1 style="font-size: 18px; line-height: 40px;">
                            <asp:Literal runat="server" ID="lblTitle"></asp:Literal></h1>
                        <table>
                            <tr>
                                <td style="border: 0px; padding-left: 10px;">
                                    <div class="bdsharebuttonbox" data-tag="share_1">
                                        <a class="bds_more" data-cmd="more"></a><a class="bds_mshare" data-cmd="mshare">
                                        </a><a class="bds_qzone" data-cmd="qzone" href="#"></a><a class="bds_tsina" data-cmd="tsina">
                                        </a><a class="bds_baidu" data-cmd="baidu"></a><a class="bds_renren" data-cmd="renren">
                                        </a><a class="bds_tqq" data-cmd="tqq"></a><a class="bds_weixin" data-cmd="weixin">
                                        </a>
                                        </a>
                                    </div>
                                </td>
                                <td style="border: 0px; text-align: right; padding-right: 10px;">
                                    <span onclick="printdiv();">
                                        <img src="/imgs/system/print.png" style="width: 18px; height: 18px;" alt="" />
                                        打印文件</span>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <table class="detaillabeltable">
                        <%--  <tr>
                            <td colspan="4" style="height: 60px; text-align: left; padding: 10px;">
                                以下内容仅对会员开放,免费注册会员可以查看7天以前的招标信息。如需查看详细内容，请先 <a target="_blank" href="/Index.html">注册</a>
                                成为会员，已注册会员请<a target="_blank" href="/Index.html"> 登录 </a>后查看。
                            </td>
                        </tr>--%>
                        <tr>
                            <th>
                                发布日期
                            </th>
                            <td>
                                <asp:Literal runat="server" ID="ltrPublishTime"></asp:Literal>
                            </td>
                            <th>
                                项目编号
                            </th>
                            <td>
                                <asp:Literal runat="server" ID="ltrBidNumber"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                招标地区
                            </th>
                            <td>
                                <asp:Literal runat="server" ID="ltrProvinceName"></asp:Literal>
                            </td>
                            <th>
                                截至日期
                            </th>
                            <td>
                                <asp:Literal runat="server" ID="ltrExpireTime"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                招标单位
                            </th>
                            <td>
                                <asp:Literal runat="server" ID="ltrBidCompany"></asp:Literal>
                            </td>
                            <th>
                                招标金额
                            </th>
                            <td>
                                <asp:Literal runat="server" ID="ltrBidAmount"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                招标类型
                            </th>
                            <td>
                                <asp:Literal runat="server" ID="ltrBidType"></asp:Literal>
                            </td>
                            <th>
                                招标分类
                            </th>
                            <td>
                                <asp:Literal runat="server" ID="ltrCategoryId"></asp:Literal>
                            </td>
                        </tr>
                        <%--  <tr>
                            <td style="text-align: center;" colspan="4">
                                <div>
                                    <input type="button" name="btn" value="打印" onclick="printView()" />
                                    <input type="button" name="show" value="预览" onclick="printpr('btn,show','0')" />
                                </div>
                            </td>
                        </tr>--%>
                        <%--  <tr>
                            <th style="height: 80px;">
                                关注过的用户
                            </th>
                            <td colspan="3" style="text-align: left; padding-left: 20px;">
                                <img src="/UserCenter/img/avatar5.png" width="50" style="border-radius: 50%;" />
                                <img src="/UserCenter/img/avatar2.png" width="50" style="border-radius: 50%; margin-left: 20px;" />
                                <img src="/UserCenter/img/avatar5.png" width="50" style="border-radius: 50%; margin-left: 20px;" />
                                <img src="/UserCenter/img/avatar2.png" width="50" style="border-radius: 50%; margin-left: 20px;" />
                            </td>
                        </tr>--%>
                    </table>
                    <div class="divbiddetailcontent" style="width: 100%; margin-top: 10px; padding: 20px;
                        background-position: center; background-repeat: repeat-y; overflow-y: hidden;">
                        <iframe src="/BidContentSource/<%= BidId %>.html" scrolling="auto" id="iframeContent"
                            style="min-height: 300px;" onload="changeFrameHeight()" width="100%" frameborder="0">
                        </iframe>
                    </div>
                    <br />
                    <div style="width: 100%; border-top: 1px solid #dcdcdc; padding-left: 20px;">
                        <br />
                        <font style="color: Red;">提示：联系招标人前请说明在去投标网上看到的招标信息,如需要下载附件请至源站点下载<br />
                        </font><a runat="server" id="ltrSourceURL" target="_blank">
                            <div style="width: 100px; height: 40px; line-height: 40px; cursor: pointer; background-color: skyblue;
                                color: #fff; text-align: center; border-radius: 5px;">
                                查看原文
                            </div>
                        </a>
                        <br />
                    </div>
                </div>
                <br />
                <br />
            </div>
            <div style="width: 380px; float: left; padding-left: 20px; margin-top: 20px;">
                <div style="width: 100%; background-color: #fff;">
                    <table border="0" style="padding: 0px; margin: 0px;">
                        <tr>
                            <td style="width: 130px; padding-left: 10px; border: 0px; border: 1px solid #efefef;
                                border-right: 0px;">
                                <img src="/imgs/system/wx300_300.png" width="110" /><br />
                            </td>
                            <td valign="top" style="padding: 10px; border: 1px solid #efefef;">
                                <div style="font-size: 12px; font-family: '微软雅黑'; padding-left: 10px;">
                                    <font style="font-size: 18px; line-height: 30px; font-weight: bolder;">去投标网微信公众号</font><br />
                                    <div style="line-height: 25px;">
                                        · 扫一扫微信公众服务号<br />
                                        · 随时随地手机也能在线投标<br />
                                        · 免安装，免升级，更便捷
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="border: 1px solid #efefef; font-weight: 700; font-size: 14px; margin-left: 0px;
                    background-color: #fff; border-bottom: 0px; padding-left: 10px; margin-top: 20px;
                    color: #666; height: 40px; line-height: 40px;">
                    相关地区招标</div>
                <div style="border: 1px solid #ececec; background-color: #fff;">
                    <asp:ListView runat="server" GroupItemCount="3" ID="lstCityList">
                        <LayoutTemplate>
                            <table style="padding: 0px; margin: 0px;">
                                <asp:PlaceHolder runat="server" ID="groupPlaceholder" />
                            </table>
                        </LayoutTemplate>
                        <GroupTemplate>
                            <tr>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </tr>
                        </GroupTemplate>
                        <ItemTemplate>
                            <td style="border: 0px; width: 120px; line-height: 26px; height: 26px; padding-top: 10px;
                                padding-left: 10px; padding-bottom: 5px;">
                                <a href='/Province/index/c/<%# Eval("CityID")%>' style="text-decoration: none;
                                    color: #333; font-size: 12px;">
                                    <%# Eval("CityName")%>招标网</a>
                            </td>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                <%--            <div style="font-weight: bold; margin-top: 20px; border-bottom: 1px solid #000;">
                &nbsp;相关行业招标</div>
            <asp:ListView runat="server" GroupItemCount="4" ID="lstCategoryList">
                <LayoutTemplate>
                    <table style="border: 0px;">
                        <asp:PlaceHolder runat="server" ID="groupPlaceholder" />
                    </table>
                </LayoutTemplate>
                <GroupTemplate>
                    <tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td style="border: 0px;  line-height:24px; height: 24px;">
                        <a href='/Province/index.html?id=<%# Eval("BidCategoryId")%>' style="text-decoration: none;
                            color: #333; font-size: 12px;">
                            <%# Eval("BidCategoryName")%>
                        </a>
                    </td>
                </ItemTemplate>
            </asp:ListView>--%>
                <div style="border: 1px solid #efefef; font-weight: 700; font-size: 14px; margin-left: 0px;
                    background-color: #fff; border-bottom: 0px; padding-left: 10px; margin-top: 20px;
                    color: #666; height: 40px; line-height: 40px;">
                    智能推荐的招标</div>
                <div style="border: 1px solid #ececec; background-color: #fff;">
                    <asp:ListView runat="server" GroupItemCount="1" ID="lstSimilarBid">
                        <LayoutTemplate>
                            <table style="border: 0px;">
                                <asp:PlaceHolder runat="server" ID="groupPlaceholder" />
                            </table>
                        </LayoutTemplate>
                        <GroupTemplate>
                            <tr>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </tr>
                        </GroupTemplate>
                        <ItemTemplate>
                            <td style="border: 0px; line-height: 26px; height: 26px; padding-bottom: 5px; padding-left: 20px;">
                                <a href='/BidDetail/<%# Eval("BidId")%>.html' style="text-decoration: none; color: #333;
                                    font-size: 14px;">
                                    <%# Eval("BidTitle")%>
                                </a>
                            </td>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                <div runat="server" id="divLatestBrowse" style="border: 1px solid #efefef; font-weight: 700;
                    font-size: 14px; margin-left: 0px; background-color: #fff; border-bottom: 0px;
                    padding-left: 10px; margin-top: 20px; color: #666; height: 40px; line-height: 40px;">
                    最近浏览的招标</div>
                <div style="border: 1px solid #ececec; background-color: #fff;">
                    <asp:ListView runat="server" GroupItemCount="1" ID="lstHistory">
                        <LayoutTemplate>
                            <table style="border: 0px;">
                                <asp:PlaceHolder runat="server" ID="groupPlaceholder" />
                            </table>
                        </LayoutTemplate>
                        <GroupTemplate>
                            <tr>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </tr>
                        </GroupTemplate>
                        <ItemTemplate>
                            <td style="border: 0px; line-height: 26px; height: 26px; padding-bottom: 5px; padding-left: 20px;">
                                <a href='/BidDetail/<%# Eval("BidId")%>.html' style="text-decoration: none; color: #333;
                                    font-size: 14px;">
                                    <%# Eval("BidTitle").ToString().Length > 20 ? Eval("BidTitle").ToString().Substring(0, 20) + "..." : Eval("BidTitle").ToString()%>
                                </a>
                            </td>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </div>
    <div id="mask" class="mask">
    </div>
    <div id="divlogin" class="box-body box box-primary box-shadow-3 mask" style="background-color: #fff;
        display: none; opacity: 1; z-index: 1004; filter: alpha(opacity=1); padding: 15px;
        padding-top: 0px; color: #000; height: 380px; width: 360px; position: absolute;
        top: 30%; left: 40%; border-radius: 4px;">
        <div class="row">
            <div class="col-lg-12" style="line-height: 32px; height: 32px; font-size: 14px;">
                帐号登录
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <input type="text" id="txtLoginUserName" class="form-control" placeholder="用户名/手机号/邮箱地址" />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <input type="password" id="txtLoginPassword" class="form-control" placeholder="用户密码" />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-4">
                <input type="text" id="txtUserCheckCode" class="form-control" placeholder="验证码" /></div>
            <div class="col-xs-6">
                <img id="Img1" alt="看不清，请点击我！" onclick="this.src=this.src+'?'" src="/CheckCodeHandler.ashx"
                    style="width: 80px; height: 34px" align="left" />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <button type="button" class="btn btn-primary" id="btnLogin" style="font-weight: 700;
                    height: 40px; width: 100%; font-size: 14px;">
                    <span>立即登录</span>
                </button>
            </div>
            <div class="col-xs-12" style="font-size: 10px; margin-top: 20px; padding: 5px; border-top: 1px solid #dcdcdc;">
                <div class="col-xs-9">
                    <a href="/Default.html" id="lnkregist">还没有账号，先注册</a>
                </div>
                <div class="col-xs-3">
                    <a href="/ForgetPassword.html" id="lnkforget" target="_blank">忘记密码</a>
                </div>
            </div>
        </div>
        <div class="row">
            <div style="float: left; padding-left: 15px; width: 50px; height: 50px;">
                <a id="qqAuthorizationUrl" runat="server" clientidmode="Static" href="/ThirdLogin/qq"
                    class="qq">
                    <img src="/imgs/system/3rdlogin/qq.png" width="40" height="40" /></a>
            </div>
            <div style="float: left; padding-left: 15px; width: 50px; height: 50px;">
                <a id="A2" href="/ThirdLogin/wx" class="qq">
                    <img src="/imgs/system/3rdlogin/WX.png" width="40" height="40" /></a>
            </div>
             <div style="float: left; padding-left: 15px; width: 50px; height: 50px;">
                <a id="A1" href="/ThirdLogin/xl" class="qq">
                    <img src="/imgs/system/3rdlogin/xl.png" width="40" height="40" /></a>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hdnIsLogin" ClientIDMode="Static" />
    <style type="text/css">
        .mask
        {
            position: absolute;
            top: 0px;
            filter: alpha(opacity=0.7);
            background-color: #666;
            z-index: 1002;
            left: 0px;
            opacity: 0.9;
            -moz-opacity: 0.7;
            scroll: none;
        }
    </style>
    <script type="text/javascript">
        Init();

        function Init() {
            if ($("#hdnIsLogin").val() != "True") {
                showMask();
            } else {
                hideMask();
                $("body").css("overflow-y", "scroll");
            }
        }

        function showMask() {
            $("#mask").css("height", $(window).height());
            $("#mask").css("width", $(window).width());
            $("#mask").show();
            $("#divlogin").show();
            $("body").css("overflow-y", "hidden");
        }
        function hideMask() {
            $("#mask").hide();
            $("#divlogin").hide();
            $("body").css("overflow-y", "scroll");

        }

        $("#btnLogin").click(function () {
            var userName = $("#txtLoginUserName").val();
            var pwd = $("#txtLoginPassword").val();
            var userCheckCode = $("#txtUserCheckCode").val();

            if (userName == "") {
                alert('请输入用户名');
                return;
            }
            if (pwd == "") {
                alert('请输入至少6位密码');
                return;
            }
            if (userCheckCode == "") {
                alert('请输入验证码');
                return;
            }

            $.ajax({
                type: "post",
                url: "/SecurityLogin.ashx",
                data: {
                    UserName: userName,
                    PWD: pwd,
                    UserCheckCode: userCheckCode
                },
                success: function (data) {
                    if (data == "OK") {
                        hideMask();
                    }
                    else {
                        alert(data);
                    }
                },
                error: function (msg) {
                    alert(msg.responseText);
                }
            });
        });
    </script>
    <script type="text/javascript">

        //设置网页打印的页眉页脚为空
        function printView() {
            window.print();
        }
        function changeFrameHeight() {
            var ifm = document.getElementById("iframeContent");
            ifm.height = ifm.contentWindow.document.body.scrollHeight;
        }
        window.onresize = function () {
            changeFrameHeight();
        } 
    </script>
    </form>
    <link href="/css/biddetail.css" rel="stylesheet" type="text/css" />
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
</body>
</html>
