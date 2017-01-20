<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BidDetail.aspx.cs" Inherits="Mercury.Web.BidDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>开标啦-中国最专业的招投标综合网站</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/biddetail.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:1000px; margin: 0px auto;">
        <div style="width: 100%; text-align: center;">
            <h1><asp:Literal runat="server" ID="lblTitle"></asp:Literal></h1>
            <br />
            发布时间<asp:Literal runat="server" ID="ltrPublishTime"></asp:Literal>
        </div>
        <div>
            <br />
            <asp:Label runat="server" ID="lblSource"></asp:Label>
        </div>
        <div style="width: 100%;">
            <asp:Label runat="server" ID="lblContent"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
