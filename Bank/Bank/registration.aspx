<%@ Page Language="C#" Async="true" CodeBehind="registration.aspx.cs" Inherits="Bank.registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label1" runat="server" Text="логин"></asp:Label>
                    </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label2" runat="server" Text="пароль"></asp:Label>
                    </asp:TableCell>
               <asp:TableCell>
                   <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
               </asp:TableCell>
                    </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="3" HorizontalAlign="Right">
                        <asp:Button ID="Button1" runat="server"  Text="зарегистрироваться" OnClick="Button1_Click1" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
