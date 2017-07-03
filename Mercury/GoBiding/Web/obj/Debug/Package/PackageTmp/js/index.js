$(document).ready(function () {


    $(".dropdown_content_areas td").click(function () {
        $("#btn_dropdown_selectarea").html($(this).html());
        $("#hdnarea").val($(this).find("span").html());
    });

    $(".ul_dropdown_industry li").click(function () {
        $("#btn_dropdown_selectindustry").html($(this).html());
        $("#hdnindustry").val($(this).val());
    });

    $(".ul_dropdown_bidtype li").click(function () {
        $("#btn_dropdown_selectbidtype").html($(this).html());
        $("#hdnbidtype").val($(this).val());
    });

    $("#hreflogin").click(function () {
        $("#divregist").hide();
        $("#divlogin").show();
    });

    $("#lnkregist").click(function () {
        $("#divregist").show();
        $("#divlogin").hide();
    });

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
                if (data == "OK")
                {
                    window.location = '/Default.aspx';
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

    $("#btnSearch").click(function () {
        var keyword = $("#txtSearchKeyword").val();
        var area = $("#hdnarea").val();
        var industry = $("#hdnindustry").val();
        var bidtype = $("#hdnbidtype").val();

        window.location = "/BidList.aspx?keyword=" + keyword + "&area=" + area + "&industry=" + industry + "&bidtype=" + bidtype;
    });

    $(".ul_dropdown_usertype li").click(function () {
        $("#btnUserType").html($(this).html());
        $("#hdnuserType").val($(this).val());
    });

    $("#btnRegist").click(function () {
        var usernickname = $("#txtUserNickName").val();
        var pwd = $("#txtPassword").val();
        var companyname = $("#txtCompanyName").val();
        var username = $("#txtUserName").val();
        var position = $("#txtPosition").val();
        var email = $("#txtEmail").val();
        var UserType = $("#txtEmail").val();


        if (usernickname == "") {
            alert('请输入用户名');
            return;
        }
        if (pwd == "") {
            alert('请输入密码');
            return;
        }
        if (email == "") {
            alert('请输入邮箱地址');
            return;
        }
        if (companyname == "") {
            alert('请输入公司名称');
            return;
        }
        if ($("#hdnuserType").val() == "0") {
            alert('请选择用户类型');
            return;
        }
        if (username == "") {
            alert('请输入联系人姓名');
            return;
        }
        if (position == "") {
            alert('请输入联系人职位');
            return;
        }

        $.ajax({
            type: "post",
            url: "Regist.ashx",
            data: {
                UserNickName: usernickname,
                Password: pwd,
                CompanyName: companyname,
                CompanyPosition: position,
                UserName: username,
                Email: email,
                UserType: $("#hdnuserType").val()
            },
            success: function (data) {
                if (data == "OK") {
                    alert('注册成功！');
                    location.reload();
                } else {
                    alert(data);
                }
            },
            error: function (msg) {
                alert(msg);
            }
        });
    });

});

function toLogin() {
    //以下为按钮点击事件的逻辑。注意这里要重新打开窗口
    //否则后面跳转到QQ登录，授权页面时会直接缩小当前浏览器的窗口，而不是打开新窗口
    var A = window.open("oauth/QQLogin.aspx", "TencentLogin", "width=450,height=320,menubar=0,scrollbars=1,resizable=1,status=1,titlebar=0,toolbar=0,location=1");
} 
