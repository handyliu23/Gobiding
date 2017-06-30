<%@ Page Title="Sys_Users" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="GoBiding.Web.Sys_Users.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--Title -->

            <!--Title end -->

            <!--Add  -->

            <!--Add end -->

            <!--Search -->
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td style="width: 80px" align="right" class="tdbg">
                         <b>关键字：</b>
                    </td>
                    <td class="tdbg">                       
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询"  OnClick="btnSearch_Click" >
                    </asp:Button>                    
                        
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="Sys_UserId" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="UserNickName" HeaderText="UserNickName" SortExpression="UserNickName" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="UserGUID" HeaderText="UserGUID" SortExpression="UserGUID" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="UserProfile" HeaderText="UserProfile" SortExpression="UserProfile" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ContacterName" HeaderText="ContacterName" SortExpression="ContacterName" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="TelephonePhone" HeaderText="TelephonePhone" SortExpression="TelephonePhone" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="TelephonePhone2" HeaderText="TelephonePhone2" SortExpression="TelephonePhone2" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MobilePhone" HeaderText="MobilePhone" SortExpression="MobilePhone" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MobilePhone2" HeaderText="MobilePhone2" SortExpression="MobilePhone2" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="QQ" HeaderText="QQ" SortExpression="QQ" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="DistrictId" HeaderText="DistrictId" SortExpression="DistrictId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="OnCreate" HeaderText="OnCreate" SortExpression="OnCreate" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Deleted" HeaderText="Deleted" SortExpression="Deleted" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ManufacturerGUID" HeaderText="ManufacturerGUID" SortExpression="ManufacturerGUID" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="PostCode" HeaderText="PostCode" SortExpression="PostCode" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="WebSite" HeaderText="WebSite" SortExpression="WebSite" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="DisplayOrder" HeaderText="DisplayOrder" SortExpression="DisplayOrder" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Scores" HeaderText="Scores" SortExpression="Scores" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="LoginIp" HeaderText="LoginIp" SortExpression="LoginIp" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="LastLoginTime" HeaderText="LastLoginTime" SortExpression="LastLoginTime" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="LevelId" HeaderText="LevelId" SortExpression="LevelId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="LastLoginIp" HeaderText="LastLoginIp" SortExpression="LastLoginIp" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="DefaultAddressId" HeaderText="DefaultAddressId" SortExpression="DefaultAddressId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="RecommenderId" HeaderText="RecommenderId" SortExpression="RecommenderId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="UserLoginType" HeaderText="1:QQ,2:新浪微博" SortExpression="UserLoginType" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="OpenId" HeaderText="OpenId" SortExpression="OpenId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="AccessToken" HeaderText="AccessToken" SortExpression="AccessToken" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="RecommendUserId" HeaderText="RecommendUserId" SortExpression="RecommendUserId" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="Sys_UserId" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="Sys_UserId" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                                Text="编辑"  />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"   Visible="false"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                         Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                </asp:GridView>
               <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td align="left">
                        <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"/>                       
                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
