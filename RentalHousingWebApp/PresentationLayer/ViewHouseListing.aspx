<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewHouseListing.aspx.cs" Inherits="RentalHousingWebApp.PresentationLayer.ViewHouseListing" %>

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
    </style>
    <title>View House Listing</title>
</head>
<body class="container">
    <div class="wrapper">
        <form class="container" runat="server">
            <h3>View All House Listing</h3>
            <asp:Button ID="btn_viewAll" CssClass="btn btn-lg btn-primary wrapper" runat="server" Text="View All" OnClick="btn_viewAll_Click" />
            &nbsp;&nbsp;<br />
            &nbsp;<textarea id="txtArea_viewAll" runat="server" cols="50" rows="4" placeholder="All Houses Listing" readonly="readonly"></textarea>
            <h3>View By Zip</h3>
            ZIP code:
            <asp:TextBox ID="txt_viewByZip" MaxLength="5" onkeypress="return isNumberKey(event)" runat="server"></asp:TextBox>
            &nbsp;<asp:Label ID="lbl_error_viewByZip" runat="server" ForeColor="#990000" Text="*"></asp:Label>
            <br />
            <asp:Button ID="btn_viewByZip" CssClass="btn btn-lg btn-primary wrapper" runat="server" Text="View By ZIP" OnClick="btn_viewByZip_Click" />
            <br />
            <textarea id="txtArea_viewByZip" runat="server" cols="50" rows="4" placeholder="Houses in the given Zip" readonly="readonly"></textarea>
            <br />
            <h4><a href="#">Wanna See NearBy Stores?</a></h4>
            <h4><a href="#">or Crime in the area may be?</a></h4>
            <h3>Book a house now!</h3>
            <div>
                House ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txt_houseId" MaxLength="4" onkeypress="return isNumberKey(event)" runat="server"></asp:TextBox><br />
                House Name:&nbsp;&nbsp;
                    <asp:TextBox ID="txt_houseName" runat="server"></asp:TextBox><br />
                House Zip:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txt_houseZip" MaxLength="5" onkeypress="return isNumberKey(event)" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lbl_error_inputBoxes" runat="server" ForeColor="#990000" Text="All fields are mandatory"></asp:Label>
                <br />
            </div>
            <div>
                <asp:Button ID="btn_BookNow" CssClass="btn btn-lg btn-primary wrapper" runat="server" Text="Book This House" OnClick="btn_BookNow_Click" /><br />
                <asp:Label ID="lbl_BookingSuccessMsg" runat="server" Text="-"></asp:Label><br />
                <textarea id="txt_HousesAfterBooking" runat="server" cols="50" rows="4" placeholder="Houses remaining after booking" readonly="readonly"></textarea>
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
    </div>

      

</body>
</html>
