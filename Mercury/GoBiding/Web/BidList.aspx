<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BidList.aspx.cs" Inherits="GoBiding.Web.BidList" %>

<%@ Import Namespace="GoBiding.BLL" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="UserCenter/Index/ucBidCategoryList.ascx" TagName="ucBidCategoryList"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>去投标网_招标大厅_免费招标采购信息发布平台_地方采购信息服务平台</title>
    <meta name="keywords" content="去投标网招标大厅,免费招标采购信息发布平台,地方采购信息服务平台" />
    <meta name="description" content="去投标网_招标大厅_免费招标采购信息发布平台_地方采购信息服务平台_上海商麓网络科技有限公司_官网" />
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <link rel="shortcut icon" type="image/x-icon" href="/imgs/system/logo_16_16.png"
        media="screen" />
    <!-- bootstrap 3.0.2 -->
    <link href="/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- font Awesome -->
    <style>
        *, body, a
        {
            font-family: '微软雅黑';
        }
        .bidlabel
        {
            background-color: #eee;
            margin-right: 10px;
            border: 1px solid #ececec;
            padding: 3px 10px 3px 10px;
            font-size: 10px;
        }
        .searchtypetitle span
        {
            margin-left: 30px;
        }
        .bidsearchtitle
        {
            width: 80px;
            margin-left: 10px;
            float: left;
        }
        .bidsearchcontent
        {
            margin-left: 0px;
            padding-left: 0px;
        }
        .bidsearchcontent ul
        {
            float: left;
            margin-left: 0px;
            padding-left: 0px;
            padding-bottom: 0px;
            margin-bottom: 0px;
        }
        
        .bidsearchcontent li
        {
            list-style: none;
            text-decoration: none;
            float: left;
            margin-left: 30px;
            margin-top: 15px;
            line-height: 24px;
            cursor: pointer;
            text-align: center;
            padding: 0px 8px 0px 8px;
        }
        .listbidtarea li
        {
            font-size: 12px;
        }
        .bidsearcharea_2
        {
            margin-top: -10px;
        }
        .bidsearcharea_2 li
        {
            float: left;
            cursor: pointer;
        }
        
        .highlightsearch
        {
            background-color: #428bca;
            color: white;
            height: 24px;
            line-height: 24px;
            font-size: 10px;
        }
        .breadcrumb a
        {
            color: #fff;
        }
        .breadcrumb li.active
        {
            color: #fff;
        }
        .breadcrumb a:hover
        {
            color: #fff;
            text-decoration: none;
        }
        .provincesite th, .provincesite td
        {
            width: 60px;
            height: 30px;
            font-size: 12px;
            color: #666;
        }
        .provincesite th
        {
            width: 80px;
            text-align: center;
        }
        .categorysite td
        {
            height: 30px;
            font-size: 12px;
            color: #666;
            text-align: center;
        }
        .pagination li span.active
        {
            color: #fff;
            cursor: default;
            background-color: #428bca;
            border-color: #428bca;
        }
        #bidinfoitem
        {
            box-shadow: 2px 2px 2px #e7e7e7;
        }
        #bidinfoitem:hover
        {
            cursor: pointer;
            background-color: #eee;
            box-shadow: 0px 1px 1px rgba(14, 15, 15, 0.5);
        }
        
        .pagination li a, .pagination li span a
        {
            color: #000;
        }
        .subIndustryAll
        {
            float: left;
            display: block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:Top ID="Top1" runat="server" />
    <div style="background-color: #22252A;">
        <div class="container" style="padding: 0px; height: 44px;">
            <ol class="breadcrumb" style="background-color: #22252A;">
                <li><a href="/Default.html">去投标网</a></li>
                <li><a href="/BidList.html">招标列表</a></li>
            </ol>
        </div>
    </div>
    <div class="container" class="col-lg-10">
        <div class="row">
            <div class="col-lg-12" style="font-size: 12px;">
                <div style="margin-top: 20px; line-height: 40px; height: 50px; font-weight: bold;
                    border: 1px solid #dcdcdc; border-top: 4px solid orange; padding: 0px 0px 10px 20px;
                    background-color: #fafafa;">
                    <span>按条件查询</span> <span style="color: #333; font-weight: normal; float: right; padding-right: 20px;">
                        符合条件的共有 <font style="color: Orange;">
                            <asp:Label runat="server" ID="lblTotalCount"></asp:Label></font> 记录</span>
                </div>
                <div class="col-lg-12 searchtypetitle" style="border: 1px solid #dcdcdc; border-top: 0px;
                    border-bottom: 1px dotted #dcdcdc; line-height: 50px; font-size: 12px;">
                    <div class="bidsearchtitle">
                        招标类型：</div>
                    <div class="bidsearchcontent">
                        <ul class="listbidttype">
                            <li value="0" class="all">全部</li>
                            <li value="1">招标公告</li>
                            <li value="2">变更公告</li>
                            <li value="3">中标公告</li>
                            <li value="4">招标预告</li>
                            <li value="5">中止公告</li>
                            <li value="6">邀请招标</li>
                            <li value="7">竞争性谈判</li>
                            <li value="8">单一源公告</li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-12 searchtypetitle" style="border: 1px solid #dcdcdc; border-top: 0px;
                    border-bottom: 1px dotted #dcdcdc; line-height: 50px; font-size: 12px;">
                    <div class="bidsearchtitle" style="height: 110px; float: left; display: block;">
                        地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;区：</div>
                    <div class="bidsearchcontent" style="float: left; display: block; width: 900px;">
                        <table>
                            <tr>
                                <td>
                                    <ul class="listbidtarea">
                                        <li value="0" class="all">全部</li>
                                        <li value="1">北京</li>
                                        <li value="9">上海</li>
                                        <li value="2">天津</li>
                                        <li value="19">广东</li>
                                        <li value="11">浙江</li>
                                        <li value="10">江苏</li>
                                        <li value="13">福建</li>
                                        <li value="12">安徽</li>
                                        <li value="17">湖北</li>
                                        <li value="18">湖南</li>
                                    </ul>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <ul class="listbidtarea bidsearcharea_2">
                                        <li value="16" style="margin-left: 100px;">河南</li>
                                        <li value="15">山东</li>
                                        <li value="28">甘肃</li>
                                        <li value="4">山西</li>
                                        <li value="27">陕西</li>
                                        <li value="8">黑龙江</li>
                                        <li value="7">吉林</li>
                                        <li value="6">辽宁</li>
                                        <li value="29">青海</li>
                                        <li value="5">内蒙古</li>
                                        <li value="3">河北</li>
                                    </ul>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <ul class="listbidtarea bidsearcharea_2">
                                        <li value="14" style="margin-left: 100px;">江西</li>
                                        <li value="25">云南</li>
                                        <li value="26">西藏</li>
                                        <li value="31">新疆</li>
                                        <li value="22">重庆</li>
                                        <li value="23">四川</li>
                                        <li value="24">贵州</li>
                                        <li value="20">广西</li>
                                        <li value="21">海南</li>
                                        <li value="30">宁夏</li>
                                        <li></li>
                                    </ul>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="col-lg-12 searchtypetitle" style="border: 1px solid #dcdcdc; border-top: 0px;
                    border-bottom: 1px dotted #dcdcdc; line-height: 50px; font-size: 12px;">
                    <div class="bidsearchtitle">
                        行业分类：</div>
                    <div class="bidsearchcontent">
                        <ul class="listbidtindustry">
                            <li value="0" class="all">全部</li>
                            <li value="1">建筑工程</li>
                            <li value="7">仪器设备</li>
                            <li value="14">办公文教</li>
                            <li value="18">医疗卫生</li>
                            <li value="21">园林环保</li>
                            <li value="26">机械设备</li>
                            <li value="31">服务行业</li>
                            <li value="38">衣食住行</li>
                            <li value="46">其他</li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-12 searchtypetitle" id="divsubindustry" style="border: 1px solid #dcdcdc;
                    border-top: 0px; display: none; border-bottom: 1px dotted #dcdcdc; line-height: 50px;
                    font-size: 12px;">
                    <div class="bidsearchtitle" style="float: left; display: block;">
                        二级分类：</div>
                    <div class="bidsearchcontent" style="float: left; width: 900px; display: block; padding-bottom: 10px;">
                        <ul class="listsubbidtindustry">
                        </ul>
                    </div>
                </div>
                <div class="col-lg-12 searchtypetitle" style="border: 1px solid #dcdcdc; border-top: 0px;
                    border-bottom: 1px dotted #dcdcdc; line-height: 50px; font-size: 12px;">
                    <div class="bidsearchtitle">
                        发布时间：</div>
                    <div class="bidsearchcontent">
                        <ul class="listbidtime">
                            <li value="0" class="all">全部</li>
                            <li value="1">今天</li>
                            <li value="2">近三天</li>
                            <li value="3">近七天</li>
                            <li value="4">近两周</li>
                            <li value="5">近一月</li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-12 searchtypetitle" style="border: 1px solid #dcdcdc; border-top: 0px;
                    border-bottom: 1px dotted #dcdcdc; line-height: 50px; font-size: 12px;">
                    <div class="bidsearchtitle">
                        关&nbsp;&nbsp;键&nbsp;&nbsp;字：</div>
                    <div class="input-group col-lg-6" style="padding: 10px; padding-left: 30px;">
                        <input type="text" id="txtSearchKeyword" class="form-control input-sm" style="border-right: 0px;
                            padding-left: 10px;" placeholder="请输入关键词" />
                        <div class="input-group-btn">
                            <button type="button" id="btnSearch" class="btn btn-primary input-sm" style="border-radius: 0px;">
                                <span class="glyphicon glyphicon-search" style="margin-left: 0px;"></span><font style="font-weight: 200;
                                    font-size: 13px; padding-left: 5px;">搜 索 </font>
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-9">
                <div style="margin-top: 20px;">
                    <img src="imgs/ad/ad_m_2.gif" style="width: 100%; margin-bottom: 20px;" />
                    <div class="box-body table-responsive no-padding" style="min-height: 400px;">
                        <asp:Repeater runat="server" ID="rptBidList">
                            <ItemTemplate>
                                <table id="bidinfoitem" cellspacing="0" style="width: 100%; border: 1px solid #dcdcdc;
                                    margin-bottom: 10px;">
                                    <tr>
                                        <td style="width: 80px; height: 130px; padding-left: 10px; text-align: center; line-height: 30px;
                                            vert-align: middle; font-size: 12px;">
                                            <%# DateTime.Parse(Eval("CreateTime").ToString()).ToShortDateString()%>
                                            <br />
                                            <img src="imgs/system/synctime.png" width="24" height="24" /><%# GetDisplayPublishTime(Eval("BidPublishTime").ToString())%>
                                        </td>
                                        <td style="width: 500px; line-height: 24px; padding: 10px; vertical-align: top;">
                                            <%# Eval("BidType").ToString() == "1" ? "<span style=\"background: #FFBB66; font-size: 9px; padding: 2px 5px 2px 5px; color: #fff;\">正在招标</span>":""%> <a href='/BidDetail/<%#Eval("BidId")%>.html' target="_blank" style="font-size: 14px;
                                                    font-family: microsoft yahei; text-decoration: none; color: #000;">
                                                    <%#Eval("BidTitle").ToString().Length > 45 ? HighlightKeyword(Eval("BidTitle").ToString().Substring(0, 45)) + "...":HighlightKeyword(Eval("BidTitle").ToString()) %></a><br />
                                            <div style="color: #666; font-size: 12px; line-height: 24px; padding-right: 100px;
                                                padding-bottom: 10px;">
                                                <%# Eval("BidContent").ToString()%><font style='color: orange; display: <%= keywords == "" ? "none":"" %>'>(内容包含:<%= keywords %>)</font></div>
                                            <span class="bidlabel">
                                                <%# GoBiding.BLL.CommonUtility.GetBidTypeValue(Eval("BidType").ToString())%></span>
                                            <span class="bidlabel">
                                                <%# GetBidCategoryNameValue(Eval("BidCategoryId").ToString())%></span> <span class="bidlabel">
                                                    <%#GetProvinceName(Eval("ProvinceId").ToString())%></span> <span class="bidlabel">编号
                                                        <%#Eval("BidNumber")%></span> <span class="bidlabel" style='display: <%# Eval("BidCompanyName") == "" ? "none":""%>'>
                                                            招标商 |
                                                                <%# Eval("BidCompanyName").ToString().Length > 10 ? Eval("BidCompanyName").ToString().Substring(0, 10) +"...": Eval("BidCompanyName").ToString()%></span>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div id="emptyDiv" runat="server" style="width: 100%; text-align: center; font-size: 20px;
                            height: 200px; padding-top: 70px; border: 1px solid #ececec;">
                            Sorry, 没有搜到您想要的信息，请换个词再搜索吧！
                        </div>
                        <div class="pull-right">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Width="100%" UrlPaging="true" NumericButtonCount="15" ForeColor="Black"
                                FirstPageText="第一页" LastPageText="尾页" ShowPageIndexBox="Never" ShowNavigationToolTip="False"
                                ShowCustomInfoSection="Never" PrevPageText="上一页" NextPageText="下一页" CssClass="pagination"
                                LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0"
                                CurrentPageButtonClass="active" PageSize="10" OnPageChanged="AspNetPager1_PageChanged">
                            </webdiyer:AspNetPager>
                        </div>
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
            <div class="col-lg-3" style="margin-left: 0px; padding-left: 0px;">
                <div style="border: 1px solid #ececec; font-weight: 700; font-size: 14px; margin-left: 0px;
                    padding-left: 10px; margin-top: 20px; color: #666; height: 40px; line-height: 40px;">
                    最新进驻企业
                </div>
                <div style="width: 100%; padding-top: 10px; border: 1px solid #ececec; border-top: 0px;">
                    <asp:ListView runat="server" ID="rptEmergencyPurchaseOrderList">
                        <LayoutTemplate>
                            <ul style="list-style: none; padding-left: 10px; margin-left: 0px;">
                                <li runat="server" id="itemplaceholder"></li>
                            </ul>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li style="width: 100%; font-size: 12px; padding-left: 0px; margin-left: 0px; line-height: 25px;
                                height: 25px; vertical-align: top; list-style: none;"><a href='/CompanyBidList/<%#Eval("CompanyId")%>.html'
                                    style="color: Black;">
                                    <%--[<%#Eval("CityName")%> ]--%>
                                    <%#Eval("CompanyName")%></a> </li>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
            <div class="col-lg-3" style="margin-left: 0px; padding-left: 0px;">
                <div style="border: 1px solid #ececec; font-weight: 700; font-size: 14px; margin-left: 0px;
                    padding-left: 10px; margin-top: 20px; color: #666; height: 40px; line-height: 40px;">
                    热门招标企业
                </div>
                <div style="width: 100%; padding-top: 10px; border: 1px solid #ececec; border-top: 0px;">
                    <asp:ListView runat="server" ID="rptHotCompanyList">
                        <LayoutTemplate>
                            <ul style="list-style: none; padding-left: 10px; margin-left: 0px;">
                                <li runat="server" id="itemplaceholder"></li>
                            </ul>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li style="width: 100%; font-size: 12px; padding-left: 0px; margin-left: 0px; line-height: 25px;
                                height: 25px; vertical-align: top; list-style: none;">
                                <%# GetHotLevel(Eval("count").ToString())%>
                                <a href="http://gobiding.com/CompanyBidList/<%#Eval("BidCompanyId")%>.html"
                                    style="color: #000;">
                                    <%#Eval("BidCompanyName")%></a> </li>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                <div style="margin-left: 0px; padding-left: 0px; width: 100%; margin-top: 20px;"
                    id="divAdPanel">
                    <a href="http://www.ctrip.com/">
                        <img src="imgs/ad/ad_xiecheng.jpg" width="100%" height="80" /></a> <a href="http://shijiazhuang0196073.3566t.com/">
                            <img src="imgs/ad/ad_jinrong.jpg" width="100%" height="80" style="margin-top: 10px;" /></a>
                    <a href="https://item.taobao.com/item.htm?spm=a1z09.8149145.0.0.uE6dMr&id=528751809018&_u=p1cvkv2c8f0">
                        <img src="imgs/ad/ad_oculus_2.jpg" width="100%" height="80" style="margin-top: 10px;" /></a>
                    <img src="imgs/ad/ad_zhaoshang.png" width="100%" height="80" style="margin-top: 10px;" />
                </div>
            </div>
        </div>
    </div>

    <div class="container" style="width: 100%; text-align: center; padding-top: 20px;
        padding-left: 12%; font-family: '微软雅黑'">
        <div class="row">
            <div style="line-height: 24px; text-align: left; margin: 0px auto; color: #666; font-size: 12px;">
                去投标网（上海商麓网络科技有限公司）<br />
                2015-2017 gobiding.com 版权所有 ICP证：沪ICP备15005938号-3 All Rights Reserved
            </div>
            <div style="width: 100%; padding-top: 10px;">
                <table>
                    <tr>
                        <td style="width: 130px;">
                            <img src="imgs/system/sf-wzba_r1_c1.gif" />
                        </td>
                        <td style="width: 130px;">
                            <img src="imgs/system/sf-wzba_r1_c3.gif" />
                        </td>
                        <td style="width: 130px;">
                            <img src="imgs/system/sf-wzba_r1_c7.gif" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnbidarea" />
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnsubindustry" />
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnbidindustry" />
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnbidtime" />
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnkeyword" />
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnbidtype" />
    <style>
        #divAdPanel img:hover
        {
            -webkit-transform: scale(1.02,1.02);
            -moz-transform: scale(1.02,1.02);
            -transform: scale(1.02,1.02);
        }
    </style>
    </form>
    <script src="/js/thirdplugin.js" type="text/javascript"></script>
    <script src="/js/jquery-1.9.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#btnSearch").click(function () {
                var keyword = $("#txtSearchKeyword").val();
                var industry = $(".listbidtindustry .highlightsearch").val();
                var subindustry = $(".listsubbidtindustry .highlightsearch").val();
                var area = $(".listbidtarea .highlightsearch").val();
                var bidtype = $(".listbidttype .highlightsearch").val();
                var bidtime = $(".listbidtime .highlightsearch").val();

                if (subindustry != null) {
                    location.href = "/BidList.html?keyword=" + keyword + "&area=" + area + "&industry=" + industry + "&subindustry=" + subindustry + "&bidtype=" + bidtype + "&bidtime=" + bidtime;
                } 
                else {
                    location.href = "/BidList.html?keyword=" + keyword + "&area=" + area + "&industry=" + industry + "&bidtype=" + bidtype + "&bidtime=" + bidtime;
                }
            });

            $("#zbdt").addClass("navchoose");

            if ($("#hdnbidarea").val() != '') {
                $(".listbidtarea").find("li[value='" + $("#hdnbidarea").val() + "']").addClass("highlightsearch");
            } else {
                $(".listbidtarea").find(".all").addClass("highlightsearch");
            }

            if ($("#hdnbidtype").val() != '') {
                $(".listbidttype").find("li[value='" + $("#hdnbidtype").val() + "']").addClass("highlightsearch");
            } else {
                $(".listbidttype").find(".all").addClass("highlightsearch");
            }

            if ($("#hdnbidindustry").val() != '') {
                $(".listbidtindustry").find("li[value='" + $("#hdnbidindustry").val() + "']").addClass("highlightsearch");

                //初始化二级分类
                if ($("#hdnsubindustry").val() != '') {
                    var currentSubInstry = $("#hdnsubindustry").val();
                    initSubIndustry(currentSubInstry);
                }
            } else {
                $(".listbidtindustry").find(".all").addClass("highlightsearch");
            }

            if ($("#hdnbidtime").val() != '') {
                $(".listbidtime").find("li[value='" + $("#hdnbidtime").val() + "']").addClass("highlightsearch");
            } else {
                $(".listbidtime").find(".all").addClass("highlightsearch");
            }
            if ($("#hdnkeyword").val() != '') {
                $("#txtSearchKeyword").val($("#hdnkeyword").val());
            }

            $(".listbidttype li").click(function () {
                $(this).parent().find("li").removeClass("highlightsearch");
                $(this).addClass("highlightsearch");
            });
            $(".listbidtarea li, .listbidtarea2 li").click(function () {
                $(this).parent().parent().parent().parent().find("li").removeClass("highlightsearch");
                $(this).addClass("highlightsearch");
            });

            //行业分类事件
            $(".listbidtindustry li").click(function () {
                $(this).parent().find("li").removeClass("highlightsearch");
                $(this).addClass("highlightsearch");

                initSubIndustry(null);
            });

            function initSubIndustry(currentSubInstry) {
                //显示行业子类
                var industry = $(".listbidtindustry .highlightsearch").val();

                $.ajax({
                    type: "post",
                    url: "/Handlers/GetSubIndustryList.ashx",
                    data: {
                        IndustryId: industry
                    },
                    dataType: "json",
                    success: function (data) {
                        var subindustrys = "";
                        for (var p in data) { //for循环直接遍历数据
                            subindustrys += "<li value='" + data[p].BidCategoryId + "'>" + data[p].BidCategoryName + "</li>";
                        }

                        var all = "<li class='subIndustryAll'  value=\"0\" class=\"all\">全部</li>";
                        $(".listsubbidtindustry").html(all + subindustrys);

                        if (currentSubInstry == null) {
                            $(".subIndustryAll").addClass("highlightsearch");
                        }
                        else {
                            $(".listsubbidtindustry").find("li[value='" + currentSubInstry + "']").addClass("highlightsearch");
                        }

                        //调整“全部”的显示样式
                        $(".listsubbidtindustry li").eq(9).css("margin-left", "100px");
                        $(".listsubbidtindustry li").eq(17).css("margin-left", "100px");
                        $(".listsubbidtindustry li").eq(25).css("margin-left", "100px");
                        $(".listsubbidtindustry li").eq(33).css("margin-left", "100px");
                    },
                    error: function (msg) {
                        alert(msg);
                    }
                });

                $("#divsubindustry").show();

                //行业分类事件
                $(".listsubbidtindustry").on("click", "li", function () {
                    $(this).parent().find("li").removeClass("highlightsearch");
                    $(this).addClass("highlightsearch");
                });

            }

            $(".listbidtime li").click(function () {
                $(this).parent().find("li").removeClass("highlightsearch");
                $(this).addClass("highlightsearch");
            });


            $("#txtSearchKeyword").keydown(function (e) {
                // 回车键事件  
                if (e.which == 13) {
                    return false;
                }
            });

        });

    </script>
</body>
</html>
