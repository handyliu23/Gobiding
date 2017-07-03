<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsEdit.aspx.cs" Inherits="GoBiding.Web.NewsEdit" %>
<%@ Register TagPrefix="CKEditor" Namespace="CKEditor.NET" Assembly="CKEditor.NET, Version=3.6.2.0, Culture=neutral, PublicKeyToken=e379cdf2f8354999" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <script src="/js/thirdplugin.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="padding: 5px;">
        标题: <asp:TextBox runat="server" ID="txtTitle" Height="30" Width="1000"></asp:TextBox>
    </div>
    <div>
        <CKEditor:CKEditorControl ID="ckDetailContent" Width="1100" Height="500" runat="server">
        </CKEditor:CKEditorControl>
    </div>
    <div style="padding: 5px;">
        <asp:Button runat="server" ID="btnSave" Text="保存" Width="100" Height="30" 
            onclick="btnSave_Click" />
    </div>
    </form>
</body>
</html>
