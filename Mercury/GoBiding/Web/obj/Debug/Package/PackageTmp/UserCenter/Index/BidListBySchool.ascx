<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BidListBySchool.ascx.cs"
    Inherits="GoBiding.Web.UserCenter.Index.BidListBySchool" %>
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
    <div class="col-lg-12" id="tablecontent">
        <table id="bidlisttypediv1">
            <asp:Repeater runat="server" ID="rptBidList">
                <ItemTemplate>
                    <tr>
                        <td style="width: 100%; font-family: '微软雅黑'; line-height: 25px; height: 25px; vertical-align: top; border:0px;">
                            <font style="font-size: 12px; color: #000">
                                [<%#Eval("BidPublishTime", "{0:D}")%>]</font> &nbsp; <a target="_blank" href='/BidDetail/<%#Eval("BidId")%>.html'
                                    style="font-size: 12px; text-decoration: none; color: #000; font-weight: 500;">
                                    <%#Eval("BidTitle").ToString().Length > 24 ? Eval("BidTitle").ToString().Substring(0, 24) + "..." : Eval("BidTitle").ToString()%></a><br />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
