<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSubCategoryList.ascx.cs"
    Inherits="GoBiding.Web.UserCenter.Index.ucSubCategoryList" %>
<style type="text/css">
    #ulCategoryList {
        text-decoration: none;
        list-style: none;
        text-align:left;
        float: left;
        margin-top: 10px;
        margin-left: 0px;
        padding-left: 10px;
        padding-right:50px;
        width:480px;
    }
    #ulCategoryList li {
        display: inline;
        line-height: 20px;
        height: 20px;
        margin-top: 10px;
        text-align: center;
        margin-right: 20px;
    }
</style>
<ul id="ulCategoryList">
    <asp:Repeater ID="rptSubCategoryList" runat="server">
        <ItemTemplate>
            <li value="<%# Eval("ParentCategoryId")%>">
                 <a href='/BidList.aspx?industry=<%# Eval("ParentCategoryId")%>' style="text-decoration: none; color: #666;">
                 <%# Eval("BidCategoryName")%></a>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
