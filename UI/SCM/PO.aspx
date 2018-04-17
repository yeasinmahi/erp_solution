<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PO.aspx.cs" Inherits="UI.SCM.PO" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/Lstyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
    <link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />

    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />

</head>
<body>
<form id="form1" runat="server">
    
    <div class="container">
    <div class="page-header">
        <h1>Panels with nav tabs.<span class="pull-right label label-default">:)</span></h1>
    </div>
    <div class="row">
    	<div class="col-md-6">
            <div class="panel with-nav-tabs panel-default">
                <div class="panel-heading">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tab1default" data-toggle="tab">Default 1</a></li>
                            <li><a href="#tab2default" data-toggle="tab">Default 2</a></li>
                            <li><a href="#tab3default" data-toggle="tab">Default 3</a></li>
                            <li class="dropdown">
                                <a href="#" data-toggle="dropdown">Dropdown <span class="caret"></span></a>
                                <ul class="dropdown-menu" role="menu">
                                    <li><a href="#tab4default" data-toggle="tab">Default 4</a></li>
                                    <li><a href="#tab5default" data-toggle="tab">Default 5</a></li>
                                </ul>
                            </li>
                        </ul>
                </div>
                <div class="panel-body">
                    <div class="tab-content">
                        <div class="tab-pane fade in active" id="tab1default">Default 1</div>
                        <div class="tab-pane fade" id="tab2default">Default 2</div>
                        <div class="tab-pane fade" id="tab3default">Default 3</div>
                        <div class="tab-pane fade" id="tab4default">Default 4</div>
                        <div class="tab-pane fade" id="tab5default">Default 5</div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="panel with-nav-tabs panel-primary">
                <div class="panel-heading">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tab1primary" data-toggle="tab">Primary 1</a></li>
                            <li><a href="#tab2primary" data-toggle="tab">Primary 2</a></li>
                            <li><a href="#tab3primary" data-toggle="tab">Primary 3</a></li>
                            <li class="dropdown">
                                <a href="#" data-toggle="dropdown">Dropdown <span class="caret"></span></a>
                                <ul class="dropdown-menu" role="menu">
                                    <li><a href="#tab4primary" data-toggle="tab">Primary 4</a></li>
                                    <li><a href="#tab5primary" data-toggle="tab">Primary 5</a></li>
                                </ul>
                            </li>
                        </ul>
                </div>
                <div class="panel-body">
                    <div class="tab-content">
                        <div class="tab-pane fade in active" id="tab1primary">Primary 1</div>
                        <div class="tab-pane fade" id="tab2primary">Primary 2</div>
                        <div class="tab-pane fade" id="tab3primary">Primary 3</div>
                        <div class="tab-pane fade" id="tab4primary">Primary 4</div>
                        <div class="tab-pane fade" id="tab5primary">Primary 5</div>
                    </div>
                </div>
            </div>
        </div>
	</div>
</div>
<div class="container">
    <div class="row">
		<div class="col-md-6">
            <div class="panel with-nav-tabs panel-success">
                <div class="panel-heading">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tab1success" data-toggle="tab">Success 1</a></li>
                            <li><a href="#tab2success" data-toggle="tab">Success 2</a></li>
                            <li><a href="#tab3success" data-toggle="tab">Success 3</a></li>
                            <li class="dropdown">
                                <a href="#" data-toggle="dropdown">Dropdown <span class="caret"></span></a>
                                <ul class="dropdown-menu" role="menu">
                                    <li><a href="#tab4success" data-toggle="tab">Success 4</a></li>
                                    <li><a href="#tab5success" data-toggle="tab">Success 5</a></li>
                                </ul>
                            </li>
                        </ul>
                </div>
                <div class="panel-body">
                    <div class="tab-content">
                        <div class="tab-pane fade in active" id="tab1success">Success 1</div>
                        <div class="tab-pane fade" id="tab2success">Success 2</div>
                        <div class="tab-pane fade" id="tab3success">Success 3</div>
                        <div class="tab-pane fade" id="tab4success">Success 4</div>
                        <div class="tab-pane fade" id="tab5success">Success 5</div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="panel with-nav-tabs panel-info">
                <div class="panel-heading">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tab1info" data-toggle="tab">Info 1</a></li>
                            <li><a href="#tab2info" data-toggle="tab">Info 2</a></li>
                            <li><a href="#tab3info" data-toggle="tab">Info 3</a></li>
                            <li class="dropdown">
                                <a href="#" data-toggle="dropdown">Dropdown <span class="caret"></span></a>
                                <ul class="dropdown-menu" role="menu">
                                    <li><a href="#tab4info" data-toggle="tab">Info 4</a></li>
                                    <li><a href="#tab5info" data-toggle="tab">Info 5</a></li>
                                </ul>
                            </li>
                        </ul>
                </div>
                <div class="panel-body">
                    <div class="tab-content">
                        <div class="tab-pane fade in active" id="tab1info">Info 1</div>
                        <div class="tab-pane fade" id="tab2info">Info 2</div>
                        <div class="tab-pane fade" id="tab3info">Info 3</div>
                        <div class="tab-pane fade" id="tab4info">Info 4</div>
                        <div class="tab-pane fade" id="tab5info">Info 5</div>
                    </div>
                </div>
            </div>
        </div>
	</div>
</div>
<div class="container">
    <div class="row">
    	<div class="col-md-6">
            <div class="panel with-nav-tabs panel-warning">
                <div class="panel-heading">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tab1warning" data-toggle="tab">Warning 1</a></li>
                            <li><a href="#tab2warning" data-toggle="tab">Warning 2</a></li>
                            <li><a href="#tab3warning" data-toggle="tab">Warning 3</a></li>
                            <li class="dropdown">
                                <a href="#" data-toggle="dropdown">Dropdown <span class="caret"></span></a>
                                <ul class="dropdown-menu" role="menu">
                                    <li><a href="#tab4warning" data-toggle="tab">Warning 4</a></li>
                                    <li><a href="#tab5warning" data-toggle="tab">Warning 5</a></li>
                                </ul>
                            </li>
                        </ul>
                </div>
                <div class="panel-body">
                    <div class="tab-content">
                        <div class="tab-pane fade in active" id="tab1warning">Warning 1</div>
                        <div class="tab-pane fade" id="tab2warning">Warning 2</div>
                        <div class="tab-pane fade" id="tab3warning">Warning 3</div>
                        <div class="tab-pane fade" id="tab4warning">Warning 4</div>
                        <div class="tab-pane fade" id="tab5warning">Warning 5</div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="panel with-nav-tabs panel-danger">
                <div class="panel-heading">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tab1danger" data-toggle="tab">Danger 1</a></li>
                            <li><a href="#tab2danger" data-toggle="tab">Danger 2</a></li>
                            <li><a href="#tab3danger" data-toggle="tab">Danger 3</a></li>
                            <li class="dropdown">
                                <a href="#" data-toggle="dropdown">Dropdown <span class="caret"></span></a>
                                <ul class="dropdown-menu" role="menu">
                                    <li><a href="#tab4danger" data-toggle="tab">Danger 4</a></li>
                                    <li><a href="#tab5danger" data-toggle="tab">Danger 5</a></li>
                                </ul>
                            </li>
                        </ul>
                </div>
                <div class="panel-body">
                    <div class="tab-content">
                        <div class="tab-pane fade in active" id="tab1danger">Danger 1</div>
                        <div class="tab-pane fade" id="tab2danger">Danger 2</div>
                        <div class="tab-pane fade" id="tab3danger">Danger 3</div>
                        <div class="tab-pane fade" id="tab4danger">Danger 4</div>
                        <div class="tab-pane fade" id="tab5danger">Danger 5</div>
                    </div>
                </div>
            </div>
        </div>
	</div>
</div>
<br/>



</form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
	<script src="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
   
    <%--=========================================End My Code From Here=================================================--%>
    
</body>
</html>