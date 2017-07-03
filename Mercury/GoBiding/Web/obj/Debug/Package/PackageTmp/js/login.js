$(document).ready(function () {
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
            url: "SecurityLogin.ashx",
            data: {
                UserName: userName,
                PWD: pwd,
                UserCheckCode: userCheckCode
            },
            success: function (data) {
                window.location = '/UserCenter/Index.aspx';
            },
            error: function (msg) {
                alert(msg.responseText);
            }
        });
    });
});
