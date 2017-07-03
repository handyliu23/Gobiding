<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UserCenterHeader.master"
    AutoEventWireup="true" CodeBehind="NewsEdit.aspx.cs" Inherits="GoBiding.Web.UserCenter.UserCenterPage.Admin.NewsEdit" %>

<%@ Register TagPrefix="CKEditor" Namespace="CKEditor.NET" Assembly="CKEditor.NET, Version=3.6.2.0, Culture=neutral, PublicKeyToken=e379cdf2f8354999" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
                                <div style="padding: 5px;">
                                    标题: <asp:TextBox runat="server" ID="txtTitle" Height="30" Width="600"></asp:TextBox>
                                     <asp:DropDownList runat="server" ID="ddlType" Height="30" Width="100"></asp:DropDownList>
                                </div>
                                 <div style="padding: 5px;">
                                    关键词: <asp:TextBox runat="server" ID="txtKeywords" Height="30" Width="600"></asp:TextBox>
                                </div>
                                      <div style="padding: 5px;">
                                    阅读量: <asp:TextBox runat="server" ID="txtBrowseCount" Height="30" Width="100"></asp:TextBox>
                                </div>
                                <div style="width: 100%; padding: 5px;">
                                <table>
                                <tr>
                                <td>主页图片: 
                                </td>
                                <td> <asp:FileUpload runat="server" ID="FileUploadControl" ClientIDMode="Static" />
                                </td>
                                <td>  <asp:Button runat="server" ID="btnUpload" Text="上传" Width="60" Height="26" 
                                                     onclick="btnUpload_Click"/>
                                                     </td>
                                </tr></table>
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <div style=" margin-top: 20px;">
                                                        <asp:Image runat="server" ID="imgProfile" alt="主图" width="300" height="180" />
                                                        <asp:HiddenField ID="hdnFileName" runat="server"/>
                                                    </div>
                                              </ContentTemplate>
                                        </asp:UpdatePanel>
                                </div>
                                <div>
                                    <CKEditor:CKEditorControl ID="ckDetailContent" Width="1100" Height="500" runat="server">
                                    </CKEditor:CKEditorControl>
                                </div>
                                <div style="padding: 5px;">
                                    <asp:Button runat="server" ID="btnSave" Text="保存" Width="100" Height="30" 
                                        onclick="btnSave_Click" />
                                </div>
                            </div>
                       </div><!-- /.box -->
                 </div>
            </div>
        </section>

        </aside>
</asp:Content>
