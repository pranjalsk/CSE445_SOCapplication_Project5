<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLoginPage.aspx.cs" Inherits="RentalHousingWebApp.PresentationLayer.UserLoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="assets/css/UserLoginStyle.css" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>

    <title>Login Page</title>
</head>
<body class="container">

    <h2 style="text-align: center" class="lead"><a href="PublicPage.aspx"> House Rental Application</a></h2>
    <div class="wrapper">
        <form class="form-signin container" runat="server">
            <div>
                <h4 class="form-signin-heading">User Login</h4>
                <input type="text" id="txt_userName" class="form-control" runat="server" name="username" placeholder="Username" autofocus="" />
                <input type="password" id="txt_password" class="form-control" runat="server" name="password" placeholder="Password" />
                <asp:Button ID="btn_login" CssClass="btn btn-sm btn-primary btn-block wrapper1" runat="server" Text="Login" OnClick="btn_login_Click" />
                <asp:Label ID="lbl_userLogin" runat="server" Text=""></asp:Label>
                <br />
            </div>
            <hr />
            <div>
                <h4 class="form-signin-heading">Staff Login</h4>
                <input type="text" id="txt_staffUsername" class="form-control" runat="server" name="username" placeholder="Username" autofocus="" />
                <input type="password" id="txt_staffPassword" class="form-control" runat="server" name="password" placeholder="Password" />
                <asp:Button ID="btn_StaffLogin" CssClass="btn btn-sm btn-primary btn-block wrapper1" runat="server" Text="Staff Login" OnClick="btn_StaffLogin_Click" />
                <asp:Label ID="lbl_StaffLoginLabel" runat="server" Text=""></asp:Label>
            </div>
            <hr />
            <div>
                <h5 class="form-signin-heading">Captcha Verification</h5>
                <asp:Image ID="img_captchImg" runat="server" ImageAlign="AbsMiddle" />
                <input type="text" id="txt_imgText" class="form-control" runat="server" name="captchInput" placeholder="Type image text here" autofocus="" />
                <asp:Button ID="btn_newImg" CssClass="btn btn-sm btn-primary btn-block wrapper1" runat="server" Text="New Image" OnClick="btn_newImg_Click" />
                <h4 class="form-signin-heading">Register New User</h4>
                <input type="text" id="txt_firstname" class="form-control" runat="server" name="firstname" placeholder="Firstname" autofocus="" />
                <input type="text" id="txt_lastname" class="form-control" runat="server" name="lastname" placeholder="Lastname" autofocus="" />
                <input type="text" id="txt_registerUsername" class="form-control" runat="server" name="username" placeholder="Username" autofocus="" />
                <input type="password" id="txt_registerPassword" class="form-control" runat="server" name="password" placeholder="Password" />
                <asp:Button ID="btn_register" CssClass="btn btn-sm btn-primary btn-block wrapper1" runat="server" Text="Register" OnClick="btn_register_Click" />
                <asp:Label ID="lbl_registerUser" runat="server" Text=""></asp:Label>
            </div>

        </form>
    </div>
                <footer>
                <h5><a href="PublicPage.aspx">Public Page</a></h5> 
            </footer>
</body>
</html>
