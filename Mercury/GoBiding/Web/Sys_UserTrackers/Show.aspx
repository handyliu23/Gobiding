<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="GoBiding.Web.Sys_UserTrackers.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		UserTrackerId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUserTrackerId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TrackerName
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTrackerName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TrackerCityIds
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTrackerCityIds" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TrackerIndustryIds
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTrackerIndustryIds" runat="server"></asp:Label>
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
		Keyword1
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblKeyword1" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Keyword2
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblKeyword2" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Keyword3
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblKeyword3" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Keyword4
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblKeyword4" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Keyword5
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblKeyword5" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Sys_UserId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSys_UserId" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




