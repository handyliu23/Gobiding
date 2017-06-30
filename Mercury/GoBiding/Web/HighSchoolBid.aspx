<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HighSchoolBid.aspx.cs"
    Inherits="GoBiding.Web.HighSchoolBid" %>

<%@ OutputCache Duration="600" VaryByParam="BId" %>
<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="UserCenter/Index/BidListBySchool.ascx" TagName="BidListBySchool"
    TagPrefix="uc2" %>
<%@ Register src="UserCenter/HighSchool/FirstAlphaList.ascx" tagname="FirstAlphaList" tagprefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>全国大学招标采购网_全国大学招投标信息网_高校招标信息_校园招标_校园采购信息发布平台_去投标网(www.gobiding.com) </title>
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <meta name="keywords" content="全国大学招标采购网_全国大学招投标信息网_高校招标信息_校园招标_校园采购信息发布平台_去投标网" />
    <meta name="description" content="全国大学招标采购网,提供全国范围大学职业大学中学的免费招标采购信息"/>
    <link rel="shortcut icon" type="image/x-icon" href="/imgs/system/logo_16_16.png" media="screen" />

    <script src="/UserCenter/js/jquery.min.js" type="text/javascript"></script>
    <script src="/js/thirdplugin.js" type="text/javascript"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                $("#xyzb").addClass("navchoose");
            });
    </script>
    <style>
        .tblFirstCh td
        {
            text-align: center;
            width: 50px;
            border-color: #eee;
            cursor: pointer;
        }
        .tblGaoxiaoBidList td
        {
            padding: 5px 0px 5px 10px;
            border-color: #eee;
        }
        .tblGaoxiaoBidList td:hover
        {
            opacity: 0.7;
        }
        td.bidcontentlist:hover
        {
            opacity: 1;
        }
        #tablecontent
        {
            padding-left:0px;
            }
        .tblGaoxiaoBidList a
        {
            color: #000;
            text-decoration: none;
        }
        .shupai
        {
            width: 30px;
            line-height: 24px;
            margin-left: -5px;
            padding-left: -5px;
        }
    </style>
</head>
<body>
    <uc1:Top ID="Top1" runat="server" />
    <form id="form1" runat="server">
    <div style="background-color: #22252A;">
        <div class="container" style="padding: 0px; height: 44px;">
            <ol class="breadcrumb" style="background-color: #22252A;">
                <li><a href="/Default.html">去投标网</a></li>
                <li><a href="/HighSchoolBid.html">校园招标</a></li>
                <li class="active">
                    <asp:Literal runat="server" ID="lblTitle2"></asp:Literal></li>
            </ol>
        </div>
    </div>
    <div style="width: 1160px; margin: 0px auto;">
        <uc3:FirstAlphaList ID="FirstAlphaList1" runat="server" />
        <div>
            <table cellpadding="0" cellspacing="0" class="tblGaoxiaoBidList">
                <tr>
                    <td rowspan="3" class="shupai">
                        华东地区
                    </td>
                    <td rowspan="3" style="width: 170px; text-align: center;">
                        <a href='/HighSchoolBidList/cn/88411'>
                            <img src="imgs/xuexiao/上海交通大学.png" style="width: 120px; height: 120px;" /><br />
                            上海交通大学<br />
                            累计发布
                            <asp:Label runat="server" ID="lblSHJTDX" Style="color: Orange;"></asp:Label>
                            次招标 </a>
                        
                    </td>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/苏州大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/125896">苏州大学</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/安徽大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/137123">安徽大学</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/浙江大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/120179">浙江大学</a>
                    </td>
                    <td rowspan="3" class="bidcontentlist">
                        <uc2:BidListBySchool ID="BidListBySchool1" CategoryId="1" CategoryName="华东" CategoryEnglishName="Latest Bid Information"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/合肥工业大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/128963">合肥工业大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/浙江师范大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/150137">浙江师范大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/浙江工业大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/162203">浙江工业大学</a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; height: 80px;">
                        <img src="imgs/xuexiao/常州大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/124490">常州大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/南京大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/136299">南京大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/扬州大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/扬州大学">扬州大学</a>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table cellpadding="0" cellspacing="0" class="tblGaoxiaoBidList">
                <tr>
                    <td rowspan="3" class="shupai">
                        华北地区
                    </td>
                    <td rowspan="3" style="width: 170px; text-align: center;">
                        <a href="/HighSchoolBidList/cn/127407">
                            <img src="imgs/xuexiao/北京大学.png" style="width: 120px; height: 120px;" /><br />
                            北京大学<br />
                            累计发布
                            <asp:Label runat="server" ID="lblBJDX" Style="color: Orange;"></asp:Label>
                            次招标</a>
                    </td>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/南开大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/132635">南开大学</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/天津大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/120139">天津大学</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/北京科技大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/120142">北京科技大学</a>
                    </td>
                    <td rowspan="3" class="bidcontentlist">
                        <uc2:BidListBySchool ID="BidListBySchool2" CategoryId="2" CategoryName=" " CategoryEnglishName="Latest Bid Information"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/中国人民大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/118920">中国人民大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/河北大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/119079">河北大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/首都医科大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/119026">首都医科大学</a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; height: 80px;">
                        <img src="imgs/xuexiao/太原科技大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/132608">太原科技大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/河北师范大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/119074">河北师范大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/山西大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/148137">山西大学</a>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table cellpadding="0" cellspacing="0" class="tblGaoxiaoBidList">
                <tr>
                    <td rowspan="3" class="shupai">
                        华南地区
                    </td>
                    <td rowspan="3" style="width: 170px; text-align: center;">
                        <a href="/HighSchoolBidList/cn/120137">
                            <img src="imgs/xuexiao/中山大学.png" style="width: 120px; height: 120px;" /><br />
                            中山大学<br />
                            累计发布
                            <asp:Label runat="server" ID="lblZSDX" Style="color: Orange;"></asp:Label>
                            次招标</a>
                    </td>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/华南理工大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/119905">华南理工大学</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/暨南大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/119485">暨南大学</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/华南师范大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/126262">华南师范大学</a>
                    </td>
                    <td rowspan="3" class="bidcontentlist">
                        <uc2:BidListBySchool ID="BidListBySchool3" CategoryId="3" CategoryName="最新招标公告" CategoryEnglishName="Latest Bid Information"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/广西大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/119499">广西大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/华南农业大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/120233">华南农业大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/广东中医药大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/广东中医药大学" style="font-size: 11px;">广东中医药大学</a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; height: 80px;">
                        <img src="imgs/xuexiao/深圳大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/135565">深圳大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/汕头大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/120317">汕头大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/海南大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/132181">海南大学</a>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table cellpadding="0" cellspacing="0" class="tblGaoxiaoBidList">
                <tr>
                    <td rowspan="3" class="shupai">
                        华中地区
                    </td>
                    <td rowspan="3" style="width: 170px; text-align: center;">
                        <a href="/HighSchoolBidList/cn/119618">
                            <img src="imgs/xuexiao/华中科技大学.png" style="width: 120px; height: 120px;" /><br />
                            华中科技大学<br />
                            累计发布
                            <asp:Label runat="server" ID="lblHZKJDX" Style="color: Orange;"></asp:Label>
                            次招标</a>
                    </td>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/武汉大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/66316">武汉大学</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/中国地质大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/中国地质大学">中国地质大学</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/武汉理工大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/165708">武汉理工大学</a>
                    </td>
                    <td rowspan="3" class="bidcontentlist">
                        <uc2:BidListBySchool ID="BidListBySchool4" CategoryId="4" CategoryName="最新招标公告" CategoryEnglishName="Latest Bid Information"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/湘潭大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/146480">湘潭大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/武汉理工大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/165708">武汉理工大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/郑州大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/120972">郑州大学</a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; height: 80px;">
                        <img src="imgs/xuexiao/长沙理工大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/141831">长沙理工大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/河南师范大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/119428">河南师范大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/长江大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/173730">长江大学</a>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table cellpadding="0" cellspacing="0" class="tblGaoxiaoBidList">
                <tr>
                    <td rowspan="3" class="shupai">
                        西南地区
                    </td>
                    <td rowspan="3" style="width: 170px; text-align: center;">
                        <a href="/HighSchoolBidList/cn/120201">
                            <img src="imgs/xuexiao/四川大学.png" style="width: 120px; height: 120px;" /><br />
                            四川大学<br />
                            累计发布
                            <asp:Label runat="server" ID="lblSCDX" Style="color: Orange;"></asp:Label>
                            次招标</a>
                    </td>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/电子科技大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/124276">电子科技大学</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/西南交通大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/120217">西南交通大学</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/重庆大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/80092">重庆大学</a>
                    </td>
                    <td rowspan="3" class="bidcontentlist">
                        <uc2:BidListBySchool ID="BidListBySchool5" CategoryId="5" CategoryName="最新招标公告" CategoryEnglishName="Latest Bid Information"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/西南民族大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/135744">西南民族大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/四川医科大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/上海交通大学">四川医科大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/云南农业大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/119402">云南农业大学</a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; height: 80px;">
                        <img src="imgs/xuexiao/贵州师范大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/119736">贵州师范大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/西南大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/125309">西南大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/贵州大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/119891">贵州大学</a>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table cellpadding="0" cellspacing="0" class="tblGaoxiaoBidList">
                <tr>
                    <td rowspan="3" class="shupai">
                        西北地区
                    </td>
                    <td rowspan="3" style="width: 170px; text-align: center;">
                        <a href="/HighSchoolBidList/cn/157901">
                            <img src="imgs/xuexiao/西安交通大学.png" style="width: 120px; height: 120px;" /><br />
                            西安交通大学<br />
                            累计发布
                            <asp:Label runat="server" ID="lblXAJTDX" Style="color: Orange;"></asp:Label>
                            次招标</a>
                    </td>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/兰州大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/120135">兰州大学</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/西北大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/126345">西北大学</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/宁夏大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/135386">宁夏大学</a>
                    </td>
                    <td rowspan="3" class="bidcontentlist">
                        <uc2:BidListBySchool ID="BidListBySchool6" CategoryId="6" CategoryName="最新招标公告" CategoryEnglishName="Latest Bid Information"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/兰州理工大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/120048">兰州理工大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/西安邮电大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/上海交通大学">西安邮电大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/新疆大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/上海交通大学">新疆大学</a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; height: 80px;">
                        <img src="imgs/xuexiao/西安理工大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/121937">西安理工大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/陕西师范大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/157856">陕西师范大学</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/西北工业大学.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/139461">西北工业大学</a>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
    <link href="/css/biddetail.css" rel="stylesheet" type="text/css" />
</body>
</html>
