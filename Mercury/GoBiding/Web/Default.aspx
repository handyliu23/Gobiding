<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GoBiding.Default" %>

<%@ Register Src="UserCenter/Index/BidListByCategory3.ascx" TagName="BidListByCategory"
    TagPrefix="uc1" %>
<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc2" %>
<%@ Register Src="UserCenter/Index/ucBidCategoryList.ascx" TagName="ucBidCategoryList"
    TagPrefix="uc3" %>
<%@ Register Src="UserCenter/Index/Bottom.ascx" TagName="Bottom" TagPrefix="uc4" %>
<!DOCTYPE&nbsp;html&nbsp;PUBLIC&nbsp;"-//W3C//DTD&nbsp;XHTML&nbsp;1.0&nbsp;Transitional//EN"&nbsp;"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="zh-CN" xmlns:wb="http://open.weibo.com/wb">
<head runat="server">
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <meta property="wb:webmaster" content="8fa9d22fc48fcb60" />
    <title>ȥͶ����_�й����������Ͷ�����ƽ̨_�����б�Ͷ�����ƽ̨_�����б���Ϣ_��Ͷ���ø���</title>
    <meta name="keywords" content="ȥͶ����,����б���Ϣ��,��Ѳɹ���Ϣ��,��ȫ�б���Ϣ,�����б���Ϣ,�б깫��,�б�Ԥ��,�����б�,�ط��ɹ���Ϣ" />
    <meta name="description" content="Ͷ�������й���һ����ѵ��б���Ϣ����ƽ̨����Ѳɹ���Ϣ�����б���Ϣ��ȫ�����ǵ������б���ҵ�����б�����ÿ����³���10000�������б���Ŀ��Ϣ��ȥͶ�����ѳ�Ϊ�������б굥λ��ҵ���б�ɹ�����ѡƽ̨,��Ͷ���ø���,ҪͶ�����ȥͶ������" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="/css/index.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" type="image/x-icon" href="/imgs/system/logo_16_16.png"
        media="screen" />
    <style>
            .btn span
            {
                color:#FFF;
                }
            .btn 
            {
                color:
                }
        </style>
</head>
<body>
    <uc2:Top ID="Top1" runat="server" />
    <form id="form1" runat="server">
    <input type="hidden" id="hdnarea" value="" />
    <input type="hidden" id="hdnindustry" value="" />
    <input type="hidden" id="hdnuserType" value="0" />
    <input type="hidden" id="hdnbidtype" value="" />
    <input type="hidden" id="hdnislogin" value="" runat="server" />
    <div class="jumbotron masthead" style="padding: 10px; background-color: #f6fbfd;
        background-image: url('/imgs/system/bg.png'); opacity: 0.9; background-size: 100% 100%;
        background-repeat: no-repeat; color: #000; width: 100%;">
        <div class="container">
            <div class="row">
                <div class="col-lg-8">
                    <br />
                    <span class="HeadImgTitle">���� | ׼ȷ | ��ʱ | �������</span>
                    <br />
                    <br />
                    <span class="HeadImgContent">�� ����ȫ�� 300+ �������б���Ϣ,ÿ��ʵʱ���·�������10,000 ���б�ɹ���Ϣ��</span><br />
                    <span class="HeadImgContent">�� �����бꡢ��Ʒ�бꡢ�����б�ȫ���ݡ�</span><br />
                    <span class="HeadImgContent">�� ��Ѷ��ģ����š�΢�š�app�������������͡�</span><br />
                    <span class="HeadImgContent">�� �б���Ϣ���ܷ��ࡢ֧�־�ȷ��ѯ��ȫ��������</span>
                </div>
                <div class="col-lg-4">
                    <div class="box box-primary box-shadow-3" id="divregist" style="background-color: #fff;
                        width: 340px; padding: 20px; margin-top: 0px; color: #000; height: 380px; border-radius: 4px;">
                        <div class="box-body">
                            <div class="row">
                                <div class="col-xs-12">
                                    <input type="text" id="txtUserNickName" class="form-control" placeholder="�������ֻ���" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-xs-12">
                                    <input type="password" id="txtPassword" class="form-control" placeholder="����������6λ����" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-xs-12">
                                    <input type="text" id="txtEmail" class="form-control" placeholder="�����ַ" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-xs-8">
                                    <input type="text" id="txtCompanyName" class="form-control" placeholder="��˾����" />
                                </div>
                                <div class="col-xs-4" style="padding-left: 0px;">
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-default dropdown-toggle" id="btnUserType" style="color: gray;
                                            border-radius: 5px; width: 100px;" data-toggle="dropdown">
                                            ѡ������<span class="caret"></span>
                                        </button>
                                        <ul class="dropdown-menu dropdown-menu-right ul_dropdown_usertype" role="menu">
                                            <li value="1">Ͷ�귽</li>
                                            <li value="2">�б귽</li>
                                            <li value="3">�������</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-xs-8">
                                    <input type="text" id="txtUserName" class="form-control" placeholder="��ϵ������" />
                                </div>
                                <div class="col-xs-4" style="padding-left: 0px;">
                                    <input type="text" id="txtPosition" class="form-control" placeholder="ְλ����" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-xs-12">
                                    <button type="button" class="btn btn-primary" id="btnRegist" style="font-weight: 700;
                                        height: 40px; width: 100%; font-size: 14px;">
                                        <span>���ע��</span>
                                    </button>
                                </div>
                                <div class="col-xs-12" style="font-size: 10px; margin-top: 10px; padding: 5px; border-top: 1px solid #dcdcdc;">
                                    <div class="col-xs-7">
                                        <div>
                                            ͬ�� <a href="#" data-toggle="modal" data-target="#myModal">��ȥͶ�����û�Э�顷</a></div>
                                    </div>
                                    <div class="col-xs-5">
                                        <a href="#" id="hreflogin">�����˻������¼</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="box box-primary box-shadow-3" id="divlogin" style="background-color: #fff;
                        width: 340px; padding: 20px; margin-top: 0px; color: #000; display: none; height: 380px;
                        border-radius: 4px;">
                        <div class="box-body">
                            <div class="row">
                                <div class="col-xs-12">
                                    <br />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <input type="text" id="txtLoginUserName" class="form-control" placeholder="�û���/�ֻ���/�����ַ" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-xs-12">
                                    <input type="password" id="txtLoginPassword" class="form-control" placeholder="�û�����" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-xs-4">
                                    <input type="text" id="txtUserCheckCode" class="form-control" placeholder="��֤��" /></div>
                                <div class="col-xs-6">
                                    <img id="Img1" alt="�����壬�����ң�" onclick="this.src=this.src+'?'" src="CheckCodeHandler.ashx"
                                        style="width: 80px; height: 34px" align="left" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-xs-12">
                                    <button type="button" class="btn btn-primary" id="btnLogin" style="font-weight: 700;
                                        height: 40px; width: 100%; font-size: 14px;">
                                        <span>������¼</span>
                                    </button>
                                </div>
                                <div class="col-xs-12" style="font-size: 10px; margin-top: 20px; padding: 5px; border-top: 1px solid #dcdcdc;">
                                    <div class="col-xs-9">
                                        <a href="#" id="lnkregist">��û���˺ţ���ע��</a>
                                    </div>
                                    <div class="col-xs-3">
                                        <a href="ForgetPassword.html" id="lnkforget">��������</a>
                                    </div>
                                </div>
                                <div class="col-xs-12" align="right" style="font-size: 11px; padding: 10px; color: #333;
                                    text-align: center;">
                                    �������ʺŵ�¼
                                </div>
                                <div style="float: left; padding-left: 15px; width: 50px; height: 50px;">
                                    <a id="qqAuthorizationUrl" href="/ThirdLogin/qq" class="qq">
                                        <img src="/imgs/system/3rdlogin/qq.png" width="40" height="40" /></a>
                                </div>
                                <div style="float: left; padding-left: 15px; width: 50px; height: 50px;">
                                    <a id="linkwx" href="/ThirdLogin/wx" class="wx" style="width: 40px; height: 40px;">
                                        <img src="/imgs/system/3rdlogin/WX.png" width="40" height="40" /></a>
                                </div>
                                <div style="float: left; padding-left: 15px; width: 50px; height: 50px;">
                                    <a id="linkxl" href="/ThirdLogin/xl" class="xl">
                                        <img src="/imgs/system/3rdlogin/xl.png" width="40" height="40" /></a>
                                </div>
                                <%-- <div style="float: left; padding-left: 15px; width: 50px; height: 50px;">
                                    <a id="A1" href="https://graph.qq.com/oauth2.0/authorize?client_id=101405089&response_type=token&scope=all&redirect_uri=http%3A%2F%2Fwww.gobiding.com"
                                        class="qq">
                                        <img src="/imgs/system/3rdlogin/xl.png" width="40" height="40" /></a>
                                </div>--%>
                                <%--  <div style="padding-left: 10px;">
                                    <a href="#" onclick='toLogin()'>
                                        <img src="/imgs/system/Connect_logo_1.png" alt=""></a>
                                </div>--%>
                            </div>
                        </div>
                    </div>
                    <div class="box box-primary box-shadow-3" id="divislogin" style="background-color: #fff;
                        width: 340px; padding: 20px; margin-top: 0px; color: #000; display: none; height: 380px;
                        line-height: 35px; border-radius: 4px;">
                        <asp:Label runat="server" ID="lblCurrentUserName"></asp:Label>,��ӭʹ��ȥͶ������ <a href="Logout.html">
                            �˳�</a><br />
                        <asp:Image runat="server" ID="imgProfile" Style="margin-left: 10px;" Width="65" Height="65" /><br />
                        �û����ͣ�<asp:Label runat="server" ID="lblCurrentUserType"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp; ���� <a href="/UserCenter/UserCenterPage/MessageCenter.html">
                            <asp:Label runat="server" ID="lblUnReadCount"></asp:Label></a> ��δ����Ϣ
                        <br />
                        ��ҵ��֤��<asp:Label runat="server" ID="lblCurrentCompanyAuditStatus"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp; �û����ޣ�<asp:Label runat="server" ID="lblCurrentUserYear"></asp:Label>
                        ��<br />
                        �ϴε�¼ʱ�䣺<asp:Label runat="server" ID="lblCurrentUserLoginTime"></asp:Label><br />
                        �ѷ������б�������<asp:Label runat="server" ID="lblCurrentUserPubBidCount"></asp:Label><br />
                        �ѷ����Ĳɹ�������<asp:Label runat="server" ID="lblCurrentUserPubPurchaseCount"></asp:Label><br />
                        <button type="button" class="btn btn-success" style="width: 300px; margin-top: 10px;"
                            id="btnUserCenter">
                            �����������</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-lg-10">
                <div class="input-group">
                    <input type="text" id="txtSearchKeyword" class="form-control" style="border-right: 0px;"
                        placeholder="��������Ͷ��ؼ���" />
                    <div class="input-group-btn">
                        <button type="button" class="btn btn-default dropdown-toggle" id="btn_dropdown_selectarea"
                            style="color: gray; width: 100px; border-radius: 0px;" data-toggle="dropdown">
                            ѡ�����<span class="caret"></span>
                        </button>
                        <div class="dropdown-menu dropdown-menu-right" style="padding: 5px; width: 380px;"
                            role="menu">
                            <div class="dropdown_menu_div">
                                <table class="dropdown_content_areas">
                                    <tr>
                                        <th style="border-bottom: 1px solid #dcdcdc;">
                                            ����
                                        </th>
                                        <td colspan="5" style="border-bottom: 1px solid #dcdcdc;">
                                            ȫ��<span style="display: none;">0</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            ����
                                        </th>
                                        <td>
                                            �Ϻ�<span style="display: none;">9</span>
                                        </td>
                                        <td>
                                            ����<span style="display: none;">10</span>
                                        </td>
                                        <td>
                                            �㽭<span style="display: none;">11</span>
                                        </td>
                                        <td>
                                            ����<span style="display: none;">12</span>
                                        </td>
                                        <td>
                                            ����<span style="display: none;">13</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                        </th>
                                        <td>
                                            ����<span style="display: none;">14</span>
                                        </td>
                                        <td>
                                            ɽ��<span style="display: none;">15</span>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            ����
                                        </th>
                                        <td>
                                            ����<span style="display: none;">1</span>
                                        </td>
                                        <td>
                                            ���<span style="display: none;">2</span>
                                        </td>
                                        <td>
                                            �ӱ�<span style="display: none;">3</span>
                                        </td>
                                        <td>
                                            ɽ��<span style="display: none;">4</span>
                                        </td>
                                        <td>
                                            ����<span style="display: none;">5</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            ����
                                        </th>
                                        <td>
                                            ������<span style="display: none;">8</span>
                                        </td>
                                        <td>
                                            ����<span style="display: none;">7</span>
                                        </td>
                                        <td>
                                            ����<span style="display: none;">6</span>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            ����
                                        </th>
                                        <td>
                                            �㶫<span style="display: none;">19</span>
                                        </td>
                                        <td>
                                            ����<span style="display: none;">20</span>
                                        </td>
                                        <td>
                                            ����<span style="display: none;">21</span>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            ����
                                        </th>
                                        <td>
                                            ����<span style="display: none;">27</span>
                                        </td>
                                        <td>
                                            ����<span style="display: none;">28</span>
                                        </td>
                                        <td>
                                            �ຣ<span style="display: none;">29</span>
                                        </td>
                                        <td>
                                            ����<span style="display: none;">30</span>
                                        </td>
                                        <td>
                                            �½�<span style="display: none;">31</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            ����
                                        </th>
                                        <td>
                                            ����<span style="display: none;">22</span>
                                        </td>
                                        <td>
                                            �Ĵ�<span style="display: none;">23</span>
                                        </td>
                                        <td>
                                            ����<span style="display: none;">24</span>
                                        </td>
                                        <td>
                                            ����<span style="display: none;">25</span>
                                        </td>
                                        <td>
                                            ����<span style="display: none;">26</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            ����
                                        </th>
                                        <td>
                                            ����<span style="display: none;">16</span>
                                        </td>
                                        <td>
                                            ����<span style="display: none;">17</span>
                                        </td>
                                        <td>
                                            ����<span style="display: none;">18</span>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="input-group-btn">
                        <button type="button" class="btn btn-default dropdown-toggle" id="btn_dropdown_selectindustry"
                            style="color: gray; width: 100px; border-radius: 0px; border-left: 0px;" data-toggle="dropdown">
                            ѡ����ҵ <span class="caret"></span>
                        </button>
                        <ul class="dropdown-menu dropdown-menu-right ul_dropdown_industry" role="menu">
                            <li value="1">��������</li>
                            <li value="7">�����豸</li>
                            <li value="14">�칫�Ľ�</li>
                            <li value="18">ҽ������</li>
                            <li value="21">�����̻�</li>
                            <li value="26">��е�豸</li>
                            <li value="31">������ҵ</li>
                            <li value="38">��װ����</li>
                        </ul>
                    </div>
                    <div class="input-group-btn">
                        <button type="button" class="btn btn-default dropdown-toggle" id="btn_dropdown_selectbidtype"
                            style="color: gray; border-radius: 0px; width: 100px; border-left: 0px;" data-toggle="dropdown">
                            �б����� <span class="caret"></span>
                        </button>
                        <ul class="dropdown-menu dropdown-menu-right ul_dropdown_bidtype" role="menu">
                            <li value="1">�б깫��</li>
                            <li value="2">�б���</li>
                            <li value="3">�б깫��</li>
                            <li value="4">�б�Ԥ��</li>
                            <li value="5">�����깫��</li>
                            <li value="6">�����б�</li>
                            <li value="7">VIP��Ŀ</li>
                        </ul>
                    </div>
                    <div class="input-group-btn">
                        <button type="button" id="btnSearch" class="btn btn-primary" style="border-radius: 0px;
                            width: 100px;">
                            <span class="glyphicon glyphicon-search"></span><font style="font-weight: 700; font-size: 14px;">
                                �� �� </font>
                        </button>
                    </div>
                </div>
                <!-- /input-group -->
            </div>
            <div class="col-lg-2" style="line-height: 34px; padding-left: 0px;">
                <div style="color: #fff; width: 100%; text-align: center;" class="label-warning">
                    7�������б꣺ <span class="badge">
                        <asp:Literal runat="server" ID="ltrTotalCount"></asp:Literal>
                        ��</span>
                </div>
            </div>
            <div class="col-lg-12">
                <div style="font-size: 10px; color: #aaa; padding: 10px;">
                    ��������: &nbsp;&nbsp;<a href="/BidList.html?keyword=ʩ��">ʩ��</a>&nbsp;&nbsp;<a href="/BidList.html?keyword=�Ʒ�">�Ʒ�</a>&nbsp;&nbsp;
                    <a href="/BidList.html?keyword=����">����</a>&nbsp;&nbsp;<a href="/BidList.html?keyword=��ѧ">��ѧ</a>&nbsp;&nbsp;
                    <a href="/BidList.html?keyword=����">����</a>&nbsp;&nbsp; <a href="/BidList.html?keyword=�칫�豸">
                        �칫�豸</a>&nbsp;&nbsp; <a href="/BidList.html?keyword=�����豸">�����豸</a>&nbsp;&nbsp;<a
                            href="/BidList.html?keyword=����豸"> ����豸</a> &nbsp;&nbsp; <a href="/BidList.html?keyword=������ʵ">
                                ������ʵ</a>&nbsp;&nbsp;<a href="/BidList.html?keyword=�̻�">�̻�</a>&nbsp;&nbsp;
                    <a href="/BidList.html?keyword=ҽԺ">ҽԺ</a></div>
            </div>
        </div>
        <!-- /.row -->
    </div>
    <div class="container">
        <div class="row">
            <div class="col-lg-12" style="margin-top: 0px; padding: 0px;">
                <uc1:BidListByCategory ID="BidListByCategory3" runat="server" CategoryId="1" CategoryName="�����б깫��"
                    CategoryEnglishName="Latest Bid Information" />
                <%--                <uc1:BidListByCategory ID="BidListByCategory2" runat="server" CategoryId="1" CategoryName="��������"
                    CategoryEnglishName="Construction Engineering" />
                <uc1:BidListByCategory ID="BidListByCategory3" runat="server" CategoryId="7" CategoryName="�����豸"
                    CategoryEnglishName="Instrumenttation" />
                <uc1:BidListByCategory ID="BidListByCategory4" runat="server" CategoryId="14" CategoryName="�칫�Ľ�"
                    CategoryEnglishName="Office Supply" />
                <uc1:BidListByCategory ID="BidListByCategory5" runat="server" CategoryId="18" CategoryName="ҽ������"
                    CategoryEnglishName="HealthMedical Treatment" />
                <uc1:BidListByCategory ID="BidListByCategory6" runat="server" CategoryId="21" CategoryName="԰�ֻ���"
                    CategoryEnglishName="Environmental" />
                <uc1:BidListByCategory ID="BidListByCategory7" runat="server" CategoryId="26" CategoryName="��е�豸"
                    CategoryEnglishName="Mechanical Equipment" />
                <uc1:BidListByCategory ID="BidListByCategory1" runat="server" CategoryId="31" CategoryName="������ҵ"
                    CategoryEnglishName="Bussiness Service" />
                <uc1:BidListByCategory ID="BidListByCategory8" runat="server" CategoryId="38" CategoryName="��װ����"
                    CategoryEnglishName="Bussiness Service" />--%>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-lg-12" style="margin-top: 0px; padding: 0px;">
                <div style="border-left: 4px solid #000; font-weight: 700; font-size: 14px; margin-left: 15px;
                    padding-left: 10px; padding-top: 0px; margin-top: 10px; color: #000; font-family: '΢���ź�';">
                    ����Ϣ <span style="font-size: 12px;">Small Purchase </span>
                </div>
                <div style="width: 100%; padding-top: 10px; float: left;">
                    <div class="col-lg-12" id="tablecontent">
                        <asp:ListView runat="server" ID="rptPurchaseOrderList" GroupItemCount="5">
                            <LayoutTemplate>
                                <table id="bidlisttypediv1" style="width: 100%;">
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
                                <td style="width: 230px; font-family: '΢���ź�'; line-height: 25px; height: 200px; vertical-align: top;">
                                    <div style="border: 1px solid #ececec; width: 220px; height: 180px; padding: 10px;
                                        font-size: 12px;">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td rowspan="2" valign="top">
                                                    <img src='<%#Eval("UserProfile").ToString() %>' style="width: 50px; height: 50px;
                                                        border-radius: 25px" alt="" />
                                                </td>
                                                <td style="padding-left: 4px;">
                                                    <a target="_blank" href='/PurchaseOrderDetail/<%#Eval("Id")%>.html' style="font-size: 12px;
                                                        text-decoration: none; color: #000; font-weight: bold;">
                                                        <div style="height: 48px;">
                                                            <%#Eval("Title") %></div>
                                                    </a>
                                                </td>
                                            </tr>
                                        </table>
                                        ����ʱ�䣺<font style="font-size: 12px; color: #000"><%#Eval("PublishTime", "{0:D}")%></font><br /><font style="font-size: 12px; color: #000">�ɹ�����<%#Eval("CompanyName")%></font><br />�󹺵�����<font style="font-size: 12px; color: #000"><%#Eval("ProvinceName")%><%# Eval("CityName").ToString().Length > 3 ? Eval("CityName").ToString().Substring(0, 3) : Eval("CityName").ToString()%></font><br /><a target="_blank" href='/PurchaseOrderDetail/<%#Eval("Id")%>.html' style="font-size: 12px;
                                            text-decoration: none;"><div style="margin-top: 5px; font-size: 12px; border-radus: 2px; text-align: center;
                                                border: 1px solid #dcdcdc; width: 80px; padding: 0px;">
                                                �鿴��ϸ</div>
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
    <br />
    <%--<div class="container" style="width: 100%; background-color: #fafafa;">
        <div class="row">
            <div style="border-bottom: 0px solid #dcdcdc; padding: 10px; font-family: '΢���ź�';
                height: 40px; line-height: 40px; text-align: center; font-size: 18px; font-weight: bold;
                padding: 20px;">
                ȫ���������б���
            </div>
            <div style="margin-left: 15%; margin-top: 30px; color: #666;">
                <font style="color: red; font-size: 12px;">*</font>��ѡ���·���ͼ������ע��ʡ�ݣ��鿴�õ�������Ͷ����Ϣ</div>
            <div class="demo">
                <table>
                    <tr>
                        <td>
                            <div id="map">
                            </div>
                        </td>
                        <td valign="top" style="width: 350px; color: #999;">
                            <div style="font-size: 14px; line-height: 30px;">
                                ----- ����34��ʡ���������򣬰���23��ʡ��5����������4��ֱϽ��<br />
                                ----- ÿ��ʵʱ�����бꡢ������бꡢ��һԴ���ɹ���Ϣ<br />
                                ----- ���ע�ἴ�ɲ��ȫ�����غ�����Ͷ����Ϣ<br />
                                ----- ע���Ա������ѷ����б�ɹ���Ϣ��ȫ����Դһ����<br />
                                ----- ��ҳ�ͻ��ˡ�΢�š����Ŷ�����ȫ��λ��Ϣչʾ<br />
                                ----- ���ܶ��ġ��������ѡ���Ҳ���ö��Ÿ��һ��������б���Ϣ<br />
                                ----- ѡ��<a href="http://www.gobiding.com">ȥͶ����</a>��Ϊ�������Ᵽ�ݻ�����<br />
                            </div>
                            <br />
                            <br />
                            <div style="padding: 20px; width: 420px; height: 140px; background-color: #fff;">
                                <table>
                                    <tr>
                                        <td>
                                            <img src="/imgs/system/wx300_300.png" width="100" />
                                        </td>
                                        <td valign="top">
                                            <div style="font-size: 14px; font-family: '΢���ź�'; padding-left: 20px;">
                                                <font style="font-size: 18px; line-height: 30px; font-weight: bolder;">ȥͶ����΢�Ź��ں�</font><br />
                                                <div style="line-height: 25px;">
                                                    ɨһɨ΢�Ź��ڷ����<br />
                                                    ��ʱ����ֻ�Ҳ������Ͷ��<br />
                                                    �ⰲװ��������������ȫ�������
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div style="background-color: #fafafa; height: 200px; width: 80%; margin: 0px auto;">
                <table style="width: 100%; font-family: '΢���ź�';">
                    <tr>
                        <td style="width: 25%; text-align: center;">
                            <div style="font-size: 24px; color: #dcdcdc; line-height: 40px; padding: 30px; border-right: 1px dotted #dcdcdc;">
                                ÿ�ո���<font style="color: #999; font-weight: bolder; font-size: 30px;"> 1200 </font>
                                ��
                                <br />
                                ���Ը�����Ͷ����վ<br />
                            </div>
                        </td>
                        <td style="width: 25%; text-align: center;">
                            <div style="font-size: 24px; color: #dcdcdc; line-height: 40px; padding: 30px; border-right: 1px dotted #dcdcdc;">
                                ÿ�շ���<font style="color: #999; font-weight: bolder; font-size: 30px;"> 10000 </font>
                                ��
                                <br />
                                ����ҵ�б�ɹ���Ϣ
                            </div>
                        </td>
                        <td style="width: 25%; text-align: center;">
                            <div style="font-size: 24px; color: #dcdcdc; line-height: 40px; padding: 30px; border-right: 1px dotted #dcdcdc;">
                                ÿ�ճ���<font style="color: #999; font-weight: bolder; font-size: 30px;"> 200 </font>
                                ��
                                <br />
                                ����ҵʹ��ȥͶ����
                            </div>
                        </td>
                        <td style="width: 25%; text-align: center;">
                            <div style="font-size: 24px; color: #dcdcdc; line-height: 40px; padding: 30px;">
                                ÿ������<font style="color: #999; font-weight: bolder; font-size: 30px;"> 20000 </font>
                                ��
                                <br />
                                ��Ա�б궩������
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>--%>
    <div class="container" style="width: 100%; text-align: center; padding-top: 30px; border-top: 1px solid #ECECEC;
        border-bottom: 1px solid #ECECEC;">
        <div class="row" style="width: 100%;">
            <div style="line-height: 40px; text-align: left; margin: 0px auto; color: #666; font-size: 12px;">
                <div style="float: left; height: 360px; margin-left: 16%;">
                    <table class="provincesite" style="line-height: 40px;">
                        <tr>
                            <th style="width: 100px;">
                                ��������
                            </th>
                            <td style="width: 120px;">
                                <a href='/Province/index/p/9.html' style="text-decoration: none; color: #666;">�Ϻ��б���Ϣ��<span
                                    style="display: none;">9</span></a>
                            </td>
                            <td style="width: 120px;">
                                <a href='/Province/index/p/10.html' style="text-decoration: none; color: #666;">�����б���Ϣ��<span
                                    style="display: none;">10</span></a>
                            </td>
                            <td style="width: 120px;">
                                <a href='/Province/index/p/1.html' style="text-decoration: none; color: #666;">�㽭�б���Ϣ��<span
                                    style="display: none;">11</span></a>
                            </td>
                            <td style="width: 120px;">
                                <a href='/Province/index/p/12.html' style="text-decoration: none; color: #666;">�����б���Ϣ��<span
                                    style="display: none;">12</span></a>
                            </td>
                            <td style="width: 120px;">
                                <a href='/Province/index/p/13.html' style="text-decoration: none; color: #666;">�����б���Ϣ��<span
                                    style="display: none;">13</span></a>
                            </td>
                        </tr>
                        <tr>
                            <th>
                            </th>
                            <td style="width: 120px;">
                                <a href='/Province/index/p/14.html' style="text-decoration: none; color: #666;">�����б���Ϣ��<span
                                    style="display: none;">14</span></a>
                            </td>
                            <td style="width: 120px;">
                                <a href='/Province/index/p/15.html' style="text-decoration: none; color: #666;">ɽ���б���Ϣ��<span
                                    style="display: none;">15</span></a>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ��������
                            </th>
                            <td>
                                <a href='/Province/index/p/1.html' style="text-decoration: none; color: #666;">�����б���Ϣ��<span
                                    style="display: none;">1</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/2.html' style="text-decoration: none; color: #666;">����б���Ϣ��<span
                                    style="display: none;">2</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/3.html' style="text-decoration: none; color: #666;">�ӱ��б���Ϣ��<span
                                    style="display: none;">3</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/4.html' style="text-decoration: none; color: #666;">ɽ���б���Ϣ��<span
                                    style="display: none;">4</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/5.html' style="text-decoration: none; color: #666;">�����б���Ϣ��<span
                                    style="display: none;">5</span></a>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ��������
                            </th>
                            <td>
                                <a href='/Province/index/p/8.html' style="text-decoration: none; color: #666;">�������б���Ϣ��<span
                                    style="display: none;">8</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/7.html' style="text-decoration: none; color: #666;">�����б���Ϣ��<span
                                    style="display: none;">7</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/6.html' style="text-decoration: none; color: #666;">�����б���Ϣ��<span
                                    style="display: none;">6</span></a>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ���ϵ���
                            </th>
                            <td>
                                <a href='/Province/index/p/19.html' style="text-decoration: none; color: #666;">�㶫�б���Ϣ��<span
                                    style="display: none;">19</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/20.html' style="text-decoration: none; color: #666;">�����б���Ϣ��<span
                                    style="display: none;">20</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/21.html' style="text-decoration: none; color: #666;">�����б���Ϣ��<span
                                    style="display: none;">21</span></a>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ��������
                            </th>
                            <td>
                                <a href='/Province/index/p/27.html' style="text-decoration: none; color: #666;">�����б���Ϣ��<span
                                    style="display: none;">27</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/28.html' style="text-decoration: none; color: #666;">�����б���Ϣ��<span
                                    style="display: none;">28</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/29.html' style="text-decoration: none; color: #666;">�ຣ�б���Ϣ��<span
                                    style="display: none;">29</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/30.html' style="text-decoration: none; color: #666;">�����б���Ϣ��<span
                                    style="display: none;">30</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/31.html' style="text-decoration: none; color: #666;">�½��б���Ϣ��<span
                                    style="display: none;">31</span></a>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ���ϵ���
                            </th>
                            <td>
                                <a href='/Province/index/p/22.html' style="text-decoration: none; color: #666;">�����б���Ϣ��<span
                                    style="display: none;">22</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/23.html' style="text-decoration: none; color: #666;">�Ĵ��б���Ϣ��<span
                                    style="display: none;">23</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/24.html' style="text-decoration: none; color: #666;">�����б���Ϣ��<span
                                    style="display: none;">24</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/25.html' style="text-decoration: none; color: #666;">�����б���Ϣ��<span
                                    style="display: none;">25</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/26.html' style="text-decoration: none; color: #666;">�����б���Ϣ��<span
                                    style="display: none;">26</span></a>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                ���е���
                            </th>
                            <td>
                                <a href='/Province/index/p/16.html' style="text-decoration: none; color: #666;">�����б���Ϣ��<span
                                    style="display: none;">16</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/17.html' style="text-decoration: none; color: #666;">�����б���Ϣ��<span
                                    style="display: none;">17</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/18.html' style="text-decoration: none; color: #666;">�����б���Ϣ��<span
                                    style="display: none;">18</span></a>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="float: left; width: 400px; border: 1px solid #FEFEFE; height: 320px;
                    background-color: #FEFEFE; margin-left: 10px;">
                    <div style="height: 44px; line-height: 44px; border: 1px solid #eee; background-color: #fff;
                        border-bottom: 0px; padding-left: 20px;">
                        <img src="imgs/system/resizeApi_news.png" /> �б���Ѷ
                    </div>
                    <div style="border: 1px solid #eee;">
                        <table style="width: 100%;" id="tblNewsList">
                            <asp:Repeater runat="server" ID="rptNewsList">
                                <ItemTemplate>
                                    <tr>
                                        <td style="border-bottom: 1px dashed #eee; padding: 10px;">
                                            <table>
                                                <tr>
                                                    <td style="width: 70px; height: 50px; padding-left: 10px;">
                                                        <a href='/BidNewsDetail/<%#Eval("Id") %>.html' style="color: #000; font-size: 14px;
                                                            font-weight: normal;">
                                                            <img src="/imgs/news/<%#Eval("ProfileImage") %>" style="width: 70px; height: 48px;"
                                                                alt="" /></a>
                                                    </td>
                                                    <td style="text-align: left; height: 30px; line-height: 30px; padding-left: 10px;
                                                        padding-top: 2px; vertical-align: top; font-size: 12px; font-weight: normal;">
                                                        ��<%# Eval("TypeName").ToString()%>��<a href='/BidNewsDetail/<%#Eval("Id") %>.html'
                                                            style="color: #000; font-size: 12px; font-weight: normal;"><%#Eval("NewsTitle")%></a></td>
                                                </tr>
                                            </table>
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
    <br />
    <div class="container" style="width: 100%; text-align: center; padding-top: 20px;
        padding-bottom: 40px; border-bottom: 1px solid #fafafa;">
        <div class="row" style="width: 100%;">
            <div style="line-height: 30px; text-align: center; margin: 0px auto; color: #666;
                float: left; font-size: 12px; margin-left: 16%; width: 700px;">
                <div style="">
                    <table class="categorysite" style="">
                        <tr>
                            <td>
                                <uc3:ucBidCategoryList ID="ucBidCategoryList1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="float: left;padding-top: 20px; margin-left:10px;">
                <img src="/imgs/system/sucai/homepagead.png" width="400" />
            </div>
        </div>
    </div>
    <div class="container" style="width: 100%; text-align: left; padding-left: 16%; padding-bottom: 10px;
        background-color: #ececec; border-bottom: 1px solid #fafafa;">
        <div class="row" style="width: 100%; padding: 10px; padding-left: 0px;">
            <table id="tblfriendlink" cellpadding="0" cellspacing="0" style="font-size: 12px;
                line-height: 30px; height: 30px;">
                <tr>
                    <td style="width: 120px;">
                        <font style="font-weight: bold;">��������</font>
                    </td>
                    <td style="width: 100px;">
                        <a href="http://www.meyjc.com">��̨ǽ��</a>
                    </td>
                    <td style="width: 100px;">
                        <a href="http://www.chinajades.cc">��ͯ����</a>
                    </td>
                    <td style="width: 100px;">
                        <a href="http://www.tm365.net">�й���֯�豸��</a>
                    </td>
                    <td style="width: 100px;">
                        <a href="http://www.hdrkjsw.cn ">�˿ںͼƻ�����</a>
                    </td>
                    <td style="width: 100px;">
                        <a href="http://www.ygbt.net.cn">ҹ����Ƹ��Ϣ</a>
                    </td>
                    <td style="width: 100px;">
                        <a href="http://www.makename.cn">����</a>
                    </td>
                    <td style="width: 110px;">
                        <a href="http://www.fxinlu.com">����������������</a>
                    </td>
                    <td style="width: 110px;">
                        <a href="http://www.g448.com">����֮��</a>
                    </td>
                    <td style="width: 100px;">
                        <a href="http://www.8899588.com">���೵�۸�</a>
                    </td>
                    <td style="width: 110px;">
                        <a href="http://xiannuo.xin">̫����·�Ƽ۸�</a>
                    </td>
                    <td style="width: 100px;">
                    </td>
                    <tr>
                        <td>
                        </td>
                        <td style="width: 100px;">
                            <a href="http://www.youjialiren.com">�Ա��ڲ��Ż�ȯ</a>
                        </td>
                        <td style="width: 100px;">
                            <a href="http://www.777yl.club">��ҵ��Ϣ</a>
                        </td>
                        <td style="width: 100px;">
                            <a href="http://www.zchldp.com">˫�浶Ƭ</a>
                        </td>
                        <td style="width: 100px;">
                            <a href="http://ningde.b2b.kuyiso.com">���¹�����Ϣ��</a>
                        </td>
                        <td style="width: 100px;">
                            <a href="http://www.12315v.org">12315��α</a>
                        </td>
                        <td style="width: 100px;">
                            <a href="http://www.jingongjxc.com">��ת���</a>
                        </td>
                        <td style="width: 100px;">
                            <a href="http://www.bckui.com">��ǽ�����վ</a>
                        </td>
                        <td style="width: 100px;">
                            <a href="http://www.0634fc.com">���߷�̽��</a>
                        </td>
                        <td style="width: 100px;">
                        </td>
                        <td style="width: 100px;">
                        </td>
                        <td style="width: 100px;">
                        </td>
                    </tr>
                </tr>
            </table>
        </div>
    </div>
    <uc4:Bottom ID="Bottom1" runat="server" />
    <!-- Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;l-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="myModalLabel">
                        ȥͶ�����û�Э��</h4>
                </div>
                <div class="modal-body">
                    <div style="width: 95%; margin: 0px auto; font-size: 12px; line-height: 24px; height: 500px;
                        overflow-y: scroll;">
                        <div style="text-align: center; font-size: 14px; color: cornflowerblue; font-weight: bold;">
                            ȥͶ�����������</div>
                        <span class="protocoltitle">1. �ر���ʾ</span>
                        <br />
                        <br />
                        1.1 ȥͶ����ͬ�ⰴ�ձ�Э��Ĺ涨���䲻��ʱ�����Ĳ��������ṩ���ڻ���������ط������³�"������� "����Ϊ���������񣬷���ʹ���ˣ����³�"�û�"��Ӧ��ͬ�ⱾЭ���ȫ���������ҳ���ϵ���ʾ���ȫ����ע������û��ڽ���ע���������е��"���ܷ�������"����ʾ�û���ȫ���ܱ�Э�����µ�ȫ�����
                        <br />
                        <br />
                        <span class="protocoltitle">2. ��������</span><br />
                        <br />
                        2.1 ȥͶ�����������ľ���������ȥͶ��������ʵ������ṩ����������ʱ������жϻ���ֹ���ֻ�ȫ����������Ȩ����
                        <br />
                        2.2 ȥͶ�������ṩ�������ʱ����Բ������������û���ȡһ���ķ��á��ڴ�����£�ȥͶ�����������ҳ��������ȷ����ʾ�����û��ܾ�֧��������ã�����ʹ����ص��������
                        <br />
                        2.3 �û���⣬ȥͶ�������ṩ��ص�������񣬳���֮���������������йص��豸������ԡ����ƽ��������������뻥�����йص�װ�ã�������ķ��ã���Ϊ���뻥������֧���ĵ绰�Ѽ������ѣ���Ӧ���û����и�����
                        <br />
                        <br />
                        <span class="protocoltitle">3. ʹ�ù���</span><br />
                        <br />
                        3.1 �û�������ʹ��ȥͶ�����������ʱ�������ṩ׼ȷ����ҵ���������ϣ����������κα䶯�����뼰ʱ���¡�
                        <br />
                        3.2 �û�ע��ɹ���ȥͶ����������ÿ���û�һ���û�������Ӧ�����룬���û������������û����𱣹ܣ��û�Ӧ���������û������е����л���¼����������Ρ�
                        <br />
                        3.3 �û�����ͬ�����ȥͶ����ͨ�������ʼ���������ʽ���û����͵������վ������Ϣ��
                        <br />
                        3.4 �û�����ͬ����ѭ����ԭ��
                        <br />
                        (a) �����й��йصķ��ɺͷ��棻
                        <br />
                        (b) ����Ϊ�κηǷ�Ŀ�Ķ�ʹ���������ϵͳ��
                        <br />
                        (c) ������������������йص�����Э�顢�涨�ͳ���
                        <br />
                        (d) ��������ȥͶ�����������ϵͳ�����κο��ܶԻ�������������ת��ɲ���Ӱ�����Ϊ��
                        <br />
                        (e) ��������ȥͶ�����������ϵͳ�����κ�ɧ���Եġ��������˵ġ������Եġ������Եġ�ӹ������Ļ������κηǷ�����Ϣ���ϣ�
                        <br />
                        (f) ��������ȥͶ�����������ϵͳ�����κβ����ڲ���������Ϊ��
                        <br />
                        (g) �緢���κηǷ�ʹ���û������û����ְ�ȫ©���������Ӧ����ͨ��ȥͶ������
                        <br />
                        3.5 �û�����ͬ����ѭ���¹���
                        <br />
                        (a) δ��ȥͶ����������ɣ��û����ý����û���������ת�ۡ����롢ת�衢�⹩����������������ҵ����;�������ɴ���ɵ�һ�к�����������û��е���ͬʱ��ȥͶ������Ȩ��������ֹΪ���ṩ�ķ���
                        <br />
                        (b) δ��ȥͶ����������ɣ��û���������ȥͶ��������õ���Ϣ������ҵ��;���緢���û���ȥͶ�����γɾ�������ȥͶ���������棬��ȥͶ������Ϊ����������Ӫ����𺦵�������Ϊ��ȥͶ������Ȩ��������ֹ��ʹ���ʸ��ɴ���ɵ�һ�к�����������û��е���
                        <br />
                        <br />
                        <span class="protocoltitle">4. ��������Ȩ</span><br />
                        <br />
                        4.1 ȥͶ�����ṩ��������������ܰ�Ȩ���̱�������Ʋ�����Ȩ���ɵı�����
                        <br />
                        4.2 �û�ֻ���ڻ��ȥͶ�������������Ȩ���˵���Ȩ֮�����ʹ����Щ���ݣ����������Ը��ơ�������Щ���ݡ������������йص�������Ʒ��
                        <br />
                        <br />
                        <span class="protocoltitle">5. ��˽����</span><br />
                        <br />
                        5.1 �����û���˽��ȥͶ������һ��������ߣ�ȥͶ������֤�����⹫������������ṩ�û�ע�����ϼ��û���ʹ���������ʱ�洢��ȥͶ�����ķǹ������ݣ�������������⣺
                        <br />
                        (a) ���Ȼ���û�����ȷ��Ȩ��
                        <br />
                        (b) �����йصķ��ɷ���Ҫ��
                        <br />
                        (c) ��������������ܲ��ŵ�Ҫ��
                        <br />
                        (d) Ϊά����ṫ�ڵ����棻
                        <br />
                        (e) Ϊά��ȥͶ�����ĺϷ�Ȩ�档
                        <br />
                        <br />
                        <span class="protocoltitle">6. ��������</span><br />
                        <br />
                        6.1 �û�ʹ��ȥͶ����������������ڵķ��ս���ȫ�����Լ��е�������ʹ��ȥͶ������������������һ�к��Ҳ�����Լ��е���ȥͶ�������û����е��κ����Ρ�
                        <br />
                        <br />
                        <span class="protocoltitle">7. ���������жϻ���ֹ</span><br />
                        <br />
                        7.1 ����ϵͳά������������Ҫ������ͣ�������ȥͶ���������������Ƚ���ͨ�档
                        <br />
                        7.2 �緢�������κ�һ�����Σ�ȥͶ������Ȩ��ʱ�жϻ���ֹ���û��ṩ��Э�����µ�������������֪ͨ�û���
                        <br />
                        (a) �û��ṩ�ĸ������ϲ���ʵ��
                        <br />
                        (b) �û�Υ����Э���й涨��ʹ�ù���
                        <br />
                        7.3 ��ǰ�����������⣬ȥͶ����ͬʱ����������֪ͨ�û����������ʱ�жϻ���ֹ���ֻ�ȫ����������Ȩ�����������з�����жϻ���ֹ����ɵ��κ���ʧ��ȥͶ����������û����κε������е��κ����Ρ�
                        <br />
                        <br />
                        <span class="protocoltitle">8. ΥԼ�⳥</span><br />
                        <br />
                        8.1 �û�ͬ�Ᵽ�Ϻ�ά��ȥͶ�����������û������棬�����û�Υ���йط��ɡ������Э�����µ��κ��������ȥͶ�������κ����������������ʧ���û�ͬ��е��ɴ���ɵ����⳥���Ρ�
                        <br />
                        <br />
                        <span class="protocoltitle">9. �޸�Э��</span><br />
                        <br />
                        9.1 ȥͶ���������ܲ�ʱ���޸ı�Э����й����һ���������ݷ����䶯��ȥͶ������������ص�ҳ����ʾ�޸����ݡ�
                        <br />
                        9.2 �����ͬ��ȥͶ�����Է��������������޸ģ��û���Ȩֹͣʹ�������������û�����ʹ�������������Ϊ�û����ܷ�������ı䶯
                        <br />
                        <br />
                        <span class="protocoltitle">10. ֪ͨ���ʹ�</span><br />
                        <br />
                        10.1 ��Э���������е�֪ͨ����ͨ����Ҫҳ�湫�桢�����ʼ��򳣹���ż����͵ȷ�ʽ���У��õ�֪ͨ�ڷ���֮����Ϊ���ʹ��ռ��ˡ�
                        <br />
                        <br />
                        <span class="protocoltitle">11. �����涨</span><br />
                        <br />
                        11.1 ��Э�鹹��˫���Ա�Э��֮Լ����������й����˵�����Э�飬����Э��涨��֮�⣬δ���豾Э���������Ȩ����
                        <br />
                        11.2 �籾Э���е��κ��������������ԭ����ȫ�򲿷���Ч�򲻾���ִ��������Э�������������Ӧ��Ч������Լ������
                        <br />
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        �ر�</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal -->
    </div>
    <style type="text/css">
        .demo
        {
            width: 600px;
            height: 500px;
            margin: 30px auto 0 15%;
            font-size: 13px;
            color: #333;
        }
        .demo p
        {
            line-height: 30px;
        }
        
        li
        {
            list-style: none;
        }
        .companybox
        {
            width: 100%;
            padding-left: 0px;
            margin-left: 0px;
            height: 210px;
            overflow: hidden;
        }
        .companybox ul
        {
            padding-left: 0px;
            margin-left: 0px;
        }
        .companybox ul li
        {
            list-style: none;
            padding-left: 0px;
            margin-left: 0px;
            line-height: 25px;
        }
        #tblfriendlink td
        {
            height: 40px;
            line-height: 40px;
        }
        #tblfriendlink a
        {
            color: #000;
        }
    </style>
    <script src="/js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="http://tjs.sjs.sinajs.cn/open/api/js/wb.js?appkey=1366921169" type="text/javascript"
        charset="utf-8"></script>
    <script type="text/javascript" src="/js/index/raphael.js"></script>
    <script type="text/javascript" src="/js/index/chinamapPath.js"></script>
    <script type="text/javascript">
        function initLoginPanel() {
            if ($("#hdnislogin").val() == "True") {
                $("#divregist").hide();
                $("#divlogin").hide();
                $("#divislogin").show();
            }
        }
        $(function () {
            $("#sy").addClass("navchoose");

            initLoginPanel();

            $("#btnUserCenter").click(function () {
                location.href = "/UserCenter/Index.aspx"
            });

        });

        window.onload = function () {
            var R = Raphael("map", 600, 500);
            //���û��Ƶ�ͼ����
            paintMap(R);

            var textAttr = {
                "fill": "#000",
                "font-size": "12px",
                "cursor": "pointer"
            };


            for (var state in china) {
                china[state]['path'].color = Raphael.getColor(0.9);

                (function (st, state) {

                    //��ȡ��ǰͼ�ε���������
                    var xx = st.getBBox().x + (st.getBBox().width / 2);
                    var yy = st.getBBox().y + (st.getBBox().height / 2);

                    //***�޸Ĳ��ֵ�ͼ����ƫ������
                    switch (china[state]['name']) {
                        case "����":
                            xx += 5;
                            yy -= 10;
                            break;
                        case "�ӱ�":
                            xx -= 10;
                            yy += 20;
                            break;
                        case "���":
                            xx += 10;
                            yy += 10;
                            break;
                        case "�Ϻ�":
                            xx += 10;
                            break;
                        case "�㶫":
                            yy -= 10;
                            break;
                        case "����":
                            yy += 10;
                            break;
                        case "���":
                            xx += 20;
                            yy += 5;
                            break;
                        case "����":
                            xx -= 40;
                            yy -= 30;
                            break;
                        case "����":
                            xx += 5;
                            yy += 10;
                            break;
                        case "���ɹ�":
                            xx -= 15;
                            yy += 65;
                            break;
                        default:
                    }
                    //д������
                    china[state]['text'] = R.text(xx, yy, china[state]['name']).attr(textAttr);

                    st[0].onmouseover = function () {
                        st.animate({ fill: st.color, stroke: "#eee" }, 500);
                        china[state]['text'].toFront();
                        R.safari();
                    };
                    st[0].onmouseout = function () {
                        st.animate({ fill: "#97d6f5", stroke: "#eee" }, 500);
                        china[state]['text'].toFront();
                        R.safari();
                    };

                    st[0].onclick = function () {
                        var province = encodeURI(encodeURI(china[state]['id']));
                        window.location = "/Province/index/p/" + province;
                    };

                })(china[state]['path'], state);

            }

        }
    </script>
    <script src="/js/index.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".companybox").scrollTop({
                speed: 200
            });
        });
    </script>
    </form>
</body>
</html>
