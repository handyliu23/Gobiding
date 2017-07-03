<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GoBiding.Web.Login" %>

<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <title>登录去投标网_中国最大的免费招投标服务平台_在线招标投标服务平台_最新招标信息_让投标变得更简单</title>
    <meta name="keywords" content="去投标网,招标信息,招标,招投标,招标公告,招标预告,政府招标,采购信息" />
    <meta name="description" content="投标网是中国第一家免费的招标信息服务平台，招标信息最全、覆盖地区及招标行业最广的招标网，每天更新超过10000条各类招标项目信息；去投标网已成为政府、招标单位、业主招标采购的首选平台,让投标变得更简单,要投标就上去投标网。" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="shortcut icon" type="image/x-icon" href="/imgs/system/logo_16_16.png" media="screen" />

    <link href="/css/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc2:Top ID="Top1" runat="server" />
    <div class="blur" style="width: 100%; height: 460px;">
        <div class="container" style="position: relative; left: 0px; top: 0px;">
            <div class="row">
                <div style="color: #fff; font-family: 微软雅黑; position: absolute; top: 70px; height: 400px;">
                    <span style="font-size: 44px;">只为投标变得更简单</span><br />
                    <br />
                    <span style="color: #fff; font-size: 20px; line-height: 40px;">万家商户推荐 品质值得信赖</span><br />
                    <span style="color: #fff; font-size: 20px; line-height: 40px;">海量信息订阅 智能匹配推送</span><br />
                    <span style="color: #fff; font-size: 20px; line-height: 40px;">手机微信app, 动动手指就能轻松招投标</span><br />
                    <br />
                    <span style="color: #fff; font-size: 14px; line-height: 40px; border: 1px solid #fafafa;
                        border-radius: 5px; padding: 5px 10px 5px 10px;">免费申请去投标网会员 </span>
                    <br />
                </div>
                <div class="box box-primary box-shadow-3" id="divlogin" style="position: absolute;
                    top: 70px; right: 10px; width: 320px; filter: alpha(opacity=95); -moz-opacity: 0.95;
                    -khtml-opacity: 0.99; opacity: 0.95; background-color: #fff; padding: 20px; margin-top: -30px;
                    color: #000; height: 360px; border-radius: 4px;">
                    <div class="box-body">
                        <div class="row">
                            <div class="col-xs-12">
                                <br />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <input type="text" id="txtLoginUserName" runat="server" clientidmode="Static" class="form-control" placeholder="用户名/手机号/邮箱地址"/>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-xs-12">
                                <input type="password" id="txtLoginPassword"  runat="server" clientidmode="Static" class="form-control" placeholder="用户密码"/>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-xs-4">
                                <input type="text" id="txtUserCheckCode" class="form-control" placeholder="验证码" /></div>
                            <div class="col-xs-6">
                                <img id="Img1" alt="看不清，请点击我！" onclick="this.src=this.src+'?'" src="CheckCodeHandler.ashx"
                                    style="width: 80px; height: 34px" align="left" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-xs-12">
                                <button type="button" class="btn btn-primary" id="btnLogin" style="font-weight: 700;
                                    height: 40px; width: 100%; font-size: 14px;">
                                    <span>立即登录</span>
                                </button>
                            </div>
                            <div class="col-xs-12" style="font-size: 10px; margin-top: 10px; padding: 5px; border-top: 1px solid #dcdcdc;">
                                <div class="col-xs-8">
                                    <a href="http://www.gobiding.com" id="lnkregist">还没有账号，先注册</a>
                                </div>
                                <div class="col-xs-4" style="text-align: right;">
                                    <a href="ForgetPassword.html" id="lnkforget">忘记密码</a>
                                </div>
                            </div>
                            <div class="col-xs-12" align="right" style="font-size: 11px; padding: 10px; color: #333;">
                            </div>
                           <div style="float: left; padding-left: 15px; width: 50px; height: 50px;">
                                    <a id="qqAuthorizationUrl" href="/ThirdLogin/qq" class="qq">
                                        <img src="/imgs/system/3rdlogin/qq.png" width="40" height="40" /></a>
                                </div>
                                <div style="float: left; padding-left: 15px; width: 50px; height: 50px;">
                                    <a id="linkwx" href="/ThirdLogin/wx" class="wx" style="width: 40px; height: 40px;">
                                        <img src="/imgs/system/3rdlogin/WX.png" width="40" height="40" /></a>
                                </div>
                                   <div style="float: left; padding-left: 15px; width: 50px; height: 50px;">
                                    <a id="A1" href="/ThirdLogin/xl" class="xl" style="width: 40px; height: 40px;">
                                        <img src="/imgs/system/3rdlogin/xl.png" width="40" height="40" /></a>
                                </div>
                            <%--  <div style="padding-left: 10px;">
                                <a href="#" onclick='toLogin()'>
                                    <img src="/imgs/system/Connect_logo_1.png" alt=""></a>
                            </div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="container">
        <div class="row">
            <div style="margin: 0px auto; font-family: 微软雅黑;">
                <div style="width: 25%; float: left;">
                    <div style="width: 30px; height: 30px; line-height: 28px; font-weight: bold; color: #428bca;
                        border-radius: 15px; border: 2px solid #428bca; text-align: center;">
                        1</div>
                    <div style="border-top: 2px solid #428bca; position: relative; top: -18px; left: 36px;
                        width: 80%;">
                        <div style="padding: 10px; font-weight: bold; font-size: 16px; color: #333;">
                            注册会员</div>
                    </div>
                    <div style="width: 80%; line-height: 24px; color: #999;">
                        申请成为去投标网会员既可免费查看发布海量招投标及采购信息，代理招标机构需实名认证
                    </div>
                </div>
                <div style="width: 25%; float: left;">
                    <div style="width: 30px; height: 30px; line-height: 28px; font-weight: bold; color: #428bca;
                        border-radius: 15px; border: 2px solid #428bca; text-align: center;">
                        2</div>
                    <div style="border-top: 2px solid #428bca; position: relative; top: -18px; left: 36px;
                        width: 80%;">
                        <div style="padding: 10px; font-weight: bold; font-size: 16px; color: #333;">
                            搜索招标</div>
                    </div>
                    <div style="width: 80%; line-height: 24px; color: #999;">
                        每日更新1万条全国招标采购信息，支持关键词多维度全文检索，毫秒级响应服务
                    </div>
                </div>
                <div style="width: 25%; float: left;">
                    <div style="width: 30px; height: 30px; line-height: 28px; font-weight: bold; color: #428bca;
                        border-radius: 15px; border: 2px solid #428bca; text-align: center;">
                        3</div>
                    <div style="border-top: 2px solid #428bca; position: relative; top: -18px; left: 36px;
                        width: 80%;">
                        <div style="padding: 10px; font-weight: bold; font-size: 16px; color: #333;">
                            订阅招标</div>
                    </div>
                    <div style="width: 80%; line-height: 24px; color: #999;">
                        注册会员根据关键词、地区、行业、分类设置招标订阅，系统多渠道发送订阅招标信息提醒
                    </div>
                </div>
                <div style="width: 25%; float: left;">
                    <div style="width: 30px; height: 30px; line-height: 28px; font-weight: bold; color: #428bca;
                        border-radius: 15px; border: 2px solid #428bca; text-align: center;">
                        4</div>
                    <div style="border-top: 2px solid #428bca; position: relative; top: -18px; left: 36px;
                        width: 80%;">
                        <div style="padding: 10px; font-weight: bold; font-size: 16px; color: #333;">
                            特殊定制</div>
                    </div>
                    <div style="width: 80%; line-height: 24px; color: #999;">
                        高级会员可以享受定制服务，专业技术一对一，专门推送您指定关注的招标站点信息
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div style="border-top: 1px solid #fafafa; width: 100%; text-align: center; background-color: #242735;
        color: #fff; margin-top: 20px; padding-bottom: 20px;">
        <div style="width: 100%; text-align: center; padding-top: 20px; font-family: '微软雅黑'">
            <div style="line-height: 24px; margin: 0px auto; font-size: 12px;">
                去投标网（上海商麓网络科技有限公司）All Rights Reserved<br />
                2015-2017 gobiding.com 版权所有 ICP证：沪ICP备15005938号-3
            </div>
        </div>
    </div>
    <script src="/js/thirdplugin.js" type="text/javascript"></script>
    <script src="/js/login.js" type="text/javascript"></script>
    <script>
        $("#txtUserCheckCode").keydown(function (e) {
            if (e.keyCode == 13) {
                $("#btnLogin").click();
            }
        });
    </script>
    </form>
</body>
</html>
