function AddRow(){       
    var tmpFrm, tmpTo;
    tmpFrm = document.getElementById('ddlFrom').value;
    tmpTo = document.getElementById('ddlTo').value;

    if(tmpFrm != tmpTo && tmpFrm != '' && tmpTo != ''){       
       var table = document.getElementById("tblMain");
       var tbody = document.getElementById("tblMain").tBodies["tbdMain"];                
       
       var ddlFrom = CreateSingleDDL('ddlFrom', count , from, fromVal);
       var ddlTo = CreateDDL('ddlTo', count, opt); 
       
       var ddlVia = CreateDDL('ddlVia', count, optVia);           
       var txtVia = CreateTextBox('txtVia', count, 125,100,'left', '', 0);                
       
       var txtMilage = CreateTextBox('txtMilage', count, 40, 7,'right', '', 0);                
       var txtFuel = CreateTextBox('txtFuel', count, 40, 7,'right', 'readonly', 0);            
       var txtTole = CreateTextBox('txtTole', count, 40, 7,'right', '', 0);                
       var txtFerry = CreateTextBox('txtFerry', count, 40, 7,'right', '', 0);                
       var txtBridge = CreateTextBox('txtBridge', count, 40, 7,'right', '', 0);                
       var txtBrocker = CreateTextBox('txtBrocker', count, 40, 7,'right', '', 0);            
       var txtOther = CreateTextBox('txtOther', count, 40, 7,'right', '', 0);
       var txtRemark = CreateTextBox('txtRemark', count, 50, 100,'left', '', '');
       
       var row = document.createElement("TR");
           if((count%2) == 0){row.className = "dynamicRowOdd";}
           else {row.className = "dynamicRowEven";}
       var td1 = document.createElement("TD");td1.innerHTML = ddlFrom;
       var td2 = document.createElement("TD");td2.innerHTML = ddlTo;       
       var td3 = document.createElement("TD");td3.innerHTML = ddlVia + "</br>"+txtVia;       
       var td4 = document.createElement("TD");td4.innerHTML = txtMilage;
       var td5 = document.createElement("TD");td5.innerHTML = txtFuel;
       var td6 = document.createElement("TD");td6.innerHTML = txtTole;
       var td7 = document.createElement("TD");td7.innerHTML = txtFerry;
       var td8 = document.createElement("TD");td8.innerHTML = txtBridge;
       var td9 = document.createElement("TD");td9.innerHTML = txtBrocker;
       var td10 = document.createElement("TD");td10.innerHTML = txtOther;
       var td11 = document.createElement("TD");td11.innerHTML = txtRemark;
       
       row.appendChild(td1);
       row.appendChild(td2);       
       row.appendChild(td3);
       row.appendChild(td4);
       row.appendChild(td5);
       row.appendChild(td6);
       row.appendChild(td7);
       row.appendChild(td8);
       row.appendChild(td9);
       row.appendChild(td10);
       row.appendChild(td11);
       
       tbody.appendChild(row);
                  
       SetDLL('ddlFrom', to);
       SetDLL('ddlTo', '');
       
       SetDLL('ddlTo'+count, to);           
       SetDLL('ddlVia'+count, via);
       via = null;           
       document.getElementById('txtVia'+count).value = document.getElementById('txtVia').value;
       
       var obj = document.getElementById('ddlTo'+count);
       fromVal = obj.options[obj.selectedIndex].text;
       from = obj.value;
       
       document.getElementById('ddlFrom').disabled = "disabled";
       ClearDDL('ddlVia', '');
       document.getElementById('txtVia').value = '';
        
       document.getElementById('txtMilage'+count).value = document.getElementById('txtMilage').value;
       document.getElementById('txtTole'+count).value = document.getElementById('txtTole').value;
       document.getElementById('txtFerry'+count).value = document.getElementById('txtFerry').value;
       document.getElementById('txtBridge'+count).value = document.getElementById('txtBridge').value;
       document.getElementById('txtBrocker'+count).value = document.getElementById('txtBrocker').value;
       
       AddAmount(document.getElementById('txtMilage'+count));
       AddAmount(document.getElementById('txtTole'+count));
       AddAmount(document.getElementById('txtFerry'+count));
       AddAmount(document.getElementById('txtBridge'+count));
       AddAmount(document.getElementById('txtBrocker'+count));
                  
       count++;                 
    }
    else{alert('Same or Blank field is not allowed');}
}

function CreateTextBox(name, i, wi, ml, al, ro, val){
    if(ro != '') ro = 'readonly="readonly"';
    var txtBox = "<input id=\""+name+i+"\" "+ro+" value=\""+val+"\" onkeyup=\"ChangeAmount(this)\"  style=\"width: "+wi+"px; text-align:"+al+";\" type=\"text\" maxlength=\""+ml+"\"/>";
    return txtBox;
}

function CreateSpan(name, i, val){
    return "<span id=\""+name+i+"\" >"+ val +"</span>";
}

function CreateDDL(name, i, opt_){          
    var ddl = "<select id=\"" + name+i +"\"  name=\"" + name+i +"\" onchange=\"DdlChange(this)\">";
    for (var i = 0; i < opt_.length; i++) {
        ddl +=  "<option value='" + opt_[i].value + "'>" + opt_[i].innerText + "</option>";
        }
    ddl +=  "</select>";
    return ddl;
}

function LoadDDL(name, i, optionsArray){
    //Clean
    ClearDDL(name, i);
            
    //Load
    var targetDropDown = document.getElementById(name+i);
    for (var i = 0; i < optionsArray.length; i++) {
    var newOption = document.createElement("OPTION");
    targetDropDown.options.add(newOption);
    newOption.value = optionsArray[i].value;
    newOption.innerText = optionsArray[i].innerText;
    }
}
function ClearDDL(name, i){
    var targetDropDown = document.getElementById(name+i);                
    for(i=targetDropDown.options.length-1;i>=0;i--){
        targetDropDown.remove(i);
        }
}

function CreateSingleDDL(name, i , val, txt){
    var ddl = "<select id=\"" + name+i +"\"  name=\"" + name+i +"\" disabled=\"disabled\"><option selected=\"selected\" value=\""+ val +"\">"+ txt +"</option></select>";        
    return ddl;
}

function DdlChange(obj){
    
    if(obj.id == 'ddlFrom'){
        fromVal = obj.options[obj.selectedIndex].text; 
        from = obj.value;
        var to_ = document.getElementById('ddlTo');
        if(to_.value != '')GetVia(obj.value, to_.value, '');
        }
    else if(obj.id == 'ddlTo'){
        to = obj.value;
        var from_ = document.getElementById('ddlFrom');
        if(from_.value != '')GetVia(from_.value, obj.value, '');
        }
    else if(obj.id == 'ddlVia'){
        via = obj.value;
        var from_ = document.getElementById('ddlFrom');
        var to_ = document.getElementById('ddlTo');
        GetInfo(from_.value, to_.value, obj.value, '');
        }
    else{//Added Controls
        var tmp = obj.id;
        var num;
        if(obj.id.indexOf('ddlTo') >= 0){
            num = parseInt(tmp.substring(5),32);            
            var from_ = document.getElementById('ddlFrom'+num);
            var to_ = document.getElementById('ddlTo'+num);
            
            num = num+1;
            var objTmp = document.getElementById('ddlFrom'+num);
            if(objTmp != null){
                objTmp.options[0].value = obj.value
                objTmp.options[0].text = obj.options[obj.selectedIndex].text;
                }
             else{
                objTmp = document.getElementById('ddlFrom');
                for(i=0; i<objTmp.options.length; i++){
                    if(objTmp.options[i].value == obj.value){            
                        objTmp.options[i].selected = "selected";              
                        break;
                        }
                    }                 
                }
            //Get Data For Via For Added Controls
            GetVia(from_.value, to_.value, (num-1));
            }
         else if(obj.id.indexOf('ddlVia') >= 0){
            var tmp = obj.id;
            var num = parseInt(tmp.substring(6),32);            
            var from_ = document.getElementById('ddlFrom'+num);
            var to_ = document.getElementById('ddlTo'+num);
            GetInfo(from_.value, to_.value, obj.value, num);
            
            } 
        }   
}

function SetDLL(id, val){
    var obj = document.getElementById(id);
    for(i=0; i<obj.options.length; i++){
    if(obj.options[i].value == val){            
        obj.options[i].selected = "selected";              
        break;
        }
    }
}

function SetSpan(id, val){
    var obj = document.getElementById(id);
    obj.innerText = val;           
}
function ChangeRootMilage(){
  document.getElementById('txtFuel').value = document.getElementById('txtMilage').value * perKM;
}
function ChangeAmount(obj){
    var tmp, val = 0, tmpVal, valF;
    if((obj.id).indexOf('txtMilage') != -1){
        for(i=0;i<count;i++){
            tmp = document.getElementById('txtMilage'+i);
            if(isNaN(tmp.value)){alert('Wrong value inserted'); return;}
            tmpVal = parseInt(tmp.value);
            val += tmpVal;                
            }
    document.getElementById('totMilage').value = val;
    
    //Fuel Cost        
    var num = obj.id.substring(9);
    document.getElementById('txtFuel'+num).value = parseInt(document.getElementById('txtMilage'+num).value) * perKM;
    val =0;
    for(i=0;i<count;i++){
            tmp = document.getElementById('txtFuel'+i);
            if(isNaN(tmp.value)){alert('Wrong value inserted'); return;}
            tmpVal = parseInt(tmp.value);
            val += tmpVal;                
            }
    document.getElementById('totFuel').value = val;
    }
    else if((obj.id).indexOf('txtTole') != -1){
        for(i=0;i<count;i++){
            tmp = document.getElementById('txtTole'+i);
            if(isNaN(tmp.value)){alert('Wrong value inserted'); return;}
            tmpVal = parseInt(tmp.value);
            val += tmpVal;                
            }
    document.getElementById('totTole').value = val;    
    }
    else if((obj.id).indexOf('txtFerry') != -1){
        for(i=0;i<count;i++){
            tmp = document.getElementById('txtFerry'+i);
            if(isNaN(tmp.value)){alert('Wrong value inserted'); return;}
            tmpVal = parseInt(tmp.value);
            val += tmpVal;                
            }
    document.getElementById('totFerry').value = val;
    }
    else if((obj.id).indexOf('txtBridge') != -1){
        for(i=0;i<count;i++){
            tmp = document.getElementById('txtBridge'+i);
            if(isNaN(tmp.value)){alert('Wrong value inserted'); return;}
            tmpVal = parseInt(tmp.value);
            val += tmpVal;                
            }
    document.getElementById('totBridge').value = val;
    } 
    else if((obj.id).indexOf('txtBrocker') != -1){
        for(i=0;i<count;i++){
            tmp = document.getElementById('txtBrocker'+i);
            if(isNaN(tmp.value)){alert('Wrong value inserted'); return;}
            tmpVal = parseInt(tmp.value);
            val += tmpVal;                
            }
    document.getElementById('totBrocker').value = val;
    }
    else if((obj.id).indexOf('txtOther') != -1){
        for(i=0;i<count;i++){
            tmp = document.getElementById('txtOther'+i);
            if(isNaN(tmp.value)){alert('Wrong value inserted'); return;}
            tmpVal = parseInt(tmp.value);
            val += tmpVal;                
            }
    document.getElementById('totOther').value = val;
    }
    
    TotalMoney();
}
function AddAmount(obj){
    var val, valF;
    if((obj.id).indexOf('txtMilage') != -1){
        val = parseInt(document.getElementById('totMilage').value);
        if(isNaN(obj.value)){alert('Wrong value inserted'); return;}            
        val += parseInt(obj.value);
        document.getElementById('totMilage').value = val;
        
        //Fuel Cost        
        num = obj.id.substring(9);
        val = document.getElementById('txtMilage'+num).value;        
        valF = val * perKM;
        
        document.getElementById('txtFuel'+num).value = valF;
        val = parseInt(document.getElementById('totFuel').value);
        val = parseInt(val) + valF;
        document.getElementById('totFuel').value = val;
        
    }
    else if((obj.id).indexOf('txtTole') != -1){
        val = parseInt(document.getElementById('totTole').value);
        if(isNaN(obj.value)){alert('Wrong value inserted'); return;}            
        val += parseInt(obj.value);
        document.getElementById('totTole').value = val;
    }
    else if((obj.id).indexOf('txtFerry') != -1){
        val = parseInt(document.getElementById('totFerry').value);
        if(isNaN(obj.value)){alert('Wrong value inserted'); return;}            
        val += parseInt(obj.value);
        document.getElementById('totFerry').value = val;
    }
    else if((obj.id).indexOf('txtBridge') != -1){
        val = parseInt(document.getElementById('totBridge').value);
        if(isNaN(obj.value)){alert('Wrong value inserted'); return;}            
        val += parseInt(obj.value);
        document.getElementById('totBridge').value = val;
    } 
    else if((obj.id).indexOf('txtBrocker') != -1){
        val = parseInt(document.getElementById('totBrocker').value);
        if(isNaN(obj.value)){alert('Wrong value inserted'); return;}            
        val += parseInt(obj.value);
        document.getElementById('totBrocker').value = val;
    }
    else if((obj.id).indexOf('txtOther') != -1){
        val = parseInt(document.getElementById('totOther').value);
        if(isNaN(obj.value)){alert('Wrong value inserted'); return;}            
        val += parseInt(obj.value);
        document.getElementById('totOther').value = val;
    }
    
    TotalMoney();        
}

function GetInfo(frmId, toId, via, idNum){
    document.getElementById("divLoading").style.display = "";
    var obj1;
    obj1 = document.getElementById("frmEdit");
    obj1.action = "AssignTrip.aspx?type=info&frmId=" + frmId + "&toId=" + toId+ "&idNum=" + idNum + "&via=" + via;
    obj1.submit();
}
function SetInfo(idNum, mile, tole, ferry, bridge, brocker){
    document.getElementById('txtMilage'+idNum).value = mile;
    document.getElementById('txtTole'+idNum).value = tole;
    document.getElementById('txtFerry'+idNum).value = ferry;
    document.getElementById('txtBridge'+idNum).value = bridge;
    document.getElementById('txtBrocker'+idNum).value = brocker;
    
    document.getElementById('txtFuel'+idNum).value = mile * perKM;

     ChangeAmount(document.getElementById('txtMilage'+idNum));
     ChangeAmount(document.getElementById('txtFuel'+idNum));
     ChangeAmount(document.getElementById('txtTole'+idNum));
     ChangeAmount(document.getElementById('txtFerry'+idNum));
     ChangeAmount(document.getElementById('txtBridge'+idNum));
     ChangeAmount(document.getElementById('txtBrocker'+idNum));
     TotalMoney();            
         
    document.getElementById("divLoading").style.display = "none";
}
function GetVia(frmId, toId, idNum){
    document.getElementById("divLoading").style.display = "";
    var obj1;
    obj1 = document.getElementById("frmEdit");
    obj1.action = "AssignTrip.aspx?type=via&frmId=" + frmId + "&toId=" + toId+ "&idNum=" + idNum;
    obj1.submit();
}
function SetVia(viaDDl, idNum){  
    optVia = viaDDl ;
    LoadDDL('ddlVia', idNum, optVia);
    document.getElementById("divLoading").style.display = "none";
}

function TotalMoney(){
    var tmpVal;
    total = 0;
    tmpVal = parseInt(document.getElementById('totFuel').value);total += tmpVal;    
    tmpVal = parseInt(document.getElementById('totTole').value);total += tmpVal;
    tmpVal = parseInt(document.getElementById('totFerry').value);total += tmpVal;
    tmpVal = parseInt(document.getElementById('totBridge').value);total += tmpVal;
    tmpVal = parseInt(document.getElementById('totBrocker').value);total += tmpVal;
    
    document.getElementById('total').innerHTML = 'Total: '+total;
}

function AddPrintData(){
    
    var table = document.getElementById("tblPrint");
    var tbody = document.getElementById("tblPrint").tBodies["tbdPrint"];
       
    for(i=0;i<count;i++){
       var ddlFrom = document.getElementById("ddlFrom"+i)
       var ddlTo =  document.getElementById("ddlTo"+i)
       
       var row = document.createElement("TR");
       var td1 = document.createElement("TD");td1.innerHTML = ddlFrom.options[ddlFrom.selectedIndex].text;
       var td2 = document.createElement("TD");td2.innerHTML = ddlTo.options[ddlTo.selectedIndex].text;
       var td3 = document.createElement("TD");td3.innerHTML = '';     
       var td4 = document.createElement("TD");td4.innerHTML = document.getElementById("txtMilage"+i).value;
       var td5 = document.createElement("TD");td5.innerHTML = document.getElementById("txtFuel"+i).value;
       var td6 = document.createElement("TD");td6.innerHTML = document.getElementById("txtTole"+i).value;
       var td7 = document.createElement("TD");td7.innerHTML = document.getElementById("txtFerry"+i).value;
       var td8 = document.createElement("TD");td8.innerHTML = document.getElementById("txtBridge"+i).value;
       var td9 = document.createElement("TD");td9.innerHTML = document.getElementById("txtBrocker"+i).value;
       var td10 = document.createElement("TD");td10.innerHTML = document.getElementById("txtOther"+i).value;
       var td11 = document.createElement("TD");td11.innerHTML = document.getElementById("txtRemark"+i).value;
       
       row.appendChild(td1);
       row.appendChild(td2);       
       row.appendChild(td3);
       row.appendChild(td4);
       row.appendChild(td5);
       row.appendChild(td6);
       row.appendChild(td7);
       row.appendChild(td8);
       row.appendChild(td9);
       row.appendChild(td10);
       row.appendChild(td11);
       
       tbody.appendChild(row);
    }
    
    document.getElementById("totTotalPR").innerHTML = document.getElementById("total").innerHTML;
    document.getElementById("totMilagePR").innerHTML = document.getElementById("totMilage").value;
    document.getElementById("totFuelPR").innerHTML = document.getElementById("totFuel").value;
    document.getElementById("totTolePR").innerHTML = document.getElementById("totTole").value;
    document.getElementById("totFerryPR").innerHTML = document.getElementById("totFerry").value;
    document.getElementById("totBridgePR").innerHTML = document.getElementById("totBridge").value;
    document.getElementById("totBrockerPR").innerHTML = document.getElementById("totBrocker").value;
    document.getElementById("totOtherPR").innerHTML = document.getElementById("totOther").value; 
        
    //document.getElementById("frmPrint").document.innerHTML =   document.getElementById("divPrint").innerHTML;
}