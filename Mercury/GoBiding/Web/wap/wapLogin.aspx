<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wapLogin.aspx.cs" Inherits="GoBiding.Web.wap.wapLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <title>去投标网_免费招标采购信息平台_上海商麓网络科技有限公司官方平台_农产品采购信息_设备招标信息_网络招标信息</title>
    <link rel="stylesheet" href="css/common.css" />
    <link rel="stylesheet" href="css/login.css" />
    <style>
        .login_bg
        {
            background: #ffffff;
        }
        .login_btn
        {
            width: 80%;
            margin: 10%;
        }
        .other_login
        {
            top: 70%;
        }
        .other_choose
        {
            top: 80%;
        }
    </style>
</head>
<body>
    <div id="login">
    </div>
    <div class="login_bg">
        <div id="logo">
            <img src="/wap/Imgs/logo.png" alt="" />
        </div>
        <br />
        <form>
        <div class="userName">
            <lable>用户名：</lable>
            <input type="text" name="name" id="txtLoginUserName" placeholder="请输入用户名" pattern="[0-9A-Za-z]{6,16}"
                required />
        </div>
        <div class="passWord">
            <lable>密&nbsp;&nbsp;&nbsp;&nbsp;码：</lable>
            <input type="password" name="password" id="txtLoginPassword" placeholder="请输入密码"
                pattern="[0-9A-Za-z]{6,25}" required />
        </div>
        <div class="choose_box">
            <div>
                <a href="/wap/wapRegist.aspx">立即注册</a>
            </div>
            <a href="newPassword.html">忘记密码</a>
        </div>
        <input type="button" class="login_btn" id="btnLogin" value="登&nbsp;&nbsp;录"></input>
        </form>
        <!--  <div class="other_login">
            <div class="other">
            </div>
            <span>其他方式登录</span>
            <div class="other">
            </div>
        </div>
        <div class="other_choose">
            <a href="">
                <img src="images/qq.png" alt="" />
            </a><a href="">
                <img src="images/wx.png" alt="" />
            </a><a href="">
                <img src="images/wb.png" alt="" />
            </a>
        </div>-->
    </div>
    <script src="../js/jquery-3.1.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnLogin").click(function () {
                var userName = $("#txtLoginUserName").val();
                var pwd = $("#txtLoginPassword").val();

                if (userName == "") {
                    alert('请输入用户名');
                    return;
                }
                if (pwd == "") {
                    alert('请输入至少6位密码');
                    return;
                }

                $.ajax({
                    type: "post",
                    url: "handlers/waplogin.ashx",
                    data: {
                        UserName: userName,
                        PWD: pwd
                    },
                    dataType: 'text',
                    success: function (result) {
                        if (result == "OK") {
                            location.href = "/wap/Default.aspx";
                            setTimeout(function () {
                                var body = document.getElementsByTagName('body');
                                body[0].style.display = 'none';
                                location.href = "/wap/Default.aspx";
                            }, 10);
                            //$("#divLoginSuccess").show(); 
                        }
                        else {
                            alert(result);
                        }
                    }
                });
            });
        });

    </script>
    <div id="divLoginSuccess" style="position: absolute; width: 100%; height: 100%; display: none;
        background-color: #fcfcfc;">
        <div style="margin-top: 60%; text-align: center; line-height: 40px; background-color: #fcfcfc;
            width: 100%; height: 40px;">
            <a id="hrefSuccess" href="/wap/Default.aspx">登录成功! 点击进入去投标网</a>
        </div>
    </div>
</body>
</html>
