<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UserCenterHeader.master"
    AutoEventWireup="true" CodeBehind="CompanyProfile.aspx.cs" Inherits="GoBiding.Web.UserCenter.UserCenterPage.CompanyProfile" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/css/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
    <style>
        .bidtitle
        {
            color: #333;
            margin-left: 5px;
            padding: 5px;
            font-weight: 700;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <aside class="right-side">                
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>
                企业设置
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i> 首页</a></li>
                <li><a href="#">用户设置</a></li>
                <li class="active">企业设置</li>
            </ol>
        </section>
        <section class="content">
            <div class="row">
                  <div class="col-md-6">
                       <div class="box box-primary">
                            <div class="box-header">
                                      <h3 class="box-title">基本信息</h3>
                                  </div>
                            <div class="box-body tracker_content_provinces">
                                 <div class="row">
                                    <div class="col-xs-3" style="text-align: right;">
                                        <span class="bidtitle glyphicon" >公司名称</span>
                                    </div>
                                    <div class="col-xs-6">
                                          <div class="input-group" style="width: 100%;">
                                              <input type="text" class="form-control" runat="server" ClientIDMode="Static" id="txtCompanyName" placeholder="请输入公司名称"/>
                                        </div>
                                    </div>
                                 </div>
                                 <br/>
                                  <div class="row">
                                    <div class="col-xs-3" style="text-align: right;"><span class="bidtitle glyphicon"> 企业类型</span></div>
                                    <div class="col-xs-6">
                                        <asp:DropDownList runat="server" ID="ddlCompanyTypes" class="form-control" Width="160">
                                            <asp:ListItem Text="中外合资企业" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="政府机构" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="个体经营" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="有限责任公司" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="外资企业" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="股份有限公司" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="事业单位或社会团体" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="国有企业" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="国内上市公司" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="港、澳、台商独资经营企业" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="非盈利组织" Value="11"></asp:ListItem>
                                        </asp:DropDownList>
                                   </div>
                                 </div>
                                  <br/>
                                   <div class="row">
                                    <div class="col-xs-3" style="text-align: right;"><span class="bidtitle glyphicon"> 公司邮箱</span></div>
                                    <div class="col-xs-6">
                                        <input type="text" id="txtEmail"  runat="server" ClientIDMode="Static"  class="form-control" placeholder="请输入公司邮箱"/>
                                   </div>
                                 </div>
                                   <br/>
                                  <div class="row">
                                    <div class="col-xs-3" style="text-align: right;"><span class="bidtitle glyphicon"> 公司地区</span>
                                    </div>
                                    <div class="col-xs-6">
                                         <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                            <asp:DropDownList ID="ddlProvince" Height="30" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged">
                                            </asp:DropDownList>&nbsp;&nbsp;<asp:DropDownList ID="ddlCity" Width="120" runat="server" AutoPostBack="True" Height="30"
                                             OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                 </div>
                                   <br/>
                                   <div class="row">
                                    <div class="col-xs-3" style="text-align: right;"><span class="bidtitle glyphicon"> 企业简介</span></div>
                                    <div class="col-xs-6">
                                        <textarea cols="100" rows="6" id="txtDesc"  runat="server" ClientIDMode="Static"  class="form-control" placeholder="请输入企业简介"/>
                                   </div>
                                 </div>
                                     <br/>
                                   <div class="row">
                                    <div class="col-xs-3" style="text-align: right;"><span class="bidtitle glyphicon"> 主营业务</span></div>
                                    <div class="col-xs-6">
                                        <input type="text" id="txtMajorBusinesses"  runat="server" ClientIDMode="Static"  class="form-control" placeholder="请输入主营业务"/>
                                   </div>
                                 </div>
                                  <br/>
                                   <div class="row">
                                    <div class="col-xs-3" style="text-align: right;"><span class="bidtitle glyphicon "> 企业官网</span></div>
                                    <div class="col-xs-6">
                                        <input type="text" id="txtWebSite"  runat="server" ClientIDMode="Static" class="form-control" placeholder="请输入企业官网"/>
                                   </div>
                                 </div>
                                    <br/>
                                   <div class="row">
                                    <div class="col-xs-3" style="text-align: right;"><span class="bidtitle glyphicon"> 主要产品</span></div>
                                    <div class="col-xs-6">
                                        <input type="text" id="txtMajorProduct"  runat="server" ClientIDMode="Static"  class="form-control" placeholder="请输入主要产品"/>
                                   </div>
                                 </div>
                                    <br/>
                                   <div class="row">
                                    <div class="col-xs-3" style="text-align: right;"><span class="bidtitle glyphicon"> 注册资金</span></div>
                                    <div class="col-xs-6">
                                        <input type="text" id="txtRegistFund"  runat="server" ClientIDMode="Static"  class="form-control" placeholder="请输入注册资金"/>
                                   </div>
                                 </div>
                                    <br/>
                                   <div class="row">
                                    <div class="col-xs-3" style="text-align: right;"><span class="bidtitle glyphicon"> 年营业额</span></div>
                                    <div class="col-xs-6">
                                        <input type="text" id="txtAnnualSalesVolume"  runat="server" ClientIDMode="Static"  class="form-control" placeholder="请输入年营业额"/>
                                   </div>
                                 </div>
                                 <br/>
                                  <div class="row">
                                    <div class="col-xs-3" style="text-align: right;">
                                    </div>
                                    <div class="col-xs-6">
                                        <asp:Button runat="server"  class="btn btn-primary" ID="btnSave" Text="保存设置" 
                                            onclick="btnSave_Click"/>
                                   </div>
                                 </div>
                            </div>
                       </div>
                  </div>
                  <div class="col-lg-6">
                       <div class="box box-primary">
                            <div class="box-header">
                                      <h3 class="box-title">证件信息</h3>
                                  </div>
                                    <div class="row" id="AuditStatusDiv" runat="server">
                                       <div class="col-xs-3" style="padding-bottom: 15px; line-height:30px; height:30px; text-align:center;">
                                          <p class="bg-success" id="AuditStatus" runat="server"></p>
                                        </div>  
                                    </div>
                                  <div class="box-body" style="padding-left: 20px; font-size: 14px;">
                                      <table>
                                          <tr>
                                              <td style="height: 36px; line-height: 36px; padding-right: 20px;">请选择营业执照：(.jpg,.png,不超过2MB)</td>
                                              <td><asp:FileUpload runat="server" ID="flpyyzz" />
                                              </td>
                                              
                                          </tr>
                                                    <tr>
                                              <td style="height: 36px; line-height: 36px;">请选择组织机构代码证：(.jpg,.png,不超过2MB)</td>
                                              <td><asp:FileUpload runat="server" ID="flpzzjgz" /></td>
                           
                                          </tr>
                                                    <tr>
                                              <td style="height: 36px; line-height: 36px;">请选择税务登记证：(.jpg,.png,不超过2MB)</td>
                                              <td><asp:FileUpload runat="server" ID="flpswdj" /></td>
                           
                                          </tr>
                                      </table>
                                  </div>
                                  
                                  <br/>
                                  <div class="row">
                                    <div class="col-xs-3" style="text-align: right;">
                                    </div>
                                    <div class="col-xs-6">
                                        <asp:Button runat="server"  class="btn btn-primary" ID="btnAudit" Text="提交审核" 
                                            onclick="btnAudit_Click" />
                                   </div>
                              
                                 </div>
                                  <br/>
                            </div>
                  </div>
             </div>
        </section>
    </aside>
</asp:Content>
