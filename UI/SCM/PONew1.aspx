<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PONew1.aspx.cs" Inherits="UI.SCM.PONew1" %>
<html lang="en">
<head>
  <title>Bootstrap Example</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>


</head>
<body>

    <form id="form1" runat="server">
    

        <div>

        <!-- Nav tabs -->
        <ul class="nav nav-tabs" role="tablist">
        <li id="l1" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Home</a></li>
        <li id="l2"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">Profile</a></li>
        <li id="l3"><a href="#messages" aria-controls="messages" role="tab" data-toggle="tab">Messages</a></li>
        <li id="4"><a href="#settings" aria-controls="settings" role="tab" data-toggle="tab">Settings</a></li>
        </ul>

        <!-- Tab panes -->
        <div class="tab-content">
        <div role="tabpanel" class="tab-pane active" id="home">...</div>
        <div role="tabpanel" class="tab-pane" id="profile">...</div>
        <div role="tabpanel" class="tab-pane" id="messages">...</div>
        <div role="tabpanel" class="tab-pane" id="settings">...</div>
        </div>

    </div>





    </form>
</body>
</html>
