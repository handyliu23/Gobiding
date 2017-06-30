<%@ Page Title="Spiders" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="GoBiding.Web.Spiders.List" %>
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
                    BorderWidth="1px" DataKeyNames="SpiderId" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="SpiderName" HeaderText="SpiderName" SortExpression="SpiderName" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="SpiderUrl" HeaderText="SpiderUrl" SortExpression="SpiderUrl" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="CreateTime" HeaderText="CreateTime" SortExpression="CreateTime" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="EncodeType" HeaderText="EncodeType" SortExpression="EncodeType" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ListExpression" HeaderText="ListExpression" SortExpression="ListExpression" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="DetailExpression" HeaderText="DetailExpression" SortExpression="DetailExpression" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="SpiderUrlPrefix" HeaderText="SpiderUrlPrefix" SortExpression="SpiderUrlPrefix" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="DistrictId" HeaderText="DistrictId" SortExpression="DistrictId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="CityId" HeaderText="CityId" SortExpression="CityId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ProvinceId" HeaderText="ProvinceId" SortExpression="ProvinceId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="TitleExpression" HeaderText="TitleExpression" SortExpression="TitleExpression" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="PublishExpression" HeaderText="PublishExpression" SortExpression="PublishExpression" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ContentExpression" HeaderText="ContentExpression" SortExpression="ContentExpression" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="SourceExpression" HeaderText="SourceExpression" SortExpression="SourceExpression" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FilenameExpressoin" HeaderText="FilenameExpressoin" SortExpression="FilenameExpressoin" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="BidType" HeaderText="BidType" SortExpression="BidType" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="HttpMethod" HeaderText="HttpMethod" SortExpression="HttpMethod" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="PageParameter" HeaderText="PageParameter" SortExpression="PageParameter" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="SpiderType" HeaderText="SpiderType" SortExpression="SpiderType" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="PageCount" HeaderText="PageCount" SortExpression="PageCount" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="SpiderId" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="SpiderId" DataNavigateUrlFormatString="Modify.aspx?id={0}"
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
