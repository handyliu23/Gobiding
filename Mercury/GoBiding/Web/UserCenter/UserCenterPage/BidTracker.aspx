<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UserCenterHeader.Master"
    AutoEventWireup="true" CodeBehind="BidTracker.aspx.cs" Inherits="GoBiding.UserCenter.UserCenterPage.BidTracker" %>

<%@ Import Namespace="GoBiding.BLL" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .row
        {
            height: 50px;
            color: #666;
        }
        .checkbox_tracker_areas label
        {
            width: 90px;
        }
        .checkbox_tracker_areas label
        {
            font-weight: normal;
        }
        
        .tracker_content_provinces
        {
            min-height: 370px;
            padding: 10px;
        }
        .usertrackerdiv
        {
            cursor: pointer;
            padding: 5px;
            margin-left: 20px;
        }
        .choosedtrackerdiv
        {
            border: 2px solid tomato;
            border-radius: 4px;
            height: 100px;
            padding: 0px;
        }
        .createNewTrackerDiv
        {
            cursor: pointer;
            background-color: orange;
            margin-top: 5px;
            height: 95px;
            color: #fff;
            line-height: 95px;
            font-size: 16px;
            text-align: center;
            font-weight: bold;
        }
        .small-box-footer a
        {
            color: #fff;
        }
    </style>
    <asp:HiddenField runat="server" ID="hdnCategorys" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hdnTrackerId" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hdnCitys" ClientIDMode="Static" />
    <!-- Right side column. Contains the navbar and content of the page -->
    <aside class="right-side">
         <!-- Content Header (Page header) -->
         <section class="content-header">
             <h1>定制追踪宝
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
                 <div class="col-md-12" >
                    <asp:Repeater runat="server" ID="rptTrackerList">
                          <ItemTemplate>
   <div class="col-md-3" >
                                        <input type="hidden" value='<%# Eval("UserTrackerId")%>' id="hdntracker"/>
                                        <div class="small-box bg-light-blue" style="margin-bottom: 0px;">
                                        <div class="inner">
                                                <span style="font-weight: bold; color: #fff;">追踪器：<%#Eval("TrackerName")%></span>
                                            <p style="font-size: 10px;padding: 10px;">
                                            </p>
                                        </div>
                                        <div class="small-box-footer">
                                             <a href="/UserCenter/UserCenterPage/BidTracker.aspx?tId=<%# Eval("UserTrackerId") %>" >
                                            查看 <i class="fa fa-arrow-circle-right"></i>
                                             <a href="/UserCenter/UserCenterPage/BidTracker.aspx?option=edit&tId=<%# Eval("UserTrackerId") %>" >
                                            编辑 <i class="fa fa-arrow-circle-right"></i>
                                            </a> <a href="/UserCenter/UserCenterPage/BidTracker.aspx?option=delete&tId=<%# Eval("UserTrackerId") %>" >
                                            删除 <i class="fa fa-arrow-circle-right"></i>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                          </ItemTemplate>
                      </asp:Repeater>
                  </div>
                 <div class="col-md-12" runat="server" clientidmode="Static" id="divCreateOrEditTracker"　style="margin-top: 20px;">
                       <div class="box box-danger">
                            <div class="box-header">
                                      <h3 class="box-title" id="titleAddOrSave" runat="server" clientidmode="Static"></h3>
                                  </div>
                            <div class="box-body tracker_content_provinces">
                                 <div class="row">
                                    <div class="col-xs-2">输入过滤器名称</div>
                                    <div class="col-xs-4">
                                        <input type="text" id="txtTrackerName" runat="server" clientidmode="Static" class="form-control" placeholder="过滤器名称" />
                                          </div>
                                 </div>
                                 <div class="row">
                                          <div class="col-xs-2">
                                            输入不超过5个关键词
                                          </div>
                                          <div class="col-xs-8" style="padding: 0px;">
                                          <div class="col-xs-2">
                                              <input type="text" id="txtKeyword1" runat="server" clientidmode="Static" class="form-control" placeholder="关键词1" />
                                          </div>
                                          <div class="col-xs-2">
                                              <input type="text" id="txtKeyword2" runat="server" clientidmode="Static" class="form-control" placeholder="关键词2"/>
                                          </div>
                                          <div class="col-xs-2">
                                              <input type="text" id="txtKeyword3" runat="server" clientidmode="Static" class="form-control" placeholder="关键词3"/>
                                          </div>
                                              <div class="col-xs-2">
                                              <input type="text" id="txtKeyword4" runat="server" clientidmode="Static" class="form-control" placeholder="关键词4"/>
                                          </div>
                                              <div class="col-xs-2">
                                              <input type="text" id="txtKeyword5" runat="server" clientidmode="Static" class="form-control" placeholder="关键词5"/>
                                          </div>
                                          </div>
                                      </div>
                                 <div class="row">
                                       <div class="col-xs-2" >
                                           选择需要跟踪的行业
                                          </div>
                                       <div class="col-xs-10">
                                            <table class="checkbox_tracker_areas">
<%--                                               <tr>
                                                   <td colspan="8" >
                                                   <label class="checkbox_tracker_allitem"><input type="checkbox" value="1"/> 全部行业</label>  
                                                   </td>
                                               </tr>--%>
                                            <tr>
                                                <td>
                                                    <label><input type="checkbox" runat="server" clientidmode="Static" value="0" class="checkbox_tracker_item"/>全部</label>  
                                                    <label><input type="checkbox" runat="server" clientidmode="Static" value="1" class="checkbox_tracker_item"/> 建筑工程</label>  
                                                    <label><input type="checkbox" runat="server" clientidmode="Static" value="7" class="checkbox_tracker_item"/> 仪器设备</label>  
                                                    <label><input type="checkbox" runat="server" clientidmode="Static" value="14" class="checkbox_tracker_item"/> 办公文教</label>  
                                                    <label><input type="checkbox" runat="server" clientidmode="Static" value="18" class="checkbox_tracker_item"/> 医疗卫生</label>  
                                                    <label><input type="checkbox" runat="server" clientidmode="Static" value="21" class="checkbox_tracker_item"/> 环保绿化</label>  
                                                    <label><input type="checkbox" runat="server" clientidmode="Static" value="26" class="checkbox_tracker_item"/> 机械设备</label>  
                                                    <label><input type="checkbox" runat="server" clientidmode="Static" value="31" class="checkbox_tracker_item"/> 服务行业</label>  
                                                    <label><input type="checkbox" runat="server" clientidmode="Static" value="38" class="checkbox_tracker_item"/> 日常生活</label>  
                                                </td>
                                            </tr>
                                            </table>
                                       </div>
                                 </div>
                                 <div class="row">
                                          <div class="col-xs-2">
                                            选择需要跟踪的地区
                                          </div>
                                          <div class="col-xs-10">
                                          <table class="checkbox_tracker_areas">
                                          <tr>
                                          <td><label><input type="checkbox" value="0" class="checkbox_tracker_area"/>全国</label>  
                                          </td></tr>
                                            <tr>
                                                <td>
                                                    <label><input type="checkbox" value="9" class="checkbox_tracker_area"/>上海</label>  
                                                    <label><input type="checkbox" value="10" class="checkbox_tracker_area"/>江苏</label>  
                                                    <label><input type="checkbox" value="11" class="checkbox_tracker_area"/>浙江</label>  
                                                    <label><input type="checkbox" value="12" class="checkbox_tracker_area"/>安徽</label>  
                                                    <label><input type="checkbox" value="13" class="checkbox_tracker_area"/>福建</label>  
                                                    <label><input type="checkbox" value="14" class="checkbox_tracker_area"/>江西</label>  
                                                    <label><input type="checkbox" value="15" class="checkbox_tracker_area"/>山东</label>  
                                                    <label><input type="checkbox" value="31" class="checkbox_tracker_area"/>新疆</label>  
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                             <label><input type="checkbox" value="1" class="checkbox_tracker_area"/>北京</label>  
                                             <label><input type="checkbox" value="3" class="checkbox_tracker_area"/>河北</label>  
                                             <label><input type="checkbox" value="4" class="checkbox_tracker_area"/>山西</label>  
                                             <label><input type="checkbox" value="5" class="checkbox_tracker_area"/>内蒙</label>  
                                             <label><input type="checkbox" value="8" class="checkbox_tracker_area"/>黑龙江</label>  
                                             <label><input type="checkbox" value="7" class="checkbox_tracker_area"/>吉林</label> 
                                             <label><input type="checkbox" value="6" class="checkbox_tracker_area"/>辽宁</label> 
                                              <label><input type="checkbox" value="25" class="checkbox_tracker_area"/>云南</label>  
                                                </td>
                                            </tr>
                                              <tr>
                                                <td>
                                             <label><input type="checkbox" value="22" class="checkbox_tracker_area"/>重庆</label> 
                                             <label><input type="checkbox" value="19" class="checkbox_tracker_area"/>广东</label>  
                                             <label><input type="checkbox" value="20" class="checkbox_tracker_area"/>广西</label>  
                                             <label><input type="checkbox" value="21" class="checkbox_tracker_area"/>海南</label>  
                                             <label><input type="checkbox" value="27" class="checkbox_tracker_area"/>陕西</label>  
                                             <label><input type="checkbox" value="29" class="checkbox_tracker_area"/>青海</label>  
                                             <label><input type="checkbox" value="30" class="checkbox_tracker_area"/>宁夏</label>  
                                             <label><input type="checkbox" value="23" class="checkbox_tracker_area"/>四川</label> 
                                                    </td>
                                                </tr>
                                              <tr>
                                                    <td>
                                             <label><input type="checkbox" value="2" class="checkbox_tracker_area"/>天津</label>  
                                             <label><input type="checkbox" value="26" class="checkbox_tracker_area"/>西藏</label>  
                                             <label><input type="checkbox" value="16" class="checkbox_tracker_area"/>河南</label>  
                                             <label><input type="checkbox" value="17" class="checkbox_tracker_area"/>湖北</label>  
                                             <label><input type="checkbox" value="18" class="checkbox_tracker_area"/>湖南</label>  
                                             <label><input type="checkbox" value="28" class="checkbox_tracker_area"/>甘肃</label> 
                                             <label><input type="checkbox" value="24" class="checkbox_tracker_area"/>贵州</label> 
                                        </td>
                                    </tr>
                                </table>
                                          </div>
                                  </div>
                                  <div class="row" style="text-align: center;">
                                      <div class="col-xs-12" style=" margin-top: 20px;">
                                        <a class="btn btn-warning" id="btnCreateTracker"><i class="fa fa-bug"></i><span runat="server" id="btnAddOrSave" clientidmode="Static">创建追踪器</span></a>
                                      </div>
                                  </div>
                            </div>
                       </div>
                   </div>
                 <br/>
                 <br/>
                 <div class="col-md-12">
                 <div class="box-body table-responsive no-padding" style="background-color: #fff; margin-top: 20px;">
                      <div class="col-md-12" style="color: #666; line-height: 30px;height: 30px; font-size: 12px; " runat="server" id="divTrackerBidList">
                         追踪器<font style="color: green;"><asp:Literal runat="server" ID="ltrTrackerName"></asp:Literal></font>共查询到 <font style="color: red;"> <asp:Literal runat="server" ID="ltrTotalCount"></asp:Literal> </font>条记录
                     </div>
                 <br/>
                        <table class="table table-hover">
                            <asp:Repeater runat="server" ID="rptBidList">
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 90px; vert-align: middle; line-height: 35px;">
                                            <%#DateTime.Parse(Eval("BidPublishTime").ToString()).ToShortDateString()%>
                                        </td>
                                        <td style="min-width: 700px; line-height: 35px;">
                                            <a href='/BidDetail.aspx?bId=<%#Eval("BidId")%>' target="_blank" style="font-size: 14px; text-decoration: none;
                                                color: #333;">
                                                <%#Eval("BidTitle").ToString().Length > 45 ? Eval("BidTitle").ToString().Substring(0, 45) + "...": Eval("BidTitle").ToString() %></a><br />
                                        </td>
                                        <td style="line-height: 35px;"><%# GoBiding.BLL.CommonUtility.GetBidTypeValue(Eval("BidType").ToString())%></td>
                                        <td style="line-height: 35px;"><%# CommonUtility.GetProvinceName(Eval("ProvinceId").ToString())%></td>
                                        <td style="line-height: 35px;"><%# Eval("BidCompanyName").ToString().Length > 10 ? Eval("BidCompanyName").ToString().Substring(0, 10) +"...": Eval("BidCompanyName").ToString()%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <div class="pull-right">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Width="100%" UrlPaging="true"
                                CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList"
                                PagingButtonSpacing="0" CurrentPageButtonClass="active" PageSize="10" OnPageChanged="AspNetPager1_PageChanged">
                            </webdiyer:AspNetPager>
                        </div>
                    </div>
                 </div>
             </div>
         </section>
     </aside>
    <!-- /.right-side -->
    <script type="text/javascript">
        jQuery(document).ready(function () {

            $(".usertrackerdiv").click(function () {
                var tId = $(this).find("input").val();
                location.href = '/UserCenter/UserCenterPage/BidTracker.aspx?tId=' + tId;
            });

            $(".usertrackerdiv").find("input[value='" + $("#hdnTrackerId").val() + "']").parent().addClass("choosedtrackerdiv");

            var words = $("#hdnCategorys").val().split(',');
            for (var i = 0; i < words.length; i++) {
                $(".checkbox_tracker_item[value='" + words[i] + "']").attr("checked", true);
            }

            var citys = $("#hdnCitys").val().split(',');
            for (var i = 0; i < citys.length; i++) {
                $(".checkbox_tracker_area[value='" + citys[i] + "']").attr("checked", true);
            }

            $(".createNewTrackerDiv").click(function () {
                location.href = "/UserCenter/UserCenterPage/BidTracker.aspx?option=add";
            });

            $("#btnCreateTracker").click(function () {
                if ($("#txtTrackerName").val() == "") {
                    alert('请输入追踪器名称');
                    return;
                }

                var industryIds = "";
                $(".checkbox_tracker_item:checked").each(function () {
                    if ($(this).val() == "0") {
                        industryIds = "0";
                        return false;
                    }
                    industryIds += $(this).val() + ",";
                });
                if (industryIds == "") {
                    alert('请选择行业范围');
                    return;
                }

                var areaIds = "";
                $(".checkbox_tracker_area:checked").each(function () {
                    if ($(this).val() == "0") {
                        areaIds = "0";
                        return false;
                    }
                    areaIds += $(this).val() + ",";
                });
                if (areaIds == "") {
                    alert('请选择地区范围');
                    return;
                }

                var trackerId = $("#hdnTrackerId").val();
                $.ajax({
                    type: "post",
                    url: "CreateTracker.ashx",
                    data: {
                        IndustryIdList: industryIds,
                        TrackerName: $("#txtTrackerName").val(),
                        Keyword1: $("#txtKeyword1").val(),
                        Keyword2: $("#txtKeyword2").val(),
                        Keyword3: $("#txtKeyword3").val(),
                        Keyword4: $("#txtKeyword4").val(),
                        Keyword5: $("#txtKeyword5").val(),
                        TrackerAreaIdList: areaIds,
                        TrackerId: trackerId
                    },
                    success: function (data) {
                        window.location = "/UserCenter/UserCenterPage/BidTracker.aspx";
                    },
                    error: function (msg) {
                        //alert(msg.responseText);
                    }

                });

                return;
            });
        });
    </script>
</asp:Content>
