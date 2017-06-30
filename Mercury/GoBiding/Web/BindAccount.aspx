<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BindAccount.aspx.cs"
    Inherits="GoBiding.Web.BindAccount" %>

<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>绑定用户_去投标网_中国最大的免费招投标服务平台_在线招标投标服务平台_最新招标信息_让投标变得更简单</title>
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <meta name="keywords" content="忘记密码,去投标网,招标信息,招标,招投标,招标公告,招标预告,政府招标,采购信息" />
    <meta name="description" content="投标网是中国第一家免费的招标信息服务平台，招标信息最全、覆盖地区及招标行业最广的招标网，每天更新超过10000条各类招标项目信息；去投标网已成为政府、招标单位、业主招标采购的首选平台,让投标变得更简单,要投标就上去投标网。" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body style="background-color: #fafafa;">
    <form id="form1" runat="server">
    <uc2:Top ID="Top1" runat="server" />
    <div style="width: 70%; border: 1px solid #fff; background-color: #fff; padding: 10px;
        margin: 0px auto; font-family: '微软雅黑'; margin-top: 5%; padding-bottom:40px;">
        <div style="font-size: 16px; font-weight: bold; margin-left: 10px; padding-left: 10px;
            margin-top: 10px; border-left: 4px solid #000;">
            绑定用户
        </div>
        <br />
        <br />
        <table style="width: 90%; margin-left: 40px;">
            <tr>
                <td style="width: 50%; padding-left: 20px; line-height: 30px; color: #333; border-right: 1px solid #ececec;
                    vertical-align: top;">
                    未注册过去投标网，请绑定新帐户
                    <br />
                    <div style="margin-top: 20px;">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="height: 50px; width: 90px; vertical-align: top;">
                                    邮箱地址
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtNewEmail" Text="" placeholder="请输入新帐户的邮箱地址" Width="240"
                                        class="form-control"></asp:TextBox>
                                    <font style="color: #666; font-size: 11px;">* 邮箱地址作为找回密码的重要依据，请仔细填写。</font>
                                </td>
                            </tr>
                             <tr>
                                <td style="height: 50px; width: 90px; ">
                                    企业名称
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCompanyName" Text="" placeholder="请输入企业名称" Width="240"
                                        class="form-control"></asp:TextBox>
                                    <font style="color: #666; font-size: 11px;"></font>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="height: 50px;">
                                    <div class="btn btn-primary" style="width: 100px;" id="newLogin">
                                        确认</div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <br />
                    <%--<div style="font-size: 10px;">为了提供更好的服务建议绑定邮箱地址，您也可以暂不绑定，<a href="" class="hrefSkip">继续之前的访问</a></div>--%>
                </td>
                <td style="width: 50%; padding-left: 50px; line-height: 30px; color: #333; vertical-align: top;">
                    已经注册过去投标网，绑定现有帐户
                    <div style="margin-top: 20px;">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="height: 50px; width: 90px; vertical-align: top;">
                                    邮箱地址
                                </td>
                                <td style="vertical-align: top;">
                                    <asp:TextBox runat="server" ID="txtOldEmail" Text="" placeholder="请输入已有帐户的邮箱地址" Width="240"
                                        class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 50px; width: 90px;">
                                    登录密码
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" placeholder="请输入至少6位包含数字字母"
                                        Width="240" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                             <tr>
                                <td style="height: 50px; width: 90px;">
                                    企业名称
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCompanyName2" Text="" placeholder="请输入企业名称" Width="240"
                                        class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="height: 50px;">
                                    <div class="btn btn-primary" style="width: 100px;" id="oldLogin">
                                        确认</div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);  //获取url中"?"符后的字符串并正则匹配
            var context = "";
            if (r != null)
                context = r[2];
            reg = null;
            r = null;
            return context == null || context == "" || context == "undefined" ? "" : context;
        }

        $(".hrefSkip").click(function () {
            self.location = "http://www.gobiding.com/Default.html";
        });

        $("#newLogin").click(function () {
            $.ajax({
                type: "post",
                url: "/BindAccountHandle.ashx",
                data: {
                    Email: $("#txtNewEmail").val(),
                    Type: "new",
                    CompanyName: $("#txtCompanyName").val()
                },
                success: function (data) {
                    if (data == "OK") {
                        if (document.location.href.indexOf("bId") > 0 && GetQueryString("bId") != '') {
                            self.location = "http://www.gobiding.com/BidDetail/" + GetQueryString("bId") +".html";
                        } else {
                            self.location = "http://www.gobiding.com/Default.html";
                        }
                    }
                    else {
                        alert(data);
                    }
                },
                error: function (msg) {
                    setTimeout("pause()", 1000);
                    initLoginPanel();
                }
            });
        });

        $("#oldLogin").click(function () {
            $.ajax({
                type: "post",
                url: "/BindAccountHandle.ashx",
                data: {
                    Email: $("#txtOldEmail").val(),
                    Password: $("#txtPassword").val(),
                    CompanyName: $("#txtCompanyName2").val(),
                    Type: "old"
                },
                success: function (data) {
                    if (data == "OK") {
                        if (document.location.href.indexOf("bId") > 0 && GetQueryString("bId") != '') {
                            self.location = "http://www.gobiding.com/BidDetail/" + GetQueryString("bId") + ".html";
                        } else {
                            self.location = "http://www.gobiding.com/Default.html";
                        }
                    }
                    else {
                        alert(data);
                    }
                },
                error: function (msg) {
                    alert(msg);
                }
            });
        });

    </script>
    </form>
</body>
</html>
