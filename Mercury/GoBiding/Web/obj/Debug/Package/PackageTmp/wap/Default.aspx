<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GoBiding.Web.wap.Default" %>

<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<%@ Register Src="UserControls/Bottom.ascx" TagName="Bottom" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>去投标网</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
    <script src="/js/jquery-3.1.1.min.js" type="text/javascript"></script>
    <script src="/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="/js/thirdplugin.js" type="text/javascript"></script>
    <link href="/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <style>
        body
        {
            font-size: 12px;
            color: #000;
            width: 100%;
            overflow-x: hidden;
            overflow-y: hidden;
            font-family: "Microsoft YaHei" !important;
        }
        a
        {
            text-decoration: none;
            color: #000;
        }
        div
        {
            font-size: 14px;
        }
        span
        {
            font-size: 14px;
            color: #333;
        }
        .table-hover span
        {
            word-wrap: break-word;
        }
        table td
        {
            border-width: 0px;
        }
        #tblSearchCondition
        {
            width: 100%;
        }
        #tblSearchCondition td
        {
            font-size: 12px;
            width: 33%;
            text-align: center;
            line-height: 40px;
            color: #999;
            border: 1px solid #FAFAFA;
        }
        .pagination li a
        {
            color: #333;
            font-size: 10px;
        }
        .tblIndustry
        {
            width: 90%;
            margin: 0px auto;
        }
        .tblIndustry td
        {
            width: 120px;
            height: 40px;
        }
        .tblBidType
        {
            width: 90%;
            margin: 0px auto;
        }
        .tblBidType td
        {
            width: 120px;
            height: 40px;
        }
        .bidlabel, .bidlabel a
        {
            text-decoration: none;
            background-color: orange;
            border-radius: 4px;
            color: white;
            padding: 3px 5px 3px 5px;
            font-size: 13px;
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
        .inactiveIndustry
        {
            font-size: 12px;
            border-radius: 5px;
            width: 80px;
            height: 30px;
            line-height: 30px;
            text-align: center;
            vertical-align: middle;
            background-color: #fafafa;
        }
        .inactiveBidType
        {
            font-size: 12px;
            border-radius: 5px;
            width: 80px;
            height: 30px;
            line-height: 30px;
            text-align: center;
            vertical-align: middle;
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
        .choosedDiv
        {
            background-color: coral;
            color: #fff;
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
        
        .conditiondivshow
        {
            display: ;
        }
        
        .conditiondivhide
        {
            display: none;
        }
    </style>
    <script>
        if (document.location.href.indexOf("code") > 0)
            alert(location.href);
        if (document.location.href.indexOf("platform=wx") > 0) {
            //开放平台
            //location.href = "https://open.weixin.qq.com/connect/qrconnect?appid=wx81f6ea9d32b5e8ef&redirect_uri=http%3A%2F%2Fwww.gobiding.com/ThirdLogin.aspx?opt=wx&response_type=code&scope=snsapi_login&state=STATE";

            //公众平台
            //location.href = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx29fcc0c33f69b37f&redirect_uri=https%3A%2F%2Fwww.gobiding.com/wap/Default.aspx?test=1&response_type=code&scope=snsapi_base&state=123#wechat_redirect";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <img src="../imgs/ad/ad_m_2.gif" style="width: 100%; height: 48px;" alt="" />
    <div class="container" style="width: 100%; padding: 0px; margin: 0px;">
        <div class="row" id="divTop" runat="server" style="width: 100%; padding: 0px; margin: 0px; height: 40px; line-height: 40px;
            border-bottom: 1px solid #ececec;">
            <div class="col-lg-12" style="width: 100%; padding-left: 10px; margin: 0px;">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 68%;">
                            <img src="/imgs/system/admin.png" width="16" height="16" style="margin-top: -6px;" />&nbsp;去投标网会员：<asp:Literal
                                runat="server" ID="ltrUserName"></asp:Literal>
                        </td>
                        <td style="width: 20%;">
                            <a href="/wap/Default.aspx">招标大厅</a>
                        </td>
                        <td style="width: 12%; text-align: right;">
                            <a href="Logout.aspx" runat="server" id="logouthref" clientidmode="Static">注销</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row" style="width: 100%; padding: 0px; margin: 0px;" id="divTrackerInfo"
            runat="server">
            <div class="col-lg-12" style="width: 100%; padding: 10px; margin: 0px; border-bottom: 1px solid #ececec;">
                <table>
                    <tr>
                        <td>
                            <div style="padding-left:20px; text-align:center;">
                                <img src="Imgs/subscribelogo.png" width="80" /><br />
                                <span style="color:#666; font-size:12px;">快速订阅查询</span>
                            </div> 
                        </td>
                        <td>
                        <div style="padding-left:30px; font-size:12px;color:#666;">
                            关键词：&nbsp;&nbsp;&nbsp;<font style="color:orange;"><asp:Literal runat="server" ID="ltrKeywords"></asp:Literal></font> <br />
                            地&nbsp;&nbsp;&nbsp;区：&nbsp;&nbsp;&nbsp;<asp:Literal runat="server" ID="ltrAreas"></asp:Literal><br />
                            行&nbsp;&nbsp;&nbsp;业：&nbsp;&nbsp;&nbsp;<asp:Literal runat="server" ID="ltrIndustry"></asp:Literal><br />
                            类&nbsp;&nbsp;&nbsp;型：&nbsp;&nbsp;&nbsp;<asp:Literal runat="server" ID="ltrBidType"></asp:Literal><br />
                            时&nbsp;&nbsp;&nbsp;间：&nbsp;&nbsp;&nbsp;<asp:Literal runat="server" ID="ltrTimeType"></asp:Literal></div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row" style="width: 100%; padding: 0px; margin: 0px;" id="divsearchrow"
            runat="server">
            <div class="col-lg-12" style="width: 100%; padding: 0px; margin: 0px;">
                <div class="input-group" style="width: 100%; margin: 0px;">
                    <input type="text" id="txtSearchKeyword" style="text-decoration: none; border: 0px;
                        margin: 0px; border-radius: 0px; color: #999; padding-left: 10px; width: 75%;
                        outline: medium; float: left; font-size: 13px; height: 40px;" placeholder="请输入招投标关键字" />
                    <input type="button" id="btnSearch" style="border: 1px; text-align: center; height: 40px;
                        border-radius: 0px; border-right: 0px; font-size: 18x; width: 25%; color: #fff;
                        background-color: steelblue; font-weight: bold;" value="搜 索"></input>
                </div>
            </div>
        </div>
        <div style="height: 40px; width: 100%;" id="divsearchconditionrow" runat="server">
            <table id="tblSearchCondition">
                <tr>
                    <td id="tdConditionArea">
                        招标地区 ▽
                    </td>
                    <td id="tdConditionIndustry">
                        招标行业 ▽
                    </td>
                    <td id="tdConditionBidType">
                        招标分类 ▽
                    </td>
                </tr>
            </table>
        </div>
        <div id="divConditionArea" style="width: 100%; padding: 10px; border: 0px;" class="conditiondivhide"
            runat="server">
            <table class="tblArea">
                <tr>
                    <td colspan="4">
                        <div class="inactiveArea">
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
        <div id="divConditionIndustry" style="width: 100%; padding: 10px; border: 0px;" class="conditiondivhide"
            runat="server">
            <table class="tblIndustry">
                <tr>
                    <td colspan="4">
                        <div class="inactiveIndustry">
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
        <div id="divConditionBidType" style="width: 100%; padding: 10px;" class="conditiondivhide"
            runat="server">
            <table class="tblBidType">
                <tr>
                    <td colspan="4">
                        <div class="inactiveBidType">
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
        <div id="divContent" style="width: 100%; padding: 0px; border: 0px;">
            <div class="col-lg-12" style="padding: 0px; border: 0px;">
                <table class="table table-hover no-padding" style="padding: 0px; border: 0px;">
                    <asp:Repeater runat="server" ID="rptBidList">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 95%; padding-top: 15px; line-height: 25px; vertical-align: top;
                                    border-top: 0px; padding-bottom: 10px; padding-left: 10px; padding-right: 10px;
                                    border-bottom: 1px solid #fafafa;">
                                    <img src="../imgs/system/synctime.png" width="20" height="20" />
                                    <span style="font-size: 10px;">
                                        <%# GetDisplayPublishTime(Eval("BidPublishTime").ToString())%></span> <a target="_blank"
                                            href='/wap/BidDetail.aspx?bId=<%#Eval("BidId")%>&keywords=<%= keywords %>' style="font-size: 14px;
                                            text-decoration: none; color: #000;">
                                            <%#Eval("BidTitle").ToString().Length > 40 ? HighlightKeyword(Eval("BidTitle").ToString().Substring(0, 40)) + "..." : HighlightKeyword(Eval("BidTitle").ToString())%></a><br />
                                    <a href='/wap/BidDetail.aspx?bId=<%#Eval("BidId")%>&keywords=<%= keywords %>' style="text-decoration: none;">
                                        <span style="color: #666; line-height: 22px; font-size: 10px;">
                                            <%# Eval("BidContent").ToString()%><font style='color: orange; display: <%= keywords == "" ? "none":"" %>'>(内容包含:<%= keywords %>)</font></span></a><br />
                                    <div style="padding-top: 10px;">
                                        <span class="bidlabel" style="background-color: #5ec6e5;">
                                            <%# GoBiding.BLL.CommonUtility.GetBidTypeValue(Eval("BidType").ToString())%></span>
                                        <span class="bidlabel" style="background-color: #5ec6e5;">
                                            <%# GetBidCategoryNameValue(Eval("BidCategoryId").ToString())%></span> <span class="bidlabel"
                                                style="background-color: #5ec6e5;">
                                                <%#GetProvinceName(Eval("ProvinceId").ToString())%></span> <span class="bidlabel"
                                                    style='display: <%# Eval("BidCompanyName") == "" ? "none":""%>'><a href="/CompanyBidList.aspx"
                                                        style='text-decoration: none;'>
                                                        <%# Eval("BidCompanyName").ToString().Length > 10 ? Eval("BidCompanyName").ToString().Trim().Substring(0, 10) + "..." : Eval("BidCompanyName").ToString().Trim()%></a></span>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div runat="server" id="divInvalid" style="padding: 15px; width: 80%; color: #333;
                    padding-bottom: 30px; height: 40px; line-height: 40px; font-size: 14px; text-align: center;">
                    为了系统安全性，只允许访问前10页的数据！
                </div>
            </div>
        </div>
        <div style="width: 180px; margin: 0px auto;" id="pager">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Width="180" UrlPaging="true"
                HorizontalAlign="Center" ShowPageIndex="False" ShowMoreButtons="False" ShowPageIndexBox="Never"
                ShowCustomInfoSection="Never" ShowFirstLast="False" CssClass="pagination" LayoutType="Ul"
                PagingButtonLayoutType="UnorderedList" NextPageText="下一页" PrevPageText="上一页"
                PagingButtonSpacing="20" PageSize="20" OnPageChanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
        </div>
    </div>
    <br />
    <br />
    <br />
    <input type="hidden" id="hdnarea" runat="server" clientidmode="Static" value="" />
    <input type="hidden" id="hdnindustry" runat="server" clientidmode="Static" value="" />
    <input type="hidden" id="hdnkeyword" runat="server" clientidmode="Static" value="" />
    <input type="hidden" id="hdnbidtype" runat="server" clientidmode="Static" value="" />
    <script>
        function init() {
            var area = $("#hdnarea").val();
            var industry = $("#hdnindustry").val();
            var bidtype = $("#hdnbidtype").val();
            var keyword = $("#hdnkeyword").val();

            if (area != '') {
                $("#tdConditionArea").html($(".tblArea").find("input[value='" + area + "']").parent().html());
            }
            if (industry != '') {
                $("#tdConditionIndustry").html($(".tblIndustry").find("input[value='" + industry + "']").parent().html());
            }
            if (bidtype != '') {
                $("#tdConditionBidType").html($(".tblBidType").find("input[value='" + bidtype + "']").parent().html());
            }
            if (keyword != '') {
                $("#txtSearchKeyword").val(keyword);
            }
        }
    </script>
    <script>
        $(document).ready(function () {

            init();

            $("#btnSearch").click(function () {
                var keyword = encodeURI(encodeURI($("#txtSearchKeyword").val()));

                var area = $("#hdnarea").val();
                var industry = $("#hdnindustry").val();
                var bidtype = $("#hdnbidtype").val();
                window.location = "Default.aspx?keyword=" + keyword + "&area=" + area + "&industry=" + industry + "&bidtype=" + bidtype;
            });
            $(".tblArea div").click(function () {
                $("#tdConditionArea").html($(this).html());
                $("#hdnarea").val($(this).find("input").val());

                $("#divConditionArea").addClass("conditiondivhide");
                $("#divConditionIndustry").addClass("conditiondivhide");
                $("#pager").show();
                $("#divContent").show();
            });
            $(".tblIndustry div").click(function () {
                $("#tdConditionIndustry").html($(this).html());
                $("#hdnindustry").val($(this).find("input").val());

                $("#divConditionArea").addClass("conditiondivhide");
                $("#divConditionIndustry").addClass("conditiondivhide");
                $("#pager").show();
                $("#divContent").show();
            });
            $(".tblBidType div").click(function () {
                $("#tdConditionBidType").html($(this).html());
                $("#hdnbidtype").val($(this).find("input").val());

                $("#divConditionArea").addClass("conditiondivhide");
                $("#divConditionBidType").addClass("conditiondivhide");
                $("#divConditionIndustry").addClass("conditiondivhide");
                $("#pager").show();
                $("#divContent").show();
            });

            $("#tdConditionArea").click(function () {
                if ($("#divConditionArea").hasClass("conditiondivshow")) {
                    $("#divConditionArea").removeClass("conditiondivshow");
                    $("#divConditionArea").addClass("conditiondivhide");
                    $("#pager").show();
                    $("#divContent").show();

                    $("#divConditionIndustry").removeClass("conditiondivshow");
                    $("#divConditionBidType").removeClass("conditiondivshow");
                }
                else {
                    $("#divConditionArea").addClass("conditiondivshow");
                    $("#divConditionArea").removeClass("conditiondivhide");
                    $("#pager").hide();
                    $("#divContent").hide();

                    $("#divConditionIndustry").addClass("conditiondivhide");
                    $("#divConditionIndustry").removeClass("conditiondivshow");

                    $("#divConditionBidType").addClass("conditiondivhide");
                    $("#divConditionIndustry").removeClass("conditiondivshow");

                }
            });

            $("#tdConditionIndustry").click(function () {

                if ($("#divConditionIndustry").hasClass("conditiondivshow")) {
                    $("#divConditionIndustry").removeClass("conditiondivshow");
                    $("#divConditionIndustry").addClass("conditiondivhide");
                    $("#pager").show();
                    $("#divContent").show();

                    $("#divConditionArea").removeClass("conditiondivshow");
                    $("#divConditionBidType").removeClass("conditiondivshow");
                }
                else {
                    $("#divConditionIndustry").addClass("conditiondivshow");
                    $("#divConditionIndustry").removeClass("conditiondivhide");
                    $("#pager").hide();
                    $("#divContent").hide();
                    $("#divConditionArea").addClass("conditiondivhide");
                    $("#divConditionArea").removeClass("conditiondivshow");
                    $("#divConditionBidType").addClass("conditiondivhide");
                    $("#divConditionBidType").removeClass("conditiondivshow");
                }
            });

            $("#tdConditionBidType").click(function () {
                if ($("#divConditionBidType").hasClass("conditiondivshow")) {
                    $("#divConditionBidType").removeClass("conditiondivshow");
                    $("#divConditionBidType").addClass("conditiondivhide");
                    $("#pager").show();
                    $("#divContent").show();

                    $("#divConditionArea").removeClass("conditiondivshow");
                    $("#divConditionIndustry").removeClass("conditiondivshow");
                }
                else {
                    $("#divConditionBidType").addClass("conditiondivshow");
                    $("#divConditionBidType").removeClass("conditiondivhide");
                    $("#pager").hide();
                    $("#divContent").hide();
                    $("#divConditionArea").addClass("conditiondivhide");
                    $("#divConditionArea").removeClass("conditiondivshow");
                    $("#divConditionIndustry").addClass("conditiondivhide");
                    $("#divConditionIndustry").removeClass("conditiondivshow");
                }
            });

            $(".favdiv").click(function () {
                var bidid = $(this).find("#hdnBidId").val();

                $.ajax({
                    type: "post",
                    url: "handlers/addFavourite.ashx",
                    data: {
                        BidId: bidid
                    },
                    dataType: 'text',
                    success: function (result) {
                        alert('添加成功！');
                    }
                });
            });
        });
    </script>
    <div style="width: 100%; padding: 0px; margin: 0px;">
        <uc1:Bottom ID="Bottom1" runat="server" />
    </div>
    </form>
</body>
</html>
