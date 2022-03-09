<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenLink.aspx.cs" Inherits="HR_EPMS.GenLink" %>


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
  <link href="include/bootstrap/css/bootstrap-toggle.min.css" rel="stylesheet" type="text/css" />
    <%--<link href="include/datatables/dataTables.bootstrap4.min.css" rel="stylesheet" type="text/css" />--%>
  <link href="css/sb-admin-2.css" rel="stylesheet">
  <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

  <script type="text/javascript">
      var arr = []
      $.ajax({
          url: 'GenLink.aspx',
          type: 'post',
          contentType: "application/json",
          data: "{}",
          success: function (data) {
              a = data.split("|");
              for (var i = 0; i < a.length; i++) {
                  arr.push(JSON.parse(a[i]))
              }
          }
      });
      console.log(arr);
     
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
            <form id="form1" runat="server">
          <!-- Page Heading -->
          <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Recruitment Link</h1>
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
                    
                      <div class="input-group input-group col-xl-12">
                      <div class="input-group-prepend">
                        <span class="input-group-text">Position Name</span>
                      </div>
                       <asp:TextBox class="form-control" placeholder="" id="v_position" runat="server" style=""/>
                      </div>
                    
                    </div>
                         <br />           
                    <div class="row">
                     <div class="input-group input-group col-xl-12">
                        <div class="input-group-prepend">
                            <span class="input-group-text">Reference Code</span>
	                    </div>
                        <div class="row">
                            <div class="input-group col-xl-12  col-lg-12 col-md-12 col-sm-12">
                                 <asp:TextBox class="form-control" placeholder="" id="v_refcode" runat="server" style=""/>
                            </div>
                        </div>
                        
                       </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="input-group input-group col-xl-12">
                           <div class="input-group-prepend">
                                <span class="input-group-text">Date</span>
	                        </div>
                            <div class="row">
                                <div class="input-group col-xl-12  col-lg-12 col-md-12 col-sm-12">
                                     <asp:TextBox class="form-control" placeholder="yyyy-MM-dd" id="dtFrom" runat="server" style="" MaxLength="10"/>
                                </div>
                            </div> 
                              <div class="input-group-prepend">
                                <span class="input-group-text"> To </span>
	                        </div>
                            <div class="row">
                                <div class="input-group col-xl-12  col-lg-12 col-md-12 col-sm-12">
                                     <asp:TextBox class="form-control" placeholder="yyyy-MM-dd" id="dtTo" runat="server" style="" MaxLength="10"/>
                                </div>
                            </div>
                          </div>
                    </div>
                    <br />
                    <div class="row">
                     <div class="input-group input-group col-xl-12">
                        <div class="input-group-prepend">
                            <span class="input-group-text">Status</span>
	                    </div>
                         <div class="input-group-prepend">
                            <select class="form-control" id="v_SelectActive" runat="server">
                              <option value="0">Select</option>
                              <option value="1">Active</option>
                              <option value="2">Inactive</option>
                            </select> 
                          </div>
                       </div>
                    </div>
    <%--                 <div class="row">
                     </div> 

                    --%>
                <br />
                <div class="row">
                  <div class="col-12">
                        <asp:Button ID="btn_Update" runat="server" Text="Generate" class="btn btn-primary" usesubmitbehavior="false" />
                        <asp:Button ID="btn_search" runat="server" Text="Search" class="btn btn-primary" usesubmitbehavior="false" />
                  </div>                  
                </div>
              </div>
              
              
              </div>
              
             <div class="card shadow mb-4">
                <div class="card-body">
              <div class="table-responsive">
              
                <asp:GridView ID="grid_Link" runat="server" AutoGenerateColumns="False" Width="100%" class="table table-bordered " OnRowCancelingEdit="grid_Link_RowCancelingEdit" 
                    OnRowEditing="grid_Link_RowEditing" OnRowUpdating="grid_Link_RowUpdating" OnRowCommand="grid_Link_RowCommand" OnRowDataBound="GridView1_RowDataBound">  
                           <Columns>  
                              
                               <asp:TemplateField HeaderText="ID">  
                                    <ItemTemplate>  
                                        <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>  
                                    </ItemTemplate>  
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Postion" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>  
                                        <asp:Label ID="lbl_position" runat="server" Text='<%#Eval("Postion") %>'></asp:Label> 
                                        <%--<%#Eval("Postion")%>--%>
                                    </ItemTemplate>  
                                    <EditItemTemplate>  
                                        <asp:TextBox ID="txt_position" runat="server" Text='<%#Eval("Postion") %>' Width="100%"></asp:TextBox>  
                                    </EditItemTemplate> 
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                               </asp:TemplateField>       
                               <asp:TemplateField HeaderText="Reference Code." HeaderStyle-HorizontalAlign="Center">  
                                   <ItemTemplate>  
                                        <asp:Label ID="lbl_refCode" runat="server" Text='<%#Eval("RefCode") %>'></asp:Label> 
                                        <%--<%#Eval("Postion")%>--%>
                                    </ItemTemplate>  
                                    <EditItemTemplate>  
                                        <asp:TextBox ID="txt_refCode" runat="server" Text='<%#Eval("RefCode") %>' Width="100%"></asp:TextBox>  
                                    </EditItemTemplate> 
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Create Date" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("CreateDate")%>
                                   </ItemTemplate>  
                                   <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                               </asp:TemplateField>    
                               <asp:TemplateField HeaderText="Expiry Date" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("ExpiryDate")%>
                                   </ItemTemplate>  
                                   <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>             
                                        <%#Eval("Status")%>
                                   </ItemTemplate>  
                                   <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                               </asp:TemplateField>                                                           
                                <asp:TemplateField HeaderText="General Link" HeaderStyle-HorizontalAlign="Center">  
                                    <ItemTemplate>  
                                        <a href='https://career.pyengineering.com/GeneralForm1/Genmain.aspx?ID=<%#Eval("ID")%>' target="_blank" ><asp:Label runat="server" Text='<%# Eval("Lock").ToString()=="0" ? "":"Link | " %>'></asp:Label></a> 
                                        <a href='Copylinkresult.aspx?ID=<%#Eval("ID")%>&LinkType=2' target="_blank"><asp:Label runat="server" Text='<%# Eval("Lock").ToString()=="0" ? "":"Copy Link" %>'></asp:Label></a>
                                   </ItemTemplate>  
                                   <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                               </asp:TemplateField>        
                               <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action">  
                                    <ItemTemplate>
                                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit"/>
                                   </ItemTemplate>  
                                   <EditItemTemplate>  
                                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                                        <asp:Button ID="btn_Repost" runat="server" Text="Active" CommandName="Repost" CommandArgument='<%#Eval("ID") %>'/> 
                                        <asp:Button ID="btn_Deactive" runat="server" Text="Deactive" CommandName="Deactive" CommandArgument='<%#Eval("ID") %>'/>                                         
                                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                                    </EditItemTemplate> 
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
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

  <script src="include/bootstrap/js/bootstrap.bundle.min.js" type="text/javascript"></script>


        
  <!-- Core plugin JavaScript-->
  <script src="include/jquery-easing/jquery.easing.min.js"></script>

  <!-- Custom scripts for all pages-->
  <script src="js/sb-admin-2.js"></script>
  <script src="include/bootstrap/js/bootstrap-toggle.min.js" type="text/javascript"></script>
  <!-- Page level plugins -->

  <script src="include/chart.js/Chart.min.js"></script>

  <script src="include/datatables/datatables.js" type="text/javascript"></script>
  <link href="include/datatables/datatables.css" rel="stylesheet" type="text/css" />
  
  <script>      
  $(function() {
    
    $('#grid_Link').DataTable({  
        dom: 'Bfrtip',
       buttons: [ 'colvis', 'excel' ],
        responsive: true,
        paging: true,
        autoWidth: false,
        info: true,
        searching: true,  
        pageLength: 20,
        "order": [ 0, 'desc' ],
      "columnDefs": [
    { "width": "10%", "targets": 0 }
  ]
     });
  });
  

  </script>
</body>

</html>