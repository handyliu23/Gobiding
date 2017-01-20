<%@ Page Title="Bids" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Mercury.Web.Bids.List" %>
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
                    BorderWidth="1px" DataKeyNames="BidId" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="BidTitle" HeaderText="BidTitle" SortExpression="BidTitle" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="BidPublishTime" HeaderText="BidPublishTime" SortExpression="BidPublishTime" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="BidContent" HeaderText="BidContent" SortExpression="BidContent" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="CityId" HeaderText="CityId" SortExpression="CityId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ProvinceId" HeaderText="ProvinceId" SortExpression="ProvinceId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="BidNumber" HeaderText="BidNumber" SortExpression="BidNumber" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="BidExpireTime" HeaderText="BidExpireTime" SortExpression="BidExpireTime" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="BidFileName" HeaderText="BidFileName" SortExpression="BidFileName" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="BidProjectName" HeaderText="BidProjectName" SortExpression="BidProjectName" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="BidAgent" HeaderText="BidAgent" SortExpression="BidAgent" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="BidKeywords" HeaderText="BidKeywords" SortExpression="BidKeywords" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="BidContacter" HeaderText="BidContacter" SortExpression="BidContacter" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="BidContacterMobile" HeaderText="BidContacterMobile" SortExpression="BidContacterMobile" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="BidContacterTel" HeaderText="BidContacterTel" SortExpression="BidContacterTel" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="BidContacterAddress" HeaderText="BidContacterAddress" SortExpression="BidContacterAddress" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="BidContacterURL" HeaderText="BidContacterURL" SortExpression="BidContacterURL" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="BidSourceURL" HeaderText="BidSourceURL" SortExpression="BidSourceURL" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="BidSourceName" HeaderText="BidSourceName" SortExpression="BidSourceName" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="CreateTime" HeaderText="CreateTime" SortExpression="CreateTime" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="LastChangeTime" HeaderText="LastChangeTime" SortExpression="LastChangeTime" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="BidId" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="BidId" DataNavigateUrlFormatString="Modify.aspx?id={0}"
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
