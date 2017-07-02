<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryItPart1.aspx.cs" Inherits="TryItPagesApplication.TryItPart1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <title>TRY IT PAGE PART 1</title>
    <style type="text/css">
        .auto-style1 {
            height: 38px;
        }
    </style>
    <script lang="Javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
</head>
<body style="margin: 50px 10px">
    <form id="form1" runat="server">
        <div style="margin-left: 720px"></div>
        <div class="navbar navbar-fixed-top navbar-light" style="background-color: #e3f2fd;">
            <div class="container">
                <div class="navbar-header">
                    <a href="#" class="navbar-brand">Service TryIt Page [PART 1]</a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li><a href="#">Home</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="container body-content">
            <h2>Crime Data Service</h2>
            <br />
            <blockquote class="blockquote">
                <p>
                    Crime Data Service can be used to view crime data in a particular area<br />
                    URL to service: <a href="http://webstrar36.fulton.asu.edu/Page2/ServiceCrimeData.svc?wsdl">http://webstrar36.fulton.asu.edu/Page2/ServiceCrimeData.svc?wsdl</a>
                    <br />
                    Method Names: getCrimeData(int:zipcode):returns array of integer having crime data
            <br />
                    Crime data is returned in order -Zip,ViolentCrime,MurderAndManslaughter,ForcibleRape,Robbery,AggravatedAssault,PropertyCrime,Burglary,LarcenyTheft,MotorVehicleTheft       
            <br />
                </p>
            </blockquote>
             Enter zipcode:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <input name="txtZipCode" maxlength="5" onkeypress="return isNumberKey(event)" type="text" id="txt_zipCode" runat="server" style="width: 150px;" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_crimeData" runat="server" OnClick="btn_crimeData_Click" Text="Get Crime Data" />
            <br />
            <asp:Label ID="lbl_errormsg_crime" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
        <div class="container">
            <h2>Crime Data Values</h2>
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
            <h2>Near By Store Service </h2>  
            <blockquote class="blockquote">
                <p>
                    Near By  Service can be used to view nearby stores in a particular area using zipcode<br />
                    URL to service: <a href="http://webstrar36.fulton.asu.edu/Page2/ServiceNearByStores.svc?wsdl">http://webstrar36.fulton.asu.edu/Page2/ServiceNearByStores.svc?wsdl</a>
                    <br />
                    Method Names: findNearestStore(string:zipcode, string:storeType):returns a string having names of desired type stores in the area
            <br /> </p>
            </blockquote>
            <asp:DropDownList ID="dpdown_storeType" runat="server">
                <asp:ListItem Text="Bank" Value="bank"></asp:ListItem>
                <asp:ListItem Text="ATM" Value="atm"></asp:ListItem>
                <asp:ListItem Text="Cafe" Value="cafe"></asp:ListItem>
                <asp:ListItem Text="Church" Value="church"></asp:ListItem>
                <asp:ListItem Text="Doctor" Value="doctor"></asp:ListItem>
                <asp:ListItem Text="Gym" Value="gym"></asp:ListItem>
                <asp:ListItem Text="Pharmacy" Value="pharmacy"></asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               Enter Zip Code: 
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
            <br />
            <asp:Button ID="btn_getStoresNearBy" runat="server" Text="Near By Stores" OnClick="btn_getStoresNearBy_Click" />
            <br />
            <br />
            <textarea id="txtArea_NearByStores" rows="4" style="width: 30%" readonly="readonly" runat="server"></textarea>
            <br />
            <asp:Label ID="lbl_errorMsg" runat="server" Text="Label" Visible="False"></asp:Label>

        </div>
    </form>
</body>
</html>
