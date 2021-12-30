<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Graduate.aspx.cs" Inherits="HR_EPMS.Graduate" %>

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
    <link href="include/datatables/dataTables.bootstrap4.min.css" rel="stylesheet" type="text/css" />
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
            <form id="form1" runat="server" action="Graduate" method="post">
          <!-- Page Heading -->
          <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Application (Graduate)</h1>
            
          </div>
             <div class="row">

            <!-- Content Column -->
            <div class="col-lg-12">

              <!-- Project Card Example -->
              <div class="card shadow mb-4">
                <div class="card-header py-3">
                  <h6 class="m-0 font-weight-bold text-primary">Search Applicants</h6>
                </div>
                <div class="card-body">
                    <div class="row">
                  <div class="input-group input-group col-xl-2 col-lg-2 col-md-6 col-sm-12">
                      <div class="input-group-prepend">
                        <span class="input-group-text">Reference No.</span>
                      </div>
                      <asp:TextBox class="form-control" placeholder="" id="v_staffid" runat="server"/>
                    </div>
                    <div class="input-group col-xl-4 col-lg-4 col-md-6 col-sm-12">
                      <div class="input-group-prepend">
                        <span class="input-group-text" id="Span9">Applied Position</span>
                      </div>
                      <input type="text" class="form-control" placeholder="Applied Position Keyword" id="v_appliedposition" runat="server" />
                    </div>
                    
                    <div class="input-group col-xl-3 col-lg-3 col-md-5 col-sm-9">
                      <div class="input-group-prepend">
                        <span class="input-group-text" id="Span1">Staff Name</span>
                      </div>
                      <input type="text" class="form-control" id="v_staffname" placeholder="English / Chinese Name Keyword" runat="server" />
                    </div>

                    
                   <div class="input-group col-xl-3 col-lg-3 col-md-6 col-sm-12">
                      <div class="input-group-prepend">
                        <span class="input-group-text" id="Span8">Salary</span>
                      </div>
                      <input type="text" class="form-control" placeholder="" id="v_Salary" runat="server" />
                      
                      <select class="form-control" id="v_SelectSalary" runat="server">
                          <option value="2">or below</option>
                          <option value="1">or above</option>
                          <option value="3">exactly </option>
                        </select>
                    </div>
                </div>
                <br />
                <div class="row">
                     <div class="input-group col-xl-4 col-lg-4 col-md-6 col-sm-12">
                      <div class="input-group-prepend">
                        <span class="input-group-text" id="Span4">Education</span>
                      </div>
                      <input type="text" class="form-control" placeholder="Education / University / Programme Name Keywords" id="v_edu" runat="server" />
                    </div>
                    
                    <div class="input-group col-xl-3 col-lg-3 col-md-6 col-sm-12">
                      <div class="input-group-prepend">
                        <span class="input-group-text" id="Span5">GPA</span>
                      </div>
                      <input type="text" class="form-control" placeholder="" id="v_gpa" runat="server" />
                      
                      <select class="form-control" id="v_SelectGPA" runat="server">
                          <option value="1">or above</option>
                          <option value="2">or below</option>
                          <option value="3">exactly </option>
                        </select>
                    </div>
                    <div class="input-group col-xl-1 col-lg-1 col-md-2 col-sm-2">
                      <div class="input-group-prepend">
                        <span class="input-group-text" id="Span7"> / </span>
                      </div>
                      <div class="input-group-prepend">
                        <span class="input-group-text" id="Span6"> Grade </span>
                      </div>
                    </div> 
                    <div class="input-group col-xl-2 col-lg-2 col-md-6 col-sm-12">

                       <select class="form-control" id="v_grade" runat="server">
                          <option value=""></option>
                          <option value="1">Distinction</option>
                          <option value="2">Credit</option>
                          <option value="3">Pass</option>
                          <option value="4">Fail</option>
                       </select>              
                      <select class="form-control" id="v_SelectGrade" runat="server">
                          <option value="1">or above</option>
                          <option value="2">or below</option>
                          <option value="3">exactly</option>
                       </select>

                    </div>

                </div>
                    <br />
                <div class="row">
                        <div class="input-group col-xl-4 col-lg-4 col-md-6 col-sm-12">
                        <div class="input-group-prepend">
                        <span class="input-group-text" id="spDatefrom">Date</span>
                        </div>
                        <input type="text" class="form-control" placeholder="yyyy-MM-dd" id="dtFrom" runat="server" />
                            <div class="input-group-prepend">
                        <span class="input-group-text" id="spDateto">To</span>
                        </div>
                        <input type="text" class="form-control" placeholder="yyyy-MM-dd" id="dtTo" runat="server" />
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
                               <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("ID")%>   
                                   </ItemTemplate>  
                               </asp:TemplateField> 
                               <asp:TemplateField HeaderText="Reference No." HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("staffID")%>   
                                   </ItemTemplate>  
                               </asp:TemplateField> 
                               <asp:TemplateField HeaderText="Apply Date" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("fromDate")%> 
                                   </ItemTemplate>  
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Applied Position" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("curPosition")%>
                                   </ItemTemplate>  
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="English Name" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("engName")%>   
                                   </ItemTemplate>  
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="District" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("district_desc")%>   
                                   </ItemTemplate>  
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Education Level" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("Education_Desc")%>   
                                   </ItemTemplate>  
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Programme Name / Subject" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("ProgrammeName")%>
                                   </ItemTemplate>  
                               </asp:TemplateField> 
                               <asp:TemplateField HeaderText="Working Exp(Year)" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("WorkingExp")%>
                                   </ItemTemplate>  
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Expected Salary" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("expectedsalary")%>
                                   </ItemTemplate>  
                               </asp:TemplateField>  
                               <asp:TemplateField HeaderText="Date Available" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("DateAvailable")%>
                                   </ItemTemplate>  
                               </asp:TemplateField>
                              
                               <asp:TemplateField HeaderText="Current Position" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("CurrPosition")%>
                                   </ItemTemplate>  
                               </asp:TemplateField>         
                                <asp:TemplateField HeaderText="CV" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>     
                                       <a href='https://career.pyengineering.com/CV1/CVFile/<%#Eval("FileName1")%>' target="_blank">View</a>
                                   </ItemTemplate>  
                               </asp:TemplateField> 
                                <asp:TemplateField HeaderText="Form2 Link" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>     
                                        <a href='https://career.pyengineering.com/cv1/phase2main.aspx?Key=<%# Eval("Token")%>&Position=<%# Eval("curPosition")%>&RefCode=<%# Eval("staffID")%>' target="_blank"><asp:Label runat="server" Text="Open Form | "></asp:Label></a>
                                        <a href='Copylinkresult.aspx?Key=<%# Eval("Token")%>&Position=<%# Eval("curPosition")%>&RefCode=<%# Eval("staffID")%>&LinkType=3' target="_blank"><asp:Label runat="server" Text="Copy Link"></asp:Label></a>
                                   </ItemTemplate>  
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Dtls/Rpt" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <a href='GraduateDetails.aspx?sid=<%#Eval("staffID")%>' target="_blank">Dtl</a>
                                        <!-- <a href='http://10.1.1.106/HRMStest/ReportFrame.aspx?Report=Career_Report-graduate.rpt&RefNo=<%#Eval("staffID")%>' target="_blank">Rpt</a>-->
                                        <a href='http://10.1.1.106/HRMSUAT_Fresh/ReportFrame.aspx?Report=Career_Report-graduate-uat.rpt&RefNo=<%#Eval("staffID")%>' target="_blank">Rpt</a>
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
  <script src="include/bootstrap/js/bootstrap.min.js"></script>

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
        //Bfrtip
        //top of datatable //<<"top"Bpl>f<t>i>
        $('#grid_Employee').DataTable({
            dom: 'Bfrtip',
            buttons: ['colvis','excel'],
            responsive: true,
            paging: true,
            info: false,
            pageLength: 10,
            searching: true,            
            "order": [ 0, 'desc' ],
            "columnDefs": [
                { "width": "5%", "targets": 0},
                { "width": "10%", "targets": 1},
                { "width": "5%", "targets": 2},
                { "width": "5%", "targets": 3},
                { "width": "5%", "targets": 4},
                { "width": "7%", "targets": 5},
                { "width": "5%", "targets": 6},
                { "width": "5%", "targets": 7},
                { "width": "10%", "targets": 8},
                { "width": "5%", "targets": 9},
                { "width": "5%", "targets": 10 }, 
                { "width": "5%", "targets": 11 },
                { "width": "3%", "targets": 12 },
                { "width": "15%", "targets": 13 },
                { "width": "2%", "targets": 14 }
            ]
         } );   
    });
    </script>
</body>

</html>