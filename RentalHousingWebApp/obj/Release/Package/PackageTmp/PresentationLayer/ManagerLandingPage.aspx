<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerLandingPage.aspx.cs" Inherits="RentalHousingWebApp.PresentationLayer.ManagerLandingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="assets/css/LandingPageStyle.css" />
    <title>Manager Landing Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="main">
                <h3>Manager Landing Page</h3>
                <h1><strong>Hey!</strong>Welcome!
                    <asp:Label ID="lbl_username" runat="server" Text=""></asp:Label>
                </h1>
                You can browse to pages!
            </div>
            <div>
                <ol class="list-numbered">
                    <li><a href="PublicPage.aspx">Public Home</a></li>
                    <li><a href="ViewHouseListing.aspx">View House Listing</a></li>
                    <li><a href="AddNewHouse.aspx">Add New House Listing</a></li>
                    <li><a href="CrimeNearByStores.aspx">Crime and NearBy Stores</a></li>
                    <li><a href="RemoveUsers.aspx">Remove users</a></li>
                </ol>
            </div>
            <footer>
                <asp:Button ID="btn_logout" runat="server" Text="Logout" OnClick="btn_logout_Click" />
            </footer>

        </div>
    </form>
</body>
</html>
