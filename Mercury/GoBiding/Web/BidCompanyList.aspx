<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BidCompanyList.aspx.cs"
    Inherits="GoBiding.Web.BidCompanyList" %>

<%@ Import Namespace="GoBiding.BLL" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>全国代理招标公司列表 - 代理招标公司 - 免费招标采购信息 - 去投标网</title>
    <meta name="keywords" content="全国代理招标公司" />
    <meta name="description" content="找全国代理招标公司,招标采购,招标公司,招标代理企业,最新招标代理公司就上去投标网(http://www.gobiding.com)" />
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">

    <link href="/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="/UserCenter/js/jquery.min.js" type="text/javascript"></script>
    <script src="/js/thirdplugin.js" type="text/javascript"></script>
    <style>
        *, body
        {
            margin: 0;
            padding: 0;
            font-family: "微软雅黑";
        }
        .breadcrumb a
        {
            color: #fff;
        }
        .breadcrumb li.active
        {
            color: #fff;
        }
        .bidlabel
        {
            margin-left: 10px;
            border: 1px solid green;
            padding: 5px 10px 5px 10px;
            font-size: 14px;
        }
        .searchtypetitle span
        {
            margin-left: 30px;
        }
        .bidsearchtitle
        {
            width: 100px;
            margin-left: 40px;
            float: left;
        }
        .bidsearchcontent
        {
            float: left;
            margin-left: 0px;
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
            margin-top: 10px;
            line-height: 30px;
            cursor: pointer;
        }
        .listbidtarea li
        {
            width: 45px;
        }
        .bidsearcharea_2
        {
            margin-top: -10px;
        }
        .bidsearcharea_2 li
        {
            float: left;
            cursor: pointer;
            width: 45px;
        }
        
        .highlightsearch
        {
            background-color: #000;
            color: white;
            height: 30px;
            font-size: 12px;
            padding: 0px 10px 0px 10px;
        }
        .breadcrumb a
        {
            color: #fff;
        }
        .breadcrumb li.active
        {
            color: #fff;
        }
        .pagination li span.active
        {
            color: #fff;
            cursor: default;
            background-color: #428bca;
            border-color: #428bca;
        }
        .bidcomapanylisttable td
        {
            padding: 10px 0px 10px 0px;
        }
        #tblbidcompanylisthead th
        {
            padding: 10px 0px 10px 0px;
            margin: 0px;
            border: 1px solid #ececec;
            font-weight: normal;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:Top ID="Top1" runat="server" />
    <div style="background-color: #22252A;">
        <div class="container" style="padding: 0px; height: 44px;">
            <ol class="breadcrumb" style="background-color: #22252A;">
                <li><a href="/Default.aspx">去投标网</a></li>
                <li><a href="/BidCompanyList.aspx">招标机构</a></li>
                <li class="active">
                    <asp:Literal runat="server" ID="lblTitle2"></asp:Literal></li>
            </ol>
        </div>
    </div>
    <br />
    <div style="height: 320px; padding: 0px; margin: 0px;">
        <div class="container" style="padding: 0px; height: 44px;">
            <div style="line-height: 40px; height: 50px; font-weight: bold; border: 1px solid #dcdcdc;
                border-top: 4px solid orange; padding: 0px 0px 10px 20px; background-color: #fafafa;">
                <span>按条件查询</span> <span style="color: #333; font-weight: normal; float: right; padding-right: 20px;">
                    符合条件的共有 <font>
                        <asp:Label runat="server" ID="lblTotalCount"></asp:Label></font>记录</span>
            </div>
            <div class="col-lg-12 searchtypetitle" style="border: 1px solid #dcdcdc; border-top: 0px;
                border-bottom: 1px dotted #dcdcdc; line-height: 50px; font-size: 14px;">
                <div class="bidsearchtitle" style="height: 110px;">
                    地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;区：</div>
                <div class="bidsearchcontent">
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
                                    <li value="16">河南</li>
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
                                    <li value="14">江西</li>
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
                line-height: 50px; font-size: 14px;">
                <div class="bidsearchcontent">
                    <div class="input-group" style="padding: 20px; width: 600px; padding-left: 170px;">
                        <input type="text" id="txtSearchKeyword" class="form-control" style="border-right: 0px;"
                            placeholder="请输入招标公司名称" />
                        <div class="input-group-btn">
                            <button type="button" id="btnSearch" class="btn" style="border-radius: 0px; background-color: #000;
                                color: #fff; width: 120px;">
                                <font style="font-weight: 300; color: #fff; font-size: 14px;">搜索招标公司 </font>
                            </button>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="col-lg-12" style="margin: 0px; margin-top: 20px; padding: 0px; padding-left: 0px;">
                <table class="table table-hover" cellpadding="0" cellspacing="0" id="tblbidcompanylisthead">
                    <tr>
                        <th style="text-align: center; width: 90px; vertical-align: middle;">
                            入驻时间
                        </th>
                        <th style="text-align: center; width: 230px; vertical-align: middle;">
                            企业名称
                        </th>
                        <th style="text-align: center; width: 110px; vertical-align: middle;">
                            所在地区
                        </th>
                        <th style="text-align: center; width: 130px;">
                            工程招标代理资格证<br />
                            甲级|乙级|临乙级
                        </th>
                        <th style="text-align: center; width: 130px;">
                            基本货物<br />
                            采购资格证
                        </th>
                        <th style="text-align: center; width: 130px;">
                            政府采购<br />
                            招标代理资格证
                        </th>
                        <th style="text-align: center; width: 120px; vertical-align: middle;">
                            国际招标资格证
                        </th>
                        <th style="text-align: center;">
                            中央投资项目<br />
                            招标代理资格证
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rptCompanyList">
                        <ItemTemplate>
                            <tr>
                                <td colspan="8" style="border: 1px solid #ececec; width: 100%; padding: 0px; margin: 0px;">
                                    <table style="width: 100%; padding: 0px;" class="bidcomapanylisttable">
                                        <tr>
                                            <td style="width: 110px; line-height: 30px; text-align: center;">
                                                <%#Eval("CreateTime","{0:D}")%>
                                            </td>
                                            <td style="line-height: 30px; width: 260px;">
                                                <a href='/CompanyBidList.aspx?CompanyName=<%#Eval("BidCompanyName") %>' style="color: #000;">
                                                    <%#Eval("BidCompanyName")%></a>
                                            </td>
                                            <td style="width: 110px; line-height: 30px; text-align: center;">
                                                <%# CommonUtility.GetProvinceName(Eval("ProvinceId").ToString())%>
                                            </td>
                                            <td style="text-align: center; width: 150px;">
                                                甲级
                                            </td>
                                            <td style="text-align: center; width: 150px;">
                                                有
                                            </td>
                                            <td style="text-align: center; width: 150px;">
                                                有
                                            </td>
                                            <td style="text-align: center; width: 150px;">
                                                无
                                            </td>
                                            <td style="text-align: center;">
                                                无
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Width="100%" UrlPaging="true"
                    FirstPageText="第一页" LastPageText="尾页" ShowPageIndexBox="Never" ShowNavigationToolTip="False"
                    ShowCustomInfoSection="Never" PrevPageText="上一页" NextPageText="下一页" CssClass="pagination"
                    LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0"
                    CurrentPageButtonClass="active" PageSize="20" OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="container" style="padding-top: 20px; visibility:hidden;">
        <div class="row">
            <div class="col-xs-4">
                <div style="padding-left: 10px; border-left: 5px solid #000; margin-bottom: 10px;">
                    最新招标公司
                </div>
                <div>
                    <table>
                        <asp:Repeater runat="server" ID="rptLatestCompanyList">
                            <ItemTemplate>
                                <tr>
                                    <td style="line-height: 30px; height: 30px;">
                                        <a href='/CompanyBidList.aspx?CompanyName=<%#Eval("BidCompanyName") %>'>
                                            <%#Eval("BidCompanyName")%></a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
            <div class="col-xs-4">
                <div style="padding-left: 10px; border-left: 5px solid maroon; margin-bottom: 10px;">
                    热门招标公司
                </div>
                <div>
                    <table>
                        <asp:Repeater runat="server" ID="rptHotCompanyList">
                            <ItemTemplate>
                                <tr>
                                    <td style="line-height: 30px; height: 30px;">
                                        <a href='/CompanyBidList.aspx?CompanyName=<%#Eval("BidCompanyName") %>'>
                                            <%#Eval("BidCompanyName")%></a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
            <div class="col-xs-4">
                <div style="padding-left: 10px; border-left: 5px solid navy; margin-bottom: 10px;">
                    专业招标代理公司
                </div>
                <div>
                    <table>
                        <asp:Repeater runat="server" ID="rptProfessionalCompanyList">
                            <ItemTemplate>
                                <tr>
                                    <td style="line-height: 30px; height: 30px;">
                                        <a href='/CompanyBidList.aspx?CompanyName=<%#Eval("BidCompanyName") %>'>
                                            <%#Eval("BidCompanyName")%></a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnbidarea" />
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnkeyword" />
    </form>
    <script>
        $(document).ready(function () {
            $("#ztjg").addClass("navchoose");

            $(".listbidtarea li, .listbidtarea2 li").click(function () {
                $(this).parent().parent().parent().parent().find("li").removeClass("highlightsearch");
                $(this).addClass("highlightsearch");
            });

            if ($("#hdnkeyword").val() != '') {
                $("#txtSearchKeyword").val($("#hdnkeyword").val());
            }

            if ($("#hdnbidarea").val() != '') {
                $(".listbidtarea").find("li[value='" + $("#hdnbidarea").val() + "']").addClass("highlightsearch");
            } else {
                $(".listbidtarea").find(".all").addClass("highlightsearch");
            }

            $("#btnSearch").click(function () {
                var keyword = encodeURI(encodeURI($("#txtSearchKeyword").val()));
                var area = $(".listbidtarea .highlightsearch").val();

                window.location = "/BidCompanyList.aspx?keyword=" + keyword + "&area=" + area;
            });

            $("#btnSearch").click(function () {
                var keyword = encodeURI(encodeURI($("#txtSearchKeyword").val()));
                var industry = $(".listbidtindustry .highlightsearch").val();
                var area = $(".listbidtarea .highlightsearch").val();
                var bidtype = $(".listbidttype .highlightsearch").val();
                var bidtime = $(".listbidtime .highlightsearch").val();

                window.location = "/BidCompanyList.aspx?keyword=" + keyword + "&area=" + area;
            });
        });
    </script>
</body>
</html>
