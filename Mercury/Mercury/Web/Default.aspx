<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" ValidateRequest="false"
    Inherits="Mercury.Web.Default" %>

<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>首页</title>
    <style>
        .bidlabel
        {
            border: 1px solid green;
            padding: 5px 10px 5px 10px;
            font-size: 12px;
            margin-right: 5px;
        }
        .dropdown_menu_item
        {
            padding: 5px;
        }
        .dropdown_menu_div
        {
            padding: 10px;
        }
        .bidcontenttable td
        {
            line-height: 30px;
            vertical-align: middle;
            height: 70px;
            padding: 10px 0px 10px 0px;
            border-bottom: 1px dashed #dcdcdc;
            font-size: 12px;
        }
        .bidcontenttable tr:hover
        {
            background-color: #eee;
        }
        .bidcontenttable td span
        {
            font-size: 11px;
            font-weight: normal;
        }
        .dropdown_content_areas
        {
            width: 100%;
        }
        .dropdown_content_areas th
        {
            padding-left: 10px;
            font-size: 11px;
            width: 70px;
            line-height: 30px;
        }
        .dropdown_content_areas td
        {
            font-size: 11px;
            min-width: 50px;
            color: #666;
        }
        .dropdown_content_areas td:hover
        {
            cursor: pointer;
        }
        .dropdown_menu_areas
        {
            width: 100px;
        }
        .ul_dropdown_industry li, .ul_dropdown_bidtype li, .ul_dropdown_usertype li
        {
            text-align: center;
            line-height: 30px;
            height: 30px;
        }
        .ul_dropdown_industry li:hover, .ul_dropdown_bidtype li:hover, .ul_dropdown_usertype li:hover
        {
            background-color: #FAFAFA;
            cursor: pointer;
        }
        .ul_dropdown_industry a, .ul_dropdown_bidtype a, .ul_dropdown_usertype a
        {
            color: #666;
            font-size: 11px;
        }
        .HeadImgTitle
        {
            font-size: 36px;
            font-weight: 800;
            line-height: 80px;
        }
        .HeadImgContent
        {
            font-size: 18px;
            line-height: 50px;
            font-weight: 500;
        }
        .box-body input
        {
            font-size: 14px;
        }
        .box-shadow-3
        {
            -webkit-box-shadow: 0 0 25px rgba(0, 255,255, .8);
            -moz-box-shadow: 0 0 25px rgba(0,255, 255, .8);
            box-shadow: 0 0 25px rgba(0, 255, 255, .8);
        }
        .protocoltitle
        {
            padding: 2px;
            font-weight: bold;
            color: dodgerblue;
        }
    </style>
    <script src="/js/jquery-3.1.1.min.js" type="text/javascript"></script>
    <script src="/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/bidlist.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <table>
            <tr>
                <th>
                    网站名
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtSpiderName" Width="200" Height="26"></asp:TextBox>
                </td>
                <th>
                    招标类型
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtBidType" Width="100" Height="26"></asp:TextBox>
                </td>
                <th>
                    地址
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtSpiderUrl" Width="400" Height="26"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    列表页地址表达式
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtListExpression" Width="300" Height="26"></asp:TextBox>
                </td>
                <th>
                    详情页表达式
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtDetailExpression" Width="300" Height="26"></asp:TextBox>
                </td>
                <th>
                    详情页URL前缀
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtSpiderUrlPrefix" Width="300" Height="26"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    TitleExpression
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtTitleExpression" TextMode="MultiLine" Width="300"
                        Height="60"></asp:TextBox>
                </td>
                <th>
                    PublishExpression
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtPublishExpression" Width="300" Height="26"></asp:TextBox>
                </td>
                <th>
                    SourceExpression
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtSourceExpression" Width="300" Height="26"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    FilenameExpressoin
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtFilenameExpressoin" Width="300" Height="26"></asp:TextBox>
                </td>
                <th>
                    ContentExpression
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtContentExpression" Width="300" Height="26"></asp:TextBox>
                </td>
                <th>
                    编码类型
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtEncodeing" Width="100" Height="26"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    所在地
                </th>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlProvince" Height="26" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlCity" Height="26" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlDistrinct" Height="26" runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <th>
                    爬虫类型
                </th>
                <td>
                    <asp:DropDownList runat="server" ID="ddlSpiderType" Height="26">
                        <asp:ListItem Text="分页式" Value="1"></asp:ListItem>
                        <asp:ListItem Text="增长式" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <th>
                    状态
                </th>
                <td>
                    <asp:DropDownList runat="server" ID="ddlStatus" Height="26">
                        <asp:ListItem Value="1">正常</asp:ListItem>
                        <asp:ListItem Value="0">异常</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    HttpMethod
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtHttpMethod" Width="100" Height="26"></asp:TextBox>
                </td>
                <th>
                    PageParameter
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtPageParameter" Width="300" Height="26"></asp:TextBox>
                </td>
                <th>
                    一次抓取页面数量
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtPageCount" Width="100" Height="26"></asp:TextBox>
                    每页记录数量
                    <asp:TextBox runat="server" ID="txtCountPerPage" Width="100" Height="26"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:HiddenField runat="server" ID="hdnSaveSpiderId" />
        <asp:Button runat="server" ID="btnSave" Text="保存" Height="30" OnClick="btnSave_Click" />
        <asp:Button runat="server" ID="btnSearch" Text="开始抓取" Height="30" OnClick="btnSearch_Click" />
        <asp:Label runat="server" ID="lblMessage"></asp:Label>
    </div>
    <br />
    <div>
        历史总共抓取数量：<asp:Literal runat="server" ID="ltrTotalCount"></asp:Literal></div>
    <div style="font-size: 12px; word-break: break-all">
        <asp:GridView runat="server" AllowPaging="False" PageSize="50" AutoGenerateColumns="False"
            ID="dgSpiders" OnRowCommand="dgSpiders_RowCommand">
            <Columns>
                <asp:BoundField DataField="SpiderId" HeaderText="ID"></asp:BoundField>
                <asp:BoundField DataField="SpiderName" HeaderText="名称">
                    <ItemStyle Width="200"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="SpiderUrl" HeaderText="抓取地址">
                    <ItemStyle Width="400"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="EncodeType" HeaderText="编码类型">
                    <ItemStyle Width="70"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="CreateTime" HeaderText="创建时间">
                    <ItemStyle Width="100"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="BidType" HeaderText="招标类型">
                    <ItemStyle Width="100"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <%# Eval("Status").ToString() == "1" ? "正常":"异常"%><br />
                        运行时间：<%#Eval("LastRunTime", "{0:yyyy-MM-dd HH:mm:ss}")%>
                    </ItemTemplate>
                    <ItemStyle Width="250"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="是否启用">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkActiveToggle" CommandName="ActiveToggleCommand" CommandArgument='<%#  Eval("SpiderId").ToString() %>'
                            runat="server" Text='<%# Eval("IsActive").ToString() == "True" ? "禁用":"启用"%>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="60"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="每页总数">
                    <ItemTemplate>
                        <%# Eval("CountPerPage").ToString()%>
                    </ItemTemplate>
                    <ItemStyle Width="80"></ItemStyle>
                </asp:TemplateField>
<%--                <asp:TemplateField HeaderText="抓取总数">
                    <ItemTemplate>
                        <%# GetCountBySpiderName(Eval("SpiderName").ToString())%>
                    </ItemTemplate>
                    <ItemStyle Width="80"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="当天抓取数">
                    <ItemTemplate>
                        <%# GetCountForCurrentDayBySpiderName(Eval("SpiderName").ToString())%>
                    </ItemTemplate>
                    <ItemStyle Width="80"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="抓取当天数">
                    <ItemTemplate>
                        <%# GetCountForBidCurrentDayBySpiderName(Eval("SpiderName").ToString())%>
                    </ItemTemplate>
                    <ItemStyle Width="80"></ItemStyle>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="爬虫类型">
                    <ItemTemplate>
                        <%# Eval("SpiderType").ToString().Equals("1") ? "分页":"增长"%>
                    </ItemTemplate>
                    <ItemStyle Width="60"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="标题">
                    <ItemTemplate>
                        <asp:LinkButton CommandName="DeleteCommand" CommandArgument='<%# Eval("SpiderId").ToString() %>'
                            runat="server" Text="删除"></asp:LinkButton>
                        <asp:LinkButton CommandName="EditCommand" CommandArgument='<%# Eval("SpiderId").ToString() %>'
                            runat="server" Text="编辑"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="120" HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="pull-right">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Width="100%" UrlPaging="true"
            CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList"
            PagingButtonSpacing="0" CurrentPageButtonClass="active" PageSize="60" OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
    </div>
    </form>
</body>
</html>
