<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Mercury.Web.Bids.Modify" Title="修改页" %>
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
		<asp:label id="lblBidId" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidTitle
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBidTitle" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidPublishTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtBidPublishTime" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidContent
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBidContent" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CityId
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCityId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ProvinceId
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtProvinceId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidNumber
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBidNumber" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidExpireTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtBidExpireTime" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidFileName
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBidFileName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidProjectName
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBidProjectName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidAgent
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBidAgent" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidKeywords
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBidKeywords" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidContacter
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBidContacter" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidContacterMobile
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBidContacterMobile" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidContacterTel
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBidContacterTel" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidContacterAddress
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBidContacterAddress" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidContacterURL
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBidContacterURL" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidSourceURL
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBidSourceURL" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidSourceName
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBidSourceName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CreateTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtCreateTime" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LastChangeTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtLastChangeTime" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
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

