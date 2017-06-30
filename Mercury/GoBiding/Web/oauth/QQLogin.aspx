<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QQLogin.aspx.cs" Inherits="GoBiding.Web.oauth.QQLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://qzonestyle.gtimg.cn/qzone/openapi/qc_loader.js"
        charset="utf-8" data-callback="true"></script>
    <script>
//        oInfo：{
//    "ret":0,
//    "msg":"",
//    "nickname":"遲來の垨堠",
//    "figureurl":"http://qzapp.qlogo.cn/qzapp/100229030/ECCC463F76A2E3C1D9217BBC30418164/30",
//    "figureurl_1":"http://qzapp.qlogo.cn/qzapp/100229030/ECCC463F76A2E3C1D9217BBC30418164/50",
//    "figureurl_2":"http://qzapp.qlogo.cn/qzapp/100229030/ECCC463F76A2E3C1D9217BBC30418164/100",
//    "gender":"男",
//    "vip":"1",
//    "level":"7"
//}
        cbLoginFun(oInfo, oOpts){
            alert(oInfo);
        }
        QC.Login.getMe(function (openId, accessToken) {
            alert(openId + accessToken);
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
    </form>
</body>
</html>
