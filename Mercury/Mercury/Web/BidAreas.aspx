<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BidAreas.aspx.cs" Inherits="Mercury.Web.BidAreas" %>

<%@ Register src="Controls/CitysControl.ascx" tagname="CitysControl" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>开通区域</title>
    <link href="css/bidlist.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ListView runat="server" ID="lstAreas">
            <LayoutTemplate>
                <table>
                   <asp:PlaceHolder ID="itemPlaceholder" runat="server" />  
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td style="width: 120px; color: <%# IsCoverd(Eval("ProvinceName").ToString()) ? "red" : "" %>">
                        <asp:Label ID="provinceName" runat="server" Text='<%# Eval("ProvinceName") %>' />
                    </td>
                    <td>
                        <uc1:CitysControl ID="citysControl" runat="server" ProvinceID='<%# int.Parse(Eval("ProvinceID").ToString())%>' />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        
    </div>
    </form>
</body>
</html>
