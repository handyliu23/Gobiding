<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Bottom.ascx.cs" Inherits="GoBiding.Web.wap.UserControls.Bottom" %>
<style>
    #bottomNav table td
    {
        border-color: #fafafa;
        padding: 2px;
        font-size: 10px;
    }
</style>
<div id="bottomNav" style="border-top:1px solid #eee;">
    <table style="width: 100%; margin: 0px auto; padding: 0px; margin-top: 0px; margin-bottom: 0px; border:0px;">
        <tr>
            <td style="width: 24%; text-align: center;border-right:1px solid #ececec;">
                <a href="/wap/Subscribe.aspx">
                    <table style="margin: 0px auto; padding: 0px; border:0px; margin-top: 0px; margin-bottom: 0px; ">
                        <tr>
                            <td style="height: 40px; line-height: 40px; vert-align: middle; width: 20px;">
                                <img src="Imgs/list_16.png" alt=""/>
                            </td>
                            <td style="height: 40px; line-height: 40px; vert-align: middle;">
                                我的订阅
                            </td>
                        </tr>
                    </table>
                </a>
            </td>
            <td style="width: 24%; border-right:1px solid #ececec; text-align: center;">
                <a href="/wap/FavouriteList.aspx">
                    <table style="margin: 0px auto; padding: 0px; margin-top: 0px; margin-bottom: 0px;">
                        <tr>
                            <td style="height: 40px; line-height: 40px; vert-align: middle; width: 20px;">
                                <img src="Imgs/history_16.png" alt=""/>
                            </td>
                            <td>
                                我的收藏
                            </td>
                        </tr>
                    </table>
                </a>
            </td>
            <td style="width: 24%; border-right:1px solid #ececec; text-align: center;">
                 <a href="/wap/Default.aspx"><table style="margin: 0px auto; padding: 0px; border:0px; margin-top: 0px; margin-bottom: 0px;">
                    <tr>
                        <td style="height: 40px; line-height: 40px; vert-align: middle; width: 20px;">
                            <img src="Imgs/category_16.png" alt="" />
                        </td>
                        <td>
                            招标大厅
                        </td>
                    </tr>
                </table></a>
            </td>
             <td style="width: 24%; text-align: center;">
                <a href="/wap/Suggest.aspx">
                <table style="margin: 0px auto; padding: 0px;border:0px; margin-top: 0px; margin-bottom: 0px;">
                    <tr>
                        <td style="height: 40px; line-height: 40px; vert-align: middle; width: 20px;">
                            <img src="Imgs/sugges_16.png" alt=""/>
                        </td>
                        <td>
                            我要报错
                        </td>
                    </tr>
                </table></a>
            </td>
        </tr>
    </table>
</div>
<style type="text/css">
    body
    {
        background-attachment: fixed;
    }
    #bottomNav
    {
        font-size: 13px;
        text-align: center;
        background-color: #fff;
        z-index: 999;
        position: fixed;
        bottom: 0;
        left: 0;
        width: 100%;
        _position: absolute;
        _top: expression_r(documentElement.scrollTop + documentElement.clientHeight-this.offsetHeight);
        overflow-x: hidden;
        filter: alpha(opacity=100);
        -moz-opacity: 1;
        -khtml-opacity: 1;
        opacity: 1;
    }
</style>
