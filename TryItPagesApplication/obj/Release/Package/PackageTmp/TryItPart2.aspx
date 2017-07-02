<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryItPart2.aspx.cs" Inherits="TryItPagesApplication.TryItPart2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />

    <title>TRY IT PART 2</title>
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
    <div style="margin-left: 720px"></div>
    <form id="form1" runat="server">
        <div class="navbar navbar-fixed-top navbar-light" style="background-color: #e3f2fd;">
            <div class="container">
                <div class="navbar-header">
                    <a href="#" class="navbar-brand">Service TryIt Page [Assignment 3 PART 2]</a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li><a href="TryItPart2.aspx#data-service">Data Access Service</a></li>
                        <li><a href="TryItPart2.aspx#valid-service">Validation Service</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div id="data-service" class="container body-content">
            <h2>Data Access &amp; Manipulation Service</h2>
            <br />
            <blockquote class="blockquote">
                <p>
                    Data Access Service can be used to manipulate [CRUD operations] data on dummy database which is a XML file.<br />
                    URL to service: <a href="http://webstrar36.fulton.asu.edu/page2/ServiceDataAccess.svc">http://webstrar36.fulton.asu.edu/page2/ServiceDataAccess.svc</a>
                    <br />
                    Method Names: createDB() - Setup initial dummy db with default with some default entries
                    <br /> readAll() - Show all the database entries
                    <br /> read(int ZIP) - Show all the entries having given ZIP code
                    <br /> addNew(int id, string name, int zip) - Add new entry in the database
                    <br /> remove(int id, string name, int zip) - Remove particular entry from the database
                </p>
            </blockquote>

            <div>
                <h3>View All House Listing</h3>
                <asp:Button ID="btn_viewAll" runat="server" Text="View All" OnClick="btn_viewAll_Click" />
                &nbsp;&nbsp;
                <textarea id="txtArea_viewAll" runat="server" cols="50" rows="4" placeholder="All Houses Listing" readonly="readonly"></textarea>
                <h3>View By Zip</h3>
                <asp:TextBox ID="txt_viewByZip" MaxLength="5" onkeypress="return isNumberKey(event)" runat="server"></asp:TextBox>
                &nbsp;<asp:Label ID="lbl_error_viewByZip" runat="server" ForeColor="#990000" Text="*"></asp:Label>
                <br />
                <asp:Button ID="btn_viewByZip" runat="server" Text="View" OnClick="btn_viewByZip_Click" />
                <br />
                <textarea id="txtArea_viewByZip" runat="server" cols="50" rows="4" placeholder="Houses in the given Zip" readonly="readonly"></textarea>

                <h3>Input Boxes</h3>
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
                    <asp:Button ID="btn_BookNow" runat="server" Text="Book This House" OnClick="btn_BookNow_Click" /><br />
                    <asp:Label ID="lbl_BookingSuccessMsg" runat="server" Text="-"></asp:Label><br />
                    <textarea id="txt_HousesAfterBooking" runat="server" cols="50" rows="4" placeholder="Houses remaining after booking" readonly="readonly"></textarea>
                </div>
            </div>
        </div>

        <div id="valid-service" class="container body-content">
            <h2>Validation Services [Restful]</h2>
            <h4>Email and Credit Card Validation</h4>
            <br />
            <blockquote class="blockquote">
                <p>
                    Email Validation service take email string as parameter and returns if the email valid or not using third party api<br />
                    Credit card validation service implments<span><a href="https://en.wikipedia.org/wiki/Luhn_algorithm"> Luhn algorithm</a></span>  for validation which is used for credit card number generation.<br />
                    URL to service: 
                    <a href="http://webstrar36.fulton.asu.edu/page1/ServiceValidation.svc"><br /> http://webstrar36.fulton.asu.edu/page1/ServiceValidation.svc/isCreditCardValid?number={CREDIT NUMBER}</a>
                    <br /> <a href="http://webstrar36.fulton.asu.edu/page1/ServiceValidation.svc"> http://webstrar36.fulton.asu.edu/page1/ServiceValidation.svc/checkEmail?email=={EMAIL ADDRESS}</a>
                    <br />
                    Method Names: checkEmail(string email) - returns different email related parameters in XML using third party API <a href="https://mailboxlayer.com/">Mailbox layer</a> which gives JSON data
                    <br />Note - This 3rd party API gives only 250 free email validations for given api key
                    <br />isCreditCardValid(string number) - Returns True/False based on credit card validity</p>
            </blockquote>
            <div>
                <asp:TextBox ID="txt_emailAddress" runat="server" Width="209px"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Button ID="btn_emailVerify" runat="server" Text="Verify email" OnClick="btn_emailVerify_Click" />
                &nbsp;&nbsp;
                <br />
                Email Validation based on different parameters(XML format)<br />
                <asp:Label ID="lbl_emailVerify" runat="server" Font-Italic="True" ForeColor="#990000" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True"></asp:Label>
               
            </div>
            <br />
            <div>
                <asp:TextBox ID="txt_creditCard" onkeypress="return isNumberKey(event)"  MaxLength="16" runat="server" Width="208px"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Button ID="btn_verifyCredit" runat="server" Text="Verify credit card" OnClick="btn_verifyCredit_Click" />
                &nbsp;
                <br />
                Is Credit Card Valid?- <asp:Label ID="lbl_creditVerify" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#990000"></asp:Label>
            </div>  
        </div>

    </form>
</body>
</html>
