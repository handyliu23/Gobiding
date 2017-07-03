<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UserCenterHeader.master"
    AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="GoBiding.Web.UserCenter.UserCenterPage.Profile" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/css/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
    <style>
        .bidtitle
        {
            color: #333;
            margin-left: 5px;
            padding: 5px;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <aside class="right-side">                
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>
                个人设置
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i> 首页</a></li>
                <li><a href="#">用户设置</a></li>
                <li class="active">个人设置</li>
            </ol>
        </section>
        <section class="content">
            <div class="row">
                  <div class="col-md-6">
                       <div class="box box-primary">
                            <div class="box-header">
                                      <h3 class="box-title">基本设置</h3>
                                  </div>
                            <div class="box-body tracker_content_provinces">
                                  <div class="row">
                                    <div class="col-xs-4" style="text-align: right;">
                                        <span class="bidtitle glyphicon" > 用户昵称</span>
                                    </div>
                                    <div class="col-xs-6">
                                          <div class="input-group" style="width: 100%;">
                                              <input type="text" class="form-control" runat="server" ClientIDMode="Static" id="txtUserNickName" placeholder=""/>
                                             
                                        </div>
                                    </div>
                                 </div>
                                 <br/>
                                 <div class="row">
                                    <div class="col-xs-4" style="text-align: right; height: 100px;">
                                        <span class="bidtitle" >用户头像</span>
                                    </div>
                                    <div class="col-xs-6">
                                        <div class="input-group" style="width: 80%; float: left;">
                                             <asp:FileUpload runat="server" ID="FileUploadControl" ClientIDMode="Static" />
                                                </div>
                                                <div style="width:20%; float: left;">
                                                     <asp:Button runat="server" ID="btnUpload" Text="上传" Width="60" Height="26" 
                                                     onclick="btnUpload_Click"/>
                                                </div>
                                                <br/>
                                                  <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <div style=" margin-top: 20px;">
                                                        <asp:Image runat="server" ID="imgProfile" alt="用户头像" width="80" height="80" />
                                                    </div>
                                              </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                 </div>
                                 <br/>
                                 <div class="row">
                                    <div class="col-xs-4" style="text-align: right;">
                                        <span class="bidtitle glyphicon">用户姓名</span>
                                    </div>
                                    <div class="col-xs-6">
                                          <div class="input-group" style="width: 100%;">
                                              <input type="text" class="form-control" runat="server" ClientIDMode="Static" id="txtUserName" placeholder=""/>
                                        </div>
                                    </div>
                                 </div>
                                 <br/>
                                  <div class="row">
                                    <div class="col-xs-4" style="text-align: right;"><span class="bidtitle glyphicon"> 手机号码</span></div>
                                    <div class="col-xs-6">
                                        <input type="text" id="txtMobile" runat="server" ClientIDMode="Static" class="form-control" placeholder=""/>
                                   </div>
                                 </div>
                                  <br/>
                                   <div class="row">
                                    <div class="col-xs-4" style="text-align: right;"><span class="bidtitle glyphicon"> 联系邮箱</span></div>
                                    <div class="col-xs-6">
                                        <input type="text" id="txtEmail"  runat="server" ClientIDMode="Static"  class="form-control" placeholder=""/>
                                   </div>
                                 </div>
                                     <br/>
                                   <div class="row">
                                    <div class="col-xs-4" style="text-align: right;"><span class="bidtitle glyphicon"> 联系地址</span></div>
                                    <div class="col-xs-6">
                                        <input type="text" id="txtAddress"  runat="server" ClientIDMode="Static"  class="form-control" placeholder=""/>
                                   </div>
                                 </div>
                                     <br/>
                                   <div class="row">
                                    <div class="col-xs-4" style="text-align: right;"><span class="bidtitle">用户性别</span></div>
                                    <div class="col-xs-6">
                                        <asp:RadioButton runat="server" GroupName="Gendor" ID="rdbMan" Text="先生" Checked="True"/>&nbsp;
                                        <asp:RadioButton runat="server" GroupName="Gendor" ID="rdbWoman" Text="女士"/>
                                   </div>
                                 </div>
                                     <br/>
                                   <div class="row">
                                    <div class="col-xs-4" style="text-align: right;"><span class="bidtitle glyphicon"> QQ号码</span></div>
                                    <div class="col-xs-6">
                                        <input type="text" id="txtQQ"  runat="server" ClientIDMode="Static"  class="form-control" placeholder=""/>
                                   </div>
                                 </div>
                                  <br/>
                                   <div class="row">
                                    <div class="col-xs-4" style="text-align: right;"><span class="bidtitle glyphicon "> 公司名称</span></div>
                                    <div class="col-xs-6">
                                        <input type="text" id="txtCompanyName"  runat="server" ClientIDMode="Static" class="form-control" placeholder=""/>
                                   </div>
                                 </div>
                                    <br/>
                                   <div class="row">
                                    <div class="col-xs-4" style="text-align: right;"><span class="bidtitle glyphicon"> 职位名称</span></div>
                                    <div class="col-xs-6">
                                        <input type="text" id="txtPosition"  runat="server" ClientIDMode="Static"  class="form-control" placeholder=""/>
                                   </div>
                                 </div>
                                 <br/>
                                  <div class="row">
                                    <div class="col-xs-4" style="text-align: right;">
                                    </div>
                                    <div class="col-xs-6">
                                        <asp:Button runat="server"  class="btn btn-primary" ID="btnSave" Text="保存设置" 
                                            onclick="btnSave_Click"/>
                                   </div>
                                 </div>
                            </div>
                       </div>
                       </div>

                  <div class="col-md-6">
                          <div class="box box-primary">
                            <div class="box-header">
                                      <h3 class="box-title">订阅设置</h3>
                                  </div>
                            <div class="box-body tracker_content_provinces">
                                 <div class="row">
                                 <div class="col-xs-4" style="text-align: right;"><span class="bidtitle glyphicon glyphicon-font"> 短信提醒</span></div>
                                 <div class="col-xs-6">
                                    <asp:DropDownList runat="server" ID="ddlSmsNotice" Width="100" Height="30">
                                        <asp:ListItem Text="开启" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="关闭" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                 </div>
                                 </div>
                                 <br/>
                                 <div class="row">
                                 <div class="col-xs-4" style="text-align: right;"><span class="bidtitle glyphicon glyphicon-envelope"> 邮件提醒</span></div>
                                 <div class="col-xs-6">
                                    <asp:DropDownList runat="server" ID="ddlEmailNotice" Width="100" Height="30">
                                        <asp:ListItem Text="开启" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="关闭" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                 </div>
                                 </div>
                                 <br/>
                                  <div class="row">
                                    <div class="col-xs-4" style="text-align: right;"><span class="bidtitle glyphicon glyphicon-comment"> 微信提醒</span></div>
                                    <div class="col-xs-6">
                                    <asp:DropDownList runat="server" ID="ddlWeiXinNotice" Width="100" Height="30">
                                        <asp:ListItem Text="开启" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="关闭" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                   </div>
                                 </div>
                                  <br/>
                                  <br/>
                                  <div class="row">
                                    <div class="col-xs-4" style="text-align: right;">
                                    </div>
                                    <div class="col-xs-6">
                                        <asp:Button runat="server" ID="btnSaveDingyue" class="btn btn-primary" 
                                            Text="保存设置" onclick="btnSaveDingyue_Click"/>
                                   </div>
                                 </div>
                            </div>
                       </div>

                       <div class="box box-primary">
                            <div class="box-header">
                                      <h3 class="box-title">安全设置</h3>
                                  </div>
                            <div class="box-body tracker_content_provinces">
                                 <div class="row">
                                 <div class="col-xs-4" style="text-align: right; line-height:34px;">修改密码</div>
                                 <div class="col-xs-6">
                                      <input type="password" id="txtPwd"  style="width:180px;"  runat="server"  ClientIDMode="Static"  class="form-control" placeholder="至少6位数字字母"/>
                                 </div>
                                 </div>
                                 <br/>
                                  <div class="row">
                                    <div class="col-xs-4" style="text-align: right; line-height:34px;">确认密码</div>
                                    <div class="col-xs-6">
                                  <input type="password" id="txtPwd2" style="width:180px;" runat="server" ClientIDMode="Static"  class="form-control" placeholder=""/>
                                   </div>
                                 </div>
                                  <br/>
                                  <br/>
                                  <div class="row">
                                    <div class="col-xs-4" style="text-align: right;">
                                    </div>
                                    <div class="col-xs-6">
                                        <asp:Button runat="server" ID="btnSavePassword" class="btn btn-primary" 
                                            Text="确认修改" onclick="btnSavePassword_Click" />
                                   </div>
                                 </div>
                            </div>
                       </div>
                  </div>
             </div>
        </section>
    </aside>
    <script>
        $(document).ready(function () {
            $("#flpProfile").change(function () {
                alert($(this).FileName);
            });
        });
    </script>
</asp:Content>
