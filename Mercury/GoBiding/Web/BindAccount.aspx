<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BindAccount.aspx.cs"
    Inherits="GoBiding.Web.BindAccount" %>

<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>���û�_ȥͶ����_�й����������Ͷ�����ƽ̨_�����б�Ͷ�����ƽ̨_�����б���Ϣ_��Ͷ���ø���</title>
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <meta name="keywords" content="��������,ȥͶ����,�б���Ϣ,�б�,��Ͷ��,�б깫��,�б�Ԥ��,�����б�,�ɹ���Ϣ" />
    <meta name="description" content="Ͷ�������й���һ����ѵ��б���Ϣ����ƽ̨���б���Ϣ��ȫ�����ǵ������б���ҵ�����б�����ÿ����³���10000�������б���Ŀ��Ϣ��ȥͶ�����ѳ�Ϊ�������б굥λ��ҵ���б�ɹ�����ѡƽ̨,��Ͷ���ø���,ҪͶ�����ȥͶ������" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body style="background-color: #fafafa;">
    <form id="form1" runat="server">
    <uc2:Top ID="Top1" runat="server" />
    <div style="width: 70%; border: 1px solid #fff; background-color: #fff; padding: 10px;
        margin: 0px auto; font-family: '΢���ź�'; margin-top: 5%; padding-bottom:40px;">
        <div style="font-size: 16px; font-weight: bold; margin-left: 10px; padding-left: 10px;
            margin-top: 10px; border-left: 4px solid #000;">
            ���û�
        </div>
        <br />
        <br />
        <table style="width: 90%; margin-left: 40px;">
            <tr>
                <td style="width: 50%; padding-left: 20px; line-height: 30px; color: #333; border-right: 1px solid #ececec;
                    vertical-align: top;">
                    δע���ȥͶ������������ʻ�
                    <br />
                    <div style="margin-top: 20px;">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="height: 50px; width: 90px; vertical-align: top;">
                                    �����ַ
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtNewEmail" Text="" placeholder="���������ʻ��������ַ" Width="240"
                                        class="form-control"></asp:TextBox>
                                    <font style="color: #666; font-size: 11px;">* �����ַ��Ϊ�һ��������Ҫ���ݣ�����ϸ��д��</font>
                                </td>
                            </tr>
                             <tr>
                                <td style="height: 50px; width: 90px; ">
                                    ��ҵ����
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCompanyName" Text="" placeholder="��������ҵ����" Width="240"
                                        class="form-control"></asp:TextBox>
                                    <font style="color: #666; font-size: 11px;"></font>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="height: 50px;">
                                    <div class="btn btn-primary" style="width: 100px;" id="newLogin">
                                        ȷ��</div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <br />
                    <%--<div style="font-size: 10px;">Ϊ���ṩ���õķ�����������ַ����Ҳ�����ݲ��󶨣�<a href="" class="hrefSkip">����֮ǰ�ķ���</a></div>--%>
                </td>
                <td style="width: 50%; padding-left: 50px; line-height: 30px; color: #333; vertical-align: top;">
                    �Ѿ�ע���ȥͶ�������������ʻ�
                    <div style="margin-top: 20px;">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="height: 50px; width: 90px; vertical-align: top;">
                                    �����ַ
                                </td>
                                <td style="vertical-align: top;">
                                    <asp:TextBox runat="server" ID="txtOldEmail" Text="" placeholder="�����������ʻ��������ַ" Width="240"
                                        class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 50px; width: 90px;">
                                    ��¼����
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" placeholder="����������6λ����������ĸ"
                                        Width="240" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                             <tr>
                                <td style="height: 50px; width: 90px;">
                                    ��ҵ����
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCompanyName2" Text="" placeholder="��������ҵ����" Width="240"
                                        class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="height: 50px;">
                                    <div class="btn btn-primary" style="width: 100px;" id="oldLogin">
                                        ȷ��</div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);  //��ȡurl��"?"������ַ���������ƥ��
            var context = "";
            if (r != null)
                context = r[2];
            reg = null;
            r = null;
            return context == null || context == "" || context == "undefined" ? "" : context;
        }

        $(".hrefSkip").click(function () {
            self.location = "http://www.gobiding.com/Default.html";
        });

        $("#newLogin").click(function () {
            $.ajax({
                type: "post",
                url: "/BindAccountHandle.ashx",
                data: {
                    Email: $("#txtNewEmail").val(),
                    Type: "new",
                    CompanyName: $("#txtCompanyName").val()
                },
                success: function (data) {
                    if (data == "OK") {
                        if (document.location.href.indexOf("bId") > 0 && GetQueryString("bId") != '') {
                            self.location = "http://www.gobiding.com/BidDetail/" + GetQueryString("bId") +".html";
                        } else {
                            self.location = "http://www.gobiding.com/Default.html";
                        }
                    }
                    else {
                        alert(data);
                    }
                },
                error: function (msg) {
                    setTimeout("pause()", 1000);
                    initLoginPanel();
                }
            });
        });

        $("#oldLogin").click(function () {
            $.ajax({
                type: "post",
                url: "/BindAccountHandle.ashx",
                data: {
                    Email: $("#txtOldEmail").val(),
                    Password: $("#txtPassword").val(),
                    CompanyName: $("#txtCompanyName2").val(),
                    Type: "old"
                },
                success: function (data) {
                    if (data == "OK") {
                        if (document.location.href.indexOf("bId") > 0 && GetQueryString("bId") != '') {
                            self.location = "http://www.gobiding.com/BidDetail/" + GetQueryString("bId") + ".html";
                        } else {
                            self.location = "http://www.gobiding.com/Default.html";
                        }
                    }
                    else {
                        alert(data);
                    }
                },
                error: function (msg) {
                    alert(msg);
                }
            });
        });

    </script>
    </form>
</body>
</html>
