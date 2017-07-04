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
    <title>去投标网_中国最大的免费招投标服务平台_在线招标投标服务平台_最新招标信息_让投标变得更简单</title>
    <meta name="keywords" content="去投标网,免费招标信息网,免费采购信息网,最全招标信息,最新招标信息,招标公告,招标预告,政府招标,地方采购信息" />
    <meta name="description" content="投标网是中国第一家免费的招标信息服务平台，免费采购信息网，招标信息最全、覆盖地区及招标行业最广的招标网，每天更新超过10000条各类招标项目信息；去投标网已成为政府、招标单位、业主招标采购的首选平台,让投标变得更简单,要投标就上去投标网。" />
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
                    <span class="HeadImgTitle">海量 | 准确 | 及时 | 永久免费</span>
                    <br />
                    <br />
                    <span class="HeadImgContent">● 覆盖全国 300+ 个城市招标信息,每日实时更新发布超过10,000 条招标采购信息。</span><br />
                    <span class="HeadImgContent">● 工程招标、货品招标、服务招标全兼容。</span><br />
                    <span class="HeadImgContent">● 免费订阅，短信、微信、app多渠道智能推送。</span><br />
                    <span class="HeadImgContent">● 招标信息智能分类、支持精确查询、全文搜索。</span>
                </div>
                <div class="col-lg-4">
                    <div class="box box-primary box-shadow-3" id="divregist" style="background-color: #fff;
                        width: 340px; padding: 20px; margin-top: 0px; color: #000; height: 380px; border-radius: 4px;">
                        <div class="box-body">
                            <div class="row">
                                <div class="col-xs-12">
                                    <input type="text" id="txtUserNickName" class="form-control" placeholder="请输入手机号" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-xs-12">
                                    <input type="password" id="txtPassword" class="form-control" placeholder="请输入至少6位密码" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-xs-12">
                                    <input type="text" id="txtEmail" class="form-control" placeholder="邮箱地址" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-xs-8">
                                    <input type="text" id="txtCompanyName" class="form-control" placeholder="公司名称" />
                                </div>
                                <div class="col-xs-4" style="padding-left: 0px;">
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-default dropdown-toggle" id="btnUserType" style="color: gray;
                                            border-radius: 5px; width: 100px;" data-toggle="dropdown">
                                            选择类型<span class="caret"></span>
                                        </button>
                                        <ul class="dropdown-menu dropdown-menu-right ul_dropdown_usertype" role="menu">
                                            <li value="1">投标方</li>
                                            <li value="2">招标方</li>
                                            <li value="3">代理机构</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-xs-8">
                                    <input type="text" id="txtUserName" class="form-control" placeholder="联系人姓名" />
                                </div>
                                <div class="col-xs-4" style="padding-left: 0px;">
                                    <input type="text" id="txtPosition" class="form-control" placeholder="职位名称" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-xs-12">
                                    <button type="button" class="btn btn-primary" id="btnRegist" style="font-weight: 700;
                                        height: 40px; width: 100%; font-size: 14px;">
                                        <span>免费注册</span>
                                    </button>
                                </div>
                                <div class="col-xs-12" style="font-size: 10px; margin-top: 10px; padding: 5px; border-top: 1px solid #dcdcdc;">
                                    <div class="col-xs-7">
                                        <div>
                                            同意 <a href="#" data-toggle="modal" data-target="#myModal">《去投标网用户协议》</a></div>
                                    </div>
                                    <div class="col-xs-5">
                                        <a href="#" id="hreflogin">已有账户，请登录</a>
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
                                    <input type="text" id="txtLoginUserName" class="form-control" placeholder="用户名/手机号/邮箱地址" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-xs-12">
                                    <input type="password" id="txtLoginPassword" class="form-control" placeholder="用户密码" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-xs-4">
                                    <input type="text" id="txtUserCheckCode" class="form-control" placeholder="验证码" /></div>
                                <div class="col-xs-6">
                                    <img id="Img1" alt="看不清，请点击我！" onclick="this.src=this.src+'?'" src="CheckCodeHandler.ashx"
                                        style="width: 80px; height: 34px" align="left" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-xs-12">
                                    <button type="button" class="btn btn-primary" id="btnLogin" style="font-weight: 700;
                                        height: 40px; width: 100%; font-size: 14px;">
                                        <span>立即登录</span>
                                    </button>
                                </div>
                                <div class="col-xs-12" style="font-size: 10px; margin-top: 20px; padding: 5px; border-top: 1px solid #dcdcdc;">
                                    <div class="col-xs-9">
                                        <a href="#" id="lnkregist">还没有账号，先注册</a>
                                    </div>
                                    <div class="col-xs-3">
                                        <a href="ForgetPassword.html" id="lnkforget">忘记密码</a>
                                    </div>
                                </div>
                                <div class="col-xs-12" align="right" style="font-size: 11px; padding: 10px; color: #333;
                                    text-align: center;">
                                    第三方帐号登录
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
                        <asp:Label runat="server" ID="lblCurrentUserName"></asp:Label>,欢迎使用去投标网！ <a href="Logout.html">
                            退出</a><br />
                        <asp:Image runat="server" ID="imgProfile" Style="margin-left: 10px;" Width="65" Height="65" /><br />
                        用户类型：<asp:Label runat="server" ID="lblCurrentUserType"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp; 您有 <a href="/UserCenter/UserCenterPage/MessageCenter.html">
                            <asp:Label runat="server" ID="lblUnReadCount"></asp:Label></a> 条未读消息
                        <br />
                        企业认证：<asp:Label runat="server" ID="lblCurrentCompanyAuditStatus"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp; 用户年限：<asp:Label runat="server" ID="lblCurrentUserYear"></asp:Label>
                        年<br />
                        上次登录时间：<asp:Label runat="server" ID="lblCurrentUserLoginTime"></asp:Label><br />
                        已发布的招标数量：<asp:Label runat="server" ID="lblCurrentUserPubBidCount"></asp:Label><br />
                        已发布的采购数量：<asp:Label runat="server" ID="lblCurrentUserPubPurchaseCount"></asp:Label><br />
                        <button type="button" class="btn btn-success" style="width: 300px; margin-top: 10px;"
                            id="btnUserCenter">
                            进入管理中心</button>
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
                        placeholder="请输入招投标关键字" />
                    <div class="input-group-btn">
                        <button type="button" class="btn btn-default dropdown-toggle" id="btn_dropdown_selectarea"
                            style="color: gray; width: 100px; border-radius: 0px;" data-toggle="dropdown">
                            选择地区<span class="caret"></span>
                        </button>
                        <div class="dropdown-menu dropdown-menu-right" style="padding: 5px; width: 380px;"
                            role="menu">
                            <div class="dropdown_menu_div">
                                <table class="dropdown_content_areas">
                                    <tr>
                                        <th style="border-bottom: 1px solid #dcdcdc;">
                                            所有
                                        </th>
                                        <td colspan="5" style="border-bottom: 1px solid #dcdcdc;">
                                            全国<span style="display: none;">0</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            华东
                                        </th>
                                        <td>
                                            上海<span style="display: none;">9</span>
                                        </td>
                                        <td>
                                            江苏<span style="display: none;">10</span>
                                        </td>
                                        <td>
                                            浙江<span style="display: none;">11</span>
                                        </td>
                                        <td>
                                            安徽<span style="display: none;">12</span>
                                        </td>
                                        <td>
                                            福建<span style="display: none;">13</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                        </th>
                                        <td>
                                            江西<span style="display: none;">14</span>
                                        </td>
                                        <td>
                                            山东<span style="display: none;">15</span>
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
                                            华北
                                        </th>
                                        <td>
                                            北京<span style="display: none;">1</span>
                                        </td>
                                        <td>
                                            天津<span style="display: none;">2</span>
                                        </td>
                                        <td>
                                            河北<span style="display: none;">3</span>
                                        </td>
                                        <td>
                                            山西<span style="display: none;">4</span>
                                        </td>
                                        <td>
                                            内蒙<span style="display: none;">5</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            东北
                                        </th>
                                        <td>
                                            黑龙江<span style="display: none;">8</span>
                                        </td>
                                        <td>
                                            吉林<span style="display: none;">7</span>
                                        </td>
                                        <td>
                                            辽宁<span style="display: none;">6</span>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            华南
                                        </th>
                                        <td>
                                            广东<span style="display: none;">19</span>
                                        </td>
                                        <td>
                                            广西<span style="display: none;">20</span>
                                        </td>
                                        <td>
                                            海南<span style="display: none;">21</span>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            西北
                                        </th>
                                        <td>
                                            陕西<span style="display: none;">27</span>
                                        </td>
                                        <td>
                                            甘肃<span style="display: none;">28</span>
                                        </td>
                                        <td>
                                            青海<span style="display: none;">29</span>
                                        </td>
                                        <td>
                                            宁夏<span style="display: none;">30</span>
                                        </td>
                                        <td>
                                            新疆<span style="display: none;">31</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            西南
                                        </th>
                                        <td>
                                            重庆<span style="display: none;">22</span>
                                        </td>
                                        <td>
                                            四川<span style="display: none;">23</span>
                                        </td>
                                        <td>
                                            贵州<span style="display: none;">24</span>
                                        </td>
                                        <td>
                                            云南<span style="display: none;">25</span>
                                        </td>
                                        <td>
                                            西藏<span style="display: none;">26</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            华中
                                        </th>
                                        <td>
                                            河南<span style="display: none;">16</span>
                                        </td>
                                        <td>
                                            湖北<span style="display: none;">17</span>
                                        </td>
                                        <td>
                                            湖南<span style="display: none;">18</span>
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
                            选择行业 <span class="caret"></span>
                        </button>
                        <ul class="dropdown-menu dropdown-menu-right ul_dropdown_industry" role="menu">
                            <li value="1">建筑工程</li>
                            <li value="7">仪器设备</li>
                            <li value="14">办公文教</li>
                            <li value="18">医疗卫生</li>
                            <li value="21">环保绿化</li>
                            <li value="26">机械设备</li>
                            <li value="31">服务行业</li>
                            <li value="38">服装日用</li>
                        </ul>
                    </div>
                    <div class="input-group-btn">
                        <button type="button" class="btn btn-default dropdown-toggle" id="btn_dropdown_selectbidtype"
                            style="color: gray; border-radius: 0px; width: 100px; border-left: 0px;" data-toggle="dropdown">
                            招标类型 <span class="caret"></span>
                        </button>
                        <ul class="dropdown-menu dropdown-menu-right ul_dropdown_bidtype" role="menu">
                            <li value="1">招标公告</li>
                            <li value="2">招标变更</li>
                            <li value="3">中标公告</li>
                            <li value="4">招标预告</li>
                            <li value="5">废流标公告</li>
                            <li value="6">邀请招标</li>
                            <li value="7">VIP项目</li>
                        </ul>
                    </div>
                    <div class="input-group-btn">
                        <button type="button" id="btnSearch" class="btn btn-primary" style="border-radius: 0px;
                            width: 100px;">
                            <span class="glyphicon glyphicon-search"></span><font style="font-weight: 700; font-size: 14px;">
                                搜 索 </font>
                        </button>
                    </div>
                </div>
                <!-- /input-group -->
            </div>
            <div class="col-lg-2" style="line-height: 34px; padding-left: 0px;">
                <div style="color: #fff; width: 100%; text-align: center;" class="label-warning">
                    7天新增招标： <span class="badge">
                        <asp:Literal runat="server" ID="ltrTotalCount"></asp:Literal>
                        个</span>
                </div>
            </div>
            <div class="col-lg-12">
                <div style="font-size: 10px; color: #aaa; padding: 10px;">
                    热门搜索: &nbsp;&nbsp;<a href="/BidList.html?keyword=施工">施工</a>&nbsp;&nbsp;<a href="/BidList.html?keyword=制服">制服</a>&nbsp;&nbsp;
                    <a href="/BidList.html?keyword=劳务">劳务</a>&nbsp;&nbsp;<a href="/BidList.html?keyword=大学">大学</a>&nbsp;&nbsp;
                    <a href="/BidList.html?keyword=监理">监理</a>&nbsp;&nbsp; <a href="/BidList.html?keyword=办公设备">
                        办公设备</a>&nbsp;&nbsp; <a href="/BidList.html?keyword=电子设备">电子设备</a>&nbsp;&nbsp;<a
                            href="/BidList.html?keyword=监控设备"> 监控设备</a> &nbsp;&nbsp; <a href="/BidList.html?keyword=虚拟现实">
                                虚拟现实</a>&nbsp;&nbsp;<a href="/BidList.html?keyword=绿化">绿化</a>&nbsp;&nbsp;
                    <a href="/BidList.html?keyword=医院">医院</a></div>
            </div>
        </div>
        <!-- /.row -->
    </div>
    <div class="container">
        <div class="row">
            <div class="col-lg-12" style="margin-top: 0px; padding: 0px;">
                <uc1:BidListByCategory ID="BidListByCategory3" runat="server" CategoryId="1" CategoryName="最新招标公告"
                    CategoryEnglishName="Latest Bid Information" />
                <%--                <uc1:BidListByCategory ID="BidListByCategory2" runat="server" CategoryId="1" CategoryName="建筑工程"
                    CategoryEnglishName="Construction Engineering" />
                <uc1:BidListByCategory ID="BidListByCategory3" runat="server" CategoryId="7" CategoryName="仪器设备"
                    CategoryEnglishName="Instrumenttation" />
                <uc1:BidListByCategory ID="BidListByCategory4" runat="server" CategoryId="14" CategoryName="办公文教"
                    CategoryEnglishName="Office Supply" />
                <uc1:BidListByCategory ID="BidListByCategory5" runat="server" CategoryId="18" CategoryName="医疗卫生"
                    CategoryEnglishName="HealthMedical Treatment" />
                <uc1:BidListByCategory ID="BidListByCategory6" runat="server" CategoryId="21" CategoryName="园林环保"
                    CategoryEnglishName="Environmental" />
                <uc1:BidListByCategory ID="BidListByCategory7" runat="server" CategoryId="26" CategoryName="机械设备"
                    CategoryEnglishName="Mechanical Equipment" />
                <uc1:BidListByCategory ID="BidListByCategory1" runat="server" CategoryId="31" CategoryName="服务行业"
                    CategoryEnglishName="Bussiness Service" />
                <uc1:BidListByCategory ID="BidListByCategory8" runat="server" CategoryId="38" CategoryName="服装日用"
                    CategoryEnglishName="Bussiness Service" />--%>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-lg-12" style="margin-top: 0px; padding: 0px;">
                <div style="border-left: 4px solid #000; font-weight: 700; font-size: 14px; margin-left: 15px;
                    padding-left: 10px; padding-top: 0px; margin-top: 10px; color: #000; font-family: '微软雅黑';">
                    求购信息 <span style="font-size: 12px;">Small Purchase </span>
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
                                <td style="width: 230px; font-family: '微软雅黑'; line-height: 25px; height: 200px; vertical-align: top;">
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
                                        发布时间：<font style="font-size: 12px; color: #000"><%#Eval("PublishTime", "{0:D}")%></font><br /><font style="font-size: 12px; color: #000">采购方：<%#Eval("CompanyName")%></font><br />求购地区：<font style="font-size: 12px; color: #000"><%#Eval("ProvinceName")%><%# Eval("CityName").ToString().Length > 3 ? Eval("CityName").ToString().Substring(0, 3) : Eval("CityName").ToString()%></font><br /><a target="_blank" href='/PurchaseOrderDetail/<%#Eval("Id")%>.html' style="font-size: 12px;
                                            text-decoration: none;"><div style="margin-top: 5px; font-size: 12px; border-radus: 2px; text-align: center;
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
    <br />
    <%--<div class="container" style="width: 100%; background-color: #fafafa;">
        <div class="row">
            <div style="border-bottom: 0px solid #dcdcdc; padding: 10px; font-family: '微软雅黑';
                height: 40px; line-height: 40px; text-align: center; font-size: 18px; font-weight: bold;
                padding: 20px;">
                全国各区域招标网
            </div>
            <div style="margin-left: 15%; margin-top: 30px; color: #666;">
                <font style="color: red; font-size: 12px;">*</font>请选择下方地图中您关注的省份，查看该地区的招投标信息</div>
            <div class="demo">
                <table>
                    <tr>
                        <td>
                            <div id="map">
                            </div>
                        </td>
                        <td valign="top" style="width: 350px; color: #999;">
                            <div style="font-size: 14px; line-height: 30px;">
                                ----- 覆盖34个省级行政区域，包括23个省，5个自治区，4个直辖市<br />
                                ----- 每日实时更新招标、变更、中标、单一源及采购信息<br />
                                ----- 免费注册即可查遍全国各地海量招投标信息<br />
                                ----- 注册会员还可免费发布招标采购信息，全国货源一网打尽<br />
                                ----- 网页客户端、微信、短信多渠道全方位信息展示<br />
                                ----- 智能订阅、智能提醒、再也不用盯着各家机构发布招标信息<br />
                                ----- 选择<a href="http://www.gobiding.com">去投标网</a>，为您的生意保驾护航！<br />
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
                                            <div style="font-size: 14px; font-family: '微软雅黑'; padding-left: 20px;">
                                                <font style="font-size: 18px; line-height: 30px; font-weight: bolder;">去投标网微信公众号</font><br />
                                                <div style="line-height: 25px;">
                                                    扫一扫微信公众服务号<br />
                                                    随时随地手机也能在线投标<br />
                                                    免安装，免升级，更安全，更便捷
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
                <table style="width: 100%; font-family: '微软雅黑';">
                    <tr>
                        <td style="width: 25%; text-align: center;">
                            <div style="font-size: 24px; color: #dcdcdc; line-height: 40px; padding: 30px; border-right: 1px dotted #dcdcdc;">
                                每日更新<font style="color: #999; font-weight: bolder; font-size: 30px;"> 1200 </font>
                                家
                                <br />
                                来自各类招投标网站<br />
                            </div>
                        </td>
                        <td style="width: 25%; text-align: center;">
                            <div style="font-size: 24px; color: #dcdcdc; line-height: 40px; padding: 30px; border-right: 1px dotted #dcdcdc;">
                                每日发布<font style="color: #999; font-weight: bolder; font-size: 30px;"> 10000 </font>
                                条
                                <br />
                                各行业招标采购信息
                            </div>
                        </td>
                        <td style="width: 25%; text-align: center;">
                            <div style="font-size: 24px; color: #dcdcdc; line-height: 40px; padding: 30px; border-right: 1px dotted #dcdcdc;">
                                每日超过<font style="color: #999; font-weight: bolder; font-size: 30px;"> 200 </font>
                                个
                                <br />
                                新企业使用去投标网
                            </div>
                        </td>
                        <td style="width: 25%; text-align: center;">
                            <div style="font-size: 24px; color: #dcdcdc; line-height: 40px; padding: 30px;">
                                每日推送<font style="color: #999; font-weight: bolder; font-size: 30px;"> 20000 </font>
                                次
                                <br />
                                会员招标订阅提醒
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
                                华东地区
                            </th>
                            <td style="width: 120px;">
                                <a href='/Province/index/p/9.html' style="text-decoration: none; color: #666;">上海招标信息网<span
                                    style="display: none;">9</span></a>
                            </td>
                            <td style="width: 120px;">
                                <a href='/Province/index/p/10.html' style="text-decoration: none; color: #666;">江苏招标信息网<span
                                    style="display: none;">10</span></a>
                            </td>
                            <td style="width: 120px;">
                                <a href='/Province/index/p/1.html' style="text-decoration: none; color: #666;">浙江招标信息网<span
                                    style="display: none;">11</span></a>
                            </td>
                            <td style="width: 120px;">
                                <a href='/Province/index/p/12.html' style="text-decoration: none; color: #666;">安徽招标信息网<span
                                    style="display: none;">12</span></a>
                            </td>
                            <td style="width: 120px;">
                                <a href='/Province/index/p/13.html' style="text-decoration: none; color: #666;">福建招标信息网<span
                                    style="display: none;">13</span></a>
                            </td>
                        </tr>
                        <tr>
                            <th>
                            </th>
                            <td style="width: 120px;">
                                <a href='/Province/index/p/14.html' style="text-decoration: none; color: #666;">江西招标信息网<span
                                    style="display: none;">14</span></a>
                            </td>
                            <td style="width: 120px;">
                                <a href='/Province/index/p/15.html' style="text-decoration: none; color: #666;">山东招标信息网<span
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
                                华北地区
                            </th>
                            <td>
                                <a href='/Province/index/p/1.html' style="text-decoration: none; color: #666;">北京招标信息网<span
                                    style="display: none;">1</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/2.html' style="text-decoration: none; color: #666;">天津招标信息网<span
                                    style="display: none;">2</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/3.html' style="text-decoration: none; color: #666;">河北招标信息网<span
                                    style="display: none;">3</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/4.html' style="text-decoration: none; color: #666;">山西招标信息网<span
                                    style="display: none;">4</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/5.html' style="text-decoration: none; color: #666;">内蒙招标信息网<span
                                    style="display: none;">5</span></a>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                东北地区
                            </th>
                            <td>
                                <a href='/Province/index/p/8.html' style="text-decoration: none; color: #666;">黑龙江招标信息网<span
                                    style="display: none;">8</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/7.html' style="text-decoration: none; color: #666;">吉林招标信息网<span
                                    style="display: none;">7</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/6.html' style="text-decoration: none; color: #666;">辽宁招标信息网<span
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
                                华南地区
                            </th>
                            <td>
                                <a href='/Province/index/p/19.html' style="text-decoration: none; color: #666;">广东招标信息网<span
                                    style="display: none;">19</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/20.html' style="text-decoration: none; color: #666;">广西招标信息网<span
                                    style="display: none;">20</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/21.html' style="text-decoration: none; color: #666;">海南招标信息网<span
                                    style="display: none;">21</span></a>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                西北地区
                            </th>
                            <td>
                                <a href='/Province/index/p/27.html' style="text-decoration: none; color: #666;">陕西招标信息网<span
                                    style="display: none;">27</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/28.html' style="text-decoration: none; color: #666;">甘肃招标信息网<span
                                    style="display: none;">28</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/29.html' style="text-decoration: none; color: #666;">青海招标信息网<span
                                    style="display: none;">29</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/30.html' style="text-decoration: none; color: #666;">宁夏招标信息网<span
                                    style="display: none;">30</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/31.html' style="text-decoration: none; color: #666;">新疆招标信息网<span
                                    style="display: none;">31</span></a>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                西南地区
                            </th>
                            <td>
                                <a href='/Province/index/p/22.html' style="text-decoration: none; color: #666;">重庆招标信息网<span
                                    style="display: none;">22</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/23.html' style="text-decoration: none; color: #666;">四川招标信息网<span
                                    style="display: none;">23</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/24.html' style="text-decoration: none; color: #666;">贵州招标信息网<span
                                    style="display: none;">24</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/25.html' style="text-decoration: none; color: #666;">云南招标信息网<span
                                    style="display: none;">25</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/26.html' style="text-decoration: none; color: #666;">西藏招标信息网<span
                                    style="display: none;">26</span></a>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                华中地区
                            </th>
                            <td>
                                <a href='/Province/index/p/16.html' style="text-decoration: none; color: #666;">河南招标信息网<span
                                    style="display: none;">16</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/17.html' style="text-decoration: none; color: #666;">湖北招标信息网<span
                                    style="display: none;">17</span></a>
                            </td>
                            <td>
                                <a href='/Province/index/p/18.html' style="text-decoration: none; color: #666;">湖南招标信息网<span
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
                        <img src="imgs/system/resizeApi_news.png" /> 招标资讯
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
                                                        【<%# Eval("TypeName").ToString()%>】<a href='/BidNewsDetail/<%#Eval("Id") %>.html'
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
                        <font style="font-weight: bold;">友情链接</font>
                    </td>
                    <td style="width: 100px;">
                        <a href="http://www.meyjc.com">烟台墙板</a>
                    </td>
                    <td style="width: 100px;">
                        <a href="http://www.chinajades.cc">儿童保险</a>
                    </td>
                    <td style="width: 100px;">
                        <a href="http://www.tm365.net">中国纺织设备网</a>
                    </td>
                    <td style="width: 100px;">
                        <a href="http://www.hdrkjsw.cn ">人口和计划生育</a>
                    </td>
                    <td style="width: 100px;">
                        <a href="http://www.ygbt.net.cn">夜场招聘信息</a>
                    </td>
                    <td style="width: 100px;">
                        <a href="http://www.makename.cn">起名</a>
                    </td>
                    <td style="width: 110px;">
                        <a href="http://www.fxinlu.com">生物质蒸汽发生器</a>
                    </td>
                    <td style="width: 110px;">
                        <a href="http://www.g448.com">世界之最</a>
                    </td>
                    <td style="width: 100px;">
                        <a href="http://www.8899588.com">吸粪车价格</a>
                    </td>
                    <td style="width: 110px;">
                        <a href="http://xiannuo.xin">太阳能路灯价格</a>
                    </td>
                    <td style="width: 100px;">
                    </td>
                    <tr>
                        <td>
                        </td>
                        <td style="width: 100px;">
                            <a href="http://www.youjialiren.com">淘宝内部优惠券</a>
                        </td>
                        <td style="width: 100px;">
                            <a href="http://www.777yl.club">创业信息</a>
                        </td>
                        <td style="width: 100px;">
                            <a href="http://www.zchldp.com">双面刀片</a>
                        </td>
                        <td style="width: 100px;">
                            <a href="http://ningde.b2b.kuyiso.com">宁德供求信息网</a>
                        </td>
                        <td style="width: 100px;">
                            <a href="http://www.12315v.org">12315防伪</a>
                        </td>
                        <td style="width: 100px;">
                            <a href="http://www.jingongjxc.com">回转风机</a>
                        </td>
                        <td style="width: 100px;">
                            <a href="http://www.bckui.com">诸城建设网站</a>
                        </td>
                        <td style="width: 100px;">
                            <a href="http://www.0634fc.com">莱芜房探网</a>
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
                        去投标网用户协议</h4>
                </div>
                <div class="modal-body">
                    <div style="width: 95%; margin: 0px auto; font-size: 12px; line-height: 24px; height: 500px;
                        overflow-y: scroll;">
                        <div style="text-align: center; font-size: 14px; color: cornflowerblue; font-weight: bold;">
                            去投标网服务条款：</div>
                        <span class="protocoltitle">1. 特别提示</span>
                        <br />
                        <br />
                        1.1 去投标网同意按照本协议的规定及其不定时发布的操作规则提供基于互联网的相关服务（以下称"网络服务 "）。为获得网络服务，服务使用人（以下称"用户"）应当同意本协议的全部条款并按照页面上的提示完成全部的注册程序。用户在进行注册程序过程中点击"接受服务条款"即表示用户完全接受本协议项下的全部条款。
                        <br />
                        <br />
                        <span class="protocoltitle">2. 服务内容</span><br />
                        <br />
                        2.1 去投标网网络服务的具体内容由去投标网根据实际情况提供，并保留随时变更、中断或终止部分或全部网络服务的权利。
                        <br />
                        2.2 去投标网在提供网络服务时，会对部分网络服务的用户收取一定的费用。在此情况下，去投标网会在相关页面上做明确的提示。如用户拒绝支付该项费用，则不能使用相关的网络服务。
                        <br />
                        2.3 用户理解，去投标网仅提供相关的网络服务，除此之外与相关网络服务有关的设备（如电脑、调制解调器及其他与接入互联网有关的装置）及所需的费用（如为接入互联网而支付的电话费及上网费）均应由用户自行负担。
                        <br />
                        <br />
                        <span class="protocoltitle">3. 使用规则</span><br />
                        <br />
                        3.1 用户在申请使用去投标网网络服务时，必须提供准确的企业及个人资料，如资料有任何变动，必须及时更新。
                        <br />
                        3.2 用户注册成功后，去投标网将给予每个用户一个用户名及相应的密码，该用户名和密码由用户负责保管；用户应当对以其用户名进行的所有活动和事件负法律责任。
                        <br />
                        3.3 用户必须同意接受去投标网通过电子邮件或其他方式向用户发送的相关网站服务信息。
                        <br />
                        3.4 用户必须同意遵循以下原则：
                        <br />
                        (a) 遵守中国有关的法律和法规；
                        <br />
                        (b) 不得为任何非法目的而使用网络服务系统；
                        <br />
                        (c) 遵守所有与网络服务有关的网络协议、规定和程序；
                        <br />
                        (d) 不得利用去投标网网络服务系统进行任何可能对互联网的正常运转造成不利影响的行为；
                        <br />
                        (e) 不得利用去投标网网络服务系统传输任何骚扰性的、中伤他人的、辱骂性的、恐吓性的、庸俗淫秽的或其他任何非法的信息资料；
                        <br />
                        (f) 不得利用去投标网网络服务系统进行任何不利于采招网的行为；
                        <br />
                        (g) 如发现任何非法使用用户名或用户出现安全漏洞的情况，应立即通告去投标网。
                        <br />
                        3.5 用户必须同意遵循以下规则：
                        <br />
                        (a) 未经去投标网书面许可，用户不得将其用户名、密码转售、赠与、转借、租供给第三方或用于商业性用途。否则，由此造成的一切后果和责任由用户承担；同时，去投标网有权单方面中止为其提供的服务。
                        <br />
                        (b) 未经去投标网书面许可，用户不得利用去投标网所获得的信息用于商业用途，如发现用户与去投标网形成竞争或损害去投标网的利益，或去投标网认为对其正常运营造成损害的其他行为，去投标网有权单方面终止其使用资格，由此造成的一切后果和责任由用户承担。
                        <br />
                        <br />
                        <span class="protocoltitle">4. 内容所有权</span><br />
                        <br />
                        4.1 去投标网提供的网络服务内容受版权、商标和其它财产所有权法律的保护。
                        <br />
                        4.2 用户只有在获得去投标网或其他相关权利人的授权之后才能使用这些内容，而不能擅自复制、再造这些内容、或创造与内容有关的派生产品。
                        <br />
                        <br />
                        <span class="protocoltitle">5. 隐私保护</span><br />
                        <br />
                        5.1 保护用户隐私是去投标网的一项基本政策，去投标网保证不对外公开或向第三方提供用户注册资料及用户在使用网络服务时存储在去投标网的非公开内容，但下列情况除外：
                        <br />
                        (a) 事先获得用户的明确授权；
                        <br />
                        (b) 根据有关的法律法规要求；
                        <br />
                        (c) 按照相关政府主管部门的要求；
                        <br />
                        (d) 为维护社会公众的利益；
                        <br />
                        (e) 为维护去投标网的合法权益。
                        <br />
                        <br />
                        <span class="protocoltitle">6. 免责声明</span><br />
                        <br />
                        6.1 用户使用去投标网网络服务所存在的风险将完全由其自己承担；因其使用去投标网网络服务而产生的一切后果也由其自己承担，去投标网对用户不承担任何责任。
                        <br />
                        <br />
                        <span class="protocoltitle">7. 服务变更、中断或终止</span><br />
                        <br />
                        7.1 如因系统维护或升级的需要而需暂停网络服务，去投标网将尽可能事先进行通告。
                        <br />
                        7.2 如发生下列任何一种情形，去投标网有权随时中断或终止向用户提供本协议项下的网络服务而无需通知用户：
                        <br />
                        (a) 用户提供的个人资料不真实；
                        <br />
                        (b) 用户违反本协议中规定的使用规则。
                        <br />
                        7.3 除前款所述情形外，去投标网同时保留在事先通知用户的情况下随时中断或终止部分或全部网络服务的权利，对于所有服务的中断或终止而造成的任何损失，去投标网无需对用户或任何第三方承担任何责任。
                        <br />
                        <br />
                        <span class="protocoltitle">8. 违约赔偿</span><br />
                        <br />
                        8.1 用户同意保障和维护去投标网及其他用户的利益，如因用户违反有关法律、法规或本协议项下的任何条款而给去投标网或任何其他第三人造成损失，用户同意承担由此造成的损害赔偿责任。
                        <br />
                        <br />
                        <span class="protocoltitle">9. 修改协议</span><br />
                        <br />
                        9.1 去投标网将可能不时的修改本协议的有关条款，一旦条款内容发生变动，去投标网将会在相关的页面提示修改内容。
                        <br />
                        9.2 如果不同意去投标网对服务条款所做的修改，用户有权停止使用网络服务。如果用户继续使用网络服务，则视为用户接受服务条款的变动
                        <br />
                        <br />
                        <span class="protocoltitle">10. 通知和送达</span><br />
                        <br />
                        10.1 本协议项下所有的通知均可通过重要页面公告、电子邮件或常规的信件传送等方式进行；该等通知于发送之日视为已送达收件人。
                        <br />
                        <br />
                        <span class="protocoltitle">11. 其他规定</span><br />
                        <br />
                        11.1 本协议构成双方对本协议之约定事项及其他有关事宜的完整协议，除本协议规定的之外，未赋予本协议各方其他权利。
                        <br />
                        11.2 如本协议中的任何条款无论因何种原因完全或部分无效或不具有执行力，本协议的其余条款仍应有效并且有约束力。
                        <br />
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        关闭</button>
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
            //调用绘制地图方法
            paintMap(R);

            var textAttr = {
                "fill": "#000",
                "font-size": "12px",
                "cursor": "pointer"
            };


            for (var state in china) {
                china[state]['path'].color = Raphael.getColor(0.9);

                (function (st, state) {

                    //获取当前图形的中心坐标
                    var xx = st.getBBox().x + (st.getBBox().width / 2);
                    var yy = st.getBBox().y + (st.getBBox().height / 2);

                    //***修改部分地图文字偏移坐标
                    switch (china[state]['name']) {
                        case "江苏":
                            xx += 5;
                            yy -= 10;
                            break;
                        case "河北":
                            xx -= 10;
                            yy += 20;
                            break;
                        case "天津":
                            xx += 10;
                            yy += 10;
                            break;
                        case "上海":
                            xx += 10;
                            break;
                        case "广东":
                            yy -= 10;
                            break;
                        case "澳门":
                            yy += 10;
                            break;
                        case "香港":
                            xx += 20;
                            yy += 5;
                            break;
                        case "甘肃":
                            xx -= 40;
                            yy -= 30;
                            break;
                        case "陕西":
                            xx += 5;
                            yy += 10;
                            break;
                        case "内蒙古":
                            xx -= 15;
                            yy += 65;
                            break;
                        default:
                    }
                    //写入文字
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
