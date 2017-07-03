<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs"
    Inherits="GoBiding.Web.ForgetPassword" %>

<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>忘记密码_去投标网_中国最大的免费招投标服务平台_在线招标投标服务平台_最新招标信息_让投标变得更简单</title>
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <meta name="keywords" content="忘记密码,去投标网,招标信息,招标,招投标,招标公告,招标预告,政府招标,采购信息" />
    <meta name="description" content="投标网是中国第一家免费的招标信息服务平台，招标信息最全、覆盖地区及招标行业最广的招标网，每天更新超过10000条各类招标项目信息；去投标网已成为政府、招标单位、业主招标采购的首选平台,让投标变得更简单,要投标就上去投标网。" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body style="background-color: #fafafa;">
    <form id="form1" runat="server">
    <uc2:Top ID="Top1" runat="server" />
    <div style="width: 80%; padding-top: 10px; border: 1px solid #fff; background-color: #fff;
        margin: 0px auto; font-family: '微软雅黑'; margin-top: 20px; height: 300px;">
        <div style="font-size: 18px; font-weight: bold; margin-left: 20px; padding-left: 5px;
            border-left: 4px solid #000;">
            找回密码
        </div>
        <br />
        <br />
        <br />
        <table>
            <tr>
                <td style="width: 200px; text-align: right; color: #999;">
                    注册邮箱地址:
                </td>
                <td style="padding: 10px;">
                    <asp:TextBox runat="server" ID="txtEmail" Text="" placeholder="请输入注册时使用的邮箱地址" Width="280"
                        class="form-control"></asp:TextBox>
                </td>
                <td>（<font style="color: red;">*</font>输入邮箱地址，去投标网将会给该邮箱地址发送一封包含密码的邮件）
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="padding: 10px;">
                    <asp:Button runat="server" ID="btnEmail" Text="提交找回密码" Width="140" Height="32" 
                        onclick="btnEmail_Click" /> <asp:Literal runat="server" ID="ltrMessage"></asp:Literal>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
