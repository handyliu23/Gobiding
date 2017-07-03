<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wapRegist.aspx.cs" Inherits="GoBiding.Web.wap.wapRegist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="viewport" content="height=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=0">
    <title>去投标网_免费招标采购信息平台_上海商麓网络科技有限公司官方平台_农产品采购信息_设备招标信息_网络招标信息</title>
    <script src="/js/jquery-3.1.1.min.js"></script>
    <link rel="stylesheet" href="css/common.css" />
    <link rel="stylesheet" href="css/register.css" />
</head>
<body>
    <form id="form1" runat="server">
    <script>
        $(document).ready(function () {
            $("#typeselect").change(function () {
                $("#hdnuserType").val($(this).val());
            });

            $("#btnRegist").click(function () {
                var userName = $("#txtLoginUserName").val();
                var pwd = $("#txtLoginPassword").val();
                var email = $("#txtEmail").val();
                var companyName = $("#txtCompanyName").val();

                var userCheckCode = "noneed";
                if (userName == "") {
                    alert('请输入用户名');
                    return false;
                }
                if (pwd == "") {
                    alert('请输入至少6位密码');
                    return false;
                }
                if (pwd.length < 6) {
                    alert('请输入至少6位密码');
                    return false;
                }
                if (email == "") {
                    alert('请输入邮箱地址');
                    return false;
                }
                if (companyName == "") {
                    alert('请输入公司名称');
                    return false;
                }
                if ($("#hdnuserType").val() == "" || $("#hdnuserType").val() == "0") {
                    alert('请选择用户类型');
                    return false;
                }
                if ($("#agreeProtocol").attr('checked')) {
                    alert('注册前请先阅读注册协议');
                    return false;
                }

                $.ajax({
                    type: "post",
                    url: "/Regist.ashx",
                    data: {
                        UserNickName: userName,
                        Password: pwd,
                        Email: email,
                        UserName: userName,
                        CompanyPosition: "",
                        CompanyName: companyName,
                        UserType: $("#hdnuserType").val()
                    },
                    success: function (data) {
                        if (data == 'OK') {
                            location.href = "/wap/Default.aspx";
                            setTimeout(function () {
                                var body = document.getElementsByTagName('body');
                                body[0].style.display = 'none';
                                location.href = "/wap/Default.aspx";
                            }, 10);
                        } else {
                            alert(data);
                        }
                    },
                    error: function (msg) {
                        location.href = "/wap/Default.aspx";
                        setTimeout(function () {
                            var body = document.getElementsByTagName('body');
                            body[0].style.display = 'none';
                            location.href = "/wap/Default.aspx";
                        }, 10);
                    }
                });

            });

        });
    </script>
    <div class="register">
        <div class="regTop">
            <span>用户注册</span> <a class="back" href="wapLogin.aspx">&lt;&nbsp;返回</a>
        </div>
        <div class="content">
            <div class="point">
                <span>注册成功后，手机号也可为登录账号。</span>
            </div>
            <form action="">
            <div class="message">
                <input id="txtLoginUserName" style="border: 1px solid #ececec; margin-top: 10px;"
                    type="tel" placeholder="输入用户名" pattern="[0-9]{11}" required />
                <input id="txtLoginPassword" style="border: 1px solid #ececec; margin-top: 10px;"
                    type="password" placeholder="请输入6-25位密码" pattern="[0-9A-Za-z]{6,25}" required />
                <input id="txtEmail" style="border: 1px solid #ececec; margin-top: 10px;" type="text"
                    placeholder="请输入邮箱地址" pattern="" required />
                <input id="txtCompanyName" style="border: 1px solid #ececec; margin-top: 10px;" type="text"
                    placeholder="请输入公司名称" pattern="" required />
                <select name="job" id="typeselect" style="padding-left: 0px; margin-left: 0px;">
                    <option value="0">选择用户类型</option>
                    <option value="1">投标商</option>
                    <option value="2">招标商</option>
                </select>
                <div class="icons">
                    <b>
                        <img src="images/zc-1.jpg" alt="" /></b> <b>
                            <img src="images/zc-2.jpg" alt="" /></b> <b>
                                <img src="images/zc-3.jpg" alt="" /></b> <b>
                                    <img src="images/email.png" alt="" /></b>
                </div>
            </div>
            <div class="agree">
                <input type="checkbox" id="agreeProtocol" /><span>&nbsp;同意&nbsp;</span><a href="">《注册协议》</a>
            </div>
            <button class="submit" id="btnRegist" type="submit">
                注册</button>
            </form>
        </div>
    </div>
    <input type="hidden" id="hdnuserType" />
    </form>
</body>
</html>
