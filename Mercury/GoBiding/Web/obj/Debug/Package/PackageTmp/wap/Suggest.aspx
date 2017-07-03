<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Suggest.aspx.cs" Inherits="GoBiding.Web.wap.Suggest" %>

<%@ Register Src="UserControls/Bottom.ascx" TagName="Bottom" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公开招标采购_去投标网_全国免费招投标服务平台</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
    <script src="/js/thirdplugin.js" type="text/javascript"></script>
    <link href="/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="row" style="width: 100%; padding: 0px; margin: 0px; height: 40px; line-height: 40px;
        background-color: #ececec;">
        <div class="col-lg-12" style="width: 100%; padding-left: 10px; margin: 0px;">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 68%;">
                        <img src="/imgs/system/admin.png" width="24" height="24" />&nbsp;去投标网会员：<asp:Literal
                            runat="server" ID="ltrUserName"></asp:Literal>
                    </td>
                    <td style="width: 20%;">
                        <a href="/wap/Default.aspx">招标大厅</a>
                    </td>
                    <td style="width: 12%; text-align: right;">
                        <a href="Logout.aspx">注销</a>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="divContent" class="row">
        <div class="col-lg-12">
            <div class="box-body no-padding">
                <div style="padding:10px; height:40px; line-height:40px; color:#333;">投诉建议：</div>
                <div style="padding:10px;">
                <asp:TextBox runat="server" ID="txtSuggest" ToolTip="请输入您的投诉或建议！" Width="100%" TextMode="MultiLine" Height="300" ></asp:TextBox>
                </div>
                <div style="padding:10px;">
                <asp:Button runat="server" ID="btnSuggest" class="btn btn-primary" Width="100%" Height="40"
                    Text="提交建议" OnClick="btnSuggest_Click" />
                </div>
            </div>
        </div>
    </div>
    <div style="width: 100%; padding: 0px; margin: 0px;">
        <uc1:Bottom ID="Bottom1" runat="server" />
    </div>
    </form>
</body>
</html>
