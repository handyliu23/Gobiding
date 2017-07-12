<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Mercury.Web.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 100%; background-color: #fff; padding: 20px;">
        <div style="width: 950px; margin: 0px auto; min-height: 300px; background-color: #fcfcfc;
            padding: 20px;">
            <img src="http://www.gobiding.com/imgs/ad/ad_m_2.gif" />
            <br />
            <div style="font-size: 13px; color: #333; padding: 10px; line-height: 24px;  font-family: '微软雅黑';">
                订阅说明：去投标网每日收集发布全国招标采购信息超过10000条，平台为您免费推送一次全国各行业招标信息，登录官方平台可以设置追踪器获取更多精准的招标采购信息商业市场竞争激烈，愿您抓住每一个机会，您的成功是我们为之努力的心愿！
                <br /><br />
                以下是为您推选的招标信息（您也可以免费注册登录去投标网设置订阅关键词，获取更精准匹配的招标信息）：
                </div>
            <asp:Repeater runat="server" ID="rptBidList">
                <ItemTemplate>
                    <table id="bidinfoitem" cellspacing="0" style="width: 100%; border: 1px solid #dcdcdc;
                        margin-bottom: 10px;">
                        <tr>
                            <td style="width: 70px; height: 110px; padding-left: 10px; text-align: center; line-height: 30px;
                                vert-align: middle; font-size: 12px;">
                                <%# DateTime.Parse(Eval("CreateTime").ToString()).ToShortDateString()%>
                            </td>
                            <td style="width: 500px; line-height: 24px; padding: 5px; vertical-align: top;">
                                <%# Eval("BidType").ToString() == "1" ? "<span style=\"background: #FFBB66; font-size: 9px; padding: 2px 5px 2px 5px; color: #fff;\">正在招标</span>":""%>
                                <a href='/BidDetail/<%#Eval("BidId")%>.html' target="_blank" style="font-size: 14px;
                                    font-family: microsoft yahei; text-decoration: none; color: #000;">
                                    <%#Eval("BidTitle").ToString().Length > 45 ? Eval("BidTitle").ToString().Substring(0, 45) + "...": Eval("BidTitle").ToString() %></a><br />
                                <div style="color: #666; font-size: 12px; line-height: 24px; padding-right: 100px;
                                    padding-bottom: 2px;">
                                    <%# Eval("BidContent").ToString()%></div>
                                <span style="background-color: #fff; font-size: 12px; padding: 5px;">
                                    <%# Mercury.BLL.CommonUtility.GetBidTypeValue(Eval("BidType").ToString())%></span>
                                <span style="background-color: #fff; font-size: 12px; padding: 5px;">
                                    <%# GetBidCategoryNameValue(Eval("BidCategoryId").ToString())%></span> <span style="background-color: #fff;
                                        font-size: 12px; padding: 5px;">
                                        <%#GetProvinceName(Eval("ProvinceId").ToString())%></span>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
            <div style="line-height: 24px; font-family: '微软雅黑'; padding: 10px; font-size: 14px;">
                <table>
                    <tr>
                        <td style="width: 200px;">
                            <img src="http://www.gobiding.com/imgs/system/wx300_300.png" width="170" />
                        </td>
                        <td>
                            扫一扫关注微信公众号即可手机微信订阅，万千商机，尽在掌握！<br />
                            如有任何疑问或者建议请及时联系我们！<br />
                            官方网址：http://www.gobiding.com<br />
                            联系地址：上海市长宁区金钟路968号<br />
                            微信公众号：去投标网<br />
                            企业邮箱：postmaster@gobiding.com<br />
                            qq客服：2968038259<br />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>


    <asp:literal runat="server" id="ltrcontent" ></asp:literal>
    </form>
</body>
</html>
