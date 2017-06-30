<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="GoBiding.Web.Spiders.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		SpiderId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSpiderId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SpiderName
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSpiderName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SpiderUrl
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSpiderUrl" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CreateTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCreateTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		EncodeType
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblEncodeType" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ListExpression
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblListExpression" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DetailExpression
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDetailExpression" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SpiderUrlPrefix
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSpiderUrlPrefix" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DistrictId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDistrictId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CityId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCityId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ProvinceId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblProvinceId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TitleExpression
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTitleExpression" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PublishExpression
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPublishExpression" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ContentExpression
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblContentExpression" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SourceExpression
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSourceExpression" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FilenameExpressoin
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFilenameExpressoin" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidType
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidType" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Status
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblStatus" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		HttpMethod
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblHttpMethod" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PageParameter
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPageParameter" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IsActive
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblIsActive" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SpiderType
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSpiderType" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PageCount
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPageCount" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




