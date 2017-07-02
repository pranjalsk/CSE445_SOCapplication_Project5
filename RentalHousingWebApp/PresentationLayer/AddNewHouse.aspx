<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewHouse.aspx.cs" Inherits="RentalHousingWebApp.PresentationLayer.AddNewHouse" %>

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
    <title>Add House</title>
</head>
<body class="container wrapper">
    <form id="form1" runat="server">
    <div class="wrapper">
        <h2>Add new house entry</h2>
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
                <asp:Button ID="btn_AddNow" CssClass="btn btn-sm btn-primary wrapper" runat="server" Text="Add House" OnClick="btn_AddNow_Click"/><br />
                <asp:Label ID="lbl_AdditionSuccessMsg" runat="server" Text="-"></asp:Label><br />
                <textarea id="txt_HousesAfterAddition" runat="server" cols="50" rows="4" placeholder="Houses remaining after booking" readonly="readonly"></textarea>
            </div>
    </div>
        <br />
        <br />
         <footer>
                <asp:Button ID="btn_logout" CssClass="btn btn-sm btn-primary" runat="server" Text="Logout" OnClick="btn_logout_Click"/>
                <asp:Button ID="btn_landingPage" CssClass="btn btn-sm btn-primary" runat="server" Text="Landing Page" OnClick="btn_landingPage_Click"/>
      </footer>


    </form>
</body>
</html>
