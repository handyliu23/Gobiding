<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceList.aspx.cs" Inherits="GoBiding.Web.ServiceList" %>

<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
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
        #tableServiceList
        {
            border: 0px;
            border-collapse: collapse;
        }
        #tableServiceList td
        {
            text-align: center;
            padding: 10px;
            border: 1px solid #dcdcdc;
            font-size: 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:Top ID="Top1" runat="server" />
    <div style="background-color: #22252A;">
        <div class="container" style="padding: 0px; height: 44px;">
            <ol class="breadcrumb" style="background-color: #22252A;">
                <li><a href="/Default.html">去投标网</a></li>
                <li class="active"><a href="/BidLaws.html">服务列表</a></li>
            </ol>
        </div>
    </div>
    <br />
    <div class="container">
        <div class="row">
            <table id="tableServiceList" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="3">
                        服务类目
                    </td>
                    <td colspan="4">
                        服务明细
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        会员级别
                    </td>
                    <td style="width: 120px;">
                        普通会员
                    </td>
                    <td style="width: 120px;">
                        VIP会员
                    </td>
                    <td style="width: 120px;">
                        白金VIP会员
                    </td>
                    <td style="width: 120px;">
                        钻石VIP会员
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        收费标准
                    </td>
                    <td>
                        <font style="color: green;">免费</font>
                    </td>
                    <td>
                        <font style="color: orange;">2800元/年</font>
                    </td>
                    <td>
                        <font style="color: orange;">6500元/年</font>
                    </td>
                    <td>
                        <font style="color: orange;">12800元/年</font>
                    </td>
                </tr>
                <tr>
                    <td rowspan="4" style="width: 100px;">
                        招标信息
                    </td>
                    <td style="width: 100px;">
                        招标预告
                    </td>
                    <td style="width: 400px;">
                        公开招标前1个月左右内采购计划预告、邀请报名等准备信息,便于企业提前了解项目招标需求。
                    </td>
                    <td>
                        7天前免费
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td>
                        招标公告
                    </td>
                    <td style="width: 400px;">
                        全国各采购中心、招标代理机构及业主单位委托发布的公开招标信息,内容包含投标要求、业主、招标公司联系人,联系方式,以及购买标书的时间、地点等，每日更新10000条以上。
                    </td>
                    <td>
                        7天前免费
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td>
                        招标变更
                    </td>
                    <td style="width: 400px;">
                        是在发布招标公告后补充公告、变更公告、废标公告、重新招标等信息,使会员单位可以及时获知并有效的对投标工作做出相应方案调整，以免因此导致投标失误。
                    </td>
                    <td>
                        7天前免费
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td>
                        中标结果
                    </td>
                    <td style="width: 400px;">
                        提供中标单位、中标项目、中标金额，部分项目还包含项目联系人及联系方式，为会员提供直接供货渠道。更有利于会员为中标企业在后期分包工作中,做好提前介入工作。
                    </td>
                    <td>
                        7天前免费
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        发布招标信息
                    </td>
                    <td style="width: 400px;">
                        会员单位可随时发布招标、中标、变更、流标等商务信息,所发布的信息除在去投标网展示外,还将被谷歌、百度等各大搜索引擎抓取,以获取更多商机。
                    </td>
                    <td>
                        免费发布3条
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                 <tr>
                    <td colspan="2">
                        发布采购信息
                    </td>
                    <td style="width: 400px;">
                        会员单位可随时发布供应、合作、求购等商务信息,所发布的信息除在去投标网展示外,还将被谷歌、百度等各大搜索引擎抓取,以获取更多商机。
                    </td>
                    <td>
                        免费发布3条
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        企业采购
                    </td>
                    <td style="width: 400px;">
                        企业通过去投标网发布企业采购信息,会员单位可以查看企业的采购商机，直接与买家联系供货。
                    </td>
                    <td>
                        7天前免费
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        招标代理查询
                    </td>
                    <td style="width: 400px;">
                        公开招标前1个月左右内采购计划预告、邀请报名等准备信息,便于企业提前了解项目招标需求。
                    </td>
                    <td>
                        7天前免费
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        去投标追踪宝
                    </td>
                    <td style="width: 400px;">
                        提供自定义定制条件追踪器，会员可以根据追踪器方便的查询，跟踪，订阅指定地区，行业和类型的招投标信息。
                    </td>
                    <td>
                        免费创建1个
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        法律法规
                    </td>
                    <td style="width: 400px;">
                        提供在线法律条文阅读、下载、咨询等服务。
                    </td>
                    <td>
                        7天前免费
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        一对一售后服务
                    </td>
                    <td style="width: 400px;">
                        去投标网将设置客服经理通过一对一的服务模式。在服务期间内为会员单位提供全方位立体式的服务,及时解决会员单位在使用过程中遇到的问题和困难。
                    </td>
                    <td>
                        7天前免费
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td rowspan="5">
                        提醒服务
                    </td>
                    <td>
                        邮件提醒
                    </td>
                    <td style="width: 400px;">
                        根据用户订阅的信息类型，每天自动推送符合条件的招标采购信息通过邮件的方式进行提醒，会员可以第一时间知道市场信息动态。
                    </td>
                    <td>
                        每天1封
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td>
                        短信提醒
                    </td>
                    <td style="width: 400px;">
                        根据用户订阅的信息类型，每天自动推送符合条件的招标采购信息通过短信的方式进行提醒，会员可以第一时间知道市场信息动态。
                    </td>
                    <td>
                        每天1条
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td>
                        App提醒
                    </td>
                    <td style="width: 400px;">
                        根据用户订阅的信息类型，每天自动推送符合条件的招标采购信息通过App消息的方式进行提醒，会员可以第一时间知道市场信息动态。
                    </td>
                    <td>
                        每天1条
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td>
                        微信提醒
                    </td>
                    <td style="width: 400px;">
                        根据用户订阅的信息类型，每天自动推送符合条件的招标采购信息通过微信消息的方式进行提醒，会员可以第一时间知道市场信息动态。
                    </td>
                    <td>
                        每天1条
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td>
                        电话提醒
                    </td>
                    <td style="width: 400px;">
                        根据用户订阅的信息类型，工作人员会不定期推荐符合条件的招标采购信息通过电话回访的方式进行提醒，会员可以第一时间知道市场信息动态。
                    </td>
                    <td>
                        无
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        行业报告
                    </td>
                    <td style="width: 400px;">
                        根据用户订阅的信息类型，工作人员会不定期推荐符合条件的招标采购信息通过电话回访的方式进行提醒，会员可以第一时间知道市场信息动态。
                    </td>
                    <td>
                        无
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        企业邮箱
                    </td>
                    <td style="width: 400px;">
                        根据用户订阅的信息类型，工作人员会不定期推荐符合条件的招标采购信息通过电话回访的方式进行提醒，会员可以第一时间知道市场信息动态。
                    </td>
                    <td>
                        无
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        企业建站
                    </td>
                    <td style="width: 400px;">
                        采招网为还未有网站的会员单位提供模板建站帮助，提供涵盖：公司简介、产品介绍、企业荣誉、业绩展示、联系我们等5个功能版块的网站设计和制作的技术支持服务。
                    </td>
                    <td>
                        无
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        唯一推荐给业主
                    </td>
                    <td style="width: 400px;">
                        对委托采招推荐供应商的项目,采招网根据会员单位业务范围、企业实力、项目需求,向业主推荐唯一供应商会员参与竞标,已推荐项目不再向其他会员提供,仅被推荐会员单位独享。
                    </td>
                    <td>
                        无
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        竞争对手监控
                    </td>
                    <td style="width: 400px;">
                        竞争对手每当产生新的动态，系统立刻做出相应提示，帮助会员单位及时掌握竞争对手投标动态、销售区域变动情况，获取一手资料并及时调整。
                    </td>
                    <td>
                        无
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        首页商家推荐
                    </td>
                    <td style="width: 400px;">
                        依据注册会员认证信息、中标情况以及业主反馈信息对会员进行综合评分,按照分数累计,对资信和实力比较好的会员单位在首页以榜单的形式进行展示。
                    </td>
                    <td>
                        无
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        √
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        移动客户端
                    </td>
                    <td style="width: 400px;">
                        根据用户订阅的信息类型，工作人员会不定期推荐符合条件的招标采购信息通过电话回访的方式进行提醒，会员可以第一时间知道市场信息动态。
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                    <td>
                        √
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
