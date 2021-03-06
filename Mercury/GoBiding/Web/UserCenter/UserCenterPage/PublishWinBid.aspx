﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UserCenterHeader.master"
    AutoEventWireup="true" CodeBehind="PublishWinBid.aspx.cs" Inherits="GoBiding.Web.UserCenter.UserCenterPage.PublishWinBid" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/css/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
    <style>
        .bidtitle
        {
            color: #333;
            border-left: 4px solid orange;
            margin-left: 10px;
            padding-left: 10px;
            line-height: 30px;
            font-weight: 700;
        }
        .col-xs-2
        {
            text-align: right;
        }
    </style>
    <aside class="right-side">                
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>
                发布中标信息
                <small>为了让供应商更好的理解招标内容提高招标成功率，请尽量填写详细招标信息!</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i> 首页</a></li>
                <li><a href="#">招标信息</a></li>
                <li class="active">发布中标信息</li>
            </ol>
        </section>
        <section class="content">
            <div class="row" id="rowNoAuthority" runat="server" style="padding-left:15px;" clientidmode="Static">
                <a href="/UserCenter/UserCenterPage/CompanyProfile.aspx" id="btnNoAuthority" class="btn btn-danger">! 您未通过企业认证，提交企业认证信息后可以发布招标信息</a>
            <br />
            </div>
            <div class="row">
                  <div class="col-md-12">
                       <div class="box box-danger">
                            <div class="box-body tracker_content_provinces">
                                 <div class="row">
                                    <div class="col-xs-2"><span class="bidtitle">公告标题</span> </div>
                                    <div class="col-xs-6">
                                          <div class="input-group" style="width: 100%;">
                                              <input type="text" class="form-control"  id="txtBidTitle" placeholder="请输入招标公告标题,例 北京XX大学XXXX管理系统采购项目,发布成功后不可修改" />
                                        </div>
                                    </div>
                                 </div>
                                 <br/>
                                  <div class="row">
                                      <div class="col-xs-2"><span class="bidtitle">行业分类</span></div>
                                          <div class="col-xs-2">
                                         <div class="form-group" style="width: 160px;">
                                            <select class="form-control" id="selectIndustry" >
                                                <option value="0">-请选择招标行业-</option>
                                                <option value="1">建筑工程</option>
                                                <option value="7">仪器设备</option>
                                                <option value="14">办公文教</option>
                                                <option value="18">医疗卫生</option>
                                                <option value="21">环保绿化</option>
                                                <option value="26">机械设备</option>
                                                <option value="31">商业服务</option>
                                                <option value="38">日常生活</option>
                                            </select>
                                        </div>
                                    </div>
                                 </div>
                                  <div class="row">
                                  <div class="col-xs-2"><span class="bidtitle">所在地区</span></div>
                                    <div class="col-xs-2">
                                         <div class="form-group" style="width: 160px;">
                                            <select class="form-control" id="selectArea">
                                                <option>-请选择所在地区-</option>
                                                <asp:Repeater runat="server" ID="rptBidAreas">
                                                    <ItemTemplate>
                                                        <option value="<%#Eval("ProvinceId") %>"><%#Eval("ProvinceName") %></option>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                           <div class="form-group" style="width: 160px; margin-left: -30px;">
                                                  <select class="form-control" id="selectCity">
                                                    <option>-请选择所在市-</option>
                                                  </select>
                                            </div>
                                          
                                    </div>
                                 </div>
                                  <div class="row">
                                    <div class="col-xs-2"><span class="bidtitle">项目编号</span> </div>
                                    <div class="col-xs-3">
                                        <input type="text" id="txtBidNumber" class="form-control" placeholder="请输入项目编号，例 CEIECZB01-XXXX284" />
                                          </div>
                                 </div>
                                 <br/>
                                  <div class="row">
                                    <div class="col-xs-2"><span class="bidtitle">中标单位</span></div>
                                    <div class="col-xs-3">
                                        <input type="text" id="txtCompanyName" class="form-control" placeholder="请输入招标单位"/>
                                   </div>
                                 </div>
                                 <br/>
                                  <div class="row">
                                    <div class="col-xs-2"><span class="bidtitle">招标内容</span></div>
                                    <div class="col-xs-8">
                                        <CKEditor:CKEditorControl ClientIDMode="Static" runat="server" ID="content" name="content" Width="100%" Height="500" ></CKEditor:CKEditorControl>
                                    </div>
                                 </div>
                                 <br/>
                                  <div class="row" style="text-align: center;">
                                    <div class="col-xs-2"></div>
                                    <div class="col-xs-8">
                                    <button type="button" class="btn btn-primary" id="btnSend" >
                                        <span class="glyphicon glyphicon-ok"></span><font style="font-weight: 700; font-size: 14px;">
                                            立即发布招标信息 </font>
                                    </button></div>
                                  </div>
                            </div>
                       </div>
                    </div>
             </div>
        </section>
    </aside>
    <asp:HiddenField runat="server" ID="IsCompanyAudited" ClientIDMode="Static" />

    <script type="text/javascript" src="/js/bootstrap-datetimepicker.js" charset="UTF-8"></script>
    <script type="text/javascript" src="/js/locales/bootstrap-datetimepicker.zh-CN.js"
        charset="UTF-8"></script>
    <script type="text/javascript">
        $('.form_date').datetimepicker({
            language: 'zh-CN',
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 2,
            minView: 2,
            forceParse: 0
        });
        $(document).ready(function () {
            if ($("#IsCompanyAudited").val() == "false") {
                $("#divContent").css({
                    "position": "absolute",
                    "display": "block",
                    "background-color": "gray",
                    "z-index": "1000",
                    "opacity": "0.5"
                });

                $("#btnSend").attr("disabled", true);

                $("#rowNoAuthority").show();
            } else {
                $("#rowNoAuthority").hide();
            }

            $("#selectArea").change(function () {
                $.ajax({
                    type: "post",
                    url: "GetCityList.ashx",
                    data: {
                        ProvinceId: $("#selectArea").val()
                    },
                    dataType: "json",
                    success: function (data) {
                        var citys = "";
                        for (var p in data) { //for循环直接遍历数据
                            citys += "<option value='" + data[p].CityID + "'>" + data[p].CityName + "</option>";
                        }
                        $("#selectCity").html(citys);
                    },
                    error: function (msg) {
                        //alert(msg.responseText);
                    }
                });
            });
            $("#btnSend").click(function () {
                var BidNumber = $("#txtBidNumber").val();
                var BidContent = CKEDITOR.instances.content.getData();
                var CategoryId = $("#selectIndustry").val();
                var ProvinceId = $("#selectArea").val();
                var CityId = $("#selectCity").val();
                var BidTitle = $("#txtBidTitle").val();
                var CompanyName = $("#txtCompanyName").val();

                if (BidTitle == "") {
                    alert('请输入公告标题');
                    return;
                }
                if (CategoryId == "0") {
                    alert('请选择行业分类');
                    return;
                }
                if (ProvinceId == "0") {
                    alert('请选择所在地区');
                    return;
                }
                if (CompanyName == "") {
                    alert('请输入招标单位');
                    return;
                }
                if (BidContent == "" || BidContent.length < 20) {
                    alert('请输入招标内容，不得少于20个字符');
                    return;
                }

                $.ajax({
                    type: "post",
                    url: "CreateWinBid.ashx",
                    data: {
                        BidNumber: BidNumber,
                        BidContent: BidContent,
                        CategoryId: CategoryId,
                        ProvinceId: ProvinceId,
                        BidTitle: BidTitle,
                        cityId: CityId,
                        CompanyName: CompanyName
                    },
                    success: function (data) {
                        alert('发布成功！');
                        window.location.href = "PublishedBids.aspx";
                    },
                    error: function (msg) {
                        alert(msg.responseText);
                    }
                });
            });
        });
    </script>
</asp:Content>
