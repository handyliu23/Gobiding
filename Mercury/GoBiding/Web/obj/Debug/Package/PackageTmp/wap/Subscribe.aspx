<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Subscribe.aspx.cs" Inherits="TestForWap.Subscribe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="/css/bootstrap.min.css">
    <script src="/js/jquery-3.1.1.min.js"></script>
    <script src="/js/bootstrap.min.js"></script>
    <script src="/js/thirdplugin.js" type="text/javascript"></script>
    <style>
        body
        {
            font-size: 12px;
        }
        .tblIndustry
        {
            width: 90%;
            margin: 0px auto;
        }
        .tblIndustry td
        {
            height: 40px;
        }
        .inactiveIndustry
        {
            font-size: 12px;
            border-radius: 5px;
            width: 60px;
            height: 30px;
            line-height: 30px;
            text-align: center;
            vertical-align: middle;
            background-color: #fafafa;
        }
        .inactiveArea
        {
            font-size: 12px;
            border-radius: 5px;
            width: 50px;
            height: 30px;
            line-height: 30px;
            text-align: center;
            background-color: #fafafa;
        }
        .inactiveTime
        {
            font-size: 12px;
            border-radius: 5px;
            width: 50px;
            height: 30px;
            line-height: 30px;
            text-align: center;
            background-color: #fafafa;
        }
        .inactiveBidType
        {
            font-size: 12px;
            border-radius: 5px;
            width: 60px;
            height: 30px;
            line-height: 30px;
            text-align: center;
            vertical-align: middle;
            background-color: #fafafa;
        }
        .tblArea
        {
            width: 90%;
            margin: 0px auto;
        }
        .tblArea td
        {
            height: 40px;
        }
        .tblBidType
        {
            width: 90%;
            margin: 0px auto;
        }
        .tblBidType td
        {
            height: 40px;
        }
        .tblTime
        {
            width: 90%;
            margin: 0px auto;
        }
        .tblTime td
        {
            height: 40px;
        }
        .choosedDiv
        {
            background-color: coral;
            color: #fff;
        }
    </style>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="myCarousel" class="carousel slide">
        <!-- 轮播（Carousel）指标 -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>
        <!-- 轮播（Carousel）项目 -->
        <div class="carousel-inner">
            <div class="item active">
                <img src="Imgs/sub.jpg" alt="First slide" width="100%" height="300">
            </div>
            <div class="item">
                <img src="Imgs/sub_2.jpg" alt="Second slide" width="100%" height="300">
            </div>
            <div class="item">
                <img src="Imgs/sub_3.png" alt="Third slide" width="100%" height="300">
            </div>
        </div>
        <!-- 轮播（Carousel）导航 -->
        <a class="carousel-control left" href="#myCarousel" data-slide="prev">&lsaquo;</a>
        <a class="carousel-control right" href="#myCarousel" data-slide="next">&rsaquo;</a>
    </div>
    <div style="width: 100%;">
        <div style="width: 100%; border-bottom: 1px solid #dcdcdc; padding: 10px; font-size: 14px;">
            <table>
                <tr>
                    <td>
                        <img src="Imgs/key.png" width="24" height="24" />
                    </td>
                    <td>
                        <span style="font-weight: bolder;">订阅关键词</span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="width: 100%; border-bottom: 1px dotted #dcdcdc; padding: 10px; font-size: 12px;">
            <table>
                <tr>
                    <td style="width: 90px;">
                        <span style="margin-left: 20px;">关键词1</span>
                    </td>
                    <td>
                        <input type="text" id="txtKeyword1" placeholder="例如电子设备 体育器材" style="outline: medium;
                            height: 20px; font-size: 12px; border: 0px; text-decoration: none;" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="width: 100%; border-bottom: 1px dotted #dcdcdc; padding: 10px; font-size: 12px;">
            <table>
                <tr>
                    <td style="width: 90px;">
                        <span style="margin-left: 20px;">关键词2</span>
                    </td>
                    <td>
                        <input type="text" id="txtKeyword2" placeholder="例如家电 家具" style="outline: medium;
                            height: 20px; font-size: 12px; border: 0px;" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="width: 100%; border-bottom: 1px dotted #dcdcdc; padding: 10px; font-size: 12px;">
            <table>
                <tr>
                    <td style="width: 90px;">
                        <span style="margin-left: 20px;">关键词3</span>
                    </td>
                    <td>
                        <input type="text" id="txtKeyword3" placeholder="例如医院 医疗设备" style="outline: medium;
                            height: 20px; font-size: 12px; border: 0px;" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="width: 100%; border-bottom: 1px solid #dcdcdc; padding: 10px; font-size: 14px;">
            <table>
                <tr>
                    <td>
                        <img src="Imgs/industry.png" width="24" height="24" />
                    </td>
                    <td>
                        <span style="font-weight: bolder;">行业订阅</span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="width: 100%; border-bottom: 1px dotted #dcdcdc; padding: 10px; font-size: 12px;">
            <table class="tblIndustry">
                <tr>
                    <td colspan="4">
                        <div class="inactiveIndustry all">
                            <input type="hidden" value="0" />
                            全部</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="inactiveIndustry">
                            <input type="hidden" value="1" />
                            建筑工程</div>
                    </td>
                    <td>
                        <div class="inactiveIndustry">
                            <input type="hidden" value="7" />
                            仪器设备</div>
                    </td>
                    <td>
                        <div class="inactiveIndustry">
                            <input type="hidden" value="14" />
                            办公设备</div>
                    </td>
                    <td>
                        <div class="inactiveIndustry">
                            <input type="hidden" value="18" />
                            医疗卫生</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="inactiveIndustry">
                            <input type="hidden" value="21" />
                            园林环保</div>
                    </td>
                    <td>
                        <div class="inactiveIndustry">
                            <input type="hidden" value="26" />
                            机械设备</div>
                    </td>
                    <td>
                        <div class="inactiveIndustry">
                            <input type="hidden" value="31" />
                            服务行业</div>
                    </td>
                    <td>
                        <div class="inactiveIndustry">
                            <input type="hidden" value="38" />
                            日常生活</div>
                    </td>
                </tr>
            </table>
        </div>
        <div style="width: 100%; border-bottom: 1px solid #dcdcdc; padding: 10px; font-size: 14px;">
            <table>
                <tr>
                    <td>
                        <img src="Imgs/area.png" width="24" height="24" />
                    </td>
                    <td>
                        <span style="font-weight: bolder;">地区订阅</span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="width: 100%; border-bottom: 1px dotted #dcdcdc; padding: 10px; font-size: 14px;">
            <table class="tblArea">
                <tr>
                    <td colspan="4">
                        <div class="inactiveArea all">
                            <input type="hidden" value="0" />
                            全部</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="1" />
                            北京</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="9" />
                            上海</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="2" />
                            天津</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="19" />
                            广东</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="11" />
                            浙江</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="10" />
                            江苏</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="13" />
                            福建</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="12" />
                            安徽</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="17" />
                            湖北</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="18" />
                            湖南</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="16" />
                            河南</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="15" />
                            山东</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="28" />
                            甘肃</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="4" />
                            山西</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="27" />
                            陕西</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="8" />
                            黑龙江</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="7" />
                            吉林</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="6" />
                            辽宁</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="29" />
                            青海</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="5" />
                            内蒙古</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="3" />
                            河北</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="14" />
                            江西</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="25" />
                            云南</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="26" />
                            西藏</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="31" />
                            新疆</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="22" />
                            重庆</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="23" />
                            四川</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="24" />
                            贵州</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="20" />
                            广西</div>
                    </td>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="21" />
                            海南</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="inactiveArea">
                            <input type="hidden" value="30" />
                            宁夏</div>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
        <div style="width: 100%; border-bottom: 1px solid #dcdcdc; padding: 10px; font-size: 14px;">
            <table>
                <tr>
                    <td>
                        <img src="Imgs/date.png" width="24" height="24" />
                    </td>
                    <td>
                        <span style="font-weight: bolder;">时间订阅</span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="width: 100%; border-bottom: 1px dotted #dcdcdc; padding: 10px; font-size: 12px;">
            <table class="tblTime">
                <tr>
                    <td colspan="4">
                        <div class="inactiveTime all">
                            <input type="hidden" value="0" />
                            全部</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="inactiveTime">
                            <input type="hidden" value="1" />
                            一天内</div>
                    </td>
                    <td>
                        <div class="inactiveTime">
                            <input type="hidden" value="2" />
                            三天内</div>
                    </td>
                    <td>
                        <div class="inactiveTime">
                            <input type="hidden" value="3" />
                            一周内</div>
                    </td>
                    <td>
                        <div class="inactiveTime">
                            <input type="hidden" value="4" />
                            半月内</div>
                    </td>
                </tr>
            </table>
        </div>
        <div style="width: 100%; border-bottom: 1px solid #dcdcdc; padding: 10px; font-size: 14px;">
            <table>
                <tr>
                    <td>
                        <img src="Imgs/weixin.png" width="24" height="24" />
                    </td>
                    <td>
                        <span style="font-weight: bolder;">招标类型</span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="width: 100%; border-bottom: 1px dotted #dcdcdc; padding: 10px; font-size: 12px;">
            <table class="tblBidType">
                <tr>
                    <td colspan="4">
                        <div class="inactiveBidType all">
                            <input type="hidden" value="0" />
                            全部</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="inactiveBidType">
                            <input type="hidden" value="4" />
                            招标预告</div>
                    </td>
                    <td>
                        <div class="inactiveBidType">
                            <input type="hidden" value="1" />
                            招标公告</div>
                    </td>
                    <td>
                        <div class="inactiveBidType">
                            <input type="hidden" value="2" />
                            招标变更</div>
                    </td>
                    <td>
                        <div class="inactiveBidType">
                            <input type="hidden" value="3" />
                            中标公告</div>
                    </td>
                </tr>
            </table>
        </div>
        <div style="width: 100%; border-bottom: 1px solid #dcdcdc; padding: 10px; font-size: 12px;">
            <input type="text" id="btnSubmit" value="提交订阅" style="width: 100%; height: 32px;
                font-size: 14px; line-height: 32px; text-align: center; font-weight: bold; color: #fff;
                background-color: Orange; border: 0px;" />
        </div>
    </div>
    <input type="hidden" runat="server" id="hdnSysUserId" />
    <input type="hidden" runat="server" id="IsSubscribed" />
    <input type="hidden" runat="server" id="hdnkeyword1" />
    <input type="hidden" runat="server" id="hdnkeyword2" />
    <input type="hidden" runat="server" id="hdnkeyword3" />
    <input type="hidden" runat="server" id="hdnindustry" />
    <input type="hidden" runat="server" id="hdnarea" />
    <input type="hidden" runat="server" id="hdnbidtype" />
    <input type="hidden" runat="server" id="hdntrackername" />
    <input type="hidden" runat="server" id="hdnbidtime" />
    <input type="hidden" runat="server" id="hdnUserTrackerId" />
    <script type="text/javascript">
        $(function () {
            // 初始化轮播
            $("#myCarousel").carousel('cycle');

            $(".tblIndustry div").click(function () {
                if ($(this).find("input").val() == "0") {
                    $(this).parent().parent().parent().find("div").each(function () { $(this).removeClass("choosedDiv"); });
                }
                else {
                    $(this).parent().parent().parent().find(".all").removeClass("choosedDiv");
                }
                $(this).toggleClass("choosedDiv");
            });
            $(".tblArea div").click(function () {
                if ($(this).find("input").val() == "0") {
                    $(this).parent().parent().parent().find("div").each(function () { $(this).removeClass("choosedDiv"); });
                }
                else {
                    $(this).parent().parent().parent().find(".all").removeClass("choosedDiv");
                }
                $(this).toggleClass("choosedDiv");
            });
            $(".tblTime div").click(function () {
                $(this).parent().parent().parent().find("div").removeClass("choosedDiv");
                $(this).toggleClass("choosedDiv");
            });
            $(".tblBidType div").click(function () {
                if ($(this).find("input").val() == "0") {
                    $(this).parent().parent().parent().find("div").each(function () { $(this).removeClass("choosedDiv"); });
                }
                else {
                    $(this).parent().parent().parent().find(".all").removeClass("choosedDiv");
                }
                $(this).toggleClass("choosedDiv");
            });

            if ($("#IsSubscribed").val() == "T") {
                $("#txtKeyword1").val($("#hdnkeyword1").val());
                $("#txtKeyword2").val($("#hdnkeyword2").val());
                $("#txtKeyword3").val($("#hdnkeyword3").val());

                var industrys = $("#hdnindustry").val();
                var industrysArray = new Array();
                industrysArray = industrys.split(",");
                for (i = 0; i < industrysArray.length; i++) {
                    if (industrysArray[i] != "") {
                        $(".tblIndustry").find("input[value='" + industrysArray[i] + "']").parent().addClass("choosedDiv");
                    }
                }

                var areas = $("#hdnarea").val();
                var areasArray = new Array();
                areasArray = areas.split(",");
                for (i = 0; i < areasArray.length; i++) {
                    if (areasArray[i] != "") {
                        $(".tblArea").find("input[value='" + areasArray[i] + "']").parent().addClass("choosedDiv");
                    }
                }

                var bidttimes = $("#hdnbidtime").val();
                var bidttimesArray = new Array();
                bidttimesArray = bidttimes.split(",");
                for (i = 0; i < bidttimesArray.length; i++) {
                    if (bidttimesArray[i] != "") {
                        $(".tblTime").find("input[value='" + bidttimesArray[i] + "']").parent().addClass("choosedDiv");
                    }
                }

                var bidtypes = $("#hdnbidtype").val();
                var bidtypesArray = new Array();
                bidtypesArray = bidtypes.split(",");
                for (i = 0; i < bidtypesArray.length; i++) {
                    if (bidtypesArray[i] != "") {
                        $(".tblBidType").find("input[value='" + bidtypesArray[i] + "']").parent().addClass("choosedDiv");
                    }
                }
            }

            $("#btnSubmit").click(function () {
                var keyword1 = $("#txtKeyword1").val();
                var keyword2 = $("#txtKeyword2").val();
                var keyword3 = $("#txtKeyword3").val();
                var industry = "";
                $(".tblIndustry .choosedDiv").find("input").each(function () {
                    industry += $(this).val() + ","
                });

                var area = "";
                $(".tblArea .choosedDiv").find("input").each(function () {
                    area += $(this).val() + ","
                });
                var bidtype = "";
                $(".tblBidType .choosedDiv").find("input").each(function () {
                    bidtype += $(this).val() + ","
                });
                var bidtime = "";
                $(".tblTime .choosedDiv").find("input").each(function () {
                    bidtime += $(this).val() + ","
                });
                var userId = $("#hdnSysUserId").val();
                var userTrackerId = $("#hdnUserTrackerId").val();

                //window.location = "/Default.aspx?keyword=" + keyword + "&area=" + area + "&industry=" + industry + "&bidtype=" + bidtype + "&bidtime=" + bidtime + "&userId=" + userId;

                var subscribe = {
                    keyword1: keyword1,
                    keyword2: keyword2,
                    keyword3: keyword3,
                    industry: industry,
                    area: area,
                    bidtype: bidtype,
                    bidtime: bidtime,
                    userId: userId,
                    userTrackerId: userTrackerId
                };

                $.ajax({
                    url: '/wap/handlers/addSubscribe.ashx',
                    data: subscribe,
                    type: 'post',
                    dataType: 'text',
                    success: function (msg) {
                        if (msg == 'Fail') {
                            console.log('添加失败');
                        } else {
                            console.log('操作成功');
                            location.href = "/wap/Default.aspx?UserTrackerId=" + msg;
                        }
                    }
                });
            });
        }); 
    </script>
    </form>
</body>
</html>
