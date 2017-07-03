<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="GoBiding.Web.Logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>注销_去投标网</title>
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <script type="text/javascript" src="http://tjs.sjs.sinajs.cn/t3/platform/js/api/wb.js" charset="utf-8" ></script>
    <script type="text/javascript" src="http://qzonestyle.gtimg.cn/qzone/openapi/qc_loader.js"
        charset="utf-8" data-callback="true"></script>
    <script>
        logout();
        
        function logout() {
            QC.Login.signOut();
            location.href = "/UserCenter/UserCenterPage/Logout.aspx";

            WB.connect.logout(function () {
            });
        }

        
        
    </script>

</head>
<body>
    <form id="form1" runat="server">

    </form>
</body>
</html>
