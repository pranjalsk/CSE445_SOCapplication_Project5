<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceDirectory.aspx.cs" Inherits="RentalHousingWebApp.PresentationLayer.ServiceDirectory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Service Directory Table</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
</head>
<body class="container">

    <table width="1250" border="1" cellspacing="0" cellpadding="2" class="table table-responsive" style="margin-top:10px">
        <tr>
            <td colspan="7" align="center"> ServiceDirectory: <a href="http://webstrar36.fulton.asu.edu">WEBSTRAR</a></td>
        </tr>
        <tr>
            <td colspan="7" align="center">Project Name: Rental House Booking System</td>
        </tr>
        <tr>
            <td colspan="7" align="center">Author Name: Pranjal Karankar</td>
        </tr>
        <tr align="center">
            <td>Provider Name</td>
            <td>Service Name</td>
            <td>Input Type</td>
            <td>Output Type</td>
            <td>TryIt link</td>
            <td>Service Description</td>
            <td>Planned resources need to implement the service</td>
        </tr>
        <tr align="center">
            <td>Pranjal Karankar</td>
            <td><a href="http://webstrar36.fulton.asu.edu/page2/ServiceCrimeData.svc">Crime Data Service [Web Service]</a></td>
            <td>Zipcode</td>
            <td>Integer Array</td>
            <td><a href="http://webstrar36.fulton.asu.edu/page0/TryItPart1.aspx">Try It</a></td>
            <td>
               <strong> [Discovered: Public Repository] </strong> Create a service that returns certain crime data for a given location. This data is given
                in the form of integer array in the order as : Zip, ViolentCrime,MurderAndManslaughter,
                ForcibleRape,Robbery,AggravatedAssault,PropertyCrime,Burglary,LarcenyTheft,MotorVehicleTheft
            </td>
            <td>
                Implementended with the help of national crime data api at
                <a href="https://azure.geodataservice.net/GeoDataService.svc/GetUSDemographics?includecrimedata=false&zipcode=85281
">Geo Data Service</a>
            </td>
        </tr>
        <tr align="center">
            <td>Pranjal Karankar</td>
            <td><a href="http://webstrar36.fulton.asu.edu/page2/ServiceNearByStores.svc">Near By Stores [Web Service]</a></td>
            <td>zip code, store type</td>
            <td>string</td>
            <td><a href="http://webstrar36.fulton.asu.edu/page0/TryItPart1.aspx">Try It</a></td>
            <td>
               <strong> [Discovered: Public Repository] </strong> A service which takes zip code and type of store as parameter. It returns a string containing
                all the near by stores separated by comma
            </td>
            <td>Implemented with the help of google place finder api</td>
        </tr>
        <tr align="center">
            <td>Pranjal Karankar</td>
            <td><a href="http://webstrar36.fulton.asu.edu/page2/ServiceDataAccess.svc">Data Access and Manipulation</a></td>
            <td>String</td>
            <td>String</td>
            <td><a href="http://webstrar36.fulton.asu.edu/page0/TryItPart2.aspx">Try It</a></td>
            <td> <strong> [Discovered: Developed on Own]</strong> Data Access Service can be used to manipulate [CRUD operations] data on dummy database which is a XML file</td>
            <td>Developed using own logic to perform CRUD operaiton on XML file database</td>
        </tr>
        <tr align="center">
            <td>Pranjal Karankar</td>
            <td>Encryption/Decryption [DLL]</a></td>
            <td>string</td>
            <td>string</td>
            <td><a href="TryItEncryptionDLL.aspx">Try It</a></td>
            <td>
                Created a <strong>DLL library</strong> which has two functions encryption and decryption. This library can be included in any application andfunctions can be invoked.
            </td>
            <td>Used System.Security.Cryptography of ASP.NET</td>
        </tr>
    </table>
</body>

</html>
