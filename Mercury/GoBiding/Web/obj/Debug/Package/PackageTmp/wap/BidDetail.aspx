<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BidDetail.aspx.cs" Inherits="GoBiding.Web.wap.BidDetail" %>

<%@ Register Src="UserControls/Bottom.ascx" TagName="Bottom" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="/js/jquery-3.1.1.min.js" type="text/javascript"></script>
    <script src="/js/thirdplugin.js" type="text/javascript"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
    <style>
        #lblContent
        {
            font-size: 8px;
            width: 400px;
            white-space: pre-wrap;
            word-wrap: break-word;
            overflow: hidden;
        }
        table
        {
            border-color: #fafafa;
            border-collapse: collapse;
            border: 0px;
            margin-top: 10px;
            margin-bottom: 10px;
        }
        table td
        {
            border-color: #fafafa;
            padding: 2px;
            font-size: 10px;
        }
        body
        {
            font-size: 10px;
            overflow-x: hidden;
            padding: 0px;
            margin: 0px;
        }
        p, div, span
        {
            margin: 0px;
            padding: 0px;
            line-height: 20px;
        }
        a
        {
            text-decoration: none;
            color: #000;
        }
        h1, h2, h3, h4, h5, h6, span, div, strong, .divbiddetailcontent li, table span
        {
            margin-top: 0px;
            margin-bottom: 0px;
            font-size: 10px;
            line-height: 2em;
        }
    </style>
    <script>
        $(document).ready(function () {
            $(".favdiv").click(function () {
                var bidid = $(this).find("#hdnBidId").val();

                $.ajax({
                    type: "post",
                    url: "handlers/addFavourite.ashx",
                    data: {
                        BidId: bidid
                    },
                    dataType: 'text',
                    success: function (result) {
                        if (result == "ok")
                            alert('添加成功！');
                        else if (result == "regist")
                            location.href = "/wap/wapLogin.aspx";
                        return;
                    }
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:Bottom ID="Bottom1" runat="server" />
    <div style="height: 40px; line-height: 40px; width: 100%; text-align: center; background-color: steelblue;
        font-size: 14px; font-weight: bold; color: #fff;">
        〓 项目内容</div>
    <div style="width: 95%; margin: 0px auto; padding-top: 10px; color: #333; font-size: 13px;
        font-weight: bolder;">
        <asp:Label runat="server" ID="lblTitle"></asp:Label>
    </div>
    <div style="width: 95%; border-bottom: 1px solid #fafafa; padding-left: 10px;">
        <table style="width: 100%; margin-top: 0px; margin-bottom: 0px;">
            <tr>
                <td style="width: 78%; font-size: 10px; color: #999; padding-bottom: 10px; line-height: 20px;">
                    <table style="width: 100%; margin-top: 0px; margin-bottom: 0px;">
                        <tr>
                            <td style="width: 20px;">
                                <img src="Imgs/location_16.png" />
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblProvinceName"></asp:Label>
                            </td>
                        </tr>
                        <tr runat="server" id="rowCategory">
                            <td>
                                <img src="Imgs/type_16.png" />
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblCategoryName"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="Imgs/bidtype_16.png" />
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblBidType"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="Imgs/time_16.png" />
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblPublishTime"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="Imgs/link_16.png" />
                            </td>
                            <td>
                                <a runat="server" id="lnkSpiderURL" clientidmode="Static" style="text-decoration: none;
                                    color: #999;">
                                    <asp:Label runat="server" ID="lblSpiderName"></asp:Label><br />
                                </a>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 22%; font-size: 10px;">
                    <div>
                    </div>
                    <div id="btnConcern" style="height: 30px; text-align: center; line-height: 30px;
                        padding: 0px; margin: 0px; background-color: steelblue; color: #fff;">
                        ☆ 收藏关注</div>
                </td>
            </tr>
        </table>
    </div>
    <div style="padding: 10px; color: orange; background-color:#fff2cc; ">
        <span style="color: orange;">去投标网（官方网站：www.gobiding.com) 提示：</span><br />
        <span>1、手机版显示的招标信息经过系统智能转换。</span><br />
        <span>2、点击"关注"，即可收藏该条标书，可以在我的关注列表中查看。</span><br />
        <span>3、遇不能正常浏览的情况可以访问网页版或点击我要报错联系我们。</span><br />
        <span>4、如果需要下载附件，可以到底部点击查看原文下载。</span><br />
    </div>
    <div style="padding-left: 10px; width: 96%; margin-top:10px;">
        <asp:Literal runat="server" ID="lblContent"></asp:Literal>
    </div>
    <br />
    <br />
    <div style="padding: 10px;">
        <a runat="server" id="lnkSpiderUrl2"><span style="width: 100px; padding: 10px; font-size: 10px;
            text-align: center; background-color: #eaeaea; border-radius: 4px; color: #fff;">
            查看原文</span></a>
    </div>
    <br />
    <br />
    <div style="text-align:center; border-top:1px solid #dcdcdc; width:100%; height:150px; background-color:#ececec;">
        <div style="padding:20px;">
            <table>
            <tr>
            <td style="width:90px; background-color:#fff; padding:0px;">
                <img src="../imgs/ad/ad_2.png" width="90" height="90" />
            </td>
            <td style="background-color:#fff; width:240px; font-family: microsoft yahei; color:#666; line-height:24px; padding:10px; padding-left:25px; padd-right:25px; font-size:16px; text-align:left;">
                去投标网，分享企业政府招标信息，让招标变得更轻松
            </td>
            </tr></table>
        </div>
    </div>
    <br />
    <br />
    <br />
    <asp:HiddenField runat="server" id="hdnBidId" />

    </form>
</body>
</html>
