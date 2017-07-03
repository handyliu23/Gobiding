<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyBidList.aspx.cs"
    Inherits="GoBiding.Web.CompanyBidList" %>

<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <link rel="shortcut icon" type="image/x-icon" href="/imgs/system/logo_16_16.png"
        media="screen" />
    <script src="/js/thirdplugin.js" type="text/javascript"></script>
    <style>
        *
        {
            margin: 0;
            padding: 0;
            font-family: "微软雅黑";
            font-size: 14px;
            line-height: 2em;
            color: #333;
        }
        .breadcrumb a
        {
            color: #fff;
        }
        .breadcrumb li.active
        {
            color: #fff;
        }
    </style>
</head>
<body>
    <uc1:Top ID="Top1" runat="server" />
    <div style="background-color: #22252A;">
        <div class="container" style="padding: 0px; height: 44px;">
            <ol class="breadcrumb" style="background-color: #22252A;">
                <li><a href="/Default.html">去投标网</a></li>
                <li><a href="/BidList.html">招标列表</a></li>
            </ol>
        </div>
    </div>
    <form id="form1" runat="server">
    <div style="width: 100%; background-color: #fcfcfc; min-height: 800px;">
        <div class="container">
            <div class="col-lg-4" style="margin-top: 20px; padding: 0px; margin-left: 0px;">
                <div style="border: 1px solid #efefef; font-size: 14px; margin-left: 0px; background-color: #fff;
                    border-bottom: 0px; padding-left: 20px; color: #666; height: 40px; line-height: 40px;">
                    采购商信息</div>
                <div style="border: 1px solid #ececec; background-color: #fff; padding: 20px; font-size: 14px;
                    line-height: 36px;">
                    <font style="font-size: 16px;">
                        <asp:Literal runat="server" ID="ltrCompanyName"></asp:Literal></font>&nbsp;&nbsp;
                    <img alt="已认证" title="已认证" src="/imgs/system/certificate_32px_1175534_easyicon.net.png"
                        style="height: 22px;" /><br />
                    所在地区：<asp:Literal runat="server" ID="ltrArea"></asp:Literal><br />
                    主营范围：<asp:Literal runat="server" ID="ltrMajor"></asp:Literal><br />
                    加入年限：<asp:Literal runat="server" ID="ltrYears"></asp:Literal>
                    年<br />
                    所属行业：<asp:Literal runat="server" ID="ltrDomain"></asp:Literal><br />
                    采购次数：<asp:Literal runat="server" ID="ltrPubCount"></asp:Literal>
                    个项目<br />
                    发布招标数：<asp:Literal runat="server" ID="ltrBidCount"></asp:Literal>
                    次<br />
                    联系人：<asp:Literal runat="server" ID="ltrContacter"></asp:Literal>

                    <asp:Button runat="server" class="btn btn-success"
                        style="width: 340px; margin-top: 10px;" id="btnUserCenter" Text="是我的公司，我要认领" 
                        onclick="btnUserCenter_Click">
                            </asp:Button>
                </div>

                <div style="border: 1px solid #efefef; font-size: 14px; margin-left: 0px; background-color: #fff;
                    border-bottom: 0px; padding-left: 20px; margin-top:20px; color: #666; height: 40px; line-height: 40px;">
                    企业证书</div>
                <div style="border: 1px solid #ececec; background-color: #fff; padding: 10px; font-size: 14px;
                    line-height: 36px;">
                    <table id="tblAuthentication" runat="server">
                        <tr>
                        <td style="padding:10px;">
                            营业执照: 已认证
                        <%--<asp:Image ID="imgYYZZ" runat="server" style="width:340px; max-height:400px;" />--%></td>
                        </tr>
                         <tr>
                        <td style="padding:10px;">
                            组织机构证: 已认证
                        <%--<asp:Image ID="imgZZJG" runat="server" style="width:340px;max-height:400px;" />--%></td>
                        </tr>
                         <tr>
                        <td style="padding:10px;">
                            税务登记证: 已认证
                        <%--<asp:Image ID="imgSWDJ" runat="server"  style="width:340px;max-height:400px;"/>--%></td>
                        </tr>
                    </table>
                    
                   
                </div>
            </div>
            <div class="col-lg-8" style="margin-left: 0px;">
                <div class="row" style="float: left; width: 100%; background-color: #fff; margin-top: 20px;
                    margin-left: 0px;">
                    <div style="line-height: 30px; padding: 5px; border-bottom: 1px solid #ececec; background-color: #fff;
                        padding-left: 20px;">
                        <font style="font-weight: bold; font-size: 14px;"></font>企业介绍</div>
                    <div style="padding: 20px;">
                        <asp:Literal runat="server" ID="ltrCompanyNotes"></asp:Literal>
                    </div>
                </div>
                <div class="row" style="float: left; width: 100%; background-color: #fff; margin-top: 20px;
                    margin-left: 0px;">
                    <div style="line-height: 30px; padding: 5px; border-bottom: 1px solid #ececec; background-color: #fff;
                        padding-left: 20px;">
                        <font style="font-weight: bold; font-size: 14px;"></font>发布过的招标公告</div>
                    <div style="margin-left: 0px; padding: 10px; padding-left: 20px;">
                        <table cellpadding="0" cellspacing="0">
                            <asp:Repeater runat="server" ID="rptBidList">
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 130px; height: 30px; line-height: 30px; padding-left: 10px;">
                                            <%#DateTime.Parse(Eval("BidPublishTime").ToString()).ToShortDateString()%>
                                        </td>
                                        <td style="height: 30px; line-height: 30px;">
                                            <a href='/BidDetail/<%#Eval("BidId")%>.html' style="text-decoration: none; color: #333;">
                                                <%# Eval("BidTitle").ToString().Length > 36 ? Eval("BidTitle").ToString().Substring(0, 36) : Eval("BidTitle").ToString()%></a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <div style="padding: 10px;" id="divzbgg" runat="server">
                            暂无
                        </div>
                    </div>
                </div>
                <div class="row" style="float: left; width: 100%; background-color: #fff; margin-top: 20px;
                    margin-left: 0px;">
                    <div style="line-height: 30px; padding: 5px; border-bottom: 1px solid #ececec; padding-left: 20px;">
                        <font style="font-weight: bold; font-size: 14px;">
                            <asp:Literal runat="server" ID="Literal1"></asp:Literal></font> 发布过的变更公告</div>
                    <div style="width: 100%; padding: 20px;">
                        <table>
                            <asp:Repeater runat="server" ID="rptZBGGBidList">
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 130px; height: 30px; line-height: 30px; padding-left: 10px;">
                                            <%#DateTime.Parse(Eval("BidPublishTime").ToString()).ToShortDateString()%>
                                        </td>
                                        <td style="height: 30px; line-height: 30px;">
                                            <a href='/BidDetail/<%#Eval("BidId")%>.html' style="text-decoration: none; color: #333;">
                                                <%# Eval("BidTitle").ToString().Length > 36 ? Eval("BidTitle").ToString().Substring(0, 36) : Eval("BidTitle").ToString()%></a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <div style="padding: 10px;" id="divbggg" runat="server">
                            暂无
                        </div>
                    </div>
                </div>
                <div class="row" style="float: left; width: 100%; background-color: #fff; margin-top: 20px;
                    margin-left: 0px;">
                    <div style="line-height: 30px; padding: 5px; border-bottom: 1px solid #ececec; padding-left: 20px;">
                        <font style="font-weight: bold; font-size: 14px;">
                            <asp:Literal runat="server" ID="Literal2"></asp:Literal></font> 发布过的中标公告</div>
                    <div style="width: 100%; padding: 20px;">
                        <table>
                            <asp:Repeater runat="server" ID="rptzbgg">
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 130px; height: 30px; line-height: 30px; padding-left: 10px;">
                                            <%#DateTime.Parse(Eval("BidPublishTime").ToString()).ToShortDateString()%>
                                        </td>
                                        <td style="height: 30px; line-height: 30px;">
                                            <a href='/BidDetail/<%#Eval("BidId")%>.html' style="text-decoration: none; color: #333;">
                                                <%# Eval("BidTitle").ToString().Length > 36 ? Eval("BidTitle").ToString().Substring(0, 36) : Eval("BidTitle").ToString()%></a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <div style="padding: 10px;" id="divzhbgg" runat="server">
                            暂无
                        </div>
                    </div>
                </div>
                <div class="row" style="float: left; width: 100%; background-color: #fff; margin-top: 20px;
                    margin-left: 0px;">
                    <div style="line-height: 30px; padding: 5px; border-bottom: 1px solid #ececec; padding-left: 20px;">
                        发布过的废标公告</div>
                    <div style="width: 100%; padding: 20px;">
                        <table>
                            <asp:Repeater runat="server" ID="rptfbgg">
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 130px; height: 30px; line-height: 30px; padding-left: 10px;">
                                            <%#DateTime.Parse(Eval("BidPublishTime").ToString()).ToShortDateString()%>
                                        </td>
                                        <td style="height: 30px; line-height: 30px;">
                                            <a href='/BidDetail/<%#Eval("BidId")%>.html' style="text-decoration: none; color: #333;">
                                                <%# Eval("BidTitle").ToString().Length > 36 ? Eval("BidTitle").ToString().Substring(0, 36) : Eval("BidTitle").ToString()%></a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
                                <div class="row" style="float: left; width: 100%; background-color: #fff; margin-top: 20px;
                    margin-left: 0px;">
                    <div style="line-height: 30px; padding: 5px; border-bottom: 1px solid #ececec; padding-left: 20px;">
                        发布过的竞争性谈判公告</div>
                    <div style="width: 100%; padding: 20px;">
                        <table>
                            <asp:Repeater runat="server" ID="rptjzxtp">
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 130px; height: 30px; line-height: 30px; padding-left: 10px;">
                                            <%#DateTime.Parse(Eval("BidPublishTime").ToString()).ToShortDateString()%>
                                        </td>
                                        <td style="height: 30px; line-height: 30px;">
                                            <a href='/BidDetail/<%#Eval("BidId")%>.html' style="text-decoration: none; color: #333;">
                                                <%# Eval("BidTitle").ToString().Length > 36 ? Eval("BidTitle").ToString().Substring(0, 36) : Eval("BidTitle").ToString()%></a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
                
            </div>
        </div>
    </div>
    </form>
</body>
</html>
