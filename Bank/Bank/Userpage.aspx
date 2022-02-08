    <       %@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="Userpage.aspx.cs" Inherits="Bank.Userpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="Table1" runat="server" style="margin-left: 20px;margin-top: 20px" >
                <asp:TableRow>
                    <asp:TableCell >
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                       
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="Button1" runat="server" Text="выйти" OnClick="Button1_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Image ID="Image1" ImageUrl="~/loginpicture.png" Height="150" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
