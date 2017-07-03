<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Top.ascx.cs" Inherits="GoBiding.Web.UserCenter.Index.Top" %>
<header class="navbar navbar-static-top bs-docs-nav" id="top" role="banner" style="margin-bottom: 0px;background-color: #fff;">
    <link href="/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .bidtopmenu li a
        {
            color: #333;
            font-weight: bold;
        }
        .navchoose
        {
            background-color: #ececec;
        }
        .navchoose a
        {
            color: #000;
        }
    </style>
    <link href="/css/qqstyle.css" rel="stylesheet" media="screen" type="text/css" />
<div style="width:100%; background-color:#fcfcfc;">
<div class="container" style="padding-left: 0px; aligh:right;">
    <div class="navbar-header">
       <div style="padding:0px; margin:0px; border:0px;">
        <a href="/Default.html">
        <table cellpadding="0" cellspacing="0" style="padding:0px; margin:0px; border:0px;" >
        <tr>
        <td style="padding:0px; margin:0px; border:0px;"><img src="/imgs/system/logo_320_2.png" height="50" alt="去投标网"/></td>
        </tr>
        </table>
        </a>
       </div>
    </div>
    <nav class="collapse navbar-collapse bs-navbar-collapse" role="navigation">
      <ul class="nav navbar-nav navbar-right bidtopmenu">
        <li class="active" id="sy">
          <a href="/Default.html">首页</a>
        </li>
         <li class="active" id="zbdt">
          <a href="/BidList.html">招投大厅</a>
        </li>
        <li class="active"  id="xyzb">
          <a href="/HighSchoolBid.html">校园招标</a>
        </li>
        <li class="active"  id="ztbfg">
          <a href="/BidNewsList.html">招标资讯</a>
        </li>
         <li class="active"  id="ztjg">
          <a href="/BidCompanyList.html">招标代理公司</a>
        </li>
        <li><a href="/UserCenter/index.aspx" target="_blank" id="pubInfo" runat="server" style="color:#4cae4c" clientidmode="Static">发布招标信息</a></li>
        <%--<li><a href="/ServiceList.html" target="_blank">服务标准</a></li>--%>
      </ul>
    </nav>
  </div>
</div>

<div class="qqcontainer"></div>
<!-- 客服部分 -->
<div style="right:-230px;" class="contactusdiyou">
	<div class="hoverbtn">
		<span>联</span><span>系</span><span>我</span><span>们</span>
		<img class="hoverimg" src="/images/hoverbtnbg.gif" height="9" width="13"/>
	</div>
	<div class="conter">
		<div class="con1"> 
			<dl class="fn_cle">
				<dt><img src="/images/tel.png" height="31" width="31"></dt>
				<dd class="f1">咨询热线：</dd>
				<dd class="f2"><span class="ph_num">183-2157-1921</span></dd>
			</dl>
		</div> 
		<div class="blank0"></div>
		<div class="qqcall"> 
			<dl class="fn_cle">
				<dt><img src="/images/zxkfqq.png" height="31" width="31"></dt>
				<dd class="f1 f_s14">在线客服：</dd>
				<dd class="f2 kefuQQ">
					<span>客服-雨天</span>
					<a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=715794512&site=gobiding.com&menu=yes"></a>
                    <br />
					<span>客服-阳光</span>
					<a target="_blank" href="http://wpa.qq.com/msgrd?v=3&amp;uin=2968038259&amp;site=qq&amp;menu=yes"></a>
                    <br />
					<span>客服-商务</span>
					<a target="_blank" href="http://wpa.qq.com/msgrd?v=3&amp;uin=715794512&amp;site=qq&amp;menu=yes"></a>
				</dd>
			</dl>
			<div class="blank0"></div>           
		</div> 
		<div class="blank0"></div>
		<div class="weixincall"> 
			<dl class="fn_cle">
				<dt><img src="/images/weixin.png" height="31" width="31"/></dt>
				<dd class="f1">官方微信站：</dd>
				<dd class="f3"><img src="/imgs/system/wx300_300.png" height="73" width="73"/></dd>
			</dl>
		</div> 
		<div class="blank0"></div>
		<div class="dytimer" style="padding-left:-20px;">
			<span style="font-weight: bold; ">公司官网：</span>
			<span><a href="http://www.gobiding.com" style="color:White">上海商麓网络科技有限公司</a></span>
			<span><a href="http://www.gobiding.com"  style="color:White">www.gobiding.com</a></span>
		</div>
	</div>
</div>

<script src="/js/wapredirect.js" type="text/javascript"></script>
<script type="text/javascript" src="/js/jquery-1.9.1.js"></script>
<script type="text/javascript">
    $(function () {
        $(".contactusdiyou").hover(function () {
            $('.contactusdiyou').animate({ right: '0' }, 300);
        }, function () {
            $('.contactusdiyou').animate({ right: '-230px' }, 300, function () { });
        });
    });
</script>


</header>
