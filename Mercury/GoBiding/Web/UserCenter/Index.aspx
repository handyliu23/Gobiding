<%@ Page Language="C#" MasterPageFile="~/UserCenter/UserCenterHeader.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="GoBiding.UserCenter.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .divMemberLevel
        {
            width: 110px;
            height: 110px;
            line-height: 110px;
            border-radius: 5px;
            vert-align: middle;
            font-weight: bold;
            text-align: center;
            font-size: 14px;
            color: #FFF;
            float: left;
            margin-right: 30px;
            cursor: pointer;
        }
        .divNavButton
        {
            width: 110px;
            height: 110px;
            line-height: 110px;
            border-radius: 5px;
            vert-align: middle;
            font-weight: bold;
            text-align: center;
            font-size: 14px;
            color: #FFF;
            float: left;
            margin-right: 40px;
            cursor: pointer;
        }
        .divNavButton a{
            color: #FFF;
        }
        .divNavButton:hover
        {
            filter: alpha(opacity=50); /*IE滤镜，透明度50%*/
            -moz-opacity: 0.5; /*Firefox私有，透明度50%*/
            opacity: 0.5; /*其他，透明度50%*/
        }
        .divindextitle
        {
            width: 40%;
            float: left;
            padding-left: 5px;
            border-left: 4px solid #000;
            font-size: 14px;
            font-weight: bold;
        }
    </style>
    <aside class="right-side">
         <!-- Content Header (Page header) -->
         <section class="content-header">
             <h1>用户操作面板
                        <small>通过设置追踪宝，可以针对您的具体需求定制专属的招标信息过滤器，让您更方便快捷的获取最有价值的招投标信息。</small>
                    </h1>
             <ol class="breadcrumb">
                 <li><a href="#"><i class="fa fa-dashboard"></i>首页</a></li>
                 <li class="active">招标追踪器</li>
             </ol>
         </section>

             <!-- Main content -->
         <section class="content">
               <div class="row">
                 <div class="col-xs-12">
                      <div class="box">
                           <div class="box-body table-responsive" style="padding: 20px;">
                               <div style="width:50%; float: left; height: 240px;">
                                   <div class="divindextitle" >会员信息</div><br/><br/>
                                   <div style="height: 40px; line-height: 40px; padding-left: 40px; font-size: 14px;">
                                       <span style="margin-right: 30px;">账户名称</span><asp:Literal runat="server" ID="ltrLoginUserName"></asp:Literal> <br/>
                                       <span style="margin-right: 30px;">用户姓名</span><asp:Literal runat="server" ID="ltrUserName"></asp:Literal>
                                       <span style="margin-left: 100px; margin-right: 30px;">积分数</span><asp:Literal runat="server" ID="ltrScore"></asp:Literal> 
                                       <br/>
                                       <span style="margin-right: 30px;">企业名称</span><asp:Literal runat="server" ID="ltrCompanyName"></asp:Literal>&nbsp;&nbsp;
                                       <a href="/UserCenter/UserCenterPage/CompanyProfile.aspx">完善企业信息</a><br/>
                                       <span style="margin-right: 30px;">账户类型</span><asp:Literal runat="server" ID="ltrUserTypeName"></asp:Literal><br/>
                                       <span style="margin-right: 30px;">会员等级</span><asp:Literal runat="server" ID="ltrUserLevel"></asp:Literal><br/>
                                   </div>
                               </div>
                               <div style="width:40%; float: left; height: 240px;">
                                   <div class="divindextitle" >
                                       服务信息
                                   </div><br/><br/>
                                    <div style="height: 40px; line-height: 40px; padding-left: 40px; font-size: 14px;">
                                       <span style="margin-right: 30px;">注册时间</span><asp:Literal runat="server" ID="ltrRegistTime"></asp:Literal> <br/>
                                       <span style="margin-right: 30px;">上次登录时间</span><asp:Literal runat="server" ID="ltrLastLoginTime"></asp:Literal><br/>
                                       <span style="margin-right: 30px;">上次登录IP</span><asp:Literal runat="server" ID="ltrLastLoginIP"></asp:Literal><br/>
                                       <span style="margin-right: 30px;">购买服务时间</span><asp:Literal runat="server" ID="ltrServiceTime"></asp:Literal><br/>
                                       <span style="margin-right: 30px;">企业认证</span>
                                       <a href="/UserCenter/UserCenterPage/CompanyProfile.aspx"><asp:Literal runat="server" ID="ltrValidation"></asp:Literal></a><br/>
                                   </div>
                               </div>

                           </div><!-- /.box-body -->
                      </div><!-- /.box -->
                 </div>
            </div>
             <div class="row">
                 <div class="col-xs-12">
                      <div class="box">
                                <div class="box-body table-responsive" style="padding: 20px; padding-left: 50px;">
                                     <a href="/UserCenter/UserCenterPage/PublishBid.aspx" style="padding:20px;"><div class="btn btn-primary">
                                       发布招标信息
                                    </div></a>
                                     <a href="/UserCenter/UserCenterPage/PublishWinBid.aspx" style="padding:20px;"><div class="btn btn-success">
                                         发布中标信息
                                    </div></a>
                                     <a href="/UserCenter/UserCenterPage/PublishPurchaseOrder.aspx" style="padding:20px;"><div class="btn btn-success">
                                         发布采购信息
                                    </div></a>
                                    <a href="/UserCenter/UserCenterPage/BidTracker.aspx" style="padding:20px;"><div class="btn btn-success" >
                                         管理追踪器
                                    </div></a>
                                    <a href="/UserCenter/UserCenterPage/BrowseHistoryBids.aspx" style="padding:20px;"><div class="btn btn-success" >
                                         浏览历史记录
                                    </div></a>
                                       <a href="/UserCenter/UserCenterPage/MessageCenter.aspx" style="padding:20px;"><div class="btn btn-success">
                                         系统消息
                                    </div></a>
                                       <a href="/UserCenter/UserCenterPage/Profile.aspx" style="padding:20px;"><div class="btn btn-success">
                                         用户设置
                                    </div></a>
                                </div><!-- /.box-body -->
                            </div><!-- /.box -->
                 </div>
            </div>
                         <div class="row">
                 <div class="col-xs-12">
                      <div class="box">
                                <div class="box-body table-responsive" style="padding: 20px;">
                                    <div class="divMemberLevel" style="background-color: #FFF; color: #333; width: 90%; height: 440px; padding: 30px;">
                                         <div style="float: left; margin-right: 30px;width: 22%;height: 360px; color: #fff;">
                                            <div style=" background-color: skyblue; height: 80px;line-height: 80px;">
                                                普通会员 (免费)
                                            </div>
                                            <div style="padding-top: 10px; line-height: 30px; color: #000; height: 300px; font-weight: normal; background-color: #fafafa;">
                                                招标信息（部分）<br/>
                                                企业采购<br/>
                                                招标代理查询<br/>
                                                去投标追踪宝<br/>
                                                提醒服务（部分）<br/>
                                            </div>
                                            <asp:Button runat="server" ID="Button4" Text="已完成" style="width: 160px; height: 40px; margin-top: -20px; line-height: 40px; border-radius: 4px; background-color: gainsboro; border-style: none;"/><br/>
                                        </div>
                                          <div style="float: left; margin-right: 30px;width: 22%;height: 360px; color: #fff;">
                                            <div style=" background-color: skyblue; height: 80px;line-height: 80px;">
                                                Vip会员 (2800 元/年)
                                            </div>
                                            <div style="padding-top: 10px; line-height: 30px; color: #000; height: 300px; font-weight: normal; background-color: #fafafa;">
                                                招标信息<br/>
                                                企业采购<br/>
                                                招标代理查询<br/>
                                                去投标追踪宝<br/>
                                                提醒服务<br/>
                                                一对一售后服务<br/>
                                            </div>
                                            <asp:Button runat="server" ID="Button1" Text="升级会员" style="color: #FFF; width: 160px; height: 40px; line-height: 40px; margin-top: -20px; border-radius: 4px; background-color: mediumspringgreen; border-style: none;"/><br/>
                                        </div>
                                          <div style="float: left; margin-right: 30px;width: 22%;height: 360px; color: #fff;">
                                            <div style=" background-color: skyblue; height: 80px;line-height: 80px;">
                                                白金Vip会员 (6500 元/年)
                                            </div>
                                            <div style="padding-top: 10px; line-height: 30px; color: #000; height: 300px; font-weight: normal; background-color: #fafafa;">
                                                招标信息<br/>
                                                企业采购<br/>
                                                招标代理查询<br/>
                                                去投标追踪宝<br/>
                                                提醒服务<br/>
                                                一对一售后服务<br/>
                                                企业邮箱<br/>
                                                企业推荐<br/>
                                            </div>
                                            <asp:Button runat="server" ID="Button2" Text="升级会员" style="width: 160px; height: 40px; margin-top: -20px; line-height: 40px; border-radius: 4px; background-color: mediumspringgreen; border-style: none;"/><br/>
                                        </div>
                                       <div style="float: left; margin-right: 30px;width: 22%;height: 360px; color: #fff;">
                                            <div style=" background-color: skyblue; height: 80px;line-height: 80px;">
                                                钻石Vip会员 (12800 元/年)
                                            </div>
                                            <div style="padding-top: 10px; line-height: 30px; color: #000; height: 300px; font-weight: normal; background-color: #fafafa;">
                                                招标信息<br/>
                                                企业采购<br/>
                                                招标代理查询<br/>
                                                去投标追踪宝<br/>
                                                提醒服务<br/>
                                                一对一售后服务<br/>
                                                企业数据库<br/>
                                                企业建站<br/>
                                                唯一推荐<br/>
                                            </div>
                                            <asp:Button runat="server" ID="Button3" Text="升级会员" style="width: 160px; height: 40px; margin-top: -20px; line-height: 40px; border-radius: 4px; background-color: mediumspringgreen; border-style: none;"/><br/>
                                        </div>
                                    </div>
                                </div><!-- /.box-body -->
                            </div><!-- /.box -->
                 </div>
            </div>
         </section>
     </aside>
</asp:Content>
