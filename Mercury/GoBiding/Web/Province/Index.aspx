<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="GoBiding.Web.Province.Index" %>

<%@ Register Src="/UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <style>
        .breadcrumb li
        {
            font-size: 14px;
            font-family: '΢���ź�';
        }
        .breadcrumb
        {
        }
        .breadcrumb a
        {
            font-size: 14px;
            font-family: '΢���ź�';
            padding: 0px;
            color: #000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:Top ID="Top1" runat="server" />
    <div style="border-top: 1px solid #ececec;">
        <div class="container" style="padding: 0px; margin-top: 20px; border: 1px solid #ececec;">
            <ol class="breadcrumb" style="background-color: #FFF; margin-bottom: 0px; padding: 12px;">
                <li>����ǰ��λ�ã�<a href="/Default.html">ȥͶ����</a></li>
                <li><a href="#">
                    <asp:Literal runat="server" ID="ltrProvinceName"></asp:Literal>�б���Ϣ��</a></li>
            </ol>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-lg-12" style="padding-left: 0px; padding-right: 0px; margin-top: 20px;">
                <div class="col-lg-12" id="Div6" style="font-family: '΢���ź�'; padding-left: 20px;
                    border: 1px solid #ececec; vertical-align: middle; margin-bottom: 20px; padding: 20px;">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 80px;">
                                �б�����
                            </td>
                            <td style="width: 120px;">
                                <asp:DropDownList runat="server" ID="ddlSelectBidType">
                                    <asp:ListItem Text="ȫ��" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="�б깫��" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="�������" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="�б깫��" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="�б�Ԥ��" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="�ϱ깫��" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="�����б�" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="������̸��" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="��һԴ����" Value="8"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                             <td style="width: 80px;">
                                �б����
                            </td>
                            <td style="width: 100px;">
                                <asp:DropDownList runat="server" ID="ddlCitys" width="90">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 80px; text-align: center;">
                                �ؼ���
                            </td>
                            <td style="width: 130px;">
                                <asp:TextBox runat="server" ID="txtKeywords" Height="24" Width="120"></asp:TextBox>
                            </td>
                            <td style="">
                                <asp:Button runat="server" ID="btnSearch" ClientIDMode="Static" Text="����" 
                                    Height="24" Width="60" onclick="btnSearch_Click"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="col-lg-9" style="padding-left: 0px;">
                    <div style="width: 100%; padding: 0px; float: left;">
                        <div class="col-lg-12" id="tabletitle" style="background-color: #fcfcfc; font-family: '΢���ź�';
                            color: #000; font-weight: bold; padding-left: 10px; border: 1px solid #ececec;
                            font-size: 14px; border-bottom: 0px; height: 48px; line-height: 48px;">
                            <img src="/imgs/system/resizeApi.png" alt=""/>&nbsp;<asp:Literal runat="server" ID="ltrProvinceName2"></asp:Literal>�б���Ϣ��
                        </div>
                        <div class="col-lg-12" id="divmaintype" style="font-family: '΢���ź�'; font-weight: bold;
                            padding-left: 20px; border: 1px solid #ececec; border-bottom: 0px; height: 48px; color:#428bca;
                            line-height: 48px;">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 100px;">
                                        <asp:LinkButton id="lnkType1" Text="�б깫��" runat="server" 
                                            onclick="lnkType1_Click"></asp:LinkButton>
                                    </td>
                                    <td style="width: 100px;">
                                        <asp:LinkButton id="lnkType2" Text="�������" runat="server" 
                                            onclick="lnkType2_Click"></asp:LinkButton>
                                    </td>
                                    <td style="width: 100px;">
                                        <asp:LinkButton id="lnkType3" Text="�б깫��" runat="server" 
                                            onclick="lnkType3_Click"></asp:LinkButton>
                                    </td>
                                    <td style="width: 100px;">
                                        <asp:LinkButton id="lnkType4" Text="�б�Ԥ��" runat="server" 
                                            onclick="lnkType4_Click"></asp:LinkButton>
                                    </td>
                                    <td style="width: 100px;">
                                        <asp:LinkButton id="lnkType5" Text="�ϱ깫��" runat="server" 
                                            onclick="lnkType5_Click"></asp:LinkButton>
                                    </td>
                                    <td style="width: 100px;">
                                        <asp:LinkButton id="lnkType6" Text="�����б�" runat="server" 
                                            onclick="lnkType6_Click"></asp:LinkButton>
                                    </td>
                                    <td style="width: 100px;">
                                        <asp:LinkButton id="lnkType7" Text="������̸��" runat="server" 
                                            onclick="lnkType7_Click"></asp:LinkButton>
                                    </td>
                                    <td style="width: 100px;">
                                        <asp:LinkButton id="lnkType8" Text="��һԴ����" runat="server" 
                                            onclick="lnkType8_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="col-lg-12" id="tablecontent" style="padding-left: 0px; padding-right: 0px;">
                            <table id="bidlisttypediv1" cellpadding="0" cellspacing="0" style="width: 100%; padding: 0px;">
                                <asp:Repeater runat="server" ID="rptBidList">
                                    <ItemTemplate>
                                        <tr>
                                            <td style="width: 100%; border: 1px solid #ececec; padding: 20px; font-family: '΢���ź�';
                                                line-height: 24px; height: 24px; font-size: 14px; vertical-align: top;">
                                                <table cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="width: 110px;">
                                                            <%# GoBiding.BLL.CommonUtility.GetBidTypeValue(Eval("BidType").ToString())%>
                                                        </td>
                                                        <td style="width: 550px; padding-right: 20px;">
                                                            <a href='/BidDetail/<%#Eval("BidId")%>.html' style="font-size: 14px; text-decoration: none;
                                                                color: #000; font-weight: 500;">
                                                                <%#Eval("BidTitle").ToString().Length > 46 ? Eval("BidTitle").ToString().Substring(0, 46) + "..." : Eval("BidTitle").ToString()%></a>
                                                            <br />
                                                        </td>
                                                        <td style="width: 260px; font-size: 12px;">
                                                            <%# GetBidCategoryNameValue(Eval("BidCategoryId").ToString())%>
                                                            &nbsp;| &nbsp; <font style="font-size: 12px; color: #000;">
                                                                <%#Eval("BidPublishTime", "{0:D}")%></font> &nbsp; | &nbsp;<font style="font-size: 12px;
                                                                    color: #000">
                                                                    <%# GetCityName(Eval("CityId").ToString())%>
                                                                </font>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr>
                                    <td>
                                        <webdiyer:aspnetpager id="AspNetPager1" runat="server" width="100%" UrlPaging="true" EnableUrlRewriting="true"
                                            numericbuttoncount="15" forecolor="Black" firstpagetext="��һҳ" lastpagetext="βҳ"
                                            showpageindexbox="Never" shownavigationtooltip="False" showcustominfosection="Never"
                                            prevpagetext="��һҳ" nextpagetext="��һҳ" cssclass="pagination" layouttype="Ul" pagingbuttonlayouttype="UnorderedList"
                                            pagingbuttonspacing="0" currentpagebuttonclass="active" pagesize="20" >
                                        </webdiyer:aspnetpager>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3" style="padding-left: 0px; padding-right: 0px;">
                    <div style="width: 100%; height: 48px; line-height: 48px; font-family: '΢���ź�'; padding-left: 10px; background-color: #fcfcfc; 
                        border: 1px solid #ececec; border-bottom: 0px; font-weight: bold;">
                        <img src="/imgs/system/resizeApi%20_city.png" alt="" />&nbsp;<asp:Literal runat="server" ID="ltrProvinceName3"></asp:Literal>�����б���
                    </div>
                    <div style="border: 1px solid #ececec; padding: 10px; line-height: 32px;">
                        <table>
                            <asp:Repeater runat="server" ID="rptBidInviteList">
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 100%; font-family: '΢���ź�'; font-size: 14px; vertical-align: top;
                                            padding-left: 30px;">
                                            <a href="/Province/index/c/<%#Eval("CityID")%>">
                                                <%# GetCityName(Eval("CityID").ToString())%>�б���Ϣ��</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>

                    <div style="width: 100%; height: 48px; line-height: 48px; font-family: '΢���ź�'; padding-left: 10px; background-color: #fcfcfc; 
                        border: 1px solid #ececec; border-bottom: 0px; margin-top:20px; font-weight: bold;">
                        <img src="/imgs/system/resizeApi%20_city.png" alt="" />&nbsp;<asp:Literal runat="server" ID="ltrProvinceName4"></asp:Literal>�����б����˾
                    </div>
                    <div style="border: 1px solid #ececec; padding: 10px; line-height: 32px;">
                        <table>
                            <asp:Repeater runat="server" ID="rptCompanyAgentList">
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 100%; font-family: '΢���ź�'; font-size: 14px; vertical-align: top;
                                            padding-left: 30px;">
                                            <a href="/CompanyBidList/<%#Eval("Id")%>.html">
                                                <%# Eval("VendorName").ToString()%></a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
                <br />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
