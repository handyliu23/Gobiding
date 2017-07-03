<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GoBiding.Web.Login" %>

<%@ Register Src="UserCenter/Index/Top.ascx" TagName="Top" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <title>��¼ȥͶ����_�й����������Ͷ�����ƽ̨_�����б�Ͷ�����ƽ̨_�����б���Ϣ_��Ͷ���ø���</title>
    <meta name="keywords" content="ȥͶ����,�б���Ϣ,�б�,��Ͷ��,�б깫��,�б�Ԥ��,�����б�,�ɹ���Ϣ" />
    <meta name="description" content="Ͷ�������й���һ����ѵ��б���Ϣ����ƽ̨���б���Ϣ��ȫ�����ǵ������б���ҵ�����б�����ÿ����³���10000�������б���Ŀ��Ϣ��ȥͶ�����ѳ�Ϊ�������б굥λ��ҵ���б�ɹ�����ѡƽ̨,��Ͷ���ø���,ҪͶ�����ȥͶ������" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="shortcut icon" type="image/x-icon" href="/imgs/system/logo_16_16.png" media="screen" />

    <link href="/css/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc2:Top ID="Top1" runat="server" />
    <div class="blur" style="width: 100%; height: 460px;">
        <div class="container" style="position: relative; left: 0px; top: 0px;">
            <div class="row">
                <div style="color: #fff; font-family: ΢���ź�; position: absolute; top: 70px; height: 400px;">
                    <span style="font-size: 44px;">ֻΪͶ���ø���</span><br />
                    <br />
                    <span style="color: #fff; font-size: 20px; line-height: 40px;">����̻��Ƽ� Ʒ��ֵ������</span><br />
                    <span style="color: #fff; font-size: 20px; line-height: 40px;">������Ϣ���� ����ƥ������</span><br />
                    <span style="color: #fff; font-size: 20px; line-height: 40px;">�ֻ�΢��app, ������ָ����������Ͷ��</span><br />
                    <br />
                    <span style="color: #fff; font-size: 14px; line-height: 40px; border: 1px solid #fafafa;
                        border-radius: 5px; padding: 5px 10px 5px 10px;">�������ȥͶ������Ա </span>
                    <br />
                </div>
                <div class="box box-primary box-shadow-3" id="divlogin" style="position: absolute;
                    top: 70px; right: 10px; width: 320px; filter: alpha(opacity=95); -moz-opacity: 0.95;
                    -khtml-opacity: 0.99; opacity: 0.95; background-color: #fff; padding: 20px; margin-top: -30px;
                    color: #000; height: 360px; border-radius: 4px;">
                    <div class="box-body">
                        <div class="row">
                            <div class="col-xs-12">
                                <br />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <input type="text" id="txtLoginUserName" runat="server" clientidmode="Static" class="form-control" placeholder="�û���/�ֻ���/�����ַ"/>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-xs-12">
                                <input type="password" id="txtLoginPassword"  runat="server" clientidmode="Static" class="form-control" placeholder="�û�����"/>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-xs-4">
                                <input type="text" id="txtUserCheckCode" class="form-control" placeholder="��֤��" /></div>
                            <div class="col-xs-6">
                                <img id="Img1" alt="�����壬�����ң�" onclick="this.src=this.src+'?'" src="CheckCodeHandler.ashx"
                                    style="width: 80px; height: 34px" align="left" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-xs-12">
                                <button type="button" class="btn btn-primary" id="btnLogin" style="font-weight: 700;
                                    height: 40px; width: 100%; font-size: 14px;">
                                    <span>������¼</span>
                                </button>
                            </div>
                            <div class="col-xs-12" style="font-size: 10px; margin-top: 10px; padding: 5px; border-top: 1px solid #dcdcdc;">
                                <div class="col-xs-8">
                                    <a href="http://www.gobiding.com" id="lnkregist">��û���˺ţ���ע��</a>
                                </div>
                                <div class="col-xs-4" style="text-align: right;">
                                    <a href="ForgetPassword.html" id="lnkforget">��������</a>
                                </div>
                            </div>
                            <div class="col-xs-12" align="right" style="font-size: 11px; padding: 10px; color: #333;">
                            </div>
                           <div style="float: left; padding-left: 15px; width: 50px; height: 50px;">
                                    <a id="qqAuthorizationUrl" href="/ThirdLogin/qq" class="qq">
                                        <img src="/imgs/system/3rdlogin/qq.png" width="40" height="40" /></a>
                                </div>
                                <div style="float: left; padding-left: 15px; width: 50px; height: 50px;">
                                    <a id="linkwx" href="/ThirdLogin/wx" class="wx" style="width: 40px; height: 40px;">
                                        <img src="/imgs/system/3rdlogin/WX.png" width="40" height="40" /></a>
                                </div>
                                   <div style="float: left; padding-left: 15px; width: 50px; height: 50px;">
                                    <a id="A1" href="/ThirdLogin/xl" class="xl" style="width: 40px; height: 40px;">
                                        <img src="/imgs/system/3rdlogin/xl.png" width="40" height="40" /></a>
                                </div>
                            <%--  <div style="padding-left: 10px;">
                                <a href="#" onclick='toLogin()'>
                                    <img src="/imgs/system/Connect_logo_1.png" alt=""></a>
                            </div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="container">
        <div class="row">
            <div style="margin: 0px auto; font-family: ΢���ź�;">
                <div style="width: 25%; float: left;">
                    <div style="width: 30px; height: 30px; line-height: 28px; font-weight: bold; color: #428bca;
                        border-radius: 15px; border: 2px solid #428bca; text-align: center;">
                        1</div>
                    <div style="border-top: 2px solid #428bca; position: relative; top: -18px; left: 36px;
                        width: 80%;">
                        <div style="padding: 10px; font-weight: bold; font-size: 16px; color: #333;">
                            ע���Ա</div>
                    </div>
                    <div style="width: 80%; line-height: 24px; color: #999;">
                        �����ΪȥͶ������Ա�ȿ���Ѳ鿴����������Ͷ�꼰�ɹ���Ϣ�������б������ʵ����֤
                    </div>
                </div>
                <div style="width: 25%; float: left;">
                    <div style="width: 30px; height: 30px; line-height: 28px; font-weight: bold; color: #428bca;
                        border-radius: 15px; border: 2px solid #428bca; text-align: center;">
                        2</div>
                    <div style="border-top: 2px solid #428bca; position: relative; top: -18px; left: 36px;
                        width: 80%;">
                        <div style="padding: 10px; font-weight: bold; font-size: 16px; color: #333;">
                            �����б�</div>
                    </div>
                    <div style="width: 80%; line-height: 24px; color: #999;">
                        ÿ�ո���1����ȫ���б�ɹ���Ϣ��֧�ֹؼ��ʶ�ά��ȫ�ļ��������뼶��Ӧ����
                    </div>
                </div>
                <div style="width: 25%; float: left;">
                    <div style="width: 30px; height: 30px; line-height: 28px; font-weight: bold; color: #428bca;
                        border-radius: 15px; border: 2px solid #428bca; text-align: center;">
                        3</div>
                    <div style="border-top: 2px solid #428bca; position: relative; top: -18px; left: 36px;
                        width: 80%;">
                        <div style="padding: 10px; font-weight: bold; font-size: 16px; color: #333;">
                            �����б�</div>
                    </div>
                    <div style="width: 80%; line-height: 24px; color: #999;">
                        ע���Ա���ݹؼ��ʡ���������ҵ�����������б궩�ģ�ϵͳ���������Ͷ����б���Ϣ����
                    </div>
                </div>
                <div style="width: 25%; float: left;">
                    <div style="width: 30px; height: 30px; line-height: 28px; font-weight: bold; color: #428bca;
                        border-radius: 15px; border: 2px solid #428bca; text-align: center;">
                        4</div>
                    <div style="border-top: 2px solid #428bca; position: relative; top: -18px; left: 36px;
                        width: 80%;">
                        <div style="padding: 10px; font-weight: bold; font-size: 16px; color: #333;">
                            ���ⶨ��</div>
                    </div>
                    <div style="width: 80%; line-height: 24px; color: #999;">
                        �߼���Ա�������ܶ��Ʒ���רҵ����һ��һ��ר��������ָ����ע���б�վ����Ϣ
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div style="border-top: 1px solid #fafafa; width: 100%; text-align: center; background-color: #242735;
        color: #fff; margin-top: 20px; padding-bottom: 20px;">
        <div style="width: 100%; text-align: center; padding-top: 20px; font-family: '΢���ź�'">
            <div style="line-height: 24px; margin: 0px auto; font-size: 12px;">
                ȥͶ�������Ϻ���´����Ƽ����޹�˾��All Rights Reserved<br />
                2015-2017 gobiding.com ��Ȩ���� ICP֤����ICP��15005938��-3
            </div>
        </div>
    </div>
    <script src="/js/thirdplugin.js" type="text/javascript"></script>
    <script src="/js/login.js" type="text/javascript"></script>
    <script>
        $("#txtUserCheckCode").keydown(function (e) {
            if (e.keyCode == 13) {
                $("#btnLogin").click();
            }
        });
    </script>
    </form>
</body>
</html>
