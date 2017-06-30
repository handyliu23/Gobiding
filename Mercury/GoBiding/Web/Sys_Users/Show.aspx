<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="GoBiding.Web.Sys_Users.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		Sys_UserId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSys_UserId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UserNickName
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUserNickName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UserGUID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUserGUID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Password
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPassword" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UserName
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUserName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Description
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDescription" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UserProfile
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUserProfile" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Gender
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGender" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Address
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAddress" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ContacterName
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblContacterName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TelephonePhone
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTelephonePhone" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TelephonePhone2
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTelephonePhone2" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MobilePhone
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMobilePhone" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MobilePhone2
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMobilePhone2" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Email
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblEmail" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QQ
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblQQ" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Fax
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblFax" runat="server"></asp:Label>
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
		OnCreate
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblOnCreate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Deleted
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDeleted" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ManufacturerGUID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblManufacturerGUID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PostCode
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPostCode" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		WebSite
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblWebSite" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Notes
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblNotes" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DisplayOrder
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDisplayOrder" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Scores
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblScores" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LoginIp
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLoginIp" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LastLoginTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLastLoginTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LevelId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLevelId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LastLoginIp
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLastLoginIp" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DefaultAddressId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDefaultAddressId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RecommenderId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRecommenderId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		1:QQ,2:新浪微博
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUserLoginType" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OpenId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblOpenId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		AccessToken
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAccessToken" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RecommendUserId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRecommendUserId" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




