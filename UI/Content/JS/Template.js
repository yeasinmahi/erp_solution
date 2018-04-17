// JavaScript Document

$(document).ready(function()
{
	$("#txtAcc").blur(function()
	{
		//remove all the class add the messagebox classes and start fading
		$("#msgBoxClass").removeClass().addClass('messagebox').html('<font color=#0000FF>Checking...</font>').fadeIn("slow");
		//check the username exists or not from ajax
		$.post("../../CheckAvailable.aspx?class=Accounts_ChartOfAccount_Template&parent="+document.getElementById("hdnParent").value,{ check_value:$(this).val() } ,function(data)
        {
		  if(data=='no') //if username not avaiable
		  {
		  	$("#msgBoxClass").fadeTo(200,0.1,function() //start fading the messagebox
			{ 
			  //add message and change the class of the box and start fading
			  $(this).html('<font color=#FF0000>Already exists</font>').addClass('messageboxerror').fadeTo(900,1);
			});		
          }else if(data=='empty'){  //Empty user name
			 	   $("#msgBoxClass").fadeTo(200,0.1,function() //start fading the messagebox
			       { 
			           //add message and change the class of the box and start fading
			          $(this).html('Fild Empty').addClass('messageboxerror').fadeTo(900,1);
			       }); 
		  }
		  else 
		  {
		  	$("#msgBoxClass").fadeTo(200,0.1,function()  //start fading the messagebox
			{ 
			  //add message and change the class of the box and start fading
			  $(this).html('<font color=#00FF00>Available</font>').addClass('messageboxok').fadeTo(900,1);	
			});
		  }
				
        });
 
	});
});