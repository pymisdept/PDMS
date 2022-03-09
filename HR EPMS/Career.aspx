<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Career.aspx.cs" Inherits="HR_EPMS.Career" %>

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

    <script type="text/javascript">
        //alert(document.getElementById('grdList1'));
        function changepage() {
            var ht = screen.height;
            var newht = ht - 380;
            document.getElementById('grdList').style.height = newht.toString() + "px";
            //alert(window.innerHeight);
        }
        function checkdate() {
            alert("Date To cannot less than date From!")
        }
    </script>
    <style type="text/css">
        .StickyHeader th {
       position: sticky;
       top: 0;
       background-color:white
       }
        .btnDownload {
            vertical-align:central
        }
     </style>

</head>

<body style="height: 100%;padding:0;margin:0;overflow:scroll">
   
  <!-- Page Wrapper -->
  <div id="wrapper">
  
    <!--#include file="LeftMenu.inc"-->

    <!-- Content Wrapper -->
    <div id="content-wrapper" class="d-flex flex-column">

      <!-- Main Content -->
      <div id="content">

    
        <!-- Begin Page Content -->
        <div class="container-fluid" >
            <form id="form1" runat="server" action="Career" method="post">
          <!-- Page Heading -->
          <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h5 class="h5 mb-0 text-gray-800">Application (General)</h5>
            
          </div>
             <div class="row">

            <!-- Content Column -->
            <div class="col-lg-12">

              <!-- Project Card Example -->
              <div class="card shadow mb-4" style="height:250px">
                <div class="card-header py-3">
                  <h6 class="m-0 font-weight-bold text-primary">Search Applicants</h6>
                </div>
                <div class="card-body">
                    <div class="row">
                  <div class="input-group col-md-6">
                      <div class="input-group-prepend">
                        <span class="input-group-text">Reference No.</span>
                      </div>
                      <asp:TextBox class="form-control" placeholder="" id="v_refno" MaxLength ="23"  runat="server"/>
                    </div>
                    
                    <div class="input-group col-xl-4 col-lg-4 col-md-6 col-sm-12">
                      <div class="input-group-prepend">
                        <span class="input-group-text" id="Span9">Applied Position</span>
                      </div>
                      <input type="text" class="form-control" placeholder="Applied Position Keyword" id="v_appliedposition" runat="server" />
                    </div>
                   <%-- <div class="input-group col-xl-3 col-lg-3 col-md-5 col-sm-9">
                      <div class="input-group-prepend">
                        <span class="input-group-text" id="Span1">Staff Name</span>
                      </div>
                      <input type="text" class="form-control" id="v_staffname" placeholder="English / Chinese Name Keyword" runat="server" />
                    </div>--%>
                    
                    
                   
                </div>
                <br />
                
                <div class="row">
                      <div class="input-group col-xl-2 col-lg-2 col-md-6 col-sm-12">
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
                     <div class="input-group col-xl-4 col-lg-4 col-md-6 col-sm-12">
                      <div class="input-group-prepend">
                        <span class="input-group-text" id="Span4">Education</span>
                      </div>
                      <input type="text" class="form-control" placeholder="Education Level" id="v_edu" runat="server" />
                    </div>
                      
                </div>    
                                           
                <br />        
               
                <div class="row">
                  <div class="input-group col-xl-4 col-lg-4 col-md-6 col-sm-12">
                        <div class="input-group-prepend">
                        <span class="input-group-text" id="DateApply">Apply Date</span>
                        </div>
                        <input type="text" class="form-control" placeholder="yyyy-MM-dd" id="v_Datefrom" runat="server" />
                            <div class="input-group-prepend">
                        <span class="input-group-text" id="Dateto">To</span>
                        </div>
                        <input type="text" class="form-control" placeholder="yyyy-MM-dd" id="v_Dateto" runat="server" />
                      <%--<div class="col-12">--%>
                      <div style="left:20px"></div>
                      <span>
                        <%--<button type="submit" class="btn btn-primary">Search</button>
                        <button type="reset" class="btn btn-secondary">Reset</button>
                        --%>
                        <asp:Button ID="btn_search" runat="server" Text="Search" class="btn btn-primary" usesubmitbehavior="false" />
                        <asp:Button ID="btn_Update" runat="server" Text="Reset" class="btn btn-primary" usesubmitbehavior="false" />
                      </span>
                     <%--</div>--%>
                    </div>
                     
                </div>
              </div>              
              </div>
            
             <div id="grdList" class="card" style="height:580px">
                <div class="card-body">
              <div style="width:100%;height:100%; overflow:scroll" >
              <%--<asp:panel id="panel1" runat="server" ScrollBars="Horizontal">--%>
                <asp:GridView ID="grid_Employee" runat="server"  AutoGenerateColumns="False" Width="100%" class="table table-bordered " OnRowCancelingEdit="grid_Employee_RowCancelingEdit" 
                    OnRowEditing="grid_Employee_RowEditing" OnRowUpdating="grid_Employee_RowUpdating" OnRowCommand="grid_Employee_RowCommand" OnRowDataBound="grid_Employee_RowDataBound" CssClass="StickyHeader" ClientIDMode="Static" ShowHeaderWhenEmpty="True">  
                           <Columns> 
                               <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center">  
                                     <ItemTemplate>  
                                        <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>  
                                    </ItemTemplate>   

<HeaderStyle HorizontalAlign="Center" BackColor="#FFDDCC"></HeaderStyle>
                               </asp:TemplateField> 
                               <asp:TemplateField HeaderText="Reference No." HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>      
                                        <asp:Label ID="lbl_refnum" runat="server" Text='<%#Eval("RefNum") %>'></asp:Label> 
                                   </ItemTemplate>  

<HeaderStyle HorizontalAlign="Center" BackColor="#FFDDCC"></HeaderStyle>
                               </asp:TemplateField> 
                               <asp:TemplateField HeaderText="Apply Date" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("AppliedDate")%> 
                                   </ItemTemplate>  

<HeaderStyle HorizontalAlign="Center" BackColor="#FFDDCC"></HeaderStyle>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Applied Position" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("ApplyPosition")%>
                                   </ItemTemplate>  

<HeaderStyle HorizontalAlign="Center" BackColor="#FFDDCC"></HeaderStyle>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="English Name" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("Eng_Surname")%> <%#Eval("Eng_Othername")%> , <%#Eval("AliasName")%>     
                                   </ItemTemplate>  

<HeaderStyle HorizontalAlign="Center" BackColor="#FFDDCC"></HeaderStyle>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="District" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("Addr_District")%>   
                                   </ItemTemplate>  

<HeaderStyle HorizontalAlign="Center" BackColor="#FFDDCC"></HeaderStyle>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Education Level" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("EduLvl")%>   
                                   </ItemTemplate>  

<HeaderStyle HorizontalAlign="Center" BackColor="#FFDDCC"></HeaderStyle>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Programme Name / Subject" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("ProgramName")%>
                                   </ItemTemplate>  

<HeaderStyle HorizontalAlign="Center" BackColor="#FFDDCC"></HeaderStyle>
                               </asp:TemplateField> 
                               <asp:TemplateField HeaderText="Working Exp(Year)" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("WorkEXP")%>
                                   </ItemTemplate>  

<HeaderStyle HorizontalAlign="Center" BackColor="#FFDDCC"></HeaderStyle>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Expected Salary" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("ExpectedSalry")%>
                                   </ItemTemplate>  

<HeaderStyle HorizontalAlign="Center" BackColor="#FFDDCC"></HeaderStyle>
                               </asp:TemplateField>  
                               <asp:TemplateField HeaderText="Date Available" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("AvailableDateOpt")%>
                                   </ItemTemplate>  

<HeaderStyle HorizontalAlign="Center" BackColor="#FFDDCC"></HeaderStyle>
                               </asp:TemplateField>
                              
                               <asp:TemplateField HeaderText="Current Position" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("LatestPosition")%>
                                   </ItemTemplate>  

<HeaderStyle HorizontalAlign="Center" BackColor="#FFDDCC"></HeaderStyle>
                               </asp:TemplateField>         
                                <asp:TemplateField HeaderText="CV" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>     
                                       <a href='https://career.pyengineering.com/GeneralForm1/CVFile/<%#Eval("FileName1")%>' target="_blank">View</a>
                                   </ItemTemplate>  

<HeaderStyle HorizontalAlign="Center" BackColor="#FFDDCC"></HeaderStyle>
                               </asp:TemplateField> 
                               <asp:TemplateField HeaderText="Dtls/Rpt" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <a href='GraduateDetails.aspx?sid=<%#Eval("RefNum")%>' target="_blank">Dtl</a>
                                        <!-- <a href='http://10.1.1.106/HRMStest/ReportFrame.aspx?Report=Career_Report-graduate.rpt&RefNo=<%#Eval("RefNum")%>' target="_blank">Rpt</a>-->
                                        <a href='http://10.1.1.106/HRMSUAT_Fresh/ReportFrame.aspx?Report=Career_Report-graduate-uat.rpt&RefNo=<%#Eval("RefNum")%>' target="_blank">Rpt</a>
                                   </ItemTemplate>  

<HeaderStyle HorizontalAlign="Center" BackColor="#FFDDCC"></HeaderStyle>
                               </asp:TemplateField>  
                               <%--Application Form--%>
                               <asp:TemplateField HeaderText="Application Form">
                                   <HeaderStyle HorizontalAlign="Center" BackColor="#E2EFDA"></HeaderStyle>
                                   <ItemTemplate>     
                                        <a href='https://career.pyengineering.com/GeneralForm2/phase2main.aspx?Position=<%# Eval("ApplyPosition")%>&RefCode=<%# Eval("RefNum")%>' target="_blank"><asp:Label runat="server" Text="Link"></asp:Label></a>
                                   </ItemTemplate>  
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Link">
                                   <ItemTemplate>     
                                        <a href='Copylinkresult.aspx?Key=<%# Eval("Token")%>&Position=<%# Eval("ApplyPosition")%>&RefCode=<%# Eval("RefNum")%>&LinkType=3' target="_blank"><asp:Label runat="server" Text="Copy Link"></asp:Label></a>
                                   </ItemTemplate>
                                   <HeaderStyle BackColor="#E2EFDA" />
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Submission">
                                   <HeaderStyle BackColor="#E2EFDA" />
                                   <ItemTemplate>
                                       <%# Eval("SubmitStatus") %>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Company Name">
                                   <HeaderStyle BackColor="#E2EFDA" />
                                   <ItemTemplate>
                                       <asp:Label ID="lbl_companyname" runat ="server" Text='<%# Eval("Companyname") %>'></asp:Label>
                                       <%--<asp:DropDownList ID="ddlcompanyname" runat ="server" Width ="250px"></asp:DropDownList>--%>
                                   </ItemTemplate>
                                   <EditItemTemplate>    
                                       <%--<asp:TextBox ID="lbl_companyname" runat ="server" Text='<%# Eval("Companyname") %>' Width ="100%"></asp:TextBox>--%>  
                                       <asp:DropDownList ID="ddlcompanyname" runat ="server" Width ="250px"></asp:DropDownList>
                                   </EditItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Action">
                                   <HeaderStyle BackColor="#E2EFDA" />
                                    <ItemTemplate>
                                        <div style="padding:15px">
                                            <asp:Button ID="btnDownload" runat="server" BorderStyle="Outset" BorderColor="#808080" Text="Download Application Form" BackColor="#5b9bd5" ForeColor ="White" CommandName="btnDownload"/>
                                        </div>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <%--Interview--%>
                               <asp:TemplateField HeaderText="Date">
                                   <HeaderStyle BackColor="#FFF2CC" />
                                    <ItemTemplate>
                                       <asp:Label ID="lbl_interviewdate" runat ="server" Text='<%# Eval("InterviewDate") %>' Width ="100%"></asp:Label>
                                   </ItemTemplate>
                                   <EditItemTemplate>
                                       <asp:TextBox ID="txt_interviewdate" runat ="server" Text ='<%# Eval("InterviewDate") %>' Width ="100%"></asp:TextBox>
                                   </EditItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Time">
                                   <HeaderStyle BackColor="#FFF2CC" />
                                   <ItemTemplate>
                                       <asp:Label ID="lbl_interviewtime" runat ="server" Text='<%# Eval("InterviewTime") %>' Width ="100%"></asp:Label>
                                   </ItemTemplate>
                                   <EditItemTemplate>
                                       <asp:TextBox ID="txt_interviewtime" runat ="server" Text ='<%# Eval("InterviewTime") %>' Width ="100%"></asp:TextBox>
                                   </EditItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Address">
                                   <HeaderStyle BackColor="#FFF2CC" />
                                     <ItemTemplate>
                                       <asp:Label ID="lbl_interviewadress" runat ="server" Text='<%# Eval("InterviewAdress") %>' Width ="100%"></asp:Label>
                                   </ItemTemplate>
                                   <EditItemTemplate>
                                       <asp:TextBox ID="txt_interviewadress" runat ="server" Text ='<%# Eval("InterviewAdress") %>' Width ="100%"></asp:TextBox>
                                   </EditItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Contact Person">
                                   <HeaderStyle BackColor="#FFF2CC" />
                                   <HeaderStyle BackColor="#FFF2CC" />
                                     <ItemTemplate>
                                       <asp:Label ID="lbl_Contactperson" runat ="server" Text='<%# Eval("Contactperson") %>' Width ="100%"></asp:Label>
                                   </ItemTemplate>
                                   <EditItemTemplate>
                                       <asp:TextBox ID="txt_Contactperson" runat ="server" Text ='<%# Eval("Contactperson") %>' Width ="100%"></asp:TextBox>
                                   </EditItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Contact No.">
                                   <HeaderStyle BackColor="#FFF2CC" />
                                   <ItemTemplate>
                                       <asp:Label ID="lbl_Contactno" runat ="server" Text='<%# Eval("Contactno") %>' Width ="100%"></asp:Label>
                                   </ItemTemplate>
                                   <EditItemTemplate>
                                       <asp:TextBox ID="txt_Contactno" runat ="server" Text ='<%# Eval("Contactno") %>' Width ="100%"></asp:TextBox>
                                   </EditItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Remark">
                                   <HeaderStyle BackColor="#FFF2CC" />
                                   <ItemTemplate>
                                       <asp:Label ID="lbl_Remarks" runat ="server" Text='<%# Eval("Remarks") %>' Width ="100%"></asp:Label>
                                   </ItemTemplate>
                                   <EditItemTemplate>
                                       <asp:TextBox ID="txt_Remarks" runat ="server" Text ='<%# Eval("Remarks") %>' Width ="100%"></asp:TextBox>
                                   </EditItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action">  
                                    <ItemTemplate>
                                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit"/>
                                        <asp:Button ID="btnsendmail" runat="server" Text="Email Invitation" CommandName="SendMail"/>
                                   </ItemTemplate>  
                                   <EditItemTemplate>  
                                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                                        <%--<asp:Button ID="btn_Repost" runat="server" Text="Active" CommandName="Repost" CommandArgument='<%#Eval("ID") %>'/> 
                                        <asp:Button ID="btn_Deactive" runat="server" Text="Deactive" CommandName="Deactive" CommandArgument='<%#Eval("ID") %>'/>    --%>                                     
                                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                                    </EditItemTemplate> 
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                               </asp:TemplateField>            
                           </Columns>  
                           <HeaderStyle CssClass="StickyHeader" Wrap="True" />
                           <PagerSettings Position="TopAndBottom" />
                  </asp:GridView>   
                  <%--</asp:panel>--%>
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
  <script src="include/bootstrap/js/bootstrap.bundle.min.js"></script>

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
            dom: '<<"top"Bpl>f<t>i>',
            buttons: ['colvis', 'excel'],
            responsive: false,
            paging: false,
            info: true,
            autoWidth: true,
            pageLength: 10,
            searching: true,            
            "order": [ 0, 'desc' ]
         } );   
    });
    </script>
</body>

</html>