<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="HR_EPMS.Main" %>

<!DOCTYPE html>
<html lang="en">

<head>

  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">

  <title>HR Department - EPMS</title>

  <!-- Custom fonts for this template-->
  <link href="include/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">

  <!-- Custom styles for this template-->
  <link href="css/sb-admin-2.css" rel="stylesheet">

</head>

<body id="page-top">

<%--    <p>
        ma</p>--%>

  <!-- Page Wrapper -->
  <div id="wrapper">
  
    <!--#include file="LeftMenu.inc"-->
      <% var userClaims = HttpContext.Current.User.Identity as System.Security.Claims.ClaimsIdentity; %>
    <!-- Content Wrapper -->
    <div id="content-wrapper" class="d-flex flex-column">
       
      
      <!-- Main Content -->
      <div id="content">

    
        <!-- Begin Page Content -->
        <div class="container-fluid">

          <!-- Page Heading -->
          <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Home</h1>
          </div>
          <div>Welcome <%=userClaims?.FindFirst("name")?.Value %></div> 
            
            <br />
        <%--</div>--%>
        <!-- /.container-fluid -->
     

          <!-- Content Row -->
          <div class="row">

            <!-- Earnings (Monthly) Card Example -->
            <div class="col-xl-4 mb-4">
              <div class="card border-left-primary shadow h-100 py-2">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="text-md font-weight-bold text-primary text-uppercase mb-1">New Application</div>
                      <div class="h5 mb-0 font-weight-bold text-gray-800">18</div>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <!-- Earnings (Monthly) Card Example -->
            <div class="col-xl-4 mb-4">
              <div class="card border-left-success shadow h-100 py-2">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="text-md font-weight-bold text-success text-uppercase mb-1">Pending Application</div>
                      <div class="h5 mb-0 font-weight-bold text-gray-800">7</div>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <!-- Earnings (Monthly) Card Example -->
            <div class="col-xl-4 mb-4">
              <div class="card border-left-info shadow h-100 py-2">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                          <div class="text-md font-weight-bold text-info text-uppercase mb-1">Today's Interview</div>
                          <div class="h5 mb-0 font-weight-bold text-gray-800">12</div>
                          </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            
             <div class="row">

            <!-- Content Column -->
            <div class="col-lg-12">

              <!-- Project Card Example -->
              <div class="card shadow mb-4">
                <div class="card-header py-3">
                  <h6 class="m-0 font-weight-bold text-primary">Most Applied Position</h6>
                </div>
                <div class="card-body">
                  <h4 class="small font-weight-bold">Senior Safety Officer  (Ref. PY-00196)<span class="float-right">29</span></h4>
                  <div class="progress mb-4">
                    <div class="progress-bar bg-primary" runat="server" id="prbar1" role="progressbar" style="width: 100%" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100"></div>
                  </div>
                  <h4 class="small font-weight-bold">Site Clerk  (Ref. PY-00202)<span class="float-right">17</span></h4>
                  <div class="progress mb-4">
                    <div class="progress-bar bg-warning" id="prbar2" role="progressbar" style="width: 75%" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100"></div>
                  </div>
                  <h4 class="small font-weight-bold">Driver (Ref. PY-00240)<span class="float-right">16</span></h4>
                  <div class="progress mb-4">
                    <div class="progress-bar bg-success" id="prbar3" role="progressbar" style="width: 72%" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100"></div>
                  </div>
                  <h4 class="small font-weight-bold">Quality Assurance Assistant (Ref. PY-00179) <span class="float-right">12</span></h4>
                  <div class="progress mb-4">
                    <div class="progress-bar bg-info" id="prbar4" role="progressbar" style="width: 60%" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100"></div>
                  </div>
                  <h4 class="small font-weight-bold">Project Manager (Ref. PY-00238) <span class="float-right">10</span></h4>
                  <div class="progress">
                    <div class="progress-bar bg-secondary" id="prbar5" role="progressbar" style="width: 55%" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100"></div>
                  </div>
                </div>
              </div>
              </div>
              </div>

          </div>



      </div>
      <!-- End of Main Content -->

    <!--#include file="Footer.inc"-->

    </div>
    <!-- End of Content Wrapper -->

  </div>
  <!-- End of Page Wrapper -->

  <!-- Scroll to Top Button-->
  <a class="scroll-to-top rounded" href="#page-top">
    <i class="fas fa-angle-up"></i>
  </a>

  <!-- Bootstrap core JavaScript-->
  <script src="include/jquery/jquery.min.js"></script>
  <script src="include/bootstrap/js/bootstrap.min.js"></script>

  <!-- Core plugin JavaScript-->
  <script src="include/jquery-easing/jquery.easing.min.js"></script>

  <!-- Custom scripts for all pages-->
  <script src="js/sb-admin-2.js"></script>

  <!-- Page level plugins -->
  <script src="include/chart.js/Chart.min.js"></script>
    <p>
        lo</p>
</body>

</html>