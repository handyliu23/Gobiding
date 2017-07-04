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
                <li><a href="/Default.html">ȥͶ����</a></li>
                <li><a href="/BidList.html">�ɹ��б�</a></li>
                <li class="active">
                    <asp:Literal runat="server" ID="lblTitle2"></asp:Literal></li>
            </ol>
        </div>
    </div>
    <div class="container" style="width: 100%; background-color: #F8F8F8; padding: 0px; min-height:800px;">
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
                                ��������
                            </th>
                            <td>
                                <asp:Literal runat="server" ID="ltrPublishTime"></asp:Literal>
                            </td>
                            <th>
                                �б����
                            </th>
                            <td>
                                <asp:Literal runat="server" ID="ltrCategoryId"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                �ɹ�����
                            </th>
                            <td>
                                <asp:Literal runat="server" ID="ltrProvinceName"></asp:Literal>
                            </td>
                            <th>
                                ��������
                            </th>
                            <td>
                                <asp:Literal runat="server" ID="ltrExpireTime"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ������
                            </th>
                            <td>
                                <asp:Literal runat="server" ID="ltrBidCompany"></asp:Literal>
                            </td>
                            <th>
                                Ԥ����
                            </th>
                            <td>
                                <asp:Literal runat="server" ID="ltrBidAmount"></asp:Literal>
                            </td>
                        </tr>
                        <%-- <tr>
                            <th style="height: 80px;">
                                ��ע�����û�
                            </th>
                            <td colspan="3" style="text-align: left; padding-left: 20px;">
                                <img src="/UserCenter/img/avatar5.png" width="55" style="border-radius: 50%;" />
                                <img src="/UserCenter/img/avatar2.png" width="55" style="border-radius: 50%; margin-left: 20px;" />
                                <img src="/UserCenter/img/avatar5.png" width="55" style="border-radius: 50%; margin-left: 20px;" />
                                <img src="/UserCenter/img/avatar2.png" width="55" style="border-radius: 50%; margin-left: 20px;" />
                            </td>
                        </tr>--%>
                    </table>
                    <div style="color: #333;">
                    </div>
                    <div style="width: 100%; padding: 10px; padding-top:20px; word-break: break-all; word-wrap: break-word;">
                        <span style="font-size:14px; color:#000;padding-bottom:20px;">�ɹ���ϸ��</span>
                        <asp:Literal runat="server" ID="lblContent"></asp:Literal>
                        <span style="font-size:11px; color:#000;padding-bottom:20px;">��ʾ:��ϵ��ʱ��˵����ȥͶ���������Ĳɹ���Ϣ</span>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div style="border: 1px solid #efefef;  font-size: 16px; margin-left: 0px;
                    background-color: #fff; border-bottom: 0px; padding-left:20px; color: #666; 
                    height: 40px; line-height: 40px;">
                    �ɹ�����Ϣ</div>
                <div runat="server" id="divCompanyUser" style="border: 1px solid #ececec; background-color: #fff; padding:20px; font-size:14px; line-height:36px;">
                    �ɹ�����<a href='/CompanyBidList/<%= companyId %>.html'>
                    <font style="font-size:16px;"><asp:Literal runat="server" ID="ltrCompanyName"></asp:Literal></font></a>&nbsp;&nbsp;
                    <img alt="����֤" title="����֤" src="/imgs/system/certificate_32px_1175534_easyicon.net.png" style="height:24px;" /><Br />
                    ���ڵ�����<asp:Literal runat="server" ID="ltrArea"></asp:Literal><br />
                    ��Ӫ��Χ��<asp:Literal runat="server" ID="ltrMajor"></asp:Literal><br />
                    �������ޣ�<asp:Literal runat="server" ID="ltrYears"></asp:Literal> ��<br /> 
                    ������ҵ��<asp:Literal runat="server" ID="ltrDomain"></asp:Literal><br />
                    �ɹ�������<asp:Literal runat="server" ID="ltrPubCount"></asp:Literal> ����Ŀ<br /> 
                    ����Ǣ̸��<a target="blank" href="tencent://message/?uin=<%= qqstring %>&Site=www.gobiding.com&Menu=yes"><img border='0' src='http://wpa.qq.com/pa?p=1:<%= qqstring %>:8' alt=''></a>
                </div>

                <div  runat="server" id="divPersonUser" style="border: 1px solid #ececec; background-color: #fff; padding:20px; font-size:14px; line-height:36px;">
                    �ɹ�����<span style="font-size:14px;" id="span1" runat="server">����</span><br />
                    ��ϵ�ˣ�<asp:Literal runat="server" ID="ltrContacter"></asp:Literal><br />
                    ������<asp:Literal runat="server" ID="ltrProvince"></asp:Literal> <asp:Literal runat="server" ID="ltrcity"></asp:Literal> <br />
                    ��ϵ�绰��<asp:Literal runat="server" ID="ltrMobile"></asp:Literal><br />
                    ����Ǣ̸��<a target="blank" href="tencent://message/?uin=<%= qqstring %>&Site=www.gobiding.com&Menu=yes"><img border='0' src='http://wpa.qq.com/pa?p=1:<%= qqstring %>:8' alt=''></a>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>