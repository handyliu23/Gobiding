<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="GoBiding.Web.Sys_Users.Modify" Title="修改页" %>
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
		<asp:label id="lblSys_UserId" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UserNickName
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUserNickName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UserGUID
	：</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblUserGUID" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Password
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPassword" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UserName
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUserName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Description
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDescription" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UserProfile
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUserProfile" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Gender
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtGender" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Address
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtAddress" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ContacterName
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtContacterName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TelephonePhone
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTelephonePhone" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TelephonePhone2
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTelephonePhone2" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MobilePhone
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMobilePhone" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		MobilePhone2
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMobilePhone2" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Email
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtEmail" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QQ
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtQQ" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Fax
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFax" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DistrictId
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDistrictId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OnCreate
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtOnCreate" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Deleted
	：</td>
	<td height="25" width="*" align="left">
		<asp:CheckBox ID="chkDeleted" Text="Deleted" runat="server" Checked="False" />
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ManufacturerGUID
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtManufacturerGUID" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PostCode
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPostCode" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		WebSite
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtWebSite" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Notes
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtNotes" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DisplayOrder
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDisplayOrder" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Scores
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtScores" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LoginIp
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtLoginIp" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LastLoginTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtLastLoginTime" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LevelId
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtLevelId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LastLoginIp
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtLastLoginIp" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DefaultAddressId
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDefaultAddressId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RecommenderId
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtRecommenderId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		1:QQ,2:新浪微博
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUserLoginType" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OpenId
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtOpenId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		AccessToken
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtAccessToken" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RecommendUserId
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtRecommendUserId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
</table>
<script src="/js/calendar1.js" type="text/javascript"></script>

            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="保存"
                    OnClick="btnSave_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                <asp:Button ID="btnCancle" runat="server" Text="取消"
                    OnClick="btnCancle_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>

