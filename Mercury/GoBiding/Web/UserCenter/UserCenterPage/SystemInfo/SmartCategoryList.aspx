<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SmartCategoryList.aspx.cs" Inherits="GoBiding.Web.UserCenter.UserCenterPage.SystemInfo.SmartCategoryList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
           <asp:ListView runat="server" ID="lstSmartCategorys" 
               onitemcommand="lstSmartCategorys_ItemCommand">
            <LayoutTemplate>
                <table>
                   <asp:PlaceHolder ID="itemPlaceholder" runat="server" />  
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td style="width: 120px;">
                    <a href="/Tools/SmartCategoryList.aspx?cId=<%#Eval("BidCategoryId") %>">
                        <asp:Label ID="lblBidCategoryName" runat="server" Text='<%# Eval("BidCategoryName") %>' /></a>
                    </td>
                    <td style="width: 600px;">
                        <asp:TextBox runat="server" TextMode="MultiLine" Text='<%# Eval("Keywords") %>' Width="1000" Height="100" ID="txtKeywords"></asp:TextBox>
                    </td>
                    <td>
                        <asp:HiddenField runat="server" ID="hdfKeyId" Value='<%# Eval("SmartCategoryId") %>' />
                        <asp:LinkButton runat="server" CommandName="SAVE" Text="保存"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        
    </div>
    </form>
</body>
</html>
