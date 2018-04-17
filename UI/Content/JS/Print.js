function CheckIsIE() 
{ 
    if (navigator.appName.toUpperCase() == 'MICROSOFT INTERNET EXPLORER') { return true;} 
    else { return false; } 
} 


function PrintThisPage(frameName) 
{   alert(frameName);
    if (CheckIsIE() == true) 
    { 
        document.ifWorkspace.focus(); 
        document.ifWorkspace.print(); 
    } 
    else 
    { 
        window.frames[frameName].focus(); 
        window.frames[frameName].print(); 
    } 
} 


