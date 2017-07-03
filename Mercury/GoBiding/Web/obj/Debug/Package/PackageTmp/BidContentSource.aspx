<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BidContentSource.aspx.cs"
    Inherits="GoBiding.Web.BidContentSource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">

    <title></title>
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
        .detaillabeltable
        {
            border: 0px;
            margin-top: 20px;
        }
        .detaillabeltable, .detaillabeltable th, .detaillabeltable td
        {
            border: 0px;
            background-color: #FCFCFC;
        }
        .detaillabeltable th
        {
            width: 160px;
            text-align: center;
            background-color: #FAFAFA;
            border: 1px dotted #FFF;
        }
        .detaillabeltable td
        {
            width: 370px;
            text-align: center;
        }
        table
        {
            border-collapse: collapse;
        }
        textarea
        {
            width: 700px;
            border: 0px;
            padding: 10px;
            height: 240px;
            overflow-y: visible;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 100%;">
        <asp:Label runat="server" ID="lblContent"></asp:Label>
    </div>
    </form>
</body>
</html>
