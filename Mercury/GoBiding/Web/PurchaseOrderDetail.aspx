<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseOrderDetail.aspx.cs"
    Inherits="GoBiding.Web.PurchaseOrderDetail" %>

<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <link href="/css/biddetail.css" rel="stylesheet" type="text/css" />
    <script src="/js/thirdplugin.js" type="text/javascript"></script>
    <style>
        .detaillabeltable
        {
            margin-top: 20px;
        }
        .detaillabeltable, .detaillabeltable th, .detaillabeltable td
        {
            border: 0px;
            background-color: #FCFCFC;
        }
        .detaillabeltable th
        {
            width: 160px;
            text-align: center;
            background-color: #FAFAFA;
            border: 1px dotted #FFF;
        }
        .detaillabeltable td
        {
            width: 370px;
            text-align: center;
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
    <form id="form1" runat="server">
    <div style="background-color: #22252A;">
        <div class="container" style="padding: 0px; height: 44px;">
            <ol class="breadcrumb" style="background-color: #22252A;">
                <li><a href="/Default.html">去投标网</a></li>
                <li><a href="/BidList.html">采购列表</a></li>
                <li class="active">
                    <asp:Literal runat="server" ID="lblTitle2"></asp:Literal></li>
            </ol>
        </div>
    </div>
    <div class="container" style="width: 100%; background-color: #F8F8F8; padding: 0px;
        min-height: 800px;">
        <div class="container" style="margin-top: 20px;">
            <div class="col-lg-8" style="padding: 20px; background-color: #FFF;">
                <div style="width: 100%; margin: 0px auto; font-size: 14px;">
                    <div style="text-align: center;">
                        <h1 style="font-size: 20px; line-height: 40px;">
                            <asp:Literal runat="server" ID="lblTitle"></asp:Literal></h1>
                    </div>
                    <div>
                        <p class="bg-success">
                        </p>
                    </div>
                    <table class="detaillabeltable">
                        <tr>
                            <th>
                                发布日期
                            </th>
                            <td>
                                <asp:Literal runat="server" ID="ltrPublishTime"></asp:Literal>
                            </td>
                            <th>
                                采购分类
                            </th>
                            <td>
                                <asp:Literal runat="server" ID="ltrCategoryId"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                采购地区
                            </th>
                            <td>
                                <asp:Literal runat="server" ID="ltrProvinceName"></asp:Literal>
                            </td>
                            <th>
                                截至日期
                            </th>
                            <td>
                                <asp:Literal runat="server" ID="ltrExpireTime"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                发布方
                            </th>
                            <td>
                                <asp:Literal runat="server" ID="ltrBidCompany"></asp:Literal>
                            </td>
                            <th>
                                预算金额
                            </th>
                            <td>
                                <asp:Literal runat="server" ID="ltrBidAmount"></asp:Literal>
                            </td>
                        </tr>
                        <%--<tr>
                            <th style="height: 80px;">
                                关注过的用户
                            </th>
                            <td colspan="3" style="text-align: left; padding-left: 20px;">
                                <img src="/UserCenter/img/avatar5.png" width="55" style="border-radius: 50%;" />
                                <img src="/UserCenter/img/avatar2.png" width="55" style="border-radius: 50%; margin-left: 20px;" />
                                <img src="/UserCenter/img/avatar5.png" width="55" style="border-radius: 50%; margin-left: 20px;" />
                                <img src="/UserCenter/img/avatar2.png" width="55" style="border-radius: 50%; margin-left: 20px;" />
                            </td>
                        </tr>--%>
                        <tr>
                            <th style="height: 80px;">
                            </th>
                            <td colspan="3" style="text-align: left; padding-left: 20px;">
                                <br />
                                <br />
                                <asp:Image ID="productImage" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <div style="color: #333;">
                    </div>
                    <div style="width: 100%; padding: 10px; padding-top: 20px; word-break: break-all;
                        word-wrap: break-word;">
                        <span style="font-size: 14px; color: #000; padding-bottom: 20px;">采购明细：</span>
                        <asp:Literal runat="server" ID="lblContent"></asp:Literal>
                        <span style="font-size: 11px; color: #000; padding-bottom: 20px;">提示:联系买方时请说明从去投标网看到的采购信息</span>
                        <br />
                        <br />
                        <div class="row">
                            <div class="col-lg-12" style="margin-top: 0px; padding: 0px;">
                                <div style="width: 100%; padding-top: 10px; float: left;">
                                    <div class="col-lg-12" id="tablecontent">
                                        <asp:ListView runat="server" ID="rptPurchaseOrderList" GroupItemCount="3">
                                            <LayoutTemplate>
                                                <table id="bidlisttypediv1" style="width: 100%; border: 1px solid #ececec;">
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
                                                <td style="width: 230px; font-family: '微软雅黑'; line-height: 25px; height: 200px; vertical-align: top;
                                                    border: 0px;">
                                                    <div style="border: 0px solid #ececec; width: 220px; height: 180px; padding: 10px;
                                                        font-size: 12px;">
                                                        <table cellpadding="0" cellspacing="0" border="0">
                                                            <tr>
                                                                <td rowspan="2" valign="top" style="border: 0px;">
                                                                    <img src='<%#Eval("UserProfile").ToString() %>' style="width: 50px; height: 50px;
                                                                        border-radius: 25px" alt="" />
                                                                </td>
                                                                <td style="padding-left: 4px; border: 0px;">
                                                                    <a target="_blank" href='/PurchaseOrderDetail/<%#Eval("Id")%>.html' style="font-size: 12px;
                                                                        text-decoration: none; color: #000; font-weight: bold;">
                                                                        <div style="height: 48px;">
                                                                            <%#Eval("Title").ToString().Length > 15 ? Eval("Title").ToString().Substring(0, 15) : Eval("Title").ToString()%></div>
                                                                    </a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        发布时间：<font style="font-size: 12px; color: #000"><%#Eval("PublishTime", "{0:D}")%></font><br />
                                                        <font style="font-size: 12px; color: #000">采购方：<%#Eval("CompanyName")%></font><br />
                                                        求购地区：<font style="font-size: 12px; color: #000"><%#Eval("ProvinceName")%><%# Eval("CityName").ToString().Length > 3 ? Eval("CityName").ToString().Substring(0, 3) : Eval("CityName").ToString()%></font><br />
                                                        <a target="_blank" href='/PurchaseOrderDetail/<%#Eval("Id")%>.html' style="font-size: 12px;
                                                            text-decoration: none;">
                                                            <div style="margin-top: 5px; font-size: 12px; border-radus: 2px; text-align: center;
                                                                border: 1px solid #dcdcdc; width: 80px; padding: 0px;">
                                                                查看详细</div>
                                                        </a>
                                                    </div>
                                                </td>
                                            </ItemTemplate>
                                        </asp:ListView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div style="border: 1px solid #efefef; font-size: 16px; margin-left: 0px; background-color: #fff;
                    border-bottom: 0px; padding-left: 20px; color: #666; height: 40px; line-height: 40px;">
                    采购商信息</div>
                <div runat="server" id="divCompanyUser" style="border: 1px solid #ececec; background-color: #fff;
                    padding: 20px; font-size: 14px; line-height: 36px;">
                    采购方：<a href='/CompanyBidList/<%= companyId %>.html'> <font style="font-size: 16px;">
                        <asp:Literal runat="server" ID="ltrCompanyName"></asp:Literal></font></a>&nbsp;&nbsp;
                    <img alt="已认证" title="已认证" src="/imgs/system/certificate_32px_1175534_easyicon.net.png"
                        style="height: 24px;" /><br />
                    所在地区：<asp:Literal runat="server" ID="ltrArea"></asp:Literal><br />
                    主营范围：<asp:Literal runat="server" ID="ltrMajor"></asp:Literal><br />
                    加入年限：<asp:Literal runat="server" ID="ltrYears"></asp:Literal>
                    年<br />
                    所属行业：<asp:Literal runat="server" ID="ltrDomain"></asp:Literal><br />
                    采购次数：<asp:Literal runat="server" ID="ltrPubCount"></asp:Literal>
                    个项目<br />
                    在线洽谈：<a target="blank" href="tencent://message/?uin=<%= qqstring %>&Site=www.gobiding.com&Menu=yes"><img
                        border='0' src='http://wpa.qq.com/pa?p=1:<%= qqstring %>:8' alt=''></a>
                </div>
                <div runat="server" id="divPersonUser" style="border: 1px solid #ececec; background-color: #fff;
                    padding: 20px; font-size: 14px; line-height: 36px;">
                    采购方：<span style="font-size: 14px;" id="span1" runat="server">个人</span><br />
                    联系人：<asp:Literal runat="server" ID="ltrContacter"></asp:Literal><br />
                    地区：<asp:Literal runat="server" ID="ltrProvince"></asp:Literal>
                    <asp:Literal runat="server" ID="ltrcity"></asp:Literal>
                    <br />
                    联系电话：<asp:Literal runat="server" ID="ltrMobile"></asp:Literal><br />
                    在线洽谈：<a target="blank" href="tencent://message/?uin=<%= qqstring %>&Site=www.gobiding.com&Menu=yes"><img
                        border='0' src='http://wpa.qq.com/pa?p=1:<%= qqstring %>:8' alt=''></a>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
