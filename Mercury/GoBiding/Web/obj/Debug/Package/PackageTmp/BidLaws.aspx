<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BidLaws.html.cs" Inherits="GoBiding.Web.BidLaws" %>

<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>去投标网_法律法规_招投标法规_中华人民共和国招标投标法</title>
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <link rel="shortcut icon" type="image/x-icon" href="/imgs/system/logo_16_16.png" media="screen" />
    <script src="/UserCenter/js/jquery.min.js" type="text/javascript"></script>
    <script src="/js/thirdplugin.js" type="text/javascript"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                $("#ztbfg").addClass("navchoose");
            });
    </script>
    <style>
        *
        {
            margin: 0;
            padding: 0;
            font-family: "微软雅黑";
            font-size: 14px;
            line-height: 2em;
            color: #333;
        }
        .breadcrumb a
        {
            color: #fff;
        }
        .breadcrumb li.active
        {
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:Top ID="Top1" runat="server" />
    <div style="background-color: #22252A;">
        <div class="container" style="padding: 0px; height: 44px;">
            <ol class="breadcrumb" style="background-color: #22252A;">
                <li><a href="/Default.html">去投标网</a></li>
                <li><a href="/BidLaws.html">招投标法规</a></li>
                <li class="active">
                    <asp:Literal runat="server" ID="lblTitle2"></asp:Literal></li>
            </ol>
        </div>
    </div>
    <div class="container" style="padding: 0px; color: #000; font-family: simhei;">
        <div class="col-lg-2" style="padding: 0px;">
            <div style="height: 400px; margin-top: 20px;">
                <table>
                    <asp:Repeater runat="server" ID="rptLawsList">
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: center; height: 40px; line-height: 40px; padding-left: 15px;">
                                    <a href='/BidLaws.html?NewsId=<%#Eval("Id") %>' style="color: #000;">
                                        <%#Eval("NewsTitle")%></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
        <div class="col-lg-10" style="padding: 0px;">
            <div style="border-bottom: 1px dashed #dcdcdc; margin-left: 50px; padding: 20px;
                line-height: 50px; font-weight: bold; font-size: 24px; text-align: center;">
                <asp:Literal runat="server" ID="lblTitle"></asp:Literal>
            </div>
            <br />
            <br />
            <div style="margin-left: 50px;">
                <asp:Literal runat="server" ID="ltrContent"></asp:Literal></div>
        </div>
    </div>
    </form>
</body>
</html>
