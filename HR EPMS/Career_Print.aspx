<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Career_Print.aspx.cs" Inherits="HR_EPMS.Career_Print" %>

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
            //layoutTemplates: {main2: '{preview} ' +  ' {browse}'},
            layoutTemplates: { main2: '{preview} '},
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
            <form id="form1" runat="server" action="Career.aspx" method="post">
          <!-- Page Heading -->
          <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Applicant Profile</h1>
            
          </div>
             <div class="row">

            <!-- Content Column -->
            <div class="col-lg-12">

              <!-- Project Card Example -->
              <div class="card shadow mb-4">
                <div class="card-header py-3">
                  <h6 class="m-0 font-weight-bold text-primary">Applicant Details</h6>
                </div>
                
                <div class="card-body">


                <div class="row">
                       <div class="col-xl-9 col-lg-9 col-md-12 col-sm-12">
                       <div class="row">
                       <div class="form-group col-xl-2 col-lg-2 col-md-6 col-sm-12">
                            <label for="exampleFormControlInput1">Reference No.</label>
                            <asp:TextBox class="form-control" id="v_RefNum" placeholder="" runat="server" readonly />                            
                        </div>
                        <div class="form-group col-xl-6 col-lg-6 col-md-6 col-sm-12 ">
                            <label for="exampleFormControlInput1">Applies Position</label>
                             <asp:TextBox class="form-control" id="v_AppliedPositionDesc" placeholder="" runat="server" readonly />        
                        </div>
                        
                        <div class="form-group col-xl-2 col-lg-2 col-md-6 col-sm-12">
                            <label for="exampleFormControlInput1">Apply Date</label>
                            <div class="input-group date" data-provide="datepicker">                                
                                <asp:TextBox class="form-control" id="v_AppliedDate" placeholder="" runat="server" disabled />       
                                <div class="input-group-addon">
                                    <span class="glyphicon glyphicon-th"></span>
                                </div>
                            </div>
                        </div>
                        
                        <div class="form-group col-xl-2 col-lg-2 col-md-6 col-sm-12">
                            <label for="exampleFormControlInput1">Expected Salary</label>
                            <asp:TextBox class="form-control" id="v_ExpectedSalry" placeholder="" runat="server" readonly />            
                        </div>
                        </div>
                       
                       
                        <div class="row">                        
                        <div class="form-group col-xl-4 col-lg-4 col-md-6 col-sm-12">
                            <label for="exampleFormControlInput1">Available Date</label>
                            <asp:TextBox class="form-control" id="v_AvailableDate" placeholder="" runat="server" readonly />           
                        </div>
                        
                        <div class="form-group col-xl-2 col-lg-2 col-md-6 col-sm12">
                            <label for="exampleFormControlInput1">Nationality</label>
                                <asp:TextBox class="form-control" id="v_Nationality" placeholder="" runat="server" readonly />       
                        </div>
                         <div class="form-group col-xl-2 col-lg-2 col-md-6 col-sm-12 ">
                            <label for="exampleFormControlInput1">Chinese Name</label>
                             <asp:TextBox class="form-control" id="v_Chi_Name" placeholder="" runat="server" readonly />        
                         </div>
                           <div class="form-group col-xl-2 col-lg-2 col-md-8 col-sm-12">
                            <label for="exampleFormControlInput1">Phone</label>
                            <asp:TextBox class="form-control" id="v_Phone" placeholder="" runat="server" readonly />     
                            </div>
                        
                            <div class="form-group col-xl-2 col-lg-2 col-md-8 col-sm-12">
                            <label for="exampleFormControlInput1">Mobile</label>
                            <asp:TextBox class="form-control" id="v_Mobile" placeholder="" runat="server" readonly />     
                            </div>
                         
                        </div>
                       
                       
                        <div class="row">
                        <div class="form-group col-xl-2 col-lg-2 col-md-6 col-sm-12">
                            <label for="exampleFormControlInput1">Salutation</label>
                            <asp:TextBox class="form-control" id="v_Salutation" placeholder="" runat="server" readonly />            
                        </div>
                        <div class="form-group col-xl-4 col-lg-4 col-md-6 col-sm-12">
                        
                            <label for="exampleFormControlInput1">Surname Name</label>
                            <asp:TextBox class="form-control" id="v_Eng_Surname" placeholder="" runat="server" readonly />                            
                        </div>
                        
                        <div class="form-group col-xl-4 col-lg-4 col-md-6 col-sm-12">
                            <label for="exampleFormControlInput1">Given Name</label>
                            <asp:TextBox class="form-control" id="v_Eng_Othername" placeholder="" runat="server" readonly />           
                        </div>
                
                        <div class="form-group col-xl-2 col-lg-2 col-md-6 col-sm-12">
                            <label for="exampleFormControlInput1">Alias</label>
                            <asp:TextBox class="form-control" id="v_AliasName" placeholder="" runat="server" readonly />            
                        </div>
                        </div>
                        
                        <div class="row">

                            <div class="form-group col-xl-3 col-lg-3 col-md-8 col-sm-12">
                            <label for="exampleFormControlInput1">Email</label>
                            <asp:TextBox class="form-control" id="v_Email" placeholder="" runat="server" readonly />     
                            </div>
                        
                            <div class="form-group col-xl-3 col-lg-3 col-md-8 col-sm-12">
                            <label for="exampleFormControlInput1">ID Card</label>
                            <asp:TextBox class="form-control" id="v_ID" placeholder="" runat="server" readonly />     
                            </div>

                            <div class="form-group col-xl-4 col-lg-4 col-md-6 col-sm-12">
                            <label for="exampleFormControlInput1">Do you need a working visa in HK?</label>
                            <asp:TextBox class="form-control" id="v_WorkingVisa" placeholder="" runat="server" readonly />     
                            </div>
                            
                            <div class="form-group col-xl-2 col-lg-2 col-md-6 col-sm12">
                            <label for="exampleFormControlInput1">Date of Birth</label>
                                <div class="input-group date" data-provide="datepicker">
                                    <asp:TextBox class="form-control" id="v_DateOfBirth" placeholder="" runat="server" disabled />       
                                    <div class="input-group-addon">
                                        <span class="glyphicon glyphicon-th"></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                         
                        <div class="row">
                          <div class="form-group col-xl-2 col-lg-2 col-md-6 col-sm-12">
                            <label for="exampleFormControlInput1">Marital  Status</label>
                            <asp:TextBox class="form-control" id="v_MaritalStatus" placeholder="" runat="server" readonly />            
                         </div>

                        

                         <div class="form-group col-xl-5 col-lg-5 col-md-6 col-sm-12">
                            <label for="exampleFormControlInput1">Name of Spouse (If any)</label>
                                <asp:TextBox class="form-control" id="v_SpouseName" placeholder="" runat="server" readonly />   
                         </div>
                         <div class="form-group col-xl-5 col-lg-5 col-md-6 col-sm-12">
                        
                            <label for="exampleFormControlInput1">Spouse's HKID / Passport No.(If any)</label>
                            <asp:TextBox class="form-control" id="v_SpouseHKID" placeholder="" runat="server" readonly />                            
                         </div>                                                
                       </div>
                       
                        <div class="row">
                          <div class="form-group col-xl-2 col-lg-2 col-md-6 col-sm-12">
                            <label for="exampleFormControlInput1">Know vacancy through</label>
                            <asp:TextBox class="form-control" id="v_HTKOth" placeholder="" runat="server" readonly />            
                         </div>
                       </div>
                       

                         
                        <div class="row">
                          <div class="form-group col-xl-6 col-lg-6 col-md-6 col-sm-12">
                            <label for="exampleFormControlInput1">Emergency Contact Person Name: </label>
                            <asp:TextBox class="form-control" id="v_EmergencyContactPerson" placeholder="" runat="server" readonly />            
                         </div>

                        

                         <div class="form-group col-xl-6 col-lg-6 col-md-6 col-sm-12">
                            <label for="exampleFormControlInput1">Relationship</label>
                                <asp:TextBox class="form-control" id="v_EmergencyContactRelationship" placeholder="" runat="server" readonly />   
                         </div>
                                               
                       </div>                       
                        <div class="row">
                          <div class="form-group col-xl-6 col-lg-6 col-md-6 col-sm-12">
                            <label for="exampleFormControlInput1">Address</label>
                            <asp:TextBox class="form-control" id="v_EmergencyContactAddr" placeholder="" runat="server" readonly />            
                         </div>

                        

                         <div class="form-group col-xl-6 col-lg-6 col-md-6 col-sm-12">
                            <label for="exampleFormControlInput1">Contact Tel. No.</label>
                                <asp:TextBox class="form-control" id="v_EmergencyContactPhone" placeholder="" runat="server" readonly />   
                         </div>
                                               
                       </div>                       

                       	<div class="row">
                        
                            <div class="form-group col-xl-8 col-lg-8 col-md-8 col-sm-12 ">
                            <label for="exampleFormControlInput1">Address</label>
                             <asp:TextBox class="form-control" id="v_Addr_1" placeholder="" runat="server" readonly />        
                            </div>
                        </div>
                        
                        <div class="row">
                        <div class="form-group col-xl-8 col-lg-8 col-md-8 col-sm-12 ">
                             <asp:TextBox class="form-control" id="v_Addr_2" placeholder="" runat="server" readonly />        
                        </div>                        
                       </div>
                       
                        <div class="row">
                        <div class="form-group col-xl-8 col-lg-8 col-md-8 col-sm-12 ">
                             <asp:TextBox class="form-control" id="v_Addr_3" placeholder="" runat="server" readonly />        
                        </div>
                        </div>
                       
                        <div class="row">
                             <div class="form-group col-xl-4 col-lg-4 col-md-6 col-sm-12 ">
                                <asp:TextBox class="form-control" id="v_Addr_Subdistrict" placeholder="" runat="server" readonly />        
                              </div>
                              <div class="form-group col-xl-4 col-lg-4 col-md-6 col-sm-12 ">
                                <asp:TextBox class="form-control" id="v_Addr_District" placeholder="" runat="server" readonly />        
                              </div>

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
                     <div class="row">
                         <div class="form-group col-xl-6 col-lg-6 col-md-6 col-sm-12 ">
                         <h6 class="m-0 font-weight-bold text-primary">Download Applicant's Uploaded Files</h6>
                         </div>
                         <div class="form-group col-xl-6 col-lg-6 col-md-6 col-sm-12 ">
                         <a id="anchorID_except"  runat="server" download>No Any Uploaded File</a>
                         </div>
                     </div>
                     <div class="row">
                        <div class="form-group col-xl-2 col-lg-3 col-md-6 col-sm-12 ">
                        <a id="anchorID_1"  runat="server" download>File 1</a>
                        </div>
                        <div class="form-group col-xl-2 col-lg-3 col-md-6 col-sm-12 ">
                        <a id="anchorID_2"  runat="server" download>File 2</a>
                        </div>
                        <div class="form-group col-xl-2 col-lg-3 col-md-6 col-sm-12 ">
                        <a id="anchorID_3"  runat="server" download>File 3</a>
                        </div>
                        <div class="form-group col-xl-2 col-lg-3 col-md-6 col-sm-12 ">
                        <a id="anchorID_4"  runat="server" download>File 4</a>
                        </div>
                        <div class="form-group col-xl-2 col-lg-3 col-md-6 col-sm-12 ">
                        <a id="anchorID_5"  runat="server" download>File 5</a>
                        </div>
                      </div>
                </div>
              
              </div>
              
              </div>
              </div>

            <div class="row">
            <!-- Pie Chart -->
          </div>


            <div class="row">

            <!-- Area Chart -->
            </div>
          <br />
          
          <div class="row">
            <!-- Pie Chart -->
          </div>

          <br />
          <div class="row">
            <!-- Pie Chart -->
          </div>

          <br />
        <div class="row">
            <!-- Pie Chart -->
            <div class="col-12">
              <div class="card shadow mb-12">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                 
                </div>
                <!-- Card Body -->
                <div class="card-body">
                  <div class="table-responsive">
                        
                       
                      </div>
                      
                       
                       
                        <div class="row">                        
                        <div class="form-group col-xl-2 col-lg-2 col-md-4 col-sm-12">
                            <label for="exampleFormControlInput1">English </label>
                        </div>
                        
                        
                         
                        <div class="form-group col-xl-2 col-lg-2 col-md-4 col-sm-12">
                            <label for="exampleFormControlInput1">Chinese </label>
                        </div>
                        
                        <div class="form-group col-xl-4 col-lg-4 col-md-4 col-sm-12">
                            <label for="exampleFormControlInput1">Others Skills</label>
                        </div>
                                                
                         
                        </div>
                        
                                                <div class="row">   
                                                <div class="form-group col-xl-1 col-lg-1 col-md-2 col-sm12">
                            <asp:TextBox class="form-control" id="v_EnglishTypeWPM" placeholder="" runat="server" readonly />       
                        </div>
                        <div class="form-group col-xl-1 col-lg-1 col-md-2 col-sm-12">
                            <label for="exampleFormControlInput1">wpm </label>
                        </div><div class="form-group col-xl-1 col-lg-1 col-md-2 col-sm12">
                            <asp:TextBox class="form-control" id="v_ChineseTypeWPM" placeholder="" runat="server" readonly />       
                        </div>
                        <div class="form-group col-xl-1 col-lg-1 col-md-2 col-sm-12">
                            <label for="exampleFormControlInput1">wpm </label>
                        </div>
                                                <div class="form-group col-xl-4 col-lg-4 col-md-6 col-sm12">
                            <asp:TextBox class="form-control" id="v_OtherSkills" placeholder="" runat="server" readonly />       
                        </div>
                                                </div>


                </div>
              </div>
            </div>
          </div>

          <br />
          <div class="row">
            <!-- Pie Chart -->
          </div>

          <br />
           <div class="row">
            <!-- Pie Chart -->
          </div>
          
          <br />
          <div class="row">
           <div class="col-12">
              <div class="card shadow mb-12">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                  <h6 class="m-0 font-weight-bold text-primary">FOR REFERENCE ONLY</h6>
          </div> 
           <div class="card-body">
                  <div class="table-responsive">
           
                       <div class="col-xl-9 col-lg-9 col-md-12 col-sm-12">
                       <div class="row">
                       <div class="form-group col-xl-6 col-lg-6 col-md-8 col-sm-12">
                            <label for="exampleFormControlInput1">Have you ever been employed by our group ?</label>
                            <asp:TextBox class="form-control" id="v_reference_employeeBefore" placeholder="" runat="server" readonly />                            
                        </div>
                        </div>
                       
                       
                        <div class="row">                        
                        <div class="form-group col-xl-8 col-lg-8 col-md-8 col-sm-12">
                            <label for="exampleFormControlInput1">Have you ever been found guilty of offence in acourt of law, whether or not in Hong Kong?</label>
                            <asp:TextBox class="form-control" id="v_reference_guility" placeholder="" runat="server" readonly />           
                        </div>
                        
                        <div class="form-group col-xl-4 col-lg-4 col-md-8 col-sm12">
                            <label for="exampleFormControlInput1">Please specify</label>
                                <asp:TextBox class="form-control" id="v_reference_TxtInputRef_Guility" placeholder="" runat="server" readonly />       
                        </div>
                         
                         
                        </div>
                        
                        <div class="row">                        
                        <div class="form-group col-xl-8 col-lg-8 col-md-8 col-sm-12">
                            <label for="exampleFormControlInput1">May we enquire information from any of your previous employee?</label>
                            <asp:TextBox class="form-control" id="v_reference_enquiryfromPrevEmployer" placeholder="" runat="server" readonly />           
                        </div>
                        
                        <div class="form-group col-xl-4 col-lg-4 col-md-8 col-sm12">
                            <label for="exampleFormControlInput1">Reason</label>
                                <asp:TextBox class="form-control" id="v_reference_TxtInputRef_enquiryfromPrevEmployer" placeholder="" runat="server" readonly />       
                        </div>
                         
                         
                        </div>
                        
                        <div class="row">                        
                        <div class="form-group col-xl-8 col-lg-8 col-md-8 col-sm-12">
                            <label for="exampleFormControlInput1">Are you currently taking injury leave and receiving periodical payment from your previous employer as per Employer's Compensation Ordinance?</label>
                            <asp:TextBox class="form-control" id="v_reference_injuiryleave" placeholder="" runat="server" readonly />           
                        </div>
                        
                        <div class="form-group col-xl-4 col-lg-4 col-md-8 col-sm12">
                            <label for="exampleFormControlInput1">Please specify</label>
                                <asp:TextBox class="form-control" id="v_reference_TxtInputRef_injuiryleave" placeholder="" runat="server" readonly />       
                        </div>
                         
                         
                        </div>
                                                
                       </div>
           </div>
            </div>
               </div>
               </div>
               </div>
          <div class="row">
            <div class="col-12">
                       <%-- <button type="submit" class="btn btn-primary">Edit</button>
                        <button type="submit" class="btn btn-primary">Print CV</button>
                        <button type="reset" class="btn btn-secondary">Back</button>--%>
                 
                <br />
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