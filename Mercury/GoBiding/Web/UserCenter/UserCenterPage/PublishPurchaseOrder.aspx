<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UserCenterHeader.master"
    AutoEventWireup="true" CodeBehind="PublishPurchaseOrder.aspx.cs" Inherits="GoBiding.Web.UserCenter.UserCenterPage.PublishPurchaseOrder" %>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <aside class="right-side">                
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>
                发布新的采购商信息
                <small>为了让供应商更好的理解采购内容，提高采购的成功率，请尽量填写详细采购信息!</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i> 首页</a></li>
                <li><a href="#">采购信息</a></li>
                <li class="active">发布新的采购信息</li>
            </ol>
        </section>
        <section class="content">
            <div class="row">
                        <div class="row" id="rowNoAuthority" runat="server" style="padding-left:15px; visibility:hidden;" clientidmode="Static">
                <a href="/UserCenter/UserCenterPage/CompanyProfile.aspx" id="btnNoAuthority" class="btn btn-danger">! 您未通过企业认证，提交企业认证信息后可以发布招标信息</a>
            <br />
            </div>
                  <div class="col-md-12">
                       <div class="box box-danger">
                            <div class="box-body tracker_content_provinces">
                                 <div class="row">
                                    <div class="col-xs-2">
                                        <span class="bidtitle">采购标题</span>
                                    </div>
                                    <div class="col-xs-6">
                                          <div class="input-group" style="width: 90%;">
                                              <input type="text" runat="server" clientidmode="Static" class="form-control" id="txtBidTitle" placeholder="请输入采购标题,例 北京XX大学XXXX管理系统采购,发布成功可修改"/>
                                        </div>
                                    </div>
                                 </div>
                                 <br/>
                                  <div class="row">
                                  <div class="col-xs-2"><span class="bidtitle">行业分类</span></div>
                                     <div class="col-xs-10" >
                                       <asp:DropDownList runat="server" Height="32" Width="150" ClientIDMode="Static" ID="selectIndustry">
                                           <asp:ListItem Text="请选择采购行业" Value="0"/>
                                           <asp:ListItem Text="建筑工程" Value="1"/>
                                           <asp:ListItem Text="仪器设备" Value="7"/>
                                           <asp:ListItem Text="办公文教" Value="14"/>
                                           <asp:ListItem Text="医疗卫生" Value="18"/>
                                           <asp:ListItem Text="环保绿化" Value="21"/>
                                           <asp:ListItem Text="机械设备" Value="26"/>
                                           <asp:ListItem Text="商业服务" Value="31"/>
                                           <asp:ListItem Text="日常生活" Value="38"/>
                                       </asp:DropDownList>
                                    </div>
                                 </div>
                                 <br/>
                                  <div class="row">
                                  <div class="col-xs-2"><span class="bidtitle">所在地区</span></div>
                                    <div class="col-xs-10" >
                                             <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                            <asp:DropDownList ID="ddlProvince" ClientIDMode="Static" Width="120" Height="32" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged">
                                            </asp:DropDownList>&nbsp;&nbsp;
                                            <asp:DropDownList ID="ddlCity" Width="120" ClientIDMode="Static" runat="server" AutoPostBack="True" Height="32"
                                             OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                 </div>
                                <br/>
                                    <div class="row">
                                        <div class="col-xs-2"><span class="bidtitle">截至日期</span></div>
                                  	    <div class="col-xs-2">
                                            <div class="input-group col-md-12" data-date-format="yyyy-mm-dd" data-link-field="dtp_input2" data-link-format="yyyy-mm-dd">
                                                <input class="form-control date form_date" runat="server" id="txtExpiretime" clientidmode="Static" data-date-format="yyyy-mm-dd"  size="16" type="text" value="" readonly/>
					                            <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                            </div>  
				                            <input type="hidden" id="dtp_input2" value="" /><br/>
                                        </div>  
                                    </div>
                                  <div class="row">
                                    <div class="col-xs-2"><span class="bidtitle">采购单位</span></div>
                                    <div class="col-xs-3">
                                        <input type="text" id="txtCompanyName" clientidmode="Static" runat="server" class="form-control" placeholder="请输入采购单位"/>
                                   </div>
                                       <div class="col-xs-2" style="margin-top:8px; text-align:left; ">
                                        <span id="chkPerson" style="border:1px solid #dcdcdc; padding:8px 10px 8px 10px;">
                                            个人采购
                                        </span>
                                   </div>
                                 </div>
                                 <br/>
                                  <div class="row">
                                    <div class="col-xs-2"><span class="bidtitle">联 系 人</span></div>
                                    <div class="col-xs-3">
                                        <input type="text" id="txtContacter" clientidmode="Static" runat="server" class="form-control" placeholder="请输入采购联系人"/>
                                   </div>
                                 </div>
                                    <br/>
                                  <div class="row">
                                    <div class="col-xs-2"><span class="bidtitle">联系电话</span></div>
                                    <div class="col-xs-2">
                                        <input type="text" id="txtContacterMobile" clientidmode="Static" runat="server" class="form-control" placeholder="请输入手机号"/>
                                   </div>
                                    <div class="col-xs-2">
                                        <input type="text" id="txtContacterTel" runat="server" clientidmode="Static" class="form-control" placeholder="请输入联系电话 010-0000000"/>
                                   </div>
                                 </div>
                                  <br/>
                                  <div class="row">
                                    <div class="col-xs-2"><span class="bidtitle">邮箱地址</span></div>
                                    <div class="col-xs-3">
                                        <input type="text" id="txtEmail" runat="server" clientidmode="Static" class="form-control" placeholder="请输入邮箱地址"/>
                                   </div>
                                 </div>
                                  <br/>
                                  <div class="row">
                                    <div class="col-xs-2"><span class="bidtitle">采购内容</span></div>
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
                                            立即发布采购信息 </font>
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
         $("#chkPerson").click(function(){
             $("#txtCompanyName").val("个人");
         });

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
                var BidContacter = $("#txtContacter").val();
                var BidContent = CKEDITOR.instances.content.getData();
                var CategoryId = $("#selectIndustry").val();
                var BidContacterMobile = $("#txtContacterMobile").val();
                var BidContacterTel = $("#txtContacterTel").val();
                var ProvinceId = $("#ddlProvince").val();
                var CityId = $("#ddlCity").val();
                var BidContacterAddress = $("#txtEmail").val();
                var BidTitle = $("#txtBidTitle").val();
                var ExpireTime = $(".form_date").val();
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
                if (BidContacter == "") {
                    alert('请输入联系人');
                    return;
                }
                if (CompanyName == "") {
                    alert('请输入采购单位');
                    return;
                }
                if (BidContent == "" || BidContent.length < 20) {
                    alert('请输入采购内容，不得少于20个字符');
                    return;
                }

                $.ajax({
                    type: "post",
                    url: "CreatePurchaseOrder.ashx",
                    data: {
                        POId: <%= poId %>,
                        BidContacter: BidContacter,
                        BidContent: BidContent,
                        CategoryId: CategoryId,
                        BidContacterMobile: BidContacterMobile,
                        BidContacterTel: BidContacterTel,
                        ProvinceId: ProvinceId,
                        BidContacterAddress: BidContacterAddress,
                        BidTitle: BidTitle,
                        ExpireTime: ExpireTime,
                        cityId: CityId,
                        CompanyName: CompanyName
                    },
                    success: function (data) {
                        alert('发布成功！');
                        window.location.href = "PurchaseOrderList.aspx";
                    },
                    error: function (msg) {
                        //alert(msg.responseText);
                    }
                });
            });

        });
    </script>
</asp:Content>
