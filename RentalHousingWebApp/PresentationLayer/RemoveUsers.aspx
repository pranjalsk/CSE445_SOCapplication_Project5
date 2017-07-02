<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoveUsers.aspx.cs" Inherits="RentalHousingWebApp.PresentationLayer.RemoveUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script lang="Javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
    <style>
        body {
            background: #eee !important;
        }

        .wrapper {
            margin: 10px 10px 10px 10px;
            padding: 10px 10px 10px 10px;
        }
        
footer {
    background: white;
    color: black;
    text-shadow: none;
    opacity: 0.5;
    position: absolute;
    bottom: 0;
    left: 0;
    right: 0;
    padding: 10px;
    font-size: 0.8em;
}
    </style>
    <title>Remove Users</title>
</head>
<body class="container">
    <form id="form1" runat="server">
    <div class="wrapper">
         <h3>Remove User!</h3>
            <div>
                UserName:&nbsp;&nbsp;
                    <asp:TextBox ID="txt_userName" runat="server"></asp:TextBox><br />
                <asp:Label ID="lbl_error_inputBoxes" runat="server" ForeColor="#990000" Text="All fields are mandatory"></asp:Label>
                <br />
            </div>
            <div>
                <asp:Button ID="btn_removeNow" CssClass="btn btn-sm btn-primary wrapper" runat="server" Text="Remove This User" OnClick="btn_removeNow_Click"/><br />
                <asp:Label ID="lbl_RemoveSuccessMsg" runat="server" Text="-"></asp:Label><br />
                <textarea id="txt_UsersAfterRemoval" runat="server" cols="50" rows="4" placeholder="Users remaining after removal" readonly="readonly"></textarea>
            </div>
    </div>
         <br />
            <br />
            <div>
                <footer>
                <asp:Button ID="btn_logout" runat="server" Text="Logout" OnClick="btn_logout_Click"/>
                <asp:Button ID="btn_landingPage" runat="server" Text="Landing Page" OnClick="btn_landingPage_Click"/>
      </footer>
            </div>
    </form>
</body>
</html>
