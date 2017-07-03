<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UserCenterHeader.master"
    AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="GoBiding.Web.UserCenter.UserCenterPage.Admin.UserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <aside class="right-side">                
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>
                已发布的采购信息
                <small>显示一年内您发布过的采购信息</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i> 首页</a></li>
                <li><a href="#">采购信息</a></li>
                <li class="active">已发布的采购信息</li>
            </ol>
        </section>
        <section class="content">
            <div class="row">
                 <div class="col-xs-12">
                      <div class="box">
                            <div runat="server" id="mainContent">
                            
                            </div>
                       </div><!-- /.box -->
                 </div>
            </div>
        </section>

        </aside>
</asp:Content>
