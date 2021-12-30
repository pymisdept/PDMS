<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Covid19.aspx.cs" Inherits="HR_EPMS.Covid19" %>


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
  <link href="include/bootstrap/css/bootstrap-toggle.min.css" rel="stylesheet" type="text/css" />
    <%--<link href="include/datatables/dataTables.bootstrap4.min.css" rel="stylesheet" type="text/css" />--%>
</head>

<body id="page-top">

  <!-- Page Wrapper -->
  <div id="wrapper">
  
    <!--#include file="LeftMenu.inc"-->

    <!-- Content Wrapper -->
    <div id="content-wrapper" class="d-flex flex-column">
       
      
      <!-- Main Content -->
      <div id="content">

    
        <!-- Begin Page Content -->
        <div class="container-fluid">
            <form id="form1" runat="server" action="Covid19.aspx" method="post">
          <!-- Page Heading -->
          <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">COVID-19 Cases</h1>
            
          </div>
             <div class="row">

            <!-- Content Column -->
            <div class="col-lg-12">

              <!-- Project Card Example -->
              <div class="card shadow mb-4">
                <div class="card-header py-3">
                  <h6 class="m-0 font-weight-bold text-primary">Action</h6>
                </div>
                <div class="card-body">
                    <div class="row">
                  <div class="input-group input-group col-xl-3 col-lg-4 col-md-6 col-sm-12">
                      <div class="">
                        <span class="">Last Update Date: </span>
                      </div>
                      <asp:TextBox class="form-control" placeholder="" id="v_lastDate" runat="server" ReadOnly style="margin-left: 15px; height: 25px;"/>
                    </div>
                </div>
                <br />
                <div class="row">
                  <div class="col-12">
                  </div>                  
                </div>
              </div>
              
              
              </div>
              
             <div class="card shadow mb-4">
                <div class="card-body">
              <div class="table-responsive">
              
                <asp:GridView ID="grid_Employee" runat="server" CellSpacing="0"  AutoGenerateColumns="false" Width="100%" class="table table-bordered " OnRowDataBound="GridView1_RowDataBound">  
                           <Columns>     
                               
                               
                               <asp:TemplateField HeaderText="Building" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("building_name")%>
                                   </ItemTemplate>  
                               </asp:TemplateField>       
                                <asp:TemplateField HeaderText="District" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("district")%>   
                                   </ItemTemplate>  
                               </asp:TemplateField> 
                               <asp:TemplateField HeaderText="Case ID" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("case_id")%>
                                   </ItemTemplate>  
                               </asp:TemplateField>    
                               <asp:TemplateField HeaderText="No Of Cases" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("case_count")%>
                                   </ItemTemplate>  
                               </asp:TemplateField>                             
                           </Columns>  
                  </asp:GridView>                  
              </div>
              
              </div>
              </div>
              </div>
              </div>

              <!-- Color System -->
              </form>
        </div>
        <!-- /.container-fluid -->
        
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

  <script src="include/jquery/jquery-3.5.1.js" type="text/javascript"></script>
  <script src="include/bootstrap/js/bootstrap.bundle.min.js" type="text/javascript"></script>


        
  <!-- Core plugin JavaScript-->
  <script src="include/jquery-easing/jquery.easing.min.js"></script>

  <!-- Custom scripts for all pages-->
  <script src="js/sb-admin-2.js"></script>
  <script src="include/bootstrap/js/bootstrap-toggle.min.js" type="text/javascript"></script>
  <!-- Page level plugins -->

  <script src="include/datatables/datatables.js" type="text/javascript"></script>
  <link href="include/datatables/datatables.css" rel="stylesheet" type="text/css" />
  
  <script>      
  $(function() {
    
    $('#grid_Employee').DataTable({  
        dom: 'Bfrtip',
       buttons: [ 'colvis', 'excel' ],
        responsive: true,
        paging: true,
        autoWidth: false,
        info: true,
        searching: true,  
        pageLength: 20,
        "order": [ 3, 'desc' ],
      "columnDefs": [
    { "width": "10%", "targets": 0 }
  ]
     });
  });
  

  </script>
</body>

</html>