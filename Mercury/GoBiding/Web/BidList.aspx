<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BidList.aspx.cs" Inherits="GoBiding.Web.BidList" %>

<%@ Import Namespace="GoBiding.BLL" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="UserCenter/Index/ucBidCategoryList.ascx" TagName="ucBidCategoryList"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ȥͶ����_�б����_����б�ɹ���Ϣ����ƽ̨_�ط��ɹ���Ϣ����ƽ̨</title>
    <meta name="keywords" content="ȥͶ�����б����,����б�ɹ���Ϣ����ƽ̨,�ط��ɹ���Ϣ����ƽ̨" />
    <meta name="description" content="ȥͶ����_�б����_����б�ɹ���Ϣ����ƽ̨_�ط��ɹ���Ϣ����ƽ̨_�Ϻ���´����Ƽ����޹�˾_����" />
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <link rel="shortcut icon" type="image/x-icon" href="/imgs/system/logo_16_16.png"
        media="screen" />
    <!-- bootstrap 3.0.2 -->
    <link href="/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- font Awesome -->
    <style>
        *, body, a
        {
            font-family: '΢���ź�';
        }
        .bidlabel
        {
            background-color: #eee;
            margin-right: 10px;
            border: 1px solid #ececec;
            padding: 3px 10px 3px 10px;
            font-size: 10px;
        }
        .searchtypetitle span
        {
            margin-left: 30px;
        }
        .bidsearchtitle
        {
            width: 80px;
            margin-left: 10px;
            float: left;
        }
        .bidsearchcontent
        {
            margin-left: 0px;
            padding-left: 0px;
        }
        .bidsearchcontent ul
        {
            float: left;
            margin-left: 0px;
            padding-left: 0px;
            padding-bottom: 0px;
            margin-bottom: 0px;
        }
        
        .bidsearchcontent li
        {
            list-style: none;
            text-decoration: none;
            float: left;
            margin-left: 30px;
            margin-top: 15px;
            line-height: 24px;
            cursor: pointer;
            text-align: center;
            padding: 0px 8px 0px 8px;
        }
        .listbidtarea li
        {
            font-size: 12px;
        }
        .bidsearcharea_2
        {
            margin-top: -10px;
        }
        .bidsearcharea_2 li
        {
            float: left;
            cursor: pointer;
        }
        
        .highlightsearch
        {
            background-color: #428bca;
            color: white;
            height: 24px;
            line-height: 24px;
            font-size: 10px;
        }
        .breadcrumb a
        {
            color: #fff;
        }
        .breadcrumb li.active
        {
            color: #fff;
        }
        .breadcrumb a:hover
        {
            color: #fff;
            text-decoration: none;
        }
        .provincesite th, .provincesite td
        {
            width: 60px;
            height: 30px;
            font-size: 12px;
            color: #666;
        }
        .provincesite th
        {
            width: 80px;
            text-align: center;
        }
        .categorysite td
        {
            height: 30px;
            font-size: 12px;
            color: #666;
            text-align: center;
        }
        .pagination li span.active
        {
            color: #fff;
            cursor: default;
            background-color: #428bca;
            border-color: #428bca;
        }
        #bidinfoitem
        {
            box-shadow: 2px 2px 2px #e7e7e7;
        }
        #bidinfoitem:hover
        {
            cursor: pointer;
            background-color: #eee;
            box-shadow: 0px 1px 1px rgba(14, 15, 15, 0.5);
        }
        
        .pagination li a, .pagination li span a
        {
            color: #000;
        }
        .subIndustryAll
        {
            float: left;
            display: block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:Top ID="Top1" runat="server" />
    <div style="background-color: #22252A;">
        <div class="container" style="padding: 0px; height: 44px;">
            <ol class="breadcrumb" style="background-color: #22252A;">
                <li><a href="/Default.html">ȥͶ����</a></li>
                <li><a href="/BidList.html">�б��б�</a></li>
            </ol>
        </div>
    </div>
    <div class="container" class="col-lg-10">
        <div class="row">
            <div class="col-lg-12" style="font-size: 12px;">
                <div style="margin-top: 20px; line-height: 40px; height: 50px; font-weight: bold;
                    border: 1px solid #dcdcdc; border-top: 4px solid orange; padding: 0px 0px 10px 20px;
                    background-color: #fafafa;">
                    <span>��������ѯ</span> <span style="color: #333; font-weight: normal; float: right; padding-right: 20px;">
                        ���������Ĺ��� <font style="color: Orange;">
                            <asp:Label runat="server" ID="lblTotalCount"></asp:Label></font> ��¼</span>
                </div>
                <div class="col-lg-12 searchtypetitle" style="border: 1px solid #dcdcdc; border-top: 0px;
                    border-bottom: 1px dotted #dcdcdc; line-height: 50px; font-size: 12px;">
                    <div class="bidsearchtitle">
                        �б����ͣ�</div>
                    <div class="bidsearchcontent">
                        <ul class="listbidttype">
                            <li value="0" class="all">ȫ��</li>
                            <li value="1">�б깫��</li>
                            <li value="2">�������</li>
                            <li value="3">�б깫��</li>
                            <li value="4">�б�Ԥ��</li>
                            <li value="5">��ֹ����</li>
                            <li value="6">�����б�</li>
                            <li value="7">������̸��</li>
                            <li value="8">��һԴ����</li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-12 searchtypetitle" style="border: 1px solid #dcdcdc; border-top: 0px;
                    border-bottom: 1px dotted #dcdcdc; line-height: 50px; font-size: 12px;">
                    <div class="bidsearchtitle" style="height: 110px; float: left; display: block;">
                        ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����</div>
                    <div class="bidsearchcontent" style="float: left; display: block; width: 900px;">
                        <table>
                            <tr>
                                <td>
                                    <ul class="listbidtarea">
                                        <li value="0" class="all">ȫ��</li>
                                        <li value="1">����</li>
                                        <li value="9">�Ϻ�</li>
                                        <li value="2">���</li>
                                        <li value="19">�㶫</li>
                                        <li value="11">�㽭</li>
                                        <li value="10">����</li>
                                        <li value="13">����</li>
                                        <li value="12">����</li>
                                        <li value="17">����</li>
                                        <li value="18">����</li>
                                    </ul>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <ul class="listbidtarea bidsearcharea_2">
                                        <li value="16" style="margin-left: 100px;">����</li>
                                        <li value="15">ɽ��</li>
                                        <li value="28">����</li>
                                        <li value="4">ɽ��</li>
                                        <li value="27">����</li>
                                        <li value="8">������</li>
                                        <li value="7">����</li>
                                        <li value="6">����</li>
                                        <li value="29">�ຣ</li>
                                        <li value="5">���ɹ�</li>
                                        <li value="3">�ӱ�</li>
                                    </ul>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <ul class="listbidtarea bidsearcharea_2">
                                        <li value="14" style="margin-left: 100px;">����</li>
                                        <li value="25">����</li>
                                        <li value="26">����</li>
                                        <li value="31">�½�</li>
                                        <li value="22">����</li>
                                        <li value="23">�Ĵ�</li>
                                        <li value="24">����</li>
                                        <li value="20">����</li>
                                        <li value="21">����</li>
                                        <li value="30">����</li>
                                        <li></li>
                                    </ul>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="col-lg-12 searchtypetitle" style="border: 1px solid #dcdcdc; border-top: 0px;
                    border-bottom: 1px dotted #dcdcdc; line-height: 50px; font-size: 12px;">
                    <div class="bidsearchtitle">
                        ��ҵ���ࣺ</div>
                    <div class="bidsearchcontent">
                        <ul class="listbidtindustry">
                            <li value="0" class="all">ȫ��</li>
                            <li value="1">��������</li>
                            <li value="7">�����豸</li>
                            <li value="14">�칫�Ľ�</li>
                            <li value="18">ҽ������</li>
                            <li value="21">԰�ֻ���</li>
                            <li value="26">��е�豸</li>
                            <li value="31">������ҵ</li>
                            <li value="38">��ʳס��</li>
                            <li value="46">����</li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-12 searchtypetitle" id="divsubindustry" style="border: 1px solid #dcdcdc;
                    border-top: 0px; display: none; border-bottom: 1px dotted #dcdcdc; line-height: 50px;
                    font-size: 12px;">
                    <div class="bidsearchtitle" style="float: left; display: block;">
                        �������ࣺ</div>
                    <div class="bidsearchcontent" style="float: left; width: 900px; display: block; padding-bottom: 10px;">
                        <ul class="listsubbidtindustry">
                        </ul>
                    </div>
                </div>
                <div class="col-lg-12 searchtypetitle" style="border: 1px solid #dcdcdc; border-top: 0px;
                    border-bottom: 1px dotted #dcdcdc; line-height: 50px; font-size: 12px;">
                    <div class="bidsearchtitle">
                        ����ʱ�䣺</div>
                    <div class="bidsearchcontent">
                        <ul class="listbidtime">
                            <li value="0" class="all">ȫ��</li>
                            <li value="1">����</li>
                            <li value="2">������</li>
                            <li value="3">������</li>
                            <li value="4">������</li>
                            <li value="5">��һ��</li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-12 searchtypetitle" style="border: 1px solid #dcdcdc; border-top: 0px;
                    border-bottom: 1px dotted #dcdcdc; line-height: 50px; font-size: 12px;">
                    <div class="bidsearchtitle">
                        ��&nbsp;&nbsp;��&nbsp;&nbsp;�֣�</div>
                    <div class="input-group col-lg-6" style="padding: 10px; padding-left: 30px;">
                        <input type="text" id="txtSearchKeyword" class="form-control input-sm" style="border-right: 0px;
                            padding-left: 10px;" placeholder="������ؼ���" />
                        <div class="input-group-btn">
                            <button type="button" id="btnSearch" class="btn btn-primary input-sm" style="border-radius: 0px;">
                                <span class="glyphicon glyphicon-search" style="margin-left: 0px;"></span><font style="font-weight: 200;
                                    font-size: 13px; padding-left: 5px;">�� �� </font>
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-9">
                <div style="margin-top: 20px;">
                    <img src="imgs/ad/ad_m_2.gif" style="width: 100%; margin-bottom: 20px;" />
                    <div class="box-body table-responsive no-padding" style="min-height: 400px;">
                        <asp:Repeater runat="server" ID="rptBidList">
                            <ItemTemplate>
                                <table id="bidinfoitem" cellspacing="0" style="width: 100%; border: 1px solid #dcdcdc;
                                    margin-bottom: 10px;">
                                    <tr>
                                        <td style="width: 80px; height: 130px; padding-left: 10px; text-align: center; line-height: 30px;
                                            vert-align: middle; font-size: 12px;">
                                            <%# DateTime.Parse(Eval("CreateTime").ToString()).ToShortDateString()%>
                                            <br />
                                            <img src="imgs/system/synctime.png" width="24" height="24" /><%# GetDisplayPublishTime(Eval("BidPublishTime").ToString())%>
                                        </td>
                                        <td style="width: 500px; line-height: 24px; padding: 10px; vertical-align: top;">
                                            <%# Eval("BidType").ToString() == "1" ? "<span style=\"background: #FFBB66; font-size: 9px; padding: 2px 5px 2px 5px; color: #fff;\">�����б�</span>":""%> <a href='/BidDetail/<%#Eval("BidId")%>.html' target="_blank" style="font-size: 14px;
                                                    font-family: microsoft yahei; text-decoration: none; color: #000;">
                                                    <%#Eval("BidTitle").ToString().Length > 45 ? HighlightKeyword(Eval("BidTitle").ToString().Substring(0, 45)) + "...":HighlightKeyword(Eval("BidTitle").ToString()) %></a><br />
                                            <div style="color: #666; font-size: 12px; line-height: 24px; padding-right: 100px;
                                                padding-bottom: 10px;">
                                                <%# Eval("BidContent").ToString()%><font style='color: orange; display: <%= keywords == "" ? "none":"" %>'>(���ݰ���:<%= keywords %>)</font></div>
                                            <span class="bidlabel">
                                                <%# GoBiding.BLL.CommonUtility.GetBidTypeValue(Eval("BidType").ToString())%></span>
                                            <span class="bidlabel">
                                                <%# GetBidCategoryNameValue(Eval("BidCategoryId").ToString())%></span> <span class="bidlabel">
                                                    <%#GetProvinceName(Eval("ProvinceId").ToString())%></span> <span class="bidlabel">���
                                                        <%#Eval("BidNumber")%></span> <span class="bidlabel" style='display: <%# Eval("BidCompanyName") == "" ? "none":""%>'>
                                                            �б��� |
                                                                <%# Eval("BidCompanyName").ToString().Length > 10 ? Eval("BidCompanyName").ToString().Substring(0, 10) +"...": Eval("BidCompanyName").ToString()%></span>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div id="emptyDiv" runat="server" style="width: 100%; text-align: center; font-size: 20px;
                            height: 200px; padding-top: 70px; border: 1px solid #ececec;">
                            Sorry, û���ѵ�����Ҫ����Ϣ���뻻�����������ɣ�
                        </div>
                        <div class="pull-right">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Width="100%" UrlPaging="true" NumericButtonCount="15" ForeColor="Black"
                                FirstPageText="��һҳ" LastPageText="βҳ" ShowPageIndexBox="Never" ShowNavigationToolTip="False"
                                ShowCustomInfoSection="Never" PrevPageText="��һҳ" NextPageText="��һҳ" CssClass="pagination"
                                LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0"
                                CurrentPageButtonClass="active" PageSize="10" OnPageChanged="AspNetPager1_PageChanged">
                            </webdiyer:AspNetPager>
                        </div>
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
            <div class="col-lg-3" style="margin-left: 0px; padding-left: 0px;">
                <div style="border: 1px solid #ececec; font-weight: 700; font-size: 14px; margin-left: 0px;
                    padding-left: 10px; margin-top: 20px; color: #666; height: 40px; line-height: 40px;">
                    ���½�פ��ҵ
                </div>
                <div style="width: 100%; padding-top: 10px; border: 1px solid #ececec; border-top: 0px;">
                    <asp:ListView runat="server" ID="rptEmergencyPurchaseOrderList">
                        <LayoutTemplate>
                            <ul style="list-style: none; padding-left: 10px; margin-left: 0px;">
                                <li runat="server" id="itemplaceholder"></li>
                            </ul>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li style="width: 100%; font-size: 12px; padding-left: 0px; margin-left: 0px; line-height: 25px;
                                height: 25px; vertical-align: top; list-style: none;"><a href='/CompanyBidList/<%#Eval("CompanyId")%>.html'
                                    style="color: Black;">
                                    <%--[<%#Eval("CityName")%> ]--%>
                                    <%#Eval("CompanyName")%></a> </li>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
            <div class="col-lg-3" style="margin-left: 0px; padding-left: 0px;">
                <div style="border: 1px solid #ececec; font-weight: 700; font-size: 14px; margin-left: 0px;
                    padding-left: 10px; margin-top: 20px; color: #666; height: 40px; line-height: 40px;">
                    �����б���ҵ
                </div>
                <div style="width: 100%; padding-top: 10px; border: 1px solid #ececec; border-top: 0px;">
                    <asp:ListView runat="server" ID="rptHotCompanyList">
                        <LayoutTemplate>
                            <ul style="list-style: none; padding-left: 10px; margin-left: 0px;">
                                <li runat="server" id="itemplaceholder"></li>
                            </ul>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li style="width: 100%; font-size: 12px; padding-left: 0px; margin-left: 0px; line-height: 25px;
                                height: 25px; vertical-align: top; list-style: none;">
                                <%# GetHotLevel(Eval("count").ToString())%>
                                <a href="http://gobiding.com/CompanyBidList/<%#Eval("BidCompanyId")%>.html"
                                    style="color: #000;">
                                    <%#Eval("BidCompanyName")%></a> </li>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                <div style="margin-left: 0px; padding-left: 0px; width: 100%; margin-top: 20px;"
                    id="divAdPanel">
                    <a href="http://www.ctrip.com/">
                        <img src="imgs/ad/ad_xiecheng.jpg" width="100%" height="80" /></a> <a href="http://shijiazhuang0196073.3566t.com/">
                            <img src="imgs/ad/ad_jinrong.jpg" width="100%" height="80" style="margin-top: 10px;" /></a>
                    <a href="https://item.taobao.com/item.htm?spm=a1z09.8149145.0.0.uE6dMr&id=528751809018&_u=p1cvkv2c8f0">
                        <img src="imgs/ad/ad_oculus_2.jpg" width="100%" height="80" style="margin-top: 10px;" /></a>
                    <img src="imgs/ad/ad_zhaoshang.png" width="100%" height="80" style="margin-top: 10px;" />
                </div>
            </div>
        </div>
    </div>

    <div class="container" style="width: 100%; text-align: center; padding-top: 20px;
        padding-left: 12%; font-family: '΢���ź�'">
        <div class="row">
            <div style="line-height: 24px; text-align: left; margin: 0px auto; color: #666; font-size: 12px;">
                ȥͶ�������Ϻ���´����Ƽ����޹�˾��<br />
                2015-2017 gobiding.com ��Ȩ���� ICP֤����ICP��15005938��-3 All Rights Reserved
            </div>
            <div style="width: 100%; padding-top: 10px;">
                <table>
                    <tr>
                        <td style="width: 130px;">
                            <img src="imgs/system/sf-wzba_r1_c1.gif" />
                        </td>
                        <td style="width: 130px;">
                            <img src="imgs/system/sf-wzba_r1_c3.gif" />
                        </td>
                        <td style="width: 130px;">
                            <img src="imgs/system/sf-wzba_r1_c7.gif" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnbidarea" />
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnsubindustry" />
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnbidindustry" />
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnbidtime" />
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnkeyword" />
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnbidtype" />
    <style>
        #divAdPanel img:hover
        {
            -webkit-transform: scale(1.02,1.02);
            -moz-transform: scale(1.02,1.02);
            -transform: scale(1.02,1.02);
        }
    </style>
    </form>
    <script src="/js/thirdplugin.js" type="text/javascript"></script>
    <script src="/js/jquery-1.9.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#btnSearch").click(function () {
                var keyword = $("#txtSearchKeyword").val();
                var industry = $(".listbidtindustry .highlightsearch").val();
                var subindustry = $(".listsubbidtindustry .highlightsearch").val();
                var area = $(".listbidtarea .highlightsearch").val();
                var bidtype = $(".listbidttype .highlightsearch").val();
                var bidtime = $(".listbidtime .highlightsearch").val();

                if (subindustry != null) {
                    location.href = "/BidList.html?keyword=" + keyword + "&area=" + area + "&industry=" + industry + "&subindustry=" + subindustry + "&bidtype=" + bidtype + "&bidtime=" + bidtime;
                } 
                else {
                    location.href = "/BidList.html?keyword=" + keyword + "&area=" + area + "&industry=" + industry + "&bidtype=" + bidtype + "&bidtime=" + bidtime;
                }
            });

            $("#zbdt").addClass("navchoose");

            if ($("#hdnbidarea").val() != '') {
                $(".listbidtarea").find("li[value='" + $("#hdnbidarea").val() + "']").addClass("highlightsearch");
            } else {
                $(".listbidtarea").find(".all").addClass("highlightsearch");
            }

            if ($("#hdnbidtype").val() != '') {
                $(".listbidttype").find("li[value='" + $("#hdnbidtype").val() + "']").addClass("highlightsearch");
            } else {
                $(".listbidttype").find(".all").addClass("highlightsearch");
            }

            if ($("#hdnbidindustry").val() != '') {
                $(".listbidtindustry").find("li[value='" + $("#hdnbidindustry").val() + "']").addClass("highlightsearch");

                //��ʼ����������
                if ($("#hdnsubindustry").val() != '') {
                    var currentSubInstry = $("#hdnsubindustry").val();
                    initSubIndustry(currentSubInstry);
                }
            } else {
                $(".listbidtindustry").find(".all").addClass("highlightsearch");
            }

            if ($("#hdnbidtime").val() != '') {
                $(".listbidtime").find("li[value='" + $("#hdnbidtime").val() + "']").addClass("highlightsearch");
            } else {
                $(".listbidtime").find(".all").addClass("highlightsearch");
            }
            if ($("#hdnkeyword").val() != '') {
                $("#txtSearchKeyword").val($("#hdnkeyword").val());
            }

            $(".listbidttype li").click(function () {
                $(this).parent().find("li").removeClass("highlightsearch");
                $(this).addClass("highlightsearch");
            });
            $(".listbidtarea li, .listbidtarea2 li").click(function () {
                $(this).parent().parent().parent().parent().find("li").removeClass("highlightsearch");
                $(this).addClass("highlightsearch");
            });

            //��ҵ�����¼�
            $(".listbidtindustry li").click(function () {
                $(this).parent().find("li").removeClass("highlightsearch");
                $(this).addClass("highlightsearch");

                initSubIndustry(null);
            });

            function initSubIndustry(currentSubInstry) {
                //��ʾ��ҵ����
                var industry = $(".listbidtindustry .highlightsearch").val();

                $.ajax({
                    type: "post",
                    url: "/Handlers/GetSubIndustryList.ashx",
                    data: {
                        IndustryId: industry
                    },
                    dataType: "json",
                    success: function (data) {
                        var subindustrys = "";
                        for (var p in data) { //forѭ��ֱ�ӱ�������
                            subindustrys += "<li value='" + data[p].BidCategoryId + "'>" + data[p].BidCategoryName + "</li>";
                        }

                        var all = "<li class='subIndustryAll'  value=\"0\" class=\"all\">ȫ��</li>";
                        $(".listsubbidtindustry").html(all + subindustrys);

                        if (currentSubInstry == null) {
                            $(".subIndustryAll").addClass("highlightsearch");
                        }
                        else {
                            $(".listsubbidtindustry").find("li[value='" + currentSubInstry + "']").addClass("highlightsearch");
                        }

                        //������ȫ��������ʾ��ʽ
                        $(".listsubbidtindustry li").eq(9).css("margin-left", "100px");
                        $(".listsubbidtindustry li").eq(17).css("margin-left", "100px");
                        $(".listsubbidtindustry li").eq(25).css("margin-left", "100px");
                        $(".listsubbidtindustry li").eq(33).css("margin-left", "100px");
                    },
                    error: function (msg) {
                        alert(msg);
                    }
                });

                $("#divsubindustry").show();

                //��ҵ�����¼�
                $(".listsubbidtindustry").on("click", "li", function () {
                    $(this).parent().find("li").removeClass("highlightsearch");
                    $(this).addClass("highlightsearch");
                });

            }

            $(".listbidtime li").click(function () {
                $(this).parent().find("li").removeClass("highlightsearch");
                $(this).addClass("highlightsearch");
            });


            $("#txtSearchKeyword").keydown(function (e) {
                // �س����¼�  
                if (e.which == 13) {
                    return false;
                }
            });

        });

    </script>
</body>
</html>
