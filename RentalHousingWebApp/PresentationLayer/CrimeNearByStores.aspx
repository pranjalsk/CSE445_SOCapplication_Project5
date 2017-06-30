<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrimeNearByStores.aspx.cs" Inherits="RentalHousingWebApp.PresentationLayer.CrimeNearByStores" %>

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
    <title>Crime Data & NearBy Stores</title>
</head>
<body class="container">
    <form id="form1" runat="server">
        <div style="margin-left: 720px">
        </div>
        <div class="container body-content wrapper">
            <h3>Crime Data in the Area</h3>
            <br />
            Enter zipcode:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <input name="txtZipCode" maxlength="5" onkeypress="return isNumberKey(event)" type="text" id="txt_zipCode" runat="server" style="width: 150px;" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_crimeData" runat="server" Text="Get Crime Data" CssClass="btn btn-lg btn-primary wrapper"/>
            <br />
            <asp:Label ID="lbl_errormsg_crime" runat="server" Text="Label" Visible="False"></asp:Label>

        </div>

        <div class="container wrapper">
            <h3>Crime Data Values</h3>
            <table id="tbl_crimeData" runat="server" class="table table-striped" style="width: 450px;">
                <thead>
                    <tr>
                        <th class="auto-style1">Attribute</th>
                        <th class="auto-style1">Value</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Zip</td>
                        <td>
                            <asp:Label ID="td_ZIP" Text="" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>ViolentCrime</td>
                        <td>
                            <asp:Label ID="td_ViolentCrime" Text="" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>MurderAndManslaughter</td>
                        <td>
                            <asp:Label ID="td_MurderAndManslaughter" Text="" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>ForcibleRape</td>
                        <td>
                            <asp:Label ID="td_ForcibleRape" Text="" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>Robbery</td>
                        <td>
                            <asp:Label ID="td_Robbery" Text="" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>AggravatedAssault</td>
                        <td>
                            <asp:Label ID="td_AggravatedAssault" Text="" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>PropertyCrime</td>
                        <td>
                            <asp:Label ID="td_PropertyCrime" Text="" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>Burglary</td>
                        <td>
                            <asp:Label ID="td_Burglary" Text="" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>LarcenyTheft</td>
                        <td>
                            <asp:Label ID="td_LarcenyTheft" Text="" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>MotorVehicleTheft</td>
                        <td>
                            <asp:Label ID="td_MotorVehicleTheft" Text="" runat="server" /></td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div class="container body-content" style="color: #000000">
            <h3>Near By Store </h3>
            <asp:DropDownList ID="dpdown_storeType" runat="server">
                <asp:ListItem Text="Bank" Value="bank"></asp:ListItem>
                <asp:ListItem Text="ATM" Value="atm"></asp:ListItem>
                <asp:ListItem Text="Cafe" Value="cafe"></asp:ListItem>
                <asp:ListItem Text="Church" Value="church"></asp:ListItem>
                <asp:ListItem Text="Doctor" Value="doctor"></asp:ListItem>
                <asp:ListItem Text="Gym" Value="gym"></asp:ListItem>
                <asp:ListItem Text="Pharmacy" Value="pharmacy"></asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;Enter Zip Code: 
            <asp:TextBox ID="txt_zip" MaxLength="5" onkeypress="return isNumberKey(event)" runat="server"></asp:TextBox>
            <br />
            <br />
            Latitude:
            <asp:Label ID="lbl_latitude" runat="server" Text="Latitude" Visible="False"></asp:Label>
            <br />
            <br />
            Longitude:
            <asp:Label ID="lbl_longitude" runat="server" Text="Longitude" Visible="False"></asp:Label>
            <br />
            <asp:Button ID="btn_getStoresNearBy" CssClass="btn btn-lg btn-primary wrapper" runat="server" Text="Near By Stores"/>
            <br />
            <textarea id="txtArea_NearByStores" class="wrapper" rows="4" style="width: 30%" readonly="readonly" runat="server"></textarea>
            <br />
            <asp:Label ID="lbl_errorMsg" runat="server" Text="Label" Visible="False"></asp:Label>

        </div>



    </form>
</body>
</html>
