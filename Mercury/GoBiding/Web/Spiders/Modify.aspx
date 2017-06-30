<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="GoBiding.Web.Spiders.Modify" Title="修改页" %>
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
		<asp:label id="lblSpiderId" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SpiderName
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtSpiderName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SpiderUrl
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtSpiderUrl" runat="server" Width="200px"></asp:TextBox>
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
		EncodeType
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtEncodeType" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ListExpression
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtListExpression" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DetailExpression
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDetailExpression" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SpiderUrlPrefix
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtSpiderUrlPrefix" runat="server" Width="200px"></asp:TextBox>
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
		TitleExpression
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTitleExpression" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PublishExpression
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPublishExpression" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ContentExpression
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtContentExpression" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SourceExpression
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtSourceExpression" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FilenameExpressoin
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFilenameExpressoin" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BidType
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBidType" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Status
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtStatus" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		HttpMethod
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtHttpMethod" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PageParameter
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPageParameter" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IsActive
	：</td>
	<td height="25" width="*" align="left">
		<asp:CheckBox ID="chkIsActive" Text="IsActive" runat="server" Checked="False" />
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SpiderType
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtSpiderType" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PageCount
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPageCount" runat="server" Width="200px"></asp:TextBox>
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

