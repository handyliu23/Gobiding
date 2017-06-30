<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="GoBiding.Web.Province.Index" %>

<%@ Register Src="/UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
</head>
<body>
    <form id="form1" runat="server">
    <uc1:Top ID="Top1" runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <img src="/imgs/system/bidlistbg.jpg" />
                <br />
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 50%; vertical-align: top;">
                            <div style="border-left: 4px solid #000; font-weight: 700; font-size: 14px; padding-left: 10px;
                                padding-top: 0px; margin-top: 10px; color: #000; font-family: '微软雅黑';">
                                招标公告 <span style="font-size: 12px;">
                                    <%= CategoryEnglishName %>
                                </span>
                            </div>
                            <div style="width: 100%; padding-top: 10px;">
                                <div class="col-lg-12" id="tablecontent">
                                    <table id="bidlisttypediv1">
                                        <asp:Repeater runat="server" ID="rptBidList">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="width: 100%; font-family: '微软雅黑'; line-height: 25px; height: 25px; vertical-align: top;">
                                                        <font style="font-size: 12px; color: #000">
                                                            <%#Eval("BidPublishTime", "{0:D}")%></font> <a href='/BidDetail/<%#Eval("BidId")%>.html'
                                                                style="font-size: 12px; text-decoration: none; color: #000; font-weight: 500;">
                                                                <%#Eval("BidTitle").ToString().Length > 36 ? Eval("BidTitle").ToString().Substring(0, 36) + "..." : Eval("BidTitle").ToString()%></a><br />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                            </div>
                        </td>
                        <td style="width: 50%; vertical-align: top;">
                            <div style="border-left: 4px solid #000; font-weight: 700; font-size: 14px; padding-left: 10px;
                                padding-top: 0px; margin-top: 10px; color: #000; font-family: '微软雅黑';">
                                中标公告 <span style="font-size: 12px;">
                                    <%= CategoryEnglishName %>
                                </span>
                            </div>
                            <div style="width: 100%; padding-top: 10px;">
                                <div class="col-lg-12" id="Div1">
                                    <table id="Table1">
                                        <asp:Repeater runat="server" ID="rptBidResultList">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="width: 100%; font-family: '微软雅黑'; line-height: 25px; height: 25px; vertical-align: top;">
                                                        <font style="font-size: 12px; color: #000">
                                                            <%#Eval("BidPublishTime", "{0:D}")%></font> <a href='/BidDetail/<%#Eval("BidId")%>.html'
                                                                style="font-size: 12px; text-decoration: none; color: #000; font-weight: 500;">
                                                                <%#Eval("BidTitle").ToString().Length > 36 ? Eval("BidTitle").ToString().Substring(0, 36) + "..." : Eval("BidTitle").ToString()%></a><br />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 50%; vertical-align: top;">
                            <div style="border-left: 4px solid #000; font-weight: 700; font-size: 14px; padding-left: 10px;
                                padding-top: 0px; margin-top: 10px; color: #000; font-family: '微软雅黑';">
                                变更公告 <span style="font-size: 12px;">
                                    <%= CategoryEnglishName %>
                                </span>
                            </div>
                            <div style="width: 100%; padding-top: 10px;">
                                <div class="col-lg-12" id="Div2">
                                    <table id="Table2">
                                        <asp:Repeater runat="server" ID="rptBidChangeList">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="width: 100%; font-family: '微软雅黑'; line-height: 25px; height: 25px; vertical-align: top;">
                                                        <font style="font-size: 12px; color: #000">
                                                            <%#Eval("BidPublishTime", "{0:D}")%></font> <a href='/BidDetail/<%#Eval("BidId")%>.html'
                                                                style="font-size: 12px; text-decoration: none; color: #000; font-weight: 500;">
                                                                <%#Eval("BidTitle").ToString().Length > 36 ? Eval("BidTitle").ToString().Substring(0, 36) + "..." : Eval("BidTitle").ToString()%></a><br />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                            </div>
                        </td>
                        <td style="width: 50%; vertical-align: top;">
                            <div style="border-left: 4px solid #000; font-weight: 700; font-size: 14px; padding-left: 10px;
                                padding-top: 0px; margin-top: 10px; color: #000; font-family: '微软雅黑';">
                                废标公告 <span style="font-size: 12px;">
                                    <%= CategoryEnglishName %>
                                </span>
                            </div>
                            <div style="width: 100%; padding-top: 10px;">
                                <div class="col-lg-12" id="Div3">
                                    <table id="Table3">
                                        <asp:Repeater runat="server" ID="rptBidCancelList">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="width: 100%; font-family: '微软雅黑'; line-height: 25px; height: 25px; vertical-align: top;">
                                                        <font style="font-size: 12px; color: #000">
                                                            <%#Eval("BidPublishTime", "{0:D}")%></font> <a href='/BidDetail/<%#Eval("BidId")%>.html'
                                                                style="font-size: 12px; text-decoration: none; color: #000; font-weight: 500;">
                                                                <%#Eval("BidTitle").ToString().Length > 36 ? Eval("BidTitle").ToString().Substring(0, 36) + "..." : Eval("BidTitle").ToString()%></a><br />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 50%; vertical-align: top;">
                            <div style="border-left: 4px solid #000; font-weight: 700; font-size: 14px; padding-left: 10px;
                                padding-top: 0px; margin-top: 10px; color: #000; font-family: '微软雅黑';">
                                邀请招标 <span style="font-size: 12px;">
                                    <%= CategoryEnglishName %>
                                </span>
                            </div>
                            <div style="width: 100%; padding-top: 10px;">
                                <div class="col-lg-12" id="Div4">
                                    <table id="Table4">
                                        <asp:Repeater runat="server" ID="rptBidInviteList">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="width: 100%; font-family: '微软雅黑'; line-height: 25px; height: 25px; vertical-align: top;">
                                                        <font style="font-size: 12px; color: #000">
                                                            <%#Eval("BidPublishTime", "{0:D}")%></font> <a href='/BidDetail/<%#Eval("BidId")%>.html'
                                                                style="font-size: 12px; text-decoration: none; color: #000; font-weight: 500;">
                                                                <%#Eval("BidTitle").ToString().Length > 36 ? Eval("BidTitle").ToString().Substring(0, 36) + "..." : Eval("BidTitle").ToString()%>
                                                            </a>
                                                        <br />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                            </div>
                        </td>
                        <td style="width: 50%; vertical-align: top;">
                            <div style="border-left: 4px solid #000; font-weight: 700; font-size: 14px; padding-left: 10px;
                                padding-top: 0px; margin-top: 10px; color: #000; font-family: '微软雅黑';">
                                单一源公告 <span style="font-size: 12px;">
                                    <%= CategoryEnglishName %>
                                </span>
                            </div>
                            <div style="width: 100%; padding-top: 10px;">
                                <div class="col-lg-12" id="Div5">
                                    <table id="Table5">
                                        <asp:Repeater runat="server" ID="rptBidSingleList">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="width: 100%; font-family: '微软雅黑'; line-height: 25px; height: 25px; vertical-align: top;">
                                                        <font style="font-size: 12px; color: #000">
                                                            <%#Eval("BidPublishTime", "{0:D}")%></font> <a href='/BidDetail/<%#Eval("BidId")%>.html'
                                                                style="font-size: 12px; text-decoration: none; color: #000; font-weight: 500;">
                                                                <%#Eval("BidTitle").ToString().Length > 36 ? Eval("BidTitle").ToString().Substring(0, 36) + "..." : Eval("BidTitle").ToString()%></a><br />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
