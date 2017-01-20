<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BidList.aspx.cs" Inherits="Mercury.Web.BidList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bidlist.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <th>spidername</th>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlSpiderNameList"/>
                    </td>
                    <th></th>
                    <td></td>
                    <th></th>
                    <td></td>
                    <th></th>
                    <td>
                        <asp:Button runat="server" ID="btnSearch" Text="查询" onclick="btnSearch_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    <div>
        <asp:GridView runat="server" AllowPaging="True" PageSize="20" AutoGenerateColumns="False"
            ID="dgBidList" OnPageIndexChanging="dgBidList_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="BidId" HeaderText="BidId"></asp:BoundField>
                <asp:TemplateField HeaderText="标题">
                    <ItemTemplate>
                          <%# "<a href=\"BidDetail.aspx?bId=" + Eval("bidId") + "\">" +  Eval("BidTitle") + "</a>"%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="BidType" HeaderText="招标类型">
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="发布时间" DataField="BidPublishTime"></asp:BoundField>
                <asp:BoundField DataField="ProvinceId" HeaderText="省"></asp:BoundField>
                <asp:BoundField DataField="CityId" HeaderText="市"></asp:BoundField>
                <asp:BoundField DataField="BidSourceName" HeaderText="发布源"></asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
