<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceList.aspx.cs" Inherits="GoBiding.Web.ServiceList" %>

<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <script src="/js/thirdplugin.js" type="text/javascript"></script>

    <style>
        *
        {
            margin: 0;
            padding: 0;
            font-family: "΢���ź�";
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
        #tableServiceList
        {
            border: 0px;
            border-collapse: collapse;
        }
        #tableServiceList td
        {
            text-align: center;
            padding: 10px;
            border: 1px solid #dcdcdc;
            font-size: 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:Top ID="Top1" runat="server" />
    <div style="background-color: #22252A;">
        <div class="container" style="padding: 0px; height: 44px;">
            <ol class="breadcrumb" style="background-color: #22252A;">
                <li><a href="/Default.html">ȥͶ����</a></li>
                <li class="active"><a href="/BidLaws.html">�����б�</a></li>
            </ol>
        </div>
    </div>
    <br />
    <div class="container">
        <div class="row">
            <table id="tableServiceList" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="3">
                        ������Ŀ
                    </td>
                    <td colspan="4">
                        ������ϸ
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        ��Ա����
                    </td>
                    <td style="width: 120px;">
                        ��ͨ��Ա
                    </td>
                    <td style="width: 120px;">
                        VIP��Ա
                    </td>
                    <td style="width: 120px;">
                        �׽�VIP��Ա
                    </td>
                    <td style="width: 120px;">
                        ��ʯVIP��Ա
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        �շѱ�׼
                    </td>
                    <td>
                        <font style="color: green;">���</font>
                    </td>
                    <td>
                        <font style="color: orange;">2800Ԫ/��</font>
                    </td>
                    <td>
                        <font style="color: orange;">6500Ԫ/��</font>
                    </td>
                    <td>
                        <font style="color: orange;">12800Ԫ/��</font>
                    </td>
                </tr>
                <tr>
                    <td rowspan="4" style="width: 100px;">
                        �б���Ϣ
                    </td>
                    <td style="width: 100px;">
                        �б�Ԥ��
                    </td>
                    <td style="width: 400px;">
                        �����б�ǰ1���������ڲɹ��ƻ�Ԥ�桢���뱨����׼����Ϣ,������ҵ��ǰ�˽���Ŀ�б�����
                    </td>
                    <td>
                        7��ǰ���
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td>
                        �б깫��
                    </td>
                    <td style="width: 400px;">
                        ȫ�����ɹ����ġ��б���������ҵ����λί�з����Ĺ����б���Ϣ,���ݰ���Ͷ��Ҫ��ҵ�����б깫˾��ϵ��,��ϵ��ʽ,�Լ���������ʱ�䡢�ص�ȣ�ÿ�ո���10000�����ϡ�
                    </td>
                    <td>
                        7��ǰ���
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td>
                        �б���
                    </td>
                    <td style="width: 400px;">
                        ���ڷ����б깫��󲹳乫�桢������桢�ϱ깫�桢�����б����Ϣ,ʹ��Ա��λ���Լ�ʱ��֪����Ч�Ķ�Ͷ�깤��������Ӧ����������������˵���Ͷ��ʧ��
                    </td>
                    <td>
                        7��ǰ���
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td>
                        �б���
                    </td>
                    <td style="width: 400px;">
                        �ṩ�б굥λ���б���Ŀ���б��������Ŀ��������Ŀ��ϵ�˼���ϵ��ʽ��Ϊ��Ա�ṩֱ�ӹ����������������ڻ�ԱΪ�б���ҵ�ں��ڷְ�������,������ǰ���빤����
                    </td>
                    <td>
                        7��ǰ���
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        �����б���Ϣ
                    </td>
                    <td style="width: 400px;">
                        ��Ա��λ����ʱ�����бꡢ�бꡢ����������������Ϣ,����������Ϣ����ȥͶ����չʾ��,�������ȸ衢�ٶȵȸ�����������ץȡ,�Ի�ȡ�����̻���
                    </td>
                    <td>
                        ��ѷ���3��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                 <tr>
                    <td colspan="2">
                        �����ɹ���Ϣ
                    </td>
                    <td style="width: 400px;">
                        ��Ա��λ����ʱ������Ӧ���������󹺵�������Ϣ,����������Ϣ����ȥͶ����չʾ��,�������ȸ衢�ٶȵȸ�����������ץȡ,�Ի�ȡ�����̻���
                    </td>
                    <td>
                        ��ѷ���3��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        ��ҵ�ɹ�
                    </td>
                    <td style="width: 400px;">
                        ��ҵͨ��ȥͶ����������ҵ�ɹ���Ϣ,��Ա��λ���Բ鿴��ҵ�Ĳɹ��̻���ֱ���������ϵ������
                    </td>
                    <td>
                        7��ǰ���
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        �б�����ѯ
                    </td>
                    <td style="width: 400px;">
                        �����б�ǰ1���������ڲɹ��ƻ�Ԥ�桢���뱨����׼����Ϣ,������ҵ��ǰ�˽���Ŀ�б�����
                    </td>
                    <td>
                        7��ǰ���
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        ȥͶ��׷�ٱ�
                    </td>
                    <td style="width: 400px;">
                        �ṩ�Զ��嶨������׷��������Ա���Ը���׷��������Ĳ�ѯ�����٣�����ָ����������ҵ�����͵���Ͷ����Ϣ��
                    </td>
                    <td>
                        ��Ѵ���1��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        ���ɷ���
                    </td>
                    <td style="width: 400px;">
                        �ṩ���߷��������Ķ������ء���ѯ�ȷ���
                    </td>
                    <td>
                        7��ǰ���
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        һ��һ�ۺ����
                    </td>
                    <td style="width: 400px;">
                        ȥͶ���������ÿͷ�����ͨ��һ��һ�ķ���ģʽ���ڷ����ڼ���Ϊ��Ա��λ�ṩȫ��λ����ʽ�ķ���,��ʱ�����Ա��λ��ʹ�ù�������������������ѡ�
                    </td>
                    <td>
                        7��ǰ���
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td rowspan="5">
                        ���ѷ���
                    </td>
                    <td>
                        �ʼ�����
                    </td>
                    <td style="width: 400px;">
                        �����û����ĵ���Ϣ���ͣ�ÿ���Զ����ͷ����������б�ɹ���Ϣͨ���ʼ��ķ�ʽ�������ѣ���Ա���Ե�һʱ��֪���г���Ϣ��̬��
                    </td>
                    <td>
                        ÿ��1��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td>
                        ��������
                    </td>
                    <td style="width: 400px;">
                        �����û����ĵ���Ϣ���ͣ�ÿ���Զ����ͷ����������б�ɹ���Ϣͨ�����ŵķ�ʽ�������ѣ���Ա���Ե�һʱ��֪���г���Ϣ��̬��
                    </td>
                    <td>
                        ÿ��1��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td>
                        App����
                    </td>
                    <td style="width: 400px;">
                        �����û����ĵ���Ϣ���ͣ�ÿ���Զ����ͷ����������б�ɹ���Ϣͨ��App��Ϣ�ķ�ʽ�������ѣ���Ա���Ե�һʱ��֪���г���Ϣ��̬��
                    </td>
                    <td>
                        ÿ��1��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td>
                        ΢������
                    </td>
                    <td style="width: 400px;">
                        �����û����ĵ���Ϣ���ͣ�ÿ���Զ����ͷ����������б�ɹ���Ϣͨ��΢����Ϣ�ķ�ʽ�������ѣ���Ա���Ե�һʱ��֪���г���Ϣ��̬��
                    </td>
                    <td>
                        ÿ��1��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td>
                        �绰����
                    </td>
                    <td style="width: 400px;">
                        �����û����ĵ���Ϣ���ͣ�������Ա�᲻�����Ƽ������������б�ɹ���Ϣͨ���绰�طõķ�ʽ�������ѣ���Ա���Ե�һʱ��֪���г���Ϣ��̬��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        ��ҵ����
                    </td>
                    <td style="width: 400px;">
                        �����û����ĵ���Ϣ���ͣ�������Ա�᲻�����Ƽ������������б�ɹ���Ϣͨ���绰�طõķ�ʽ�������ѣ���Ա���Ե�һʱ��֪���г���Ϣ��̬��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        ��ҵ����
                    </td>
                    <td style="width: 400px;">
                        �����û����ĵ���Ϣ���ͣ�������Ա�᲻�����Ƽ������������б�ɹ���Ϣͨ���绰�طõķ�ʽ�������ѣ���Ա���Ե�һʱ��֪���г���Ϣ��̬��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        ��ҵ��վ
                    </td>
                    <td style="width: 400px;">
                        ������Ϊ��δ����վ�Ļ�Ա��λ�ṩģ�彨վ�������ṩ���ǣ���˾��顢��Ʒ���ܡ���ҵ������ҵ��չʾ����ϵ���ǵ�5�����ܰ�����վ��ƺ������ļ���֧�ַ���
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        Ψһ�Ƽ���ҵ��
                    </td>
                    <td style="width: 400px;">
                        ��ί�в����Ƽ���Ӧ�̵���Ŀ,���������ݻ�Ա��λҵ��Χ����ҵʵ������Ŀ����,��ҵ���Ƽ�Ψһ��Ӧ�̻�Ա���뾺��,���Ƽ���Ŀ������������Ա�ṩ,�����Ƽ���Ա��λ����
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        �������ּ��
                    </td>
                    <td style="width: 400px;">
                        ��������ÿ�������µĶ�̬��ϵͳ����������Ӧ��ʾ��������Ա��λ��ʱ���վ�������Ͷ�궯̬����������䶯�������ȡһ�����ϲ���ʱ������
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        ��ҳ�̼��Ƽ�
                    </td>
                    <td style="width: 400px;">
                        ����ע���Ա��֤��Ϣ���б�����Լ�ҵ��������Ϣ�Ի�Ա�����ۺ�����,���շ����ۼ�,�����ź�ʵ���ȽϺõĻ�Ա��λ����ҳ�԰񵥵���ʽ����չʾ��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        -
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        �ƶ��ͻ���
                    </td>
                    <td style="width: 400px;">
                        �����û����ĵ���Ϣ���ͣ�������Ա�᲻�����Ƽ������������б�ɹ���Ϣͨ���绰�طõķ�ʽ�������ѣ���Ա���Ե�һʱ��֪���г���Ϣ��̬��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                    <td>
                        ��
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
