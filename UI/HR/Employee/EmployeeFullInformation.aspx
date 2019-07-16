<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeFullInformation.aspx.cs" Inherits="UI.HR.Employee.EmployeeFullInformation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Information</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel0" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <div style="height: 10px; width: 100%"></div>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="container">
                    <h2>Employee Information</h2>
                    <ul class="nav nav-tabs">
                        <li class="active"><a data-toggle="tab" href="#personal">Personal</a></li>
                        <li><a data-toggle="tab" href="#education">Education/Training</a></li>
                        <li><a data-toggle="tab" href="#experience">Experience</a></li>
                        <li><a data-toggle="tab" href="#training">Training</a></li>
                        <li><a data-toggle="tab" href="#others">Others</a></li>
                        <li><a data-toggle="tab" href="#photograph">Photograph</a></li>
                    </ul>

                    <div class="tab-content">
                        <div id="personal" class="tab-pane fade">
                            <h3>Personal Inforation</h3>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                        <asp:Label ID="Label2" runat="server" Text="Enroll"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtEnroll" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Enter Epmoyee Enroll"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                        <asp:Label ID="Label3" runat="server" Text="Code"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtCode" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Enter Epmoyee Code"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-sm-4 col-xs-12" style="padding-top: 20px">
                                        <asp:Button ID="btnShowEmployeeInformation" runat="server" class="btn btn-primary form-control pull-right" Text="Show" OnClientClick="return showValidation();" OnClick="btnShowEmployeeInformation_Click" />
                                    </div>
                                     <div class="col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px">
                                        <br />
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <asp:Label ID="Label20" runat="server" Text="Name"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtName" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Enter Epmoyee Name"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label12" runat="server" Text="Fathers Name"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtFatherName" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Enter Father Name" ></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label13" runat="server" Text="Mothers Name"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtMotherNmae" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Enter Mother name" ></asp:TextBox>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <asp:Label ID="Label15" runat="server" Text="Permanent Address"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtPermanetAddress" TextMode="MultiLine" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Write your full Permamet Address" ></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                        <asp:Label ID="Label16" runat="server" Text="NID no"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtNidNo" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Enter NID NO" ></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                        <asp:Label ID="Label1" runat="server" Text="Mobile No"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtMobileNo" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Ex:01XXXXXXXXX" ></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                        <asp:Label ID="Label17" runat="server" Text="Last Promotion Date"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtPromotionDate" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="DD/MM/YYYY" ></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                        <asp:Label ID="Label18" runat="server" Text="Present Designation"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:DropDownList ID="ddlPresentDesignation" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                        <asp:Label ID="Label4" runat="server" Text="Present Department"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:DropDownList ID="ddlPresentDepartment" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                        <asp:Label ID="Label19" runat="server" Text="Present Salary"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtPresentSalary" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Enter Present Salary" ></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                        <asp:Label ID="Label21" runat="server" Text="joining Date of Organization"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtJoiningDate" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="DD/MM/YYYY" ></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                        <asp:Label ID="Label22" runat="server" Text="joining Designation"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:DropDownList ID="ddlJoiningDesignation" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                        <asp:Label ID="Label23" runat="server" Text="joining salary"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtJoiningSalary" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Enter Joing Salary" ></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                        <asp:Label ID="Label24" runat="server" Text="previous Organization"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtPreviousOrganization" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Enter Previous Organization" ></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                        <asp:Label ID="Label25" runat="server" Text="previous Designation"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtPreviousDesignation" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Enter Previous Designation" ></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                        <asp:Label ID="Label26" runat="server" Text="previous Salary"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtPreviousSalary" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Enter Previous Salry" ></asp:TextBox>
                                    </div>

                                    <div class="col-md-12 col-sm-12" style="padding-top: 10px">
                                        <asp:Button ID="btnInsertPersonalInfo" runat="server" class="btn btn-success form-control pull-right" Text="Insert" OnClientClick="return PersonalInfoValidate();" OnClick="btnInsertPersonalInfo_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="education" class="tab-pane fade">
                            <h3>Education Iformation</h3>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label5" runat="server" Text="Level Of Education"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:DropDownList ID="ddlLevelOfEducation" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label6" runat="server" Text="Result"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:DropDownList ID="ddlResult" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label7" runat="server" Text="Exam/Degree"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:DropDownList ID="ddlExam" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label8" runat="server" Text="Board"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:DropDownList ID="ddlBoard" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label37" runat="server" Text="Year Of Passing"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:DropDownList ID="ddlYearOfPassing" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label9" runat="server" Text="CGPA"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtCgpa" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Ex: 3.92" ></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label10" runat="server" Text="Scale"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtScale" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Ex: 4.00" ></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label11" runat="server" Text="Concentration/ Major/ Group"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtMajorGroup" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Major / Group" ></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label14" runat="server" Text="Institude Name"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtInstitude" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Ex: Dhaka University" ></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label27" runat="server" Text="Duration"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtDuration" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="EX: 4 Yeasrs" ></asp:TextBox>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <asp:Label ID="Label30" runat="server" Text="Achivement"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtAchivement" TextMode="MultiLine" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Enter all of your Achivements" ></asp:TextBox>
                                    </div>

                                    <div class="col-md-12 col-sm-12" style="padding-top: 10px">
                                        <asp:Button ID="btnAddEducationInfo" runat="server" class="btn btn-success form-control pull-right" Text="Add" OnClientClick="return EducationInfoValidate();" OnClick="btnAddEducationInfo_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="experience" class="tab-pane fade in active">
                            <h3>Experience Information</h3>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label28" runat="server" Text="Comapny Name"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtCompanyName" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Ex: Akij Group"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label29" runat="server" Text="Company Business"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtCompanyBusiness" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Company Business"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label32" runat="server" Text="Designation"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtEmploymentDesignation" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Ex: Software Engineer"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label34" runat="server" Text="Department"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtEmployementDepartment" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Ex: Planning and Implementation" ></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label31" runat="server" Text="Responsibilities"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtResponsibilities" TextMode="MultiLine" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Write your responsibility in this company"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label33" runat="server" Text="Company Address"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtCompanyAddress" TextMode="MultiLine" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Write full address of your company"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3 col-sm-3 col-xs-6">
                                        <asp:Label ID="Label35" runat="server" Text="Employment From"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtFromDate" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Ex: dd/mm/yyyy" ></asp:TextBox>
                                    </div>
                                    <div class="col-md-3 col-sm-3 col-xs-6">
                                        <asp:Label ID="Label36" runat="server" Text="Employment To"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtToDate" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Ex: dd/mm/yyyy" ></asp:TextBox>
                                        <asp:CheckBox ID="chkCurentlyWorking" CssClass="col-md-12 col-sm-12 col-xs-12" runat="server" Text="Currently Working"/>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label38" runat="server" Text="Area Of Experience"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtAreaOfExperience" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Ex: Asp.net, Android, Marketting" ></asp:TextBox>
                                    </div>

                                    <div class="col-md-12 col-sm-12" style="padding-top: 10px">
                                        <asp:Button ID="btnAddExperience" runat="server" class="btn btn-success form-control pull-right" Text="Add" OnClientClick="return ExperienceInfoValidate();" OnClick="btnAddExperience_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="training" class="tab-pane fade">
                            <h3>Training Information</h3>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label39" runat="server" Text="Training Title"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtTrainingTitle" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Ex: Natinal Apps Trainig"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label41" runat="server" Text="Topic Covered"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtTopicCovered" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Ex: Java , Xml, Android"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label40" runat="server" Text="Country"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:DropDownList ID="ddlCountry" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label42" runat="server" Text="Training Year"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:DropDownList ID="ddlTrainingYear" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" ></asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label43" runat="server" Text="Institude"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtTrainingInstitude" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Ex: People N Tech"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label44" runat="server" Text="Duration"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtTrainingDuration" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Ex: 3 Month"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Label ID="Label45" runat="server" Text="Location"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtTrainingLocation" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Ex: Banani" ></asp:TextBox>
                                    </div>
                                    
                                    <div class="col-md-12 col-sm-12" style="padding-top: 10px">
                                        <asp:Button ID="btnAddTrainig" runat="server" class="btn btn-success form-control pull-right" Text="Add" OnClientClick="return TrainingInfoValidate();" OnClick="btnAddTrainig_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="others" class="tab-pane fade">
                            <h3>Others Information</h3>
                            <p>Eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.</p>
                        </div>
                        <div id="photograph" class="tab-pane fade">
                            <h3>Photograph</h3>
                            <p>Eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.</p>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
     <script type="text/javascript">
            
            function Validate() {
                var txtEnroll = document.getElementById("txtEnroll").value;
                var txtDate = document.getElementById("txtDate").value;
                var txtMove = document.getElementById("txtMove").value;
                var txtStarTime = document.getElementById("txtStrtTime").value;
                var txtEndTime = document.getElementById("txtEndTime").value;

                if (txtEnroll === null || txtEnroll === "") {
                    ShowNotification('Enter Employee properly', 'OverTime', 'warning');
                    return false;
                }
                if (txtDate === null || txtDate === "") {
                    ShowNotification('Date can not be blank', 'OverTime', 'warning');
                    return false;
                }
                if (txtMove === null || txtMove === "") {
                    ShowNotification('Movement hour can not be blank', 'OverTime', 'warning');
                    return false;
                }
                if (txtStarTime === null || txtStarTime === "") {
                    ShowNotification('Start time can not be blank', 'OverTime', 'warning');
                    return false;
                }
                if (txtEndTime === null || txtEndTime === "") {
                    ShowNotification('End time can not be blank', 'OverTime', 'warning');
                    return false;
                }
                return true;
            }
            
            $(function () {
                
                Init();
                //ShowHideGridviewPanels();
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Init);
                //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(ShowHideGridviewPanels);
            });

            function Init() {
                $('#txtPromotionDate').datepicker({
                    dateFormat: 'dd/mm/yy'
                });
                $('#txtJoiningDate').datepicker({
                    dateFormat: 'dd/mm/yy'
                });
                $('#txtFromDate').datepicker({
                    dateFormat: 'dd/mm/yy'
                });
                $('#txtToDate').datepicker({
                    dateFormat: 'dd/mm/yy'
                });
                
            }
        </script>
</body>
</html>
