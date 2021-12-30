<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="HR_EPMS.EmployeeDetails" %>

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
  <link href="include/file-input/css/fileinput.css" rel="stylesheet" type="text/css" />
  <link href="include/bootstrap/css/bootstrap-datepicker.css" rel="stylesheet" type="text/css" />
  <link href="css/style.css" rel="stylesheet" type="text/css" />
  <link href="include/datatables/datatables.css" rel="stylesheet" type="text/css" />
  <link href="css/table.css" rel="stylesheet" type="text/css" />
  
  <!-- Bootstrap core JavaScript-->
   <script src="https://code.jquery.com/jquery-3.5.1.js" type="text/javascript"></script>
   
  <script src="include/bootstrap/js/bootstrap.bundle.min.js" type="text/javascript"></script>
  <!-- Core plugin JavaScript-->
  <script src="include/jquery-easing/jquery.easing.min.js"></script>

  <!-- Custom scripts for all pages-->
  <script src="js/sb-admin-2.js"></script>
  <script src="include/bootstrap/js/bootstrap-toggle.min.js" type="text/javascript"></script>
  <!-- Page level plugins -->
  <script src="include/file-input/js/fileinput.min.js" type="text/javascript"></script>
  
  <script src="include/bootstrap/js/bootstrap-datepicker.js" type="text/javascript"></script>
        
  <script src="include/datatables/datatables.js" type="text/javascript"></script>
  <script>    
      
        $(function() {     
         var btnCust = '<div style="text-align:center"></div>'; 
        
       $("#avatar-2").fileinput({
            overwriteInitial: true,
            maxFileSize: 1500,
            showClose: false,
            showCaption: false,
            browseLabel: 'Browse',
            removeLabel: 'Remove',
            browseIcon: '',
            removeIcon: '',
            removeTitle: 'Cancel or reset changes',
            elErrorContainer: '#kv-avatar-errors-1',
            msgErrorClass: 'alert alert-block alert-danger',
            defaultPreviewContent: '<img id="v_profilepic" src="img/profile.png" alt="Profile Picture" style="width: 100%" runat="server" />',
            layoutTemplates: {main2: '{preview} ' +  ' {browse}'},
            allowedFileExtensions: ["jpg", "jpeg",  "png", "gif"]
        });
               
        
        $('.datepicker').datepicker({
            autoclose: true
        });
           });

  </script>
    
    
    
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
                  <h6 class="m-0 font-weight-bold text-primary">Employee Details</h6>
                </div>
                
                <div class="card-body">


                <div class="row">
                       <div class="col-xl-9 col-lg-9 col-md-12 col-sm-12">
                        <div class="row">
                        <div class="form-group col-xl-4 col-lg-4 col-md-6 col-sm-12 span4">
                        
                            <label for="exampleFormControlInput1">English Name</label>
                            <asp:TextBox class="form-control" id="v_engname" placeholder="" runat="server" readonly />                            
                        </div>
                        
                        <div class="form-group col-xl-4 col-lg-4 col-md-6 col-sm-12 span4">
                            <label for="exampleFormControlInput1">Chinese Name</label>
                            <asp:TextBox class="form-control" id="v_chiname" placeholder="" runat="server" readonly />           
                        </div>
                
                        <div class="form-group col-xl-4 col-lg-4 col-md-6 col-sm-12 span4">
                            <label for="exampleFormControlInput1">Staff ID</label>
                            <asp:TextBox class="form-control" id="v_staffid" placeholder="" runat="server" readonly />            
                        </div>
                        </div>
                        <div class="row">
                        
                        <div class="form-group col-xl-6 col-lg-6 col-md-6 col-sm12 ">
                            <label for="exampleFormControlInput1">Profession</label>
                             <asp:TextBox class="form-control" id="v_prof" placeholder="" runat="server" readonly />        
                        </div>
                        
                        <div class="form-group col-xl-3 col-lg-3 col-md-6 col-sm12">
                            <label for="exampleFormControlInput1">Date of Birth</label>
                            <div class="input-group date" data-provide="datepicker">                                
                                <asp:TextBox class="form-control" id="v_dateofbirth" placeholder="" runat="server" disabled />       
                                <div class="input-group-addon">
                                    <span class="glyphicon glyphicon-th"></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-3"></div>
                         </div>
                         
                        <div class="row">
                        
                        <div class="form-group col-xl-6 col-lg-6 col-md-6 col-sm12">
                            <label for="exampleFormControlInput1">Current Position</label>
                                <asp:TextBox class="form-control" id="v_curpos" placeholder="" runat="server" readonly />       
                        </div>
                        
                        <div class="form-group col-xl-3 col-lg-3 col-md-6 col-sm12">
                            <label for="exampleFormControlInput1">Joined Date</label>
                            <div class="input-group date" data-provide="datepicker">
                                <asp:TextBox class="form-control" id="v_joineddate" placeholder="" runat="server" disabled />       
                                <div class="input-group-addon">
                                    <span class="glyphicon glyphicon-th"></span>
                                </div>
                            </div>
                        </div>
                        
                         <div class="form-group col-xl-3 col-lg-3 col-md-6 col-sm-12">
                            <label for="exampleFormControlInput1">Leave Date</label>
                            <div class="input-group date" data-provide="datepicker">
                                <asp:TextBox class="form-control" id="v_leavedate" placeholder="" runat="server" disabled />       
                                <div class="input-group-addon">
                                    <span class="glyphicon glyphicon-th"></span>
                                </div>
                            </div>
                        </div>
                                                
                       </div>
                       
                       <div class="row">
                        
                        <div class="form-group col-xl-6 col-lg-6 col-md-12 col-sm-12">
                            <label for="exampleFormControlInput1">Key Data</label>                            
                             <textarea class="form-control" id="v_keydata" rows="6" readonly runat="server"></textarea></div>
                        
                       
                        <div class="form-group col-xl-6 col-lg-6 col-md-12 col-sm-12">
                            <label for="exampleFormControlInput1">Remarks</label>                            
                             <textarea class="form-control" id="v_remarks" rows="6" readonly runat="server"></textarea></div>
                        
                       </div>
                       </div>
                       
                                
                        
                        <div class="col-xl-3 col-lg-3 col-md-12 col-sm-12" style="text-align: center">
                            <%--<div class="span8">
                                <img src="img/profile_pic.png" class="rounded mx-auto d-block"/>
                                
                            </div>--%>
                                             <div class="kv-avatar">
                                <div class="file-loading">
                                    <input id="avatar-2" name="avatar-2" type="file" required disabled>
                                </div>
                            </div>
                        </div>
                </div>
                
              </div>
              
              
              </div>
              
              </div>
              </div>

<div class="row">

            <!-- Area Chart -->
            <div class="col-xl-6">
              <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                  <h6 class="m-0 font-weight-bold text-primary">Qualification</h6>                                    
                </div>
                
                <!-- Card Body -->
                <div class="card-body">
                  <div class="table-responsive">
                         <asp:GridView ID="grid_Quali" runat="server" CellSpacing="0"  AutoGenerateColumns="false" Width="100%" class="table table-bordered " OnRowDataBound="GridView1_RowDataBound">  
                           <Columns>     
                               <asp:TemplateField HeaderText="Year obtained<div>(yyyy)</div>" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="gridExpDate">  
                                    <ItemTemplate>             
                                        <asp:TextBox class="form-control grid"  placeholder="" runat="server" readonly="true" Text='<%#Eval("issuedYear")%>' ></asp:TextBox>                                        
                                   </ItemTemplate>  
                               </asp:TemplateField>  
                               <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Qualification" HeaderStyle-HorizontalAlign="Center">  
                               
                                   <ItemTemplate>       
                                <div class="form-row">
                                            <div class="col" style="max-width: 150px" >
                                                <label for="exampleFormControlInput1">Qualification</label>
                                            </div>
                                            <div class="col">
                                        <asp:TextBox ID="TextBox2" class="form-control grid" placeholder="" runat="server" readonly="true" Text=<%#Eval("qualiName")%> ></asp:TextBox>      
                                            </div>
                                          </div>     
                                             <br />       
                                           <div class="form-row">
                                            <div class="col"  style="max-width: 150px" >
                                        <label for="exampleFormControlInput1">Issued By</label>
                                            </div>
                                            <div class="col">
                                        <asp:TextBox ID="TextBox3" class="form-control grid" placeholder="" runat="server" readonly="true" Text=<%#Eval("issuedBy")%> ></asp:TextBox>   
                                            </div>
                                 </div>                    
                                    
                                     
                                   </ItemTemplate>  
                               </asp:TemplateField>  
                               
                               <asp:TemplateField HeaderText="Show in CV" HeaderStyle-CssClass="gridShowInCV">  
                                   <ItemTemplate>  
                                         <div style="text-align: center"><asp:CheckBox ID="CheckBox1" runat="server" Checked='<%#Convert.ToBoolean(Eval("showInCV"))%>' CssClass="checkboxClass" Enabled="false" /></div>
                                   </ItemTemplate>  
                               </asp:TemplateField>          
                           </Columns>  
                           <EmptyDataTemplate>
                                <thead>
                                   <td colspan="3" style="text-align: center">No records found</td>
                                </tr>
                        </EmptyDataTemplate>
                        </asp:GridView>                         
                      </div>
                </div>
              </div>
              
              
            </div>
            
            <div class="col-xl-6">
            
              <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                  <h6 class="m-0 font-weight-bold text-primary">Position Movement</h6>                  
                  
                  <div><b>Paul Y. Management Limited</b></div>
                </div>
                
                <!-- Card Body -->
                <div class="card-body">
                  <div class="table-responsive">
                      
                       <asp:GridView ID="grid_Movement" runat="server" CellSpacing="0"  AutoGenerateColumns="false" Width="100%" class="table table-bordered " OnRowDataBound="GridView1_RowDataBound">  
                           <Columns>     
                               <asp:TemplateField HeaderText="From Date <div>(yyyy-mm-dd)</div>" HeaderStyle-CssClass="gridExpDate">  
                                    <ItemTemplate>             
                                        <asp:TextBox ID="TextBox4" class="form-control grid" placeholder="" runat="server" readonly="true" Text='<%#Eval("fromDate")%>' style="display: inline-block;max-width: 120px;" ></asp:TextBox> 
                                                                
                                   </ItemTemplate>  
                               </asp:TemplateField>  
                               <asp:TemplateField HeaderText="To Date <div>(yyyy-mm-dd)</div>" HeaderStyle-CssClass="gridExpDate">  
                                    <ItemTemplate>             
                                         <asp:TextBox ID="TextBox1" class="form-control grid"  placeholder="" runat="server" readonly="true" Text='<%#Eval("toDate")%>' style="display: inline-block;max-width: 120px;" ></asp:TextBox>   
                                                                    
                                   </ItemTemplate>  
                               </asp:TemplateField>   
                               <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Position" HeaderStyle-HorizontalAlign="Center">  
                                   <ItemTemplate>  
                                        <asp:TextBox class="form-control grid" placeholder="" runat="server" readonly="true" Text=<%#Eval("position")%> Width="100%"></asp:TextBox>        
                                   </ItemTemplate>  
                               </asp:TemplateField> 
                               <asp:TemplateField HeaderText="Show in CV" HeaderStyle-CssClass="gridShowInCV">  
                                   <ItemTemplate>  
                                         <div style="text-align: center"><asp:CheckBox ID="CheckBox1" runat="server" Checked='<%#Convert.ToBoolean(Eval("showInCV"))%>' CssClass="checkboxClass" Enabled="false" /></div>
                                   </ItemTemplate>  
                               </asp:TemplateField>      
                           </Columns>  
                        </asp:GridView>                         
                      </div>
                </div>
              </div>
              
            </div>
            </div>
            <div class="row">
            <!-- Pie Chart -->
            <div class="col-12">
              <div class="card shadow mb-12">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                  <h6 class="m-0 font-weight-bold text-primary">Working Expereince</h6>
                 
                </div>
                <!-- Card Body -->
                <div class="card-body">
                  <div class="table-responsive">
                      <asp:GridView ID="grid_Exp" runat="server" CellSpacing="0"  AutoGenerateColumns="false" Width="100%" class="table table-bordered " OnRowDataBound="GridView1_RowDataBound">  
                           <Columns>     
                               <asp:TemplateField HeaderText="From Date <div>(yyyy-mm-dd)</div>" HeaderStyle-CssClass="gridExpDate">  
                                    <ItemTemplate>             
                                        <asp:TextBox ID="TextBox4" class="form-control grid" placeholder="" runat="server" readonly="true" Text='<%#Eval("fromDate")%>' style="display: inline-block;max-width: 120px;" ></asp:TextBox> 
                                                                
                                   </ItemTemplate>  
                               </asp:TemplateField>  
                               <asp:TemplateField HeaderText="To Date <div>(yyyy-mm-dd)</div>" HeaderStyle-CssClass="gridExpDate">  
                                    <ItemTemplate>             
                                         <asp:TextBox ID="TextBox1" class="form-control grid"  placeholder="" runat="server" readonly="true" Text='<%#Eval("toDate")%>' style="display: inline-block;max-width: 120px;" ></asp:TextBox>   
                                                                    
                                   </ItemTemplate>  
                               </asp:TemplateField>   
                               <asp:TemplateField HeaderText="Company & Position" HeaderStyle-CssClass="gridExpInfo">   
                                   <ItemTemplate>           
                                           <div class="form-row">
                                            <div class="col" style="max-width: 150px" >
                                                <label for="exampleFormControlInput1">Company Name</label>
                                            </div>
                                            <div class="col">
                                        <asp:TextBox ID="TextBox2" class="form-control grid" placeholder="" runat="server" readonly="true" Text=<%#Eval("compName")%> ></asp:TextBox>      
                                            </div>
                                          </div>     
                                             <br />       
                                           <div class="form-row">
                                            <div class="col"  style="max-width: 150px" >
                                        <label for="exampleFormControlInput1">Position</label>
                                            </div>
                                            <div class="col">
                                        <asp:TextBox ID="TextBox3" class="form-control grid" placeholder="" runat="server" readonly="true" Text=<%#Eval("position")%> ></asp:TextBox>   
                                            </div>
                                          </div>                    
                                    
                                   </ItemTemplate>  
                               </asp:TemplateField> 
                               <asp:TemplateField HeaderText="Job Description" HeaderStyle-CssClass="gridDesc">  
                                   <ItemTemplate>  
                                       <textarea id="Textarea1" class="form-control" rows="4" readonly runat="server" Value=<%#Eval("jobDesc")%>></textarea>        
                                   </ItemTemplate>  
                               </asp:TemplateField>  
                               <asp:TemplateField HeaderText="Show in CV" HeaderStyle-CssClass="gridShowInCV">  
                                   <ItemTemplate>  
                                         <div style="text-align: center"><asp:CheckBox runat="server" Checked='<%#Convert.ToBoolean(Eval("showInCV"))%>' CssClass="checkboxClass" Enabled="false" /></div>
                                   </ItemTemplate>  
                               </asp:TemplateField>         
                           </Columns>  
                           <EmptyDataTemplate>
                                <thead>
                                   <td colspan="3" style="text-align: center">No records found</td>
                                </tr>
                        </EmptyDataTemplate>
                     </asp:GridView>       
                        
                       
                      </div>
                </div>
              </div>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-12">
                       <%-- <button type="submit" class="btn btn-primary">Edit</button>
                        <button type="submit" class="btn btn-primary">Print CV</button>
                        <button type="reset" class="btn btn-secondary">Back</button>--%>
                 

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
</body>

</html>