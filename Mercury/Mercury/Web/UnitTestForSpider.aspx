<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnitTestForSpider.aspx.cs"
    ValidateRequest="false" Inherits="Mercury.Web.UnitTestForSpider" %>

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
                    爬虫类型:<asp:TextBox runat="server" ID="txtSpiderType" Width="300" Height="26"></asp:TextBox><br />
                    测试地址:<asp:TextBox runat="server" ID="txtSpiderUrl" Width="300" Height="26"></asp:TextBox><br />
                    Http Method:<asp:TextBox runat="server" ID="txtHttpMethod" Width="300" Height="26"></asp:TextBox><br />
                    分页参数:<asp:TextBox runat="server" ID="txtPageParameter" Width="300" Height="26"></asp:TextBox><br />
                    字符编码：<asp:TextBox runat="server" ID="txtEncode" Width="300" Height="26"></asp:TextBox><br />
                    页数：<asp:TextBox runat="server" ID="txtPageNumber" Width="300" Height="26"></asp:TextBox><br />
                    <asp:Button runat="server" ID="btnUrl" Text="Test" Width="100" OnClick="btnUrl_Click" />
                    <br />
                    列表页链接：<asp:TextBox runat="server" ID="txtListExpression" Width="300" Height="26"></asp:TextBox><br />
                    <asp:Button runat="server" ID="btnListExpression" Text="Test" Width="100" OnClick="btnListExpression_Click" />
                    <br />
                    详情页URL前缀:<asp:TextBox runat="server" ID="txtDetailURLPrefix" Width="300" Height="26"></asp:TextBox><br />
                    <asp:Button runat="server" ID="btnDetailPrefix" Text="Test" Width="100" OnClick="btnDetailPrefix_Click" /><br />
                    标题：<asp:TextBox runat="server" ID="txtTitleExpression" Width="300" Height="26"></asp:TextBox><br />
                    <asp:Button runat="server" ID="btnTitle" Text="Test" Width="100" 
                        onclick="btnTitle_Click" /><br />
                    发布时间：<asp:TextBox runat="server" ID="txtPublishExpression" Width="300" Height="26"></asp:TextBox><br />
                    <asp:Button runat="server" ID="btnPublishTime" Text="Test" Width="100" 
                        onclick="btnPublishTime_Click" /><br />
                    发布内容：<asp:TextBox runat="server" ID="txtContentExpression" Width="300" Height="26"></asp:TextBox><br />
                    <asp:Button runat="server" ID="btnContent" Text="Test" Width="100" 
                        onclick="btnContent_Click" />
                </td>
                <td style="width: 800px;">
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="txtUrlResponse" Width="800"
                        Height="400"></asp:TextBox>
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="txtResponse2" Width="800" Height="100"></asp:TextBox>
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="txtResponse3" Width="800" Height="500"></asp:TextBox>
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="txtResponse4" Width="800" Height="100"></asp:TextBox>
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="txtResponse5" Width="800" Height="100"></asp:TextBox>
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="txtResponse6" Width="800" Height="100"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
