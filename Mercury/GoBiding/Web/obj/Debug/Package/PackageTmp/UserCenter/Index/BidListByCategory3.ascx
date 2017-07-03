<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BidListByCategory3.ascx.cs"
    Inherits="GoBiding.Web.UserCenter.Index.BidListByCategory3" %>
<style>
    .bidlabel
    {
        margin-left: 0px;
        border: 1px solid green;
        padding: 5px 10px 5px 0px;
        font-size: 12px;
    }
    .bidlisttypetable td
    {
        background-color: #fafafa;
        line-height: 40px;
        height: 40px;
        text-align: center;
        font-size: 12px;
        border-bottom: 2px solid #fafafa;
        color: #333;
        font-weight: bold;
    }
    .bidlisttypetable .bidlisttypetableactive
    {
        background-color: #000;
        color: #fff;
    }
</style>
<br />
<div class="col-lg-12">
    <table style="width: 100%;">
        <tr>
            <td style="width: 50%; vertical-align: top;">
                <div style="border-left: 4px solid #000; font-weight: 700; font-size: 14px; padding-left: 10px;
                    padding-top: 0px; margin-top: 10px; color: #000; font-family: '微软雅黑';">
                    <%= CategoryName %>
                    <span style="font-size: 12px;">
                        <%= CategoryEnglishName %>
                    </span>
                </div>
                <div style="width: 100%; padding-top: 10px;">
                    <div class="col-lg-12" id="tablecontent">
                        <table id="bidlisttypediv1">
                            <asp:Repeater runat="server" ID="rptBidList">
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 100%; font-family: '微软雅黑'; line-height: 25px; height: 25px; vertical-align: top;">
                                            <font style="font-size: 12px; color: #000">
                                                <%#Eval("BidPublishTime", "{0:D}")%></font> <a target="_blank" href='/BidDetail/<%#Eval("BidId")%>.html'
                                                    style="font-size: 12px; text-decoration: none; color: #000; font-weight: 500;">
                                                    <%#Eval("BidTitle").ToString().Length > 36 ? Eval("BidTitle").ToString().Substring(0, 36) + "..." : Eval("BidTitle").ToString()%></a><br />
                                            <%--  <span class="bidlabel">类型 |
                                    <%#GetBidTypeValue(Eval("BidType").ToString())%></span> <span class="bidlabel">地区 |
                                        <%#GetProvinceName(Eval("ProvinceId").ToString())%></span> <span class="bidlabel">编号
                                            <%#Eval("BidNumber")%></span> <span class="bidlabel" style='display: <%# Eval("BidCompanyName") == "" ? "none":""%>'>
                                                <a href='/CompanyBidList.aspx?CompanyName=<%#Eval("BidCompanyName") %>' style='color: green;
                                                    text-decoration: none;'>招标人 |
                                                    <%# Eval("BidCompanyName").ToString().Length > 10 ? Eval("BidCompanyName").ToString().Substring(0, 10) +"...": Eval("BidCompanyName").ToString()%></a></span>--%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
            </td>
            <td style="width: 50%; vertical-align: top;">
                <div style="border-left: 4px solid #000; font-weight: 700; font-size: 14px; padding-left: 10px;
                    padding-top: 0px; margin-top: 10px; color: #000; font-family: '微软雅黑';">
                    最新中标公告 <span style="font-size: 12px;">
                        <%= CategoryEnglishName %>
                    </span>
                </div>
                <div style="width: 100%; padding-top: 10px;">
                    <div class="col-lg-12" id="Div1">
                        <table id="Table1">
                            <asp:Repeater runat="server" ID="rptBidResultList">
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 100%; font-family: '微软雅黑'; line-height: 25px; height: 25px; vertical-align: top;">
                                            <font style="font-size: 12px; color: #000">
                                                <%#Eval("BidPublishTime", "{0:D}")%></font> <a href='/BidDetail/<%#Eval("BidId")%>.html'
                                                    style="font-size: 12px; text-decoration: none; color: #000; font-weight: 500;">
                                                    <%#Eval("BidTitle").ToString().Length > 36 ? Eval("BidTitle").ToString().Substring(0, 36) + "..." : Eval("BidTitle").ToString()%></a><br />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</div>
