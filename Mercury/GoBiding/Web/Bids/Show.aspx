<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="GoBiding.Web.Bids.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		BidId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidTitle
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidTitle" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidPublishTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidPublishTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidContent
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidContent" runat="server"></asp:Label>
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
		BidNumber
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidNumber" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidExpireTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidExpireTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidFileName
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidFileName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidProjectName
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidProjectName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidAgent
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidAgent" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidKeywords
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidKeywords" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidContacter
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidContacter" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidContacterMobile
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidContacterMobile" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidContacterTel
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidContacterTel" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidContacterAddress
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidContacterAddress" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidContacterURL
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidContacterURL" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidSourceURL
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidSourceURL" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidSourceName
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidSourceName" runat="server"></asp:Label>
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
		LastChangeTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLastChangeTime" runat="server"></asp:Label>
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
		BidFileNameURI
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidFileNameURI" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidSpiderName
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidSpiderName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidCategoryId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidCategoryId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidCompanyId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidCompanyId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidCompanyName
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidCompanyName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidOpenTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidOpenTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidPlatFrom
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBidPlatFrom" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




