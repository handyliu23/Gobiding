<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThirdLogin.aspx.cs" Inherits="GoBiding.Web.ThirdLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>第三方登录_去投标网_上海免费招标服务平台</title>
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <script src="/UserCenter/js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://qzonestyle.gtimg.cn/qzone/openapi/qc_loader.js"
        data-appid="101405089" data-redirecturi="http://www.gobiding.com" charset="utf-8"></script>
    <script type="text/javascript" src="http://qzonestyle.gtimg.cn/qzone/openapi/qc_loader.js"
        charset="utf-8" data-callback="true"></script>

    <script src="http://tjs.sjs.sinajs.cn/open/api/js/wb.js?appkey=1366921169" type="text/javascript" charset="utf-8"></script>
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

        var paras = {};
        //用js SDK调用OpenAPI
        QC.api("get_user_info", paras)
        //指定接口访问成功的接收函数，s为成功返回Response对象
                .success(function (s) {
                    //成功回调，通过s.data获取OpenAPI的返回数据
                    QC.Login.getMe(function (openId, accessToken) {
                        qq_Login(s, openId, accessToken); //对应JS的qq_Login()的方法，继续往下看
                    })
                })
        //指定接口访问失败的接收函数，f为失败返回Response对象
                .error(function (f) {
                    //失败回调
                    qq_error(f); //这个地方可以自动以逻辑处理，也可以不处理，就是请求失败的提示
                })
        //指定接口完成请求后的接收函数，c为完成请求返回Response对象
                .complete(function (c) {
                    //完成请求回调
                    // qq_complete(c);
                });

        //QQ登录
        function qq_Login(s, openId, accessToken) {
            $.ajax({
                type: "post",
                url: "/logingateway.ashx",
                data: {
                    UserNickName: s.data.nickname,
                    Profile: s.data.figureurl_1,
                    Gender: s.data.gender,
                    AccessToken: accessToken,
                    OpenId: openId,
                    ThirdLoginPartyName: "QQ"
                },
                success: function (data) {
                    if (data == "OK") {
                        //已第三方登录且有绑定过邮箱
                        if (document.location.href.indexOf("urlredirect") > 0 && GetQueryString("urlredirect") != '') {
                            self.location = "http://www.gobiding.com/BidDetail/" + GetQueryString("urlredirect") + ".html";
                        }
                        else {
                            setTimeout("pause()", 1000);
                            self.location = "http://www.gobiding.com/"
                        }
                    }
                    else if (data == "Bind") {
                        var urlredirect = "";
                        if (document.location.href.indexOf("urlredirect") > 0 && GetQueryString("urlredirect") != '') {
                            urlredirect = "?bId=" + +GetQueryString("urlredirect");
                        }
                        self.location = "http://www.gobiding.com/BindAccount.html" + urlredirect;
                    }
                    else {
                        alert(data);
                    }
                },
                error: function (msg) {
                    setTimeout("pause()", 1000);
                }
            });
        }

        function logout() {
            QC.Login.signOut();
            return true;
        }

        (function ($) {
            $.fn.scrollTop = function (options) {
                var defaults = {
                    speed: 30
                }
                var opts = $.extend(defaults, options);
                this.each(function () {
                    var $timer;
                    var scroll_top = 0;
                    var obj = $(this);
                    var $height = obj.find("ul").height();
                    obj.find("ul").clone().appendTo(obj);
                    obj.hover(function () {
                        clearInterval($timer);
                    }, function () {
                        $timer = setInterval(function () {
                            scroll_top++;
                            if (scroll_top > $height) {
                                scroll_top = 0;
                            }
                            obj.find("ul").first().css("margin-top", -scroll_top);
                        }, opts.speed);
                    }).trigger("mouseleave");
                })
            }
        })(jQuery)
        $(document).ready(function () {
            if (document.location.href.indexOf("qq") > 0) {
                window.location.href = "https://graph.qq.com/oauth2.0/authorize?client_id=101405089&response_type=token&scope=all&redirect_uri=http%3A%2F%2Fwww.gobiding.com/ThirdLogin.aspx";
            }
        });

        WB2.anyWhere(function (W) {
            W.widget.connectButton({
                id: "wb_connect_btn",
                type: "3,2",
                callback: {
                    login: function (o) {	//登录后的回调函数
                        alert('123');
                    },
                    logout: function () {	//退出后的回调函数
                        alert('123');
                    }
                }
            });
        });
    </script>
    <script>
        //微信登录
        $(document).ready(function () {
            if ($("#hdnUserNickName").val() == null || $("#hdnUserNickName").val() == "") {
                return;
            }

            if (document.location.href.indexOf("wx") > 0) {
                $.ajax({
                    type: "post",
                    url: "/logingateway.ashx",
                    data: {
                        UserNickName: $("#hdnUserNickName").val(),
                        Profile: $("#hdnProfile").val(),
                        Gender: $("#hdnGender").val(),
                        AccessToken: $("#hdnAccessToken").val(),
                        OpenId: $("#hdnOpenId").val(),
                        ThirdLoginPartyName: "WeiXin"
                    },
                    success: function (data) {
                        if (data == "OK") {
                            //已第三方登录且有绑定过邮箱
                            if (document.location.href.indexOf("urlredirect") > 0 && GetQueryString("urlredirect") != '') {
                                self.location = "http://www.gobiding.com/BidDetail/" + GetQueryString("urlredirect") + ".html";
                            }
                            else {
                                setTimeout("pause()", 1000);
                                self.location = "http://www.gobiding.com/"
                            }
                        }
                        else if (data == "Bind") {
                            var urlredirect = "";
                            if (document.location.href.indexOf("urlredirect") > 0 && GetQueryString("urlredirect") != '') {
                                urlredirect = "?bId=" + +GetQueryString("urlredirect");
                            }
                            self.location = "http://www.gobiding.com/BindAccount.html" + urlredirect;
                        }
                        else {
                            alert(data);
                        }
                    },
                    error: function (msg) {
                        setTimeout("pause()", 1000);
                    }
                });
            }
        });
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField runat="server" ID="hdnUserNickName" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hdnProfile" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hdnAccessToken" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hdnGender" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hdnOpenId" ClientIDMode="Static" />
    <div>
    </div>
    </form>
</body>
</html>
