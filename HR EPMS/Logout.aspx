<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="HR_EPMS.Acknowledge" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    
    <link href="lib/boostrap/bootstrap.css?timestamp=201809201509" rel="stylesheet" type="text/css" /> 
    <link rel="stylesheet" href="include/style.css?timestamp=201809201509" type="text/css" />

    <script src="include/main.js" type="text/javascript"></script>    
    <script src="lib/jquery/jquery-3.5.1.js" type="text/javascript"></script>
    <script src="lib/boostrap/bootstrap.js" type="text/javascript"></script>

</head>
<body>

    <form id="form1" runat="server">
        <% var userClaims = HttpContext.Current.User.Identity as System.Security.Claims.ClaimsIdentity; %>
        <div><%=userClaims?.FindFirst("name")?.Value %></div> 
        <div><%=userClaims?.FindFirst("preferred_username")?.Value %></div>
            <br />
            <br />
            <div class="row">
                <h3>User has been Logout !!</h3>
            </div>
            <div class="col-sm-12">
            </div>
         </div>
    </form>
</body>
</html>
