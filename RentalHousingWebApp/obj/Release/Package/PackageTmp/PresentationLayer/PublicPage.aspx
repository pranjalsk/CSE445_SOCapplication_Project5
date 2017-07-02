<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicPage.aspx.cs" Inherits="RentalHousingWebApp.PresentationLayer.PublicPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="assets/css/publicPageStyle.css" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script src="https://code.jquery.com/jquery-2.2.4.js" integrity="sha256-iT6Q9iMJYuQiMWNd9lDyBUStIq/8PuOW33aOqmvFpqI=" crossorigin="anonymous"></script>
    <title>Public Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">

                <div class="row">
                    <div class="col-lg-10 col-lg-offset-1">
                        <div class="jumbotron black">
                            <h2 style="color:steelblue">Rental House Application</h2>
                            <p>The system offers...</p>
                            <blockquote class="blockquote">
                                <p>
                                    This system offers several functionalities related to Rental House search and booking. It has 3 actors namely End-User, Staff and Manager.
                                    Each has different access levels. Users can view and book house from the available houses. Staff can add new houses in the datbase.
                                    Only manager has right to remove any users. Users can login or self-subscribe to application. In addition to this core functionality,
                                    all actors can view supplementary information about the area by accessing service like crime data and near by stores.
                                </p>
                            </blockquote>
                            <p><a class="btn btn-primary btn-lg" role="button" href="UserLoginPage.aspx">Login/Sign-Up</a></p>
                        </div>
                    </div>
                </div>

                <div class="row black">
                    <div class="col-lg-10 col-lg-offset-1">
                        <div class="col-md-3 col-md-offset-1 col-sm-3 col-sm-offset-1 col-xs-3 col-xs-offset-1">
                            <span class="glyphicon glyphicon-hand-right" style="font-size: 73px;"></span>
                        </div>
                        <div class="col-md-5 col-md-offset-2 col-sm-5 col-sm-offset-3 col-xs-5 col-xs-offset-3">
                            <h4 style="color:steelblue">How to Login/register...</h4>
                            <p>
                                Users and staff can log into the system by using login button. New users can subscribe to
                                service by registering in the system. 
                            </p>
                            <p>
                                <strong>Test Inputs for TA:</strong>    
                                <br /><strong>User Login </strong> {username: "testUser1", password: "password"},{username: "testUser2", password: "password"}
                                <br /><strong>Staff Login</strong> {username: "managerTest1", password: "password"}, {username: "clerkTest1", password: "password"},
                                <br /><strong>Register</strong> {Choose your own username and password, use that to login}
                            </p>
                        </div>

                        <div class="col-md-5 col-md-offset-1 col-sm-5 col-sm-offset-1 col-xs-5 col-xs-offset-1">
                            <h4 style="color:steelblue">Know more about the services...</h4>
                            <p>This application uses several external services and self developed service. To know more about it
                               <strong> <a href="ServiceDirectory.aspx">Click Here...</a></strong>
                            </p>
                        </div>
                        <div class="col-md-2 col-md-offset-3 col-sm-2 col-sm-offset-4 col-xs-3 col-xs-offset-3">
                            <span class="glyphicon glyphicon-hand-left" style="font-size: 73px;"></span>
                        </div>
                    </div>
                </div>


                <!-- Site footer -->
                <div class="footer">
                    <p>&copy; Pranjal Karankar @CSE445-Summer2017 @Arizona State University</p>
                </div>

            </div>
        </div>
    </form>

</body>
</html>
