<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeProfile.aspx.cs" Inherits="HR_EPMS.EmployeeProfile" %>


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
            <form id="form1" runat="server" action="EmployeeProfile.aspx" method="post">
          <!-- Page Heading -->
          <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Employee Profile</h1>
            
          </div>
             <div class="row">

            <!-- Content Column -->
            <div class="col-lg-12">

              <!-- Project Card Example -->
              <div class="card shadow mb-4">
                <div class="card-header py-3">
                  <h6 class="m-0 font-weight-bold text-primary">Search Employee</h6>
                </div>
                <div class="card-body">
                    <div class="row">
                  <div class="input-group input-group col-xl-3 col-lg-4 col-md-6 col-sm-12">
                      <div class="input-group-prepend">
                        <span class="input-group-text">Staff ID</span>
                      </div>
                      <asp:TextBox class="form-control" placeholder="Staff ID" id="v_staffid" runat="server"/>
                    </div>
                    <div class="input-group col-xl-4 col-lg-4 col-md-6 col-sm-12">
                      <div class="input-group-prepend">
                        <span class="input-group-text" id="Span1">Staff Name</span>
                      </div>
                      <input type="text" class="form-control" id="v_staffname" placeholder="English / Chinese Name" runat="server" />
                    </div>
                    <div class="input-group col-xl-5 col-lg-5 col-md-12 col-sm-12">
                      <div class="input-group-prepend">
                        <span class="input-group-text" id="Span2" >Show Inactive</span>
                      </div>
                        <input type="checkbox" data-toggle="toggle" id="v_isactive" runat="server" >
                    </div>
                </div>
                <br />
                <div class="row">
                  <div class="input-group col-xl-3 col-lg-4 col-md-6 col-sm-12">
                      <div class="input-group-prepend">
                        <span class="input-group-text" id="Span3">Experience</span>
                      </div>
                      <select class="form-control" id="v_exp" runat="server">
                          <option value="A">Any</option>
                          <option value="3">< 3 Years</option>
                          <option value="5">3 - 5 Years</option>
                          <option value="10">5 - 10 Years</option>
                          <option value="20">10 - 20 Years</option>
                          <option value="X">> 20 Years</option>
                        </select>
                    </div>
                    <div class="input-group col-4">
                      <div class="input-group-prepend">
                        <span class="input-group-text" id="Span4">Qualification</span>
                      </div>
                      <input type="text" class="form-control" placeholder="Qualification Keywords" id="v_quali" runat="server" />
                    </div>
                </div>
                
                <br />
                <div class="row">
                  <div class="col-12">
                        <button type="submit" class="btn btn-primary">Search</button>
                        <button type="reset" class="btn btn-secondary">Reset</button>
                  </div>                  
                </div>
              </div>
              
              
              </div>
              
             <div class="card shadow mb-4">
                <div class="card-body">
              <div class="table-responsive">
              
                <asp:GridView ID="grid_Employee" runat="server" CellSpacing="0"  AutoGenerateColumns="false" Width="100%" class="table table-bordered " OnRowDataBound="GridView1_RowDataBound">  
                           <Columns>     
                               <asp:TemplateField HeaderText="Staff ID" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("staffID")%>   
                                   </ItemTemplate>  
                               </asp:TemplateField>  
                               <asp:TemplateField HeaderText="English Name" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("engName")%>   
                                   </ItemTemplate>  
                               </asp:TemplateField>  
                               <asp:TemplateField HeaderText="Chinese Name" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("chiName")%>
                                   </ItemTemplate>  
                               </asp:TemplateField>   
                               <asp:TemplateField HeaderText="Current Position" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("curPosition")%>
                                   </ItemTemplate>  
                               </asp:TemplateField>  
                               <asp:TemplateField HeaderText="Join Date" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("fromDate")%> 
                                   </ItemTemplate>  
                               </asp:TemplateField>  
                               <asp:TemplateField HeaderText="Working Exp" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("workExp")%> years  
                                   </ItemTemplate>  
                               </asp:TemplateField>  
                               <asp:TemplateField HeaderText="Show Details" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <a href='EmployeeDetails.aspx?sid=<%#Eval("staffID")%>' target="_self">Details</a>
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
    $('#toggle-two').bootstrapToggle({
      on: 'Yes',
      off: 'No'
    });
    
    $('#grid_Employee').DataTable({  
        dom: 'Bfrtip',
       buttons: [ 'colvis', 'excel' ],
        responsive: true,
        paging: true,
        autoWidth: false,
        info: false,
        searching: false,
      "columnDefs": [
    { "width": "10%", "targets": 0 }
  ]
     });
  });
  

  </script>
</body>

</html>