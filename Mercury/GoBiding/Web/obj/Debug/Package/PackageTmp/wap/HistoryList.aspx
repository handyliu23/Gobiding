<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistoryList.aspx.cs" Inherits="GoBiding.Web.wap.HistoryList" %>
<%@ Register Src="UserControls/Bottom.ascx" TagName="Bottom" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的关注列表_去投标网_全国免费招投标服务平台</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
    <script src="/js/thirdplugin.js" type="text/javascript"></script>
            <link href="/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <style>
        body
        {
            font-size: 12px;
            color: #000;
            width: 100%;
            overflow-x: hidden;
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
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container" style="width: 100%; padding: 0px; margin: 0px;">
        <div class="row" style="width: 100%; padding: 0px; margin: 0px; height: 40px; line-height: 40px;
            background-color: #ececec;">
            <div class="col-lg-12" style="width: 100%; padding-left: 10px; margin: 0px;">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 68%;">
                            <img src="/imgs/system/admin.png" width="24" height="24" />&nbsp;去投标网会员：<asp:Literal
                                runat="server" ID="ltrUserName"></asp:Literal>
                        </td>
                        <td style="width: 20%;">
                            <a href="/wap/Default.aspx">招标大厅</a>
                        </td>
                        <td style="width: 12%; text-align: right;">
                            <a href="Logout.aspx">注销</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div id="divContent" class="row">
        <div class="col-lg-12">
            <div class="box-body no-padding">
                <table class="table table-hover">
                    <asp:Repeater runat="server" ID="rptBidList">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 100%; line-height: 25px; vertical-align: top; padding-bottom: 10px;
                                    border-bottom: 1px solid #fafafa;">
                                    <a href='/wap/BidDetail.aspx?bId=<%#Eval("BidId")%>' style="font-size: 13px; text-decoration: none;
                                        color: #666;">
                                        <%#Eval("BidTitle").ToString().Length > 45 ? Eval("BidTitle").ToString().Substring(0, 45) + "...":Eval("BidTitle").ToString() %></a><br />
                                    <%--    <div style="text-align: right; color: #666; font-size: 12px;">
                                            <%#DateTime.Parse(Eval("BidPublishTime").ToString()).ToShortDateString()%>
                                        </div>--%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
    </div>
        <div style="width: 100%; padding: 0px; margin: 0px;">
        <uc1:Bottom ID="Bottom1" runat="server" />
    </div>
    </form>
</body>
</html>
