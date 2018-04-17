function CmdAdd_onclick() {

var newTable,startTag,endTag;


//Creating a new table
startTag="<TABLE id='mainTable'><TBODY><TR><TD style=\"WIDTH: 120px\">User ID</TD><TD style=\"WIDTH: 120px\">User Name</TD><TD style=\"WIDTH: 120px\">Department</TD></TR>"
endTag="</TBODY></TABLE>"

newTable=startTag;
var trContents;
   //Add the Latest row
newTable+="<TR><TD style=\"WIDTH: 120px\" >" + document.getElementById('userid').value +"</TD>";
newTable+="<TD style=\"WIDTH: 120px\" >" + document.getElementById('username').value +"</TD>";
newTable+="<TD style=\"WIDTH: 120px\" >" + document.getElementById('department').value +"</TD><TR>";

//Get the row contents
trContents=document.body.getElementsByTagName('TR');
if(trContents.length>1)
    {
     for(i=1;i<trContents.length;i++)
      {
       if(trContents(i).innerHTML)
       {
       // Add previous rows
        newTable+="<TR>";
        newTable+=trContents(i).innerHTML;
        newTable+="</TR>";
       } 
     }
   }
   
newTable+=endTag;

//Update the Previous Table With New Table.
document.getElementById('tableDiv').innerHTML=newTable;
}