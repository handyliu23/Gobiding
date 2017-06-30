<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BidListByCategory2.ascx.cs"
    Inherits="GoBiding.Web.UserCenter.Index.BidListByCategory2" %>
<style>
            .bidlabel
        {
            margin-left: 10px;
            border: 1px solid green;
            padding: 5px 10px 5px 10px;
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
<script type="text/javascript">
    $(document).ready(function () {
        $(".bidlisttypetable td").hover(function () {
            $(this).parent().parent().find("td").removeClass("bidlisttypetableactive");
            $(this).addClass("bidlisttypetableactive");

            $(this).parent().parent().parent().parent().parent().find("#tablecontent").find("table").hide();
            $(this).parent().parent().parent().parent().parent().find("#tablecontent").find("#bidlisttypediv" + $(this).attr("id")).show();
        });
    });
</script>
<div class="col-lg-12">
    <br />
    <div style="border-bottom: 3px solid #111; height: 40px; font-weight: 700; font-size: 18px;
                                      padding-top: 0px; margin-top: 10px; color: #111;">
        <%= CategoryName %>
        <span style="font-size: 12px;">
            <%= CategoryEnglishName %>
        </span>
    </div>
    <div style="width: 100%;">
        <div class="col-lg-2" style="padding: 2px;">
            <table style="width: 100%;" class="bidlisttypetable">
                <tr>
                    <td id="1" class="bidlisttypetableactive">
                        招标公告
                    </td>
                </tr>
            </table>
        </div>
        <div class="col-lg-10" id="tablecontent">
            <table id="bidlisttypediv1">
                <asp:Repeater runat="server" ID="rptBidList">
                    <ItemTemplate>
                        <tr>
                            <td style="width: 90%; line-height: 35px; vertical-align: top;">
                                <a href='/BidDetail.aspx?bId=<%#Eval("BidId")%>'  target="_blank" style="font-size: 14px; text-decoration: none;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                               color: #444; font-weight: 500;">
                                    <%#Eval("BidTitle").ToString().Length > 50 ? Eval("BidTitle").ToString().Substring(0, 50) + "..." : Eval("BidTitle").ToString()%></a><br />
                                <span class="bidlabel">类型 |
                                    <%#GetBidTypeValue(Eval("BidType").ToString())%></span> <span class="bidlabel">地区 |
                                        <%#GetProvinceName(Eval("ProvinceId").ToString())%></span> <span class="bidlabel">编号
                                            <%#Eval("BidNumber")%></span> <span class="bidlabel" style='display: <%# Eval("BidCompanyName") == "" ? "none":""%>'>
                                                <a href='/CompanyBidList.aspx?CompanyName=<%#Eval("BidCompanyName") %>' style='color: green;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               text-decoration: none;'>招标人 |
                                                    <%# Eval("BidCompanyName").ToString().Length > 10 ? Eval("BidCompanyName").ToString().Substring(0, 10) +"...": Eval("BidCompanyName").ToString()%></a></span>
                            </td>
                            <td style="width: 120px; height: 60px; font-size: 12px; line-height: 60px;">
                                <%#Eval("BidPublishTime", "{0:D}")%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 10px; border-bottom: 1px solid #fafafa;">
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>
</div>
