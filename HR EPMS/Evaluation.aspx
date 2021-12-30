<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Evaluation.aspx.cs" Inherits="HR_EPMS.Evaluation" %>
<!DOCTYPE html>
<html lang="en" class="no-js">
  <head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge"> 
    <title>Evaluation Form</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    
    <link href="include/evaluation/evaluation_main.css?timestamp=202105181732" rel="stylesheet" />
    <link href="include/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="include/accordion/style.css" rel="stylesheet" />
    
    <script src="include/jquery/jquery.min.js"></script>
  </head>

  <body class="material-template">
      <form id="form1" runat="server">
    <!-- Loading animation -->
    <div class="preloader">
      <div class="preloader-animation">
        <div class="preloader-spinner">
        </div>
      </div>
    </div>
    <!-- /Loading animation -->

    <div id="page" class="page">
      <!-- Header -->
      <header id="site_header" class="header mobile-menu-hide">
        <div class="header-content" style="width: 100%; max-width: 100%">
          <div class="site-title-block mobile-hidden">
            <div class="site-title" placeholder="" runat="server" id="v_name_with_AppliedPositionDesc"></span></div>
          </div>

        
          <!-- Navigation -->
        </div>
      </header>
      <!-- /Header -->

    
      <!-- Mobile Header -->
      <div class="mobile-header mobile-visible">
        <div class="mobile-logo-container">
          <div class="mobile-site-title" placeholder="" runat="server" id="v_name_with_AppliedPositionDesc2"></div>
        </div>

        <a class="menu-toggle mobile-visible">
          <i class="fa fa-bars"></i>
        </a>
      </div>
      <!-- /Mobile Header -->

        
      <!-- Main Content -->
      <div id="main" class="site-main">
        <!-- Page changer wrapper -->
          <div class="container-fluid" style="max-width: 100%">
              <div class="row">
                  <div class="col-8">
                      
        <div class="pt-wrapper">
          <!-- Subpages -->
          <div class="subpages">

            <!-- Home Subpage -->
            <section class="pt-page" data-id="home">
              <div class="section-inner start-page-content">
                <div class="page-header" style="height: 220px;">
                  <div class="row">
                    <div class="col-sm-4 col-md-4 col-lg-4">
                      <div class="photo" style="text-align: left; border: 0px; box-shadow: 0px 0px 0px 0px rgb(0 0 0 / 10%); background: transparent;">
                        <img id="v_profilepic" src="include/evaluation/img/photo.png" alt="" style="height: 200px" runat="server">
                      </div>
                    </div>

                    <div class="col-sm-8 col-md-8 col-lg-8">
                      <div class="title-block">
                        <h1 style="font-size: 30pt" placeholder="" runat="server" id="v_Eng_name"></h1>
                          <div class="item" >
                            <div class="sp-subtitle" style="20pt" runat="server" id="v_Chi_Name"></div>
                          </div>
                       </div>

                    </div>
                  </div>
                </div>

                <div class="page-content">
					<div class="container-fluid" style="padding: 0px;">
					 <div class="row" style="width:100%">
                    <div class="col-sm-6 col-md-6 col-lg-6">
						<div class="row">
                            <div class="title col-sm-6 col-md-6 col-lg-6">Residential Address</div><div class="value col-sm-6 col-md-6 col-lg-6" runat="server" id="v_address_1"></div>                            
                        </div>

						<div class="row">
							<div class="title col-sm-6 col-md-6 col-lg-6">Tel No.</div><div class="value col-sm-6 col-md-6 col-lg-6" runat="server" id="h_phone"></div>
                        </div>
						<div class="row">
							<div class="title col-sm-6 col-md-6 col-lg-6">Mobile No.</div><div class="value col-sm-6" runat="server" id="t_mobile"></div>
						</div>
                    </div>

					<div class="col-sm-6 col-md-6 col-lg-6">
						<div class="row">
							<div class="title col-sm-6 col-md-6 col-lg-6">Date of Birth</div><div class="value col-sm-6 col-md-6 col-lg-6" runat="server" id="v_DateOfBirth"></div>
                        </div>
						<div class="row">                            
							<div class="title col-sm-6 col-md-6 col-lg-6">Nationality</div><div class="value col-sm-6 col-md-6 col-lg-6" runat="server" id="v_Nationality"></div>
                        </div>
						<div class="row">
                            <div class="title col-sm-6 col-md-6 col-lg-6">Need Working VISA ?</div><div class="value col-sm-6 col-md-6 col-lg-6" runat="server" id="v_WorkingVisa"></div>
						</div>
						<div class="row">
							<div class="title col-sm-6">HKID / Passport No.</div><div class="value col-sm-6" runat="server" id="v_ID"></div>
						</div>
						<div class="row">
							<div class="title col-sm-6">Martial</div><div class="value col-sm-6" runat="server" id="v_MaritalStatus"></div>
						</div>
                    </div>
                  </div>
				  <hr style="height: 1px"/>
				  <div class="row" style="width:100%">
					<div class="col-sm-6 col-md-6 col-lg-6">
						<div class="row">
							<div class="title col-sm-6">Date Available</div><div class="value col-sm-6" runat="server" id="v_AvailableDate"></div>
						</div>
                    </div>
					<div class="col-sm-6 col-md-6 col-lg-6">
						<div class="row">
							<div class="title col-sm-6">Expected Salary</div><div class="value col-sm-6" runat="server" id="v_ExpectedSalry"></div>
						</div>
                    </div>
                  </div>
				  
					</div>
                </div>
              </div>
            </section>
            <!-- End of Home Subpage -->

            <!-- Resume Subpage -->
            <section class="pt-page" data-id="resume">
              <div class="section-inner custom-page-content" style="box-shadow: 0px; -webkit-box-shadow: 0px; -moz-box-shadow: 0px ;">
                <div class="page-content">

                  <div class="row">
                    <div class="col-sm-6 col-md-6 col-lg-6">
                      <div class="block">
                        <div class="block-title">
                          <h3>Education</h3>
                        </div>

                        <div class="timeline">
                          <!-- Education 1 -->
                          <div class="timeline-item">
                            <h4 class="item-title" runat="server" id="v_Edu_Description_1"></h4>
                            <span class="item-period" runat="server" id="v_GradYear_1"></span>
                            <span class="item-small" id="v_Sch_Desc_1" placeholder="" runat="server"></span>
                            <p class="item-description" id="v_ProgrammeName_1" placeholder="" runat="server"></p>
                          </div>
                          <!-- / Education 1 -->

                          <!-- Education 2 -->
                          <div class="timeline-item">
                            <h4 class="item-title" runat="server" id="v_Edu_Description_2"></h4>
                            <span class="item-period" runat="server" id="v_GradYear_2"></span>
                            <span class="item-small" id="v_Sch_Desc_2" placeholder="" runat="server"></span>
                            <p class="item-description" id="v_ProgrammeName_2" placeholder="" runat="server"></p>
                          </div>
                          <!-- / Education 2 -->

                          <!-- Education 3 -->
                          <div class="timeline-item">
                            <h4 class="item-title" runat="server" id="v_Edu_Description_3"></h4>
                            <span class="item-period" runat="server" id="v_GradYear_3"></span>
                            <span class="item-small" id="v_Sch_Desc_3" placeholder="" runat="server"></span>
                            <p class="item-description" id="v_ProgrammeName_3" placeholder="" runat="server"></p>
                          </div>
                          <!-- / Education 3 -->
                        </div>
                      </div>
                    </div>

                    <div class="col-sm-6 col-md-6 col-lg-6">
                      <div class="block">
                        <div class="block-title">
                          <h3>Experience</h3>
                        </div>

                        <div class="timeline">
                          <!-- Experience 1 -->
                          <div class="timeline-item">
                            <h4 class="item-title" runat="server" id="v_Position_1"></h4>
                            <span class="item-period" runat="server" id="v_ExpYear_1"></span>
                            <span class="item-small" runat="server" id="v_Exp_Description_1"></span>
                            <p class="item-description" runat="server" id="v_LeaveDes_1"></p>
                          </div>
                          <!-- / Experience 1 -->

                          <!-- Experience 2 -->
                          <div class="timeline-item">
                            <h4 class="item-title" runat="server" id="v_Position_2"></h4>
                            <span class="item-period" runat="server" id="v_ExpYear_2"></span>
                            <span class="item-small" runat="server" id="v_Exp_Description_2"></span>
                            <p class="item-description" runat="server" id="v_LeaveDes_2"></p>
                          </div>
                          <!-- / Experience 2 -->

                          <!-- Experience 3 -->
                          <div class="timeline-item">
                            <h4 class="item-title" runat="server" id="v_Position_3"></h4>
                            <span class="item-period" runat="server" id="v_ExpYear_3"></span>
                            <span class="item-small" runat="server" id="v_Exp_Description_3"></span>
                            <p class="item-description" runat="server" id="v_LeaveDes_3"></p>
                          </div>
                          <!-- / Experience 3 -->
                        </div>
                      </div>
                    </div>
                  </div>

                  <div class="row">
                    <div class="col-sm-6 col-md-6 col-lg-6">
                      <div class="block">
                        <div class="block-title">
                          <h3><span>Languge</span></h3>
                        </div>

                        <div class="skills-info">
                          <h4 runat="server" id="v_skill_1"></h4>                               
                          <div class="skill-container">
                            <div class="skill-percentage skill-1"></div>
                          </div>

                          <h4 runat="server" id="v_skill_2"></h4>
                          <div class="skill-container">
                            <div class="skill-percentage skill-2"></div>
                          </div>

                          <h4 runat="server" id="v_skill_3"></h4>
                          <div class="skill-container">
                            <div class="skill-percentage skill-3"></div>
                          </div> 
                        </div>

                      </div>
                    </div>

                    <div class="col-sm-6 col-md-6 col-lg-6">
                      <div class="block">
                        <div class="block-title">
                          <h3><span>Qulification</span></h3>
                        </div>

                        <div class="skills-info">
                          <h4 runat="server" id="v_skill_4"></h4>                               
                          <div class="skill-container">
                            <div class="skill-percentage skill-4"></div>
                          </div>

                          <h4 runat="server" id="v_skill_5"></h4>
                          <div class="skill-container">
                            <div class="skill-percentage skill-5"></div>
                          </div>

                          <h4 runat="server" id="v_skill_6"></h4>
                          <div class="skill-container">
                            <div class="skill-percentage skill-6"></div>
                          </div> 
                        </div>
                        
                      </div>
                    </div>
                  </div>
                  <!-- End of Download Resume Button -->

                </div>
              </div>
            </section>
            <!-- End of Resume Subpage -->
			<section class="pt-page" data-id="services">
              <div class="section-inner custom-page-content">
                <div class="page-content">
                  <div class="row">
                    <div class="col-sm-6 col-md-6">
                      <div class="block-title">
                        <h3>Referee</h3>
                      </div>

						   <!-- Picture -->
                            <div class="testimonial-picture">
                              <img src="include/evaluation/img/temp.jpg" alt="">
                            </div>              
                            <!-- /Picture -->
                            <!-- Testimonial author information -->
                            <div class="testimonial-author-info">
                              <p class="testimonial-author" runat="server" id="v_ref_name"></p>
                              <p class="testimonial-firm" runat="server" id="v_ref_comp"></p>
							  <br />
                              <p class="testimonial-firm" runat="server" id="v_ref_position"></p>
                            </div>						
						
						</div>
						 <div class="col-sm-6 col-md-6">
                      <div class="block-title">
                        <h3>Relatives or Friends</h3>
                      </div>

						   <!-- Picture -->
                            <div class="testimonial-picture">
                              <img src="include/evaluation/img/temp.jpg" alt="">
                            </div>              
                            <!-- /Picture -->
                            <!-- Testimonial author information -->
                            <div class="testimonial-author-info">
                              <p class="testimonial-author" runat="server" id="v_relat_name"></p>
                              <p class="testimonial-firm" runat="server" id="v_relat_comp"></p>
							  <br />
                              <p class="testimonial-firm" runat="server" id="v_relat_position"></p>
                            </div>			
						
						</div>
				
                      </div>
					  <div class="clearfix" style="padding-top: 30px"></div>
					   <div class="row">
						<div class="col-sm-12">
						  <div class="block-title">
							<h3>For Reference Only</h3>
						  </div>
						  <div class="container-fluid" style="padding: 0px;">
					 <div class="row" style="width:100%">
                    <div class="col-12">
						<div class="row">
                            <ol>
                                <li><span class="title-q">Have you ever been employed by our group ?</span><br /><span runat="server" id="v_reference_employeeBefore"></span></li>
                                <li><span class="title-q">Have you ever been found guilty of offence in a court of law, whether or not in Hong Kong ?</span><br /><span runat="server" id="v_reference_guility"></span></li>
                                <li><span class="title-q">May we enquire information from any of your previous employer or insitution ?</span><br /><span runat="server" id="v_reference_enquiryfromPrevEmployer"></span></li>
                                <li><span class="title-q">Are you currently taking injury leave and receiving periodical payment from your previous employer as per Employer's Compensation Ordinance ?</span><br /><span runat="server" id="v_reference_injuiryleave"></span></li>                      

                            </ol>
							
				
                        <br />
                    </div>
                  </div>
                </div>
                                  <!-- Download Resume Button -->
                  <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12">
                      <div class="block">
                        <div class="center download-resume">
                            <a id="anchorRefID" href="" class="btn btn-secondary" target="_blank" runat="server">Download Application Form</a>
                        </div>
                      </div>
                    </div>
                  </div>
                  <!-- End of Download Resume Button -->
              </div>
            </section>

          </div>
        </div>
                  </div>
                  <div class="col-4">
                       <div class="subpages">
                          <div class="section-inner custom-page-content">
                <div class="page-header color-1">
                  <h2>Evaluation Form</h2>
                </div>
                <div class="page-content" style="padding: 0px;">
                        Ref No: <span id="cRefNo" runat="server"></span> <br />
                        Current User: <span id="cUser" runat="server"></span><br />
                            <div id="aspect-content">
  <div class="aspect-tab ">
    <input id="item-18" type="checkbox" class="aspect-input" name="aspect">
    <label for="item-18" class="aspect-label"></label>
    <div class="aspect-content">
        <div class="aspect-info">
            <div class="chart-pie negative over50">
                <span class="chart-pie-count">2</span>
                <div>
                    <div class="first-fill"></div>
                    <div class="second-fill" style="transform: rotate(249deg)"></div>
                </div>
            </div>
            <span class="aspect-name">1st Interview</span>
        </div>
        <div class="aspect-stat">
            <div class="all-opinions">
                 <span id="v_interview_1_1" runat="server"></span>    
            </div>
        </div>
    </div>
   <div class="aspect-tab-content">
        <div class="sentiment-wrapper">
                             <input name="e1_hidden_level" id="e1_hidden_level" type="hidden" value="1" runat="server" />
                             <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Qualification</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font " id="e1_quali" placeholder="" max="4" min="1" runat="server" readonly="readonly" value="3">
                                </div>
                              </div>      
                                  <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Experience</label>
                                      <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="e1_exp" placeholder="" max="4" min="1" runat="server"  readonly="readonly" value="2">
                                </div>
                              </div>      
             <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Language Ability</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="e1_lang" placeholder="" max="4" min="1" runat="server"  readonly="readonly" value="3">
                                </div>
                              </div>      
             <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Communication Skill
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="e1_comm" placeholder="" max="4" min="1" runat="server"  readonly="readonly" value="2">
                                </div>
                              </div>      
							   <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Maturity
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="e1_maturity" placeholder="" max="4" min="1" runat="server"  readonly="readonly" value="2">
                                </div>
                              </div>      
							   <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Initiative
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="e1_initiative" placeholder="" max="4" min="1" runat="server" readonly="readonly" value="2">
                                </div>
                              </div>      
							   <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Sense of Responsibility
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="e1_sense" placeholder="" max="4" min="1" runat="server" readonly="readonly" value="2">
                                </div>
                              </div>       <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Stability
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="e1_stable" placeholder="" max="4" min="1" runat="server" readonly="readonly" value="2">
                                </div>
                              </div>      
							   <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Attitude
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="e1_attitude" placeholder="" max="4" min="1" runat="server" readonly="readonly" value="3">
                                </div>
                              </div>  

								<hr />
							   <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm" style="font-weight: bold">Overall Rating
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="e1_overall" placeholder="" max="4" min="1" runat="server"  readonly="readonly" value="2">
                                </div>
                              </div>      
							  
							  
                            <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-12 col-form-label col-form-label-sm">Remarks</label>
                                <div class="col-sm-12" style="padding: 0px;">                                 
                                  <textarea class="form-control text-font" id="e1_remarks" rows="3" runat="server" readonly="readonly"></textarea>
                                </div>                              
                            </div>
                                     
                            <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Interview By</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                                                   <span  id="v_interview_1_2" runat="server" style="font-size: 12pt;"></span>
                                </div>                              
                            </div>

                                <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Interview Date</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <span style="font-size: 12pt;">15 May 2021</span>
                                </div>                              
                            </div>
                        
        </div>
    </div>
  </div>
  <div class="aspect-tab ">
    <input id="item-14" type="checkbox" class="aspect-input" name="aspect">
    <label for="item-14" class="aspect-label"></label>
    <div class="aspect-content">
        <div class="aspect-info">
            <div class="chart-pie positive over50">
                <span class="chart-pie-count"></span>
                <div>
                    <div class="first-fill"></div>
                    <div class="second-fill" style="transform: rotate(209deg)"></div>
                </div>
            </div>

            <span class="aspect-name">2nd Interview</span>
        </div>
        <div class="aspect-stat">
            <div class="all-opinions">
                               <span id="v_interview_2_1" runat="server"></span>      
            </div>
        </div>
    </div>
     <div class="aspect-tab-content">
        <div class="sentiment-wrapper">
                             <input name="e2_hidden_level" id="e2_hidden_level" type="hidden" value="2" runat="server" />
                             <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Qualification</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font " id="e2_quali" placeholder="" max="4" min="1" runat="server" >
                                </div>
                              </div>      
                                  <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Experience</label>
                                      <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="e2_exp" placeholder="" max="4" min="1" runat="server" >
                                </div>
                              </div>      
             <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Language Ability</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="e2_lang" placeholder="" max="4" min="1" runat="server" >
                                </div>
                              </div>      
             <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Communication Skill
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="e2_comm" placeholder="" max="4" min="1" runat="server" >
                                </div>
                              </div>      
							   <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Maturity
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="e2_maturity" placeholder="" max="4" min="1" runat="server" >
                                </div>
                              </div>      
							   <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Initiative
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="e2_initiative" placeholder="" max="4" min="1" runat="server" >
                                </div>
                              </div>      
							   <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Sense of Responsibility
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="e2_sense" placeholder="" max="4" min="1" runat="server" >
                                </div>
                              </div>       <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Stability
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="e2_stable" placeholder="" max="4" min="1" runat="server" >
                                </div>
                              </div>      
							   <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Attitude
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="e2_attitude" placeholder="" max="4" min="1" runat="server" >
                                </div>
                              </div>  

								<hr />
							   <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm" style="font-weight: bold">Overall Rating
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="e2_overall" placeholder="" max="4" min="1" runat="server" >
                                </div>
                              </div>      
							  
							  
                            <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-12 col-form-label col-form-label-sm">Remarks</label>
                                <div class="col-sm-12" style="padding: 0px;">                                 
                                  <textarea class="form-control text-font" id="e2_remarks" rows="3" runat="server" ></textarea>
                                </div>                              
                            </div>
                                     
                            <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Interview By</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                    
                                                                      <span id="v_interview_2_2" runat="server" style="font-size: 12pt;"></span>
                                </div>                              
                            </div>

                                <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Interview Date</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <span style="font-size: 12pt;">15 May 2021</span>
                                </div>                              
                            </div>                       
    </div>
  </div>
  </div>
  <div class="aspect-tab ">
    <input id="item-2" type="checkbox" class="aspect-input" name="aspect">
    <label for="item-2" class="aspect-label"></label>
    <div class="aspect-content">
        <div class="aspect-info">
            <div class="chart-pie positive over50">
                <span class="chart-pie-count"></span>
                <div>
                    <div class="first-fill"></div>
                    <div class="second-fill" style="transform: rotate(119deg)"></div>
                </div>
            </div>
            <span class="aspect-name">3rd Interview</span>
        </div>
        <div class="aspect-stat">
            <div class="all-opinions">
                <span id="v_interview_3_1" runat="server"></span>
            </div>
        </div>
    </div>
         <div class="aspect-tab-content">
        <div class="sentiment-wrapper">
                             <input name="e1_hidden_level" id="Hidden2" type="hidden" value="1" runat="server" />
                             <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Qualification</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font " id="Number11" placeholder="" max="4" min="1" runat="server" readonly="readonly" >
                                </div>
                              </div>      
                                  <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Experience</label>
                                      <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="Number12" placeholder="" max="4" min="1" runat="server"  readonly="readonly" >
                                </div>
                              </div>      
             <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Language Ability</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="Number13" placeholder="" max="4" min="1" runat="server"  readonly="readonly" >
                                </div>
                              </div>      
             <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Communication Skill
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="Number14" placeholder="" max="4" min="1" runat="server"  readonly="readonly" >
                                </div>
                              </div>      
							   <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Maturity
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="Number15" placeholder="" max="4" min="1" runat="server"  readonly="readonly">
                                </div>
                              </div>      
							   <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Initiative
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="Number16" placeholder="" max="4" min="1" runat="server" readonly="readonly" >
                                </div>
                              </div>      
							   <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Sense of Responsibility
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="Number17" placeholder="" max="4" min="1" runat="server" readonly="readonly" >
                                </div>
                              </div>       <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Stability
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="Number18" placeholder="" max="4" min="1" runat="server" readonly="readonly">
                                </div>
                              </div>      
							   <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Attitude
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="Number19" placeholder="" max="4" min="1" runat="server" readonly="readonly" >
                                </div>
                              </div>  

								<hr />
							   <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm" style="font-weight: bold">Overall Rating
</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <input type="number" class="form-control form-control-sm text-font" id="Number20" placeholder="" max="4" min="1" runat="server"  readonly="readonly" >
                                </div>
                              </div>      
							  
							  
                            <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-12 col-form-label col-form-label-sm">Remarks</label>
                                <div class="col-sm-12" style="padding: 0px;">                                 
                                  <textarea class="form-control text-font" id="Textarea2" rows="3" runat="server" readonly="readonly"></textarea>
                                </div>                              
                            </div>
                                     
                            <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Interview By</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <span id="v_interview_3_2" runat="server" style="font-size: 12pt;"></span>
                                </div>                              
                            </div>

                                <div class="form-group row" style="display: flex; max-width: 100%; width: 100%">
                                <label for="colFormLabelSm" class="col-sm-8 col-form-label col-form-label-sm">Interview Date</label>
                                <div class="col-sm-4" style="padding: 0px;">
                                  <span style="font-size: 12pt;"></span>
                                </div>                              
                            </div>
                        
        </div>
    </div>
  </div>
</div>

                           </form>
                    </div>
                        <br />
                        <input type="submit" />
                </div>
              </div>
                  </div></div>
              </div>
          </div>
        <!-- /Page changer wrapper -->
      </div>
     
      <!-- /Main Content -->
    </div>
    <footer>
      
    </footer>

    <!-- <script type="text/javascript" src="js/bootstrap.min.js"></script> -->
    <script src="Scripts/bootstrap.js"></script>
      <script src="include/accordion/script.js"></script>
      <script src="include/evaluation/validator.js"></script>
      <script src="include/evaluation/jquery.hoverdir.js"></script>
      <script src="include/evaluation/evaluation_main.js"></script>
  </body>
</html>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             