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
    <title>ȫ����ѧ�б�ɹ���_ȫ����ѧ��Ͷ����Ϣ��_��У�б���Ϣ_У԰�б�_У԰�ɹ���Ϣ����ƽ̨_ȥͶ����(www.gobiding.com) </title>
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <meta name="keywords" content="ȫ����ѧ�б�ɹ���_ȫ����ѧ��Ͷ����Ϣ��_��У�б���Ϣ_У԰�б�_У԰�ɹ���Ϣ����ƽ̨_ȥͶ����" />
    <meta name="description" content="ȫ����ѧ�б�ɹ���,�ṩȫ����Χ��ѧְҵ��ѧ��ѧ������б�ɹ���Ϣ"/>
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
                <li><a href="/Default.html">ȥͶ����</a></li>
                <li><a href="/HighSchoolBid.html">У԰�б�</a></li>
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
                        ��������
                    </td>
                    <td rowspan="3" style="width: 170px; text-align: center;">
                        <a href='/HighSchoolBidList/cn/88411'>
                            <img src="imgs/xuexiao/�Ϻ���ͨ��ѧ.png" style="width: 120px; height: 120px;" /><br />
                            �Ϻ���ͨ��ѧ<br />
                            �ۼƷ���
                            <asp:Label runat="server" ID="lblSHJTDX" Style="color: Orange;"></asp:Label>
                            ���б� </a>
                        
                    </td>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/���ݴ�ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/125896">���ݴ�ѧ</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/���մ�ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/137123">���մ�ѧ</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/�㽭��ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/120179">�㽭��ѧ</a>
                    </td>
                    <td rowspan="3" class="bidcontentlist">
                        <uc2:BidListBySchool ID="BidListBySchool1" CategoryId="1" CategoryName="����" CategoryEnglishName="Latest Bid Information"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/�Ϸʹ�ҵ��ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/128963">�Ϸʹ�ҵ��ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/�㽭ʦ����ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/150137">�㽭ʦ����ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/�㽭��ҵ��ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/162203">�㽭��ҵ��ѧ</a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; height: 80px;">
                        <img src="imgs/xuexiao/���ݴ�ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/124490">���ݴ�ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/�Ͼ���ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/136299">�Ͼ���ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/���ݴ�ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/���ݴ�ѧ">���ݴ�ѧ</a>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table cellpadding="0" cellspacing="0" class="tblGaoxiaoBidList">
                <tr>
                    <td rowspan="3" class="shupai">
                        ��������
                    </td>
                    <td rowspan="3" style="width: 170px; text-align: center;">
                        <a href="/HighSchoolBidList/cn/127407">
                            <img src="imgs/xuexiao/������ѧ.png" style="width: 120px; height: 120px;" /><br />
                            ������ѧ<br />
                            �ۼƷ���
                            <asp:Label runat="server" ID="lblBJDX" Style="color: Orange;"></asp:Label>
                            ���б�</a>
                    </td>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/�Ͽ���ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/132635">�Ͽ���ѧ</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/����ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/120139">����ѧ</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/�����Ƽ���ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/120142">�����Ƽ���ѧ</a>
                    </td>
                    <td rowspan="3" class="bidcontentlist">
                        <uc2:BidListBySchool ID="BidListBySchool2" CategoryId="2" CategoryName=" " CategoryEnglishName="Latest Bid Information"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/�й������ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/118920">�й������ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/�ӱ���ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/119079">�ӱ���ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/�׶�ҽ�ƴ�ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/119026">�׶�ҽ�ƴ�ѧ</a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; height: 80px;">
                        <img src="imgs/xuexiao/̫ԭ�Ƽ���ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/132608">̫ԭ�Ƽ���ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/�ӱ�ʦ����ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/119074">�ӱ�ʦ����ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/ɽ����ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/148137">ɽ����ѧ</a>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table cellpadding="0" cellspacing="0" class="tblGaoxiaoBidList">
                <tr>
                    <td rowspan="3" class="shupai">
                        ���ϵ���
                    </td>
                    <td rowspan="3" style="width: 170px; text-align: center;">
                        <a href="/HighSchoolBidList/cn/120137">
                            <img src="imgs/xuexiao/��ɽ��ѧ.png" style="width: 120px; height: 120px;" /><br />
                            ��ɽ��ѧ<br />
                            �ۼƷ���
                            <asp:Label runat="server" ID="lblZSDX" Style="color: Orange;"></asp:Label>
                            ���б�</a>
                    </td>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/��������ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/119905">��������ѧ</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/���ϴ�ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/119485">���ϴ�ѧ</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/����ʦ����ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/126262">����ʦ����ѧ</a>
                    </td>
                    <td rowspan="3" class="bidcontentlist">
                        <uc2:BidListBySchool ID="BidListBySchool3" CategoryId="3" CategoryName="�����б깫��" CategoryEnglishName="Latest Bid Information"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/������ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/119499">������ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/����ũҵ��ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/120233">����ũҵ��ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/�㶫��ҽҩ��ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/�㶫��ҽҩ��ѧ" style="font-size: 11px;">�㶫��ҽҩ��ѧ</a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; height: 80px;">
                        <img src="imgs/xuexiao/���ڴ�ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/135565">���ڴ�ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/��ͷ��ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/120317">��ͷ��ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/���ϴ�ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/132181">���ϴ�ѧ</a>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table cellpadding="0" cellspacing="0" class="tblGaoxiaoBidList">
                <tr>
                    <td rowspan="3" class="shupai">
                        ���е���
                    </td>
                    <td rowspan="3" style="width: 170px; text-align: center;">
                        <a href="/HighSchoolBidList/cn/119618">
                            <img src="imgs/xuexiao/���пƼ���ѧ.png" style="width: 120px; height: 120px;" /><br />
                            ���пƼ���ѧ<br />
                            �ۼƷ���
                            <asp:Label runat="server" ID="lblHZKJDX" Style="color: Orange;"></asp:Label>
                            ���б�</a>
                    </td>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/�人��ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/66316">�人��ѧ</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/�й����ʴ�ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/�й����ʴ�ѧ">�й����ʴ�ѧ</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/�人����ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/165708">�人����ѧ</a>
                    </td>
                    <td rowspan="3" class="bidcontentlist">
                        <uc2:BidListBySchool ID="BidListBySchool4" CategoryId="4" CategoryName="�����б깫��" CategoryEnglishName="Latest Bid Information"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/��̶��ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/146480">��̶��ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/�人����ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/165708">�人����ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/֣�ݴ�ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/120972">֣�ݴ�ѧ</a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; height: 80px;">
                        <img src="imgs/xuexiao/��ɳ����ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/141831">��ɳ����ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/����ʦ����ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/119428">����ʦ����ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/������ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/173730">������ѧ</a>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table cellpadding="0" cellspacing="0" class="tblGaoxiaoBidList">
                <tr>
                    <td rowspan="3" class="shupai">
                        ���ϵ���
                    </td>
                    <td rowspan="3" style="width: 170px; text-align: center;">
                        <a href="/HighSchoolBidList/cn/120201">
                            <img src="imgs/xuexiao/�Ĵ���ѧ.png" style="width: 120px; height: 120px;" /><br />
                            �Ĵ���ѧ<br />
                            �ۼƷ���
                            <asp:Label runat="server" ID="lblSCDX" Style="color: Orange;"></asp:Label>
                            ���б�</a>
                    </td>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/���ӿƼ���ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/124276">���ӿƼ���ѧ</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/���Ͻ�ͨ��ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/120217">���Ͻ�ͨ��ѧ</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/�����ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/80092">�����ѧ</a>
                    </td>
                    <td rowspan="3" class="bidcontentlist">
                        <uc2:BidListBySchool ID="BidListBySchool5" CategoryId="5" CategoryName="�����б깫��" CategoryEnglishName="Latest Bid Information"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/���������ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/135744">���������ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/�Ĵ�ҽ�ƴ�ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/�Ϻ���ͨ��ѧ">�Ĵ�ҽ�ƴ�ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/����ũҵ��ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/119402">����ũҵ��ѧ</a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; height: 80px;">
                        <img src="imgs/xuexiao/����ʦ����ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/119736">����ʦ����ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/���ϴ�ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/125309">���ϴ�ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/���ݴ�ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/119891">���ݴ�ѧ</a>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table cellpadding="0" cellspacing="0" class="tblGaoxiaoBidList">
                <tr>
                    <td rowspan="3" class="shupai">
                        ��������
                    </td>
                    <td rowspan="3" style="width: 170px; text-align: center;">
                        <a href="/HighSchoolBidList/cn/157901">
                            <img src="imgs/xuexiao/������ͨ��ѧ.png" style="width: 120px; height: 120px;" /><br />
                            ������ͨ��ѧ<br />
                            �ۼƷ���
                            <asp:Label runat="server" ID="lblXAJTDX" Style="color: Orange;"></asp:Label>
                            ���б�</a>
                    </td>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/���ݴ�ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/120135">���ݴ�ѧ</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/������ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/126345">������ѧ</a>
                    </td>
                    <td style="width: 170px;">
                        <img src="imgs/xuexiao/���Ĵ�ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/135386">���Ĵ�ѧ</a>
                    </td>
                    <td rowspan="3" class="bidcontentlist">
                        <uc2:BidListBySchool ID="BidListBySchool6" CategoryId="6" CategoryName="�����б깫��" CategoryEnglishName="Latest Bid Information"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 170px; height: 80px;">
                        <img src="imgs/xuexiao/��������ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/120048">��������ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/�����ʵ��ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/�Ϻ���ͨ��ѧ">�����ʵ��ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/�½���ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/�Ϻ���ͨ��ѧ">�½���ѧ</a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; height: 80px;">
                        <img src="imgs/xuexiao/��������ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/121937">��������ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/����ʦ����ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/157856">����ʦ����ѧ</a>
                    </td>
                    <td>
                        <img src="imgs/xuexiao/������ҵ��ѧ.png" style="width: 60px; height: 60px;" />
                        &nbsp;<a href="/HighSchoolBidList/cn/139461">������ҵ��ѧ</a>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
    <link href="/css/biddetail.css" rel="stylesheet" type="text/css" />
</body>
</html>
