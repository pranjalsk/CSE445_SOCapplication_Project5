<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryItEncryptionDLL.aspx.cs" Inherits="RentalHousingWebApp.PresentationLayer.TryItEncryptionDLL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Encryption DLL library try it page</h3>
        <asp:TextBox ID="txt_encryptiontext" runat="server" Width="232px"></asp:TextBox>
        *<br />
        <asp:Button ID="btn_encypt" runat="server" Text="Encrypt" OnClick="btn_encypt_Click" />
        <br />
        Encrypted Text:&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lbl_encryptedtext" runat="server" Text=""></asp:Label>
        <br />
        <br />
        Decrypted Text:&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lbl_decryptedtext" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
