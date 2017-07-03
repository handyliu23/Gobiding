<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HighSchoolBidList.aspx.cs"
    Inherits="GoBiding.Web.HighSchoolBidList" %>

<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="UserCenter/Index/BidListBySchool.ascx" TagName="BidListBySchool"
    TagPrefix="uc2" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register src="UserCenter/HighSchool/FirstAlphaList.ascx" tagname="FirstAlphaList" tagprefix="uc3" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <meta name="keywords" runat="server" id="keyTitle" />
    <meta name="description" runat="server" id="descMeta" />
    <link rel="shortcut icon" type="image/x-icon" href="/imgs/system/logo_16_16.png" media="screen" />

    <script src="/js/thirdplugin.js" type="text/javascript"></script>
    <style>
        .tblFirstCh td
        {
            text-align: center;
            width: 50px;
            border-color: #eee;
            cursor: pointer;
        }
        #bidlisttypediv td
        {
            padding: 5px 0px 5px 0px;
            border-color: #eee;
            height: 24px;
            line-height: 24px;
            text-align: center;
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
        .tblBottom td
        {
            border: 0px;
        }
        .tbltop
        {
            border: 0px solid #ececec;
        }
        .tbltop td
        {
            border: 0px;
        }
        .icon
        {
            box-sizing: border-box;
            width: 68px;
            height: 85px;
            position: absolute;
            left: 60px;
            top: 0;
            color: #fff;
            overflow: hidden;
            text-align: center;
            font-size: 16px;
            padding: 8px 12px;
            background: url(/imgs/system/zhidingTJ.png) center no-repeat;
        }
        .tbltop td:hover
        {
            opacity: 0.7;
        }
        .tbltop a:hover
        {
            color: #000;
            text-decoration: none;
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
    <div style="width: 1140px; margin: 0px auto;">
        <uc3:FirstAlphaList ID="FirstAlphaList1" runat="server" />
        
        <div style="width: 100%; padding-top: 10px;">
            <div class="col-lg-12" id="tablecontent">
                <div style="height: 120px; border-top:1px solid #dcdcdc;">
                    <div class="icon">
                        <span style="box-sizing: border-box; color: #fff; word-wrap: break-word; line-height: 1.6;
                            font-size: 16px;">热门招标</span>
                    </div>
                    <table class="tbltop">
                        <tr>
                        <td style="width:100px;"></td>
                            <td style="border-right:1px solid #dcdcdc; text-align:center;">
                            <a href="HighSchoolBidList/cn/119093">
                                <img alt="华北理工大学" src="/imgs/xuexiao/华北理工大学.png" style="width: 65px; height: 65px;" /> <br />华北理工大学<br />
                                <font style="font-size:10px;">累计发布  <asp:Label runat="server" ID="lblhblgdx" Style="color: Orange;"></asp:Label> 条招标信息</font></a>
                            </td>
                            <td style="border-right:1px solid #dcdcdc;text-align:center;">
                                <a href="HighSchoolBidList/cn/119077"><img alt="河北工业大学" src="/imgs/xuexiao/河北工业大学.png" style="width: 65px; height: 65px;" /> <br />河北工业大学<br />
                                <font style="font-size:10px;">累计发布  <asp:Label runat="server" ID="lblhbgydx" Style="color: Orange;"></asp:Label> 条招标信息</font></a>
                            </td>
                            <td style="border-right:1px solid #dcdcdc;text-align:center;">
                                <a href="HighSchoolBidList/cn/119328"><img alt="福建农林大学" src="/imgs/xuexiao/福建农林大学.png" style="width: 65px; height: 65px;" /> <br />福建农林大学<br />
                                <font style="font-size:10px;">累计发布  <asp:Label runat="server" ID="lblfjnldx" Style="color: Orange;"></asp:Label> 条招标信息</font></a>
                            </td>
                            <td style="text-align:center;">
                                <a href="HighSchoolBidList/cn/124678"><img alt="南昌大学" src="/imgs/xuexiao/南昌大学.png" style="width: 65px; height: 65px;" /> <br />南昌大学<br />
                                <font style="font-size:10px;">累计发布  <asp:Label runat="server" ID="lblncdx" Style="color: Orange;"></asp:Label> 条招标信息</font></a>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div style="border-top:1px solid #dcdcdc;">
                    <table border="0" cellpadding="0" cellspacing="0" class="tblBottom">
                    <tr>
                        <td style="max-width: 50%;">
                            <p class="bg-success" style="padding: 5px 10px 5px 10px;">
                                <asp:Label runat="server" ID="lblCompanyName" style="font-weight:bold;"></asp:Label> 及附属单位累计共发布招标信息
                                <asp:Label runat="server" ID="lblTotalCount"></asp:Label>
                                条!</p>
                        </td>
                        <td>
                            <div class="pull-right">
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Width="100%" UrlPaging="true"
                                    ShowPageIndexBox="Never" ShowNavigationToolTip="False" ShowCustomInfoSection="Never"
                                    CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList"
                                    PagingButtonSpacing="0" CurrentPageButtonClass="active" PageSize="15" OnPageChanged="AspNetPager1_PageChanged">
                                </webdiyer:AspNetPager>
                            </div>
                        </td>
                    </tr>
                </table>
                <table id="bidlisttypediv">
                    <asp:Repeater runat="server" ID="rptBidList">
                        <HeaderTemplate>
                            <tr>
                                <th>
                                    发布类型
                                </th>
                                <th>
                                    发布时间
                                </th>
                                <th>
                                    招标标题
                                </th>
                                <th>
                                    发布单位
                                </th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td style="width: 100px;">
                                    <%# GoBiding.BLL.CommonUtility.GetBidTypeValue(Eval("BidType").ToString())%>
                                </td>
                                <td style="width: 140px;">
                                    <font style="font-size: 12px; color: #000">
                                        <%#Eval("BidPublishTime", "{0:D}")%></font>
                                </td>
                                <td style="font-family: '微软雅黑'; line-height: 25px; height: 25px; vertical-align: top;
                                    text-align: left; padding-left:10px;">
                                    <a href='/BidDetail/<%#Eval("BidId")%>.html' style="text-decoration: none; color: #000;
                                        font-weight: 500;">
                                        <%#Eval("BidTitle").ToString().Length > 36 ? Eval("BidTitle").ToString().Substring(0, 36) + "..." : Eval("BidTitle").ToString()%></a><br />
                                </td>
                                <td style="width: 240px;">
                                    <%#Eval("BidCompanyName")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table></div>
            
            </div>
        </div>
    </div>
    <div>
    </div>
    </form>
    <link href="/css/biddetail.css" rel="stylesheet" type="text/css" />
</body>
</html>
