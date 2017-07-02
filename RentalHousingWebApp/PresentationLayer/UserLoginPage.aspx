<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLoginPage.aspx.cs" Inherits="RentalHousingWebApp.PresentationLayer.UserLoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="assets/css/UserLoginStyle.css" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
  
    <title>User Login Page</title>
</head>
<body class="container">

    <h2 style="text-align:center">House Rental Application Login</h2>
    <div class="wrapper">
        <form class="form-signin container" runat="server">
            <h4 class="form-signin-heading">User Login</h4>
            <input type="text" id="txt_userName" class="form-control" runat="server" name="username" placeholder="username" autofocus="" />
            <input type="password" id="txt_password" class="form-control" runat="server" name="password" placeholder="Password" />
            <asp:Button ID="btn_login" CssClass="btn btn-lg btn-primary btn-block wrapper1" runat="server" Text="Login" OnClick="btn_login_Click" />
            <asp:Label ID="lbl_userLogin" runat="server" Text=""></asp:Label>
            <br />
            <h4 class="form-signin-heading">Register New User</h4>
            <input type="text" id="txt_firstname" class="form-control" runat="server" name="firstname" placeholder="Firstname" autofocus="" />
            <input type="text" id="txt_lastname" class="form-control" runat="server" name="lastname" placeholder="Lastname" autofocus="" />
            <input type="text" id="txt_registerUsername" class="form-control" runat="server" name="username" placeholder="username" autofocus="" />
            <input type="password" id="txt_registerPassword" class="form-control" runat="server" name="password" placeholder="Password" />
            <asp:Button ID="btn_register" CssClass="btn btn-lg btn-primary btn-block wrapper1" runat="server" Text="Register" OnClick="btn_register_Click" />
            <asp:Label ID="lbl_registerUser" runat="server" Text=""></asp:Label>
            <br />
            <h4 class="form-signin-heading">Staff Login</h4>
            <input type="text" id="txt_staffUsername" class="form-control" runat="server" name="username" placeholder="username" autofocus="" />
            <input type="password" id="txt_staffPassword" class="form-control" runat="server" name="password" placeholder="Password"/>
            <asp:Button ID="btn_StaffLogin" CssClass="btn btn-lg btn-primary btn-block wrapper1" runat="server" Text="Staff Login" OnClick="btn_StaffLogin_Click"/>
            <asp:Label ID="lbl_StaffLoginLabel" runat="server" Text=""></asp:Label>
        </form>
    </div>
</body>
</html>
