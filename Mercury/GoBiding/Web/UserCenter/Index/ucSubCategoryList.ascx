<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSubCategoryList.ascx.cs"
    Inherits="GoBiding.Web.UserCenter.Index.ucSubCategoryList" %>
<style type="text/css">
    #ulCategoryList
    {
        text-decoration: none;
        list-style: none;
        text-align: left;
        float: left;
        margin: 0px;
        padding: 0px;
        width: 600px;
    }
    #ulCategoryList li
    {
        float: left;
        display: inline;
        height:34px;
        text-align: center;
        width: 70px;
         line-height:34px;
    }
</style>
<ul id="ulCategoryList">
    <asp:Repeater ID="rptSubCategoryList" runat="server">
        <ItemTemplate>
            <li value="<%# Eval("ParentCategoryId")%>"><a href='/BidList.aspx?industry=<%# Eval("ParentCategoryId")%>'
                style="text-decoration: none; color: #666;">
                <%# Eval("BidCategoryName")%></a> </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
