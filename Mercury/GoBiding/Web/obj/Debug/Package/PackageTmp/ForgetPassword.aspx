<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs"
    Inherits="GoBiding.Web.ForgetPassword" %>

<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>��������_ȥͶ����_�й����������Ͷ�����ƽ̨_�����б�Ͷ�����ƽ̨_�����б���Ϣ_��Ͷ���ø���</title>
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <meta name="keywords" content="��������,ȥͶ����,�б���Ϣ,�б�,��Ͷ��,�б깫��,�б�Ԥ��,�����б�,�ɹ���Ϣ" />
    <meta name="description" content="Ͷ�������й���һ����ѵ��б���Ϣ����ƽ̨���б���Ϣ��ȫ�����ǵ������б���ҵ�����б�����ÿ����³���10000�������б���Ŀ��Ϣ��ȥͶ�����ѳ�Ϊ�������б굥λ��ҵ���б�ɹ�����ѡƽ̨,��Ͷ���ø���,ҪͶ�����ȥͶ������" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body style="background-color: #fafafa;">
    <form id="form1" runat="server">
    <uc2:Top ID="Top1" runat="server" />
    <div style="width: 80%; padding-top: 10px; border: 1px solid #fff; background-color: #fff;
        margin: 0px auto; font-family: '΢���ź�'; margin-top: 20px; height: 300px;">
        <div style="font-size: 18px; font-weight: bold; margin-left: 20px; padding-left: 5px;
            border-left: 4px solid #000;">
            �һ�����
        </div>
        <br />
        <br />
        <br />
        <table>
            <tr>
                <td style="width: 200px; text-align: right; color: #999;">
                    ע�������ַ:
                </td>
                <td style="padding: 10px;">
                    <asp:TextBox runat="server" ID="txtEmail" Text="" placeholder="������ע��ʱʹ�õ������ַ" Width="280"
                        class="form-control"></asp:TextBox>
                </td>
                <td>��<font style="color: red;">*</font>���������ַ��ȥͶ����������������ַ����һ�����������ʼ���
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="padding: 10px;">
                    <asp:Button runat="server" ID="btnEmail" Text="�ύ�һ�����" Width="140" Height="32" 
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
