<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HighSchoolListByAlpha.aspx.cs"
    Inherits="GoBiding.Web.HighSchoolListByAlpha" %>
<%@ Register src="UserCenter/HighSchool/FirstAlphaList.ascx" tagname="FirstAlphaList" tagprefix="uc3" %>
<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <asp:Literal runat="server" ID="ltrBitTitle"></asp:Literal>-去投标网(www.gobiding.com)
    </title>
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <meta name="keywords" runat="server" id="keyTitle" />
    <meta name="description" runat="server" id="descMeta" />
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
                <div style="border-top: 1px solid #dcdcdc;">
                    <table border="0" cellpadding="0" cellspacing="0" class="tblBottom">
                        <tr>
                            <td style="max-width: 50%;">
                                <p class="bg-success" style="padding: 5px 10px 5px 10px;">
                                    <asp:Label runat="server" ID="lblCompanyName" Style="font-weight: bold;"></asp:Label>
                                    按 <asp:Label runat="server" ID="lblFirstCh"></asp:Label> 字母排序，排名不分先后
                                    
                                    </p>
                            </td>
                        </tr>
                    </table>
                    <asp:ListView runat="server" ID="rptBidList" GroupItemCount="5">
                        <LayoutTemplate>
                            <table>
                                <tr runat="server" id="groupplaceholder">
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <GroupTemplate>
                            <tr>
                                <td id="itemplaceholder" runat="server">
                                </td>
                            </tr>
                        </GroupTemplate>
                        <ItemTemplate>
                            <td style="width: 240px;">
                                <a href="HighSchoolBidList.html?cn=<%#Eval("SchoolName")%>">
                                <%#Eval("SchoolName")%>
                                </a>
                            </td>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </div>
    <div>
    </div>
    </form>
    <link href="/css/biddetail.css" rel="stylesheet" type="text/css" />
</body>
</html>
