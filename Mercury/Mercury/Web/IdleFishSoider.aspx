<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IdleFishSoider.aspx.cs"
    Inherits="Mercury.Web.IdleFish" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td valign="top" style="padding: 10px; line-height: 30px;">
                    分类名称:<asp:TextBox runat="server" ID="txtGoodsType" Width="300" Height="26"></asp:TextBox><br />
                    测试地址:<asp:TextBox runat="server" ID="txtSpiderUrl" Text="https://s.2.taobao.com/list/waterfall/waterfall.htm?wp={0}&_ksTS=1499005753518_143&start=800&end=&callback=jsonp144&stype=1&catid=50100398&st_trust=1&page=1&q=%C7%F3%B9%BA&ist=1" Width="300" Height="26"></asp:TextBox><br />
                    Http Method:<asp:TextBox runat="server" ID="txtHttpMethod" Width="300" Height="26"></asp:TextBox><br />
                    起始页:<asp:TextBox runat="server" ID="txtPageStart" Width="300" Height="26"></asp:TextBox><br />
                    字符编码：<asp:TextBox runat="server" ID="txtEncode" Width="300" Height="26"></asp:TextBox><br />
                    截止页：<asp:TextBox runat="server" ID="txtPageEnd" Width="300" Height="26"></asp:TextBox><br />
                    <asp:Button runat="server" ID="btnUrl" Text="Test" Width="100" OnClick="btnUrl_Click" />
                </td>
                <td style="width: 800px;">
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="txtUrlResponse" Width="800"
                        Height="400"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
