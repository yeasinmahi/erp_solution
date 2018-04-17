    var xpPanel_slideActive = true;	// Slide down/up active?
	var xpPanel_slideSpeed = 30;	// Speed of slide
	var xpPanel_onlyOneExpandedPane = true;	// Only one pane expanded at a time ?
	
	var sggbe_xpPane;
	var sggbe_paneIndex;
	
	var savedActivePane = false;
	var savedActiveSub = false;

	var xpPanel_currentDirection = new Array();
	
	var cookieNames = new Array();
	
	
	var currentlyExpandedPane = false;
	
	
		
	function Get_Cookie(name) { 
	   var start = document.cookie.indexOf(name+"="); 
	   var len = start+name.length+1; 
	   if ((!start) && (name != document.cookie.substring(0,name.length))) return null; 
	   if (start == -1) return null; 
	   var end = document.cookie.indexOf(";",len); 
	   if (end == -1) end = document.cookie.length; 
	   return unescape(document.cookie.substring(len,end)); 
	} 
	
	
	function Set_Cookie(name,value,expires,path,domain,secure) { 
		expires = expires * 60*60*24*1000;
		var today = new Date();
		var expires_date = new Date( today.getTime() + (expires) );
	    var cookieString = name + "=" +escape(value) + 
	       ( (expires) ? ";expires=" + expires_date.toGMTString() : "") + 
	       ( (path) ? ";path=" + path : "") + 
	       ( (domain) ? ";domain=" + domain : "") + 
	       ( (secure) ? ";secure" : ""); 
	    document.cookie = cookieString; 
	}

	function cancelXpWidgetEvent()
	{
		return false;	
		
	}
	
	function showHidePaneContent(e,inputObj)
	{
	
		if(!inputObj)inputObj = this;
		
		var img = inputObj.getElementsByTagName('IMG')[0];		
		var numericId = img.id.replace(/[^0-9]/g,'');
		
		var obj = document.getElementById('paneContent' + numericId);
		
				///////--- Additional ---///////
				/*		
				for(i=0; i<6; i++)
				{
					if(i!=numericId)
					{
						var obj2 = document.getElementById('paneContent' + i);
						xpPanel_currentDirection[obj2.id] = (xpPanel_slideSpeed*-1);
						slidePane((xpPanel_slideSpeed*-1), obj2.id);
						//Set_Cookie(cookieNames[i],'0',100000);				
					}
				}
				*/		
				///////--- Additional ---///////	
						
		if(img.src.toLowerCase().indexOf('up')>=0){
			currentlyExpandedPane = false;
			img.src = img.src.replace('up','down');
			if(xpPanel_slideActive){			
				obj.style.display='block';
				xpPanel_currentDirection[obj.id] = (xpPanel_slideSpeed*-1);
				slidePane((xpPanel_slideSpeed*-1), obj.id);
			}else{			
				obj.style.display='none';
			}
			if(cookieNames[numericId])Set_Cookie(cookieNames[numericId],'0',100000);
			
			//////--- Additional ---//////
			// Set_Cookie(cookieNames[i],'1',100000);
			//////--- Additional ---//////
			
		}else{
			if(this){
				if(currentlyExpandedPane && xpPanel_onlyOneExpandedPane)showHidePaneContent(false,currentlyExpandedPane);
				currentlyExpandedPane = this;	
			}else{
				currentlyExpandedPane = false;
			}
			img.src = img.src.replace('down','up');
			if(xpPanel_slideActive){
				if(document.all){
					obj.style.display='block';					
				}
				xpPanel_currentDirection[obj.id] = xpPanel_slideSpeed;
				slidePane(xpPanel_slideSpeed,obj.id);
			}else{
				obj.style.display='block';
				subDiv = obj.getElementsByTagName('DIV')[0];
				obj.style.height = subDiv.offsetHeight + 'px';
			}
			if(cookieNames[numericId])Set_Cookie(cookieNames[numericId],'1',100000);
			
			
			//////--- Additional ---//////
			// Set_Cookie(cookieNames[i],'0',100000);
			//////--- Additional ---//////
			
		}
		
					
		//////--- Additional ---//////
		// }
		// }
		//////--- Additional ---//////
		
		
		return true;	
	}
	
	
	
	function slidePane(slideValue,id)
	{
	
		if(slideValue!=xpPanel_currentDirection[id]){
			return false;
		}
		var activePane = document.getElementById(id);
		if(activePane==savedActivePane){
			var subDiv = savedActiveSub;
		}else{
			var subDiv = activePane.getElementsByTagName('DIV')[0];
		}
		savedActivePane = activePane;
		savedActiveSub = subDiv;
		
		var height = activePane.offsetHeight;
		var innerHeight = subDiv.offsetHeight;
		height+=slideValue;
		if(height<0)height=0;
		if(height>innerHeight)height = innerHeight;
		
		if(document.all){
			activePane.style.filter = 'alpha(opacity=' + Math.round((height / subDiv.offsetHeight)*100) + ')';
		}else{
			var opacity = (height / subDiv.offsetHeight);
			if(opacity==0)opacity=0.01;
			if(opacity==1)opacity = 0.99;
			activePane.style.opacity = opacity;
		}			
		
					
		if(slideValue<0){			
			activePane.style.height = height + 'px';
			subDiv.style.top = height - subDiv.offsetHeight + 'px';
			if(height>0){
				setTimeout('slidePane(' + slideValue + ',"' + id + '")',10);
			}else{
				if(document.all)activePane.style.display='none';
			}
		}else{			
			subDiv.style.top = height - subDiv.offsetHeight + 'px';
			activePane.style.height = height + 'px';
			if(height<innerHeight){
				setTimeout('slidePane(' + slideValue + ',"' + id + '")',10);				
			}		
		}
		
	}
	
	function mouseoverTopbar()
	{
		var img = this.getElementsByTagName('IMG')[0];
		var src = img.src;
		img.src = img.src.replace('.gif','_over.gif');
		
		var span = this.getElementsByTagName('SPAN')[0];
		span.style.color='#428EFF';		
		
	}
	function mouseoutTopbar()
	{
		var img = this.getElementsByTagName('IMG')[0];
		var src = img.src;
		img.src = img.src.replace('_over.gif','.gif');		
		
		var span = this.getElementsByTagName('SPAN')[0];
		span.style.color='';
		
		
		
	}
	
	
	function initsggbe_xpPane(panelTitles,panelDisplayed,cookieArray,imglocation)
	{
		sggbe_xpPane = document.getElementById('sggbe_xpPane');
		var divs = sggbe_xpPane.getElementsByTagName('DIV');
		sggbe_paneIndex=0;
		cookieNames = cookieArray;
		for(var no=0;no<divs.length;no++){
			if(divs[no].className=='sggbe_panel'){
				
				var outerContentDiv = document.createElement('DIV');	
				var contentDiv = divs[no].getElementsByTagName('DIV')[0];
				outerContentDiv.appendChild(contentDiv);	
			
				outerContentDiv.id = 'paneContent' + sggbe_paneIndex;
				outerContentDiv.className = 'panelContent';
				var topBar = document.createElement('DIV');
				topBar.onselectstart = cancelXpWidgetEvent;
				var span = document.createElement('SPAN');				
				span.innerHTML = panelTitles[sggbe_paneIndex];
				topBar.appendChild(span);
				topBar.onclick = showHidePaneContent;
				if(document.all)topBar.ondblclick = showHidePaneContent;
				topBar.onmouseover = mouseoverTopbar;
				topBar.onmouseout = mouseoutTopbar;
				topBar.style.position = 'relative';

				var img = document.createElement('IMG');
				img.id = 'showHideButton' + sggbe_paneIndex;
				img.src = imglocation + '/arrow_up.gif';				
				topBar.appendChild(img);
				
				if(cookieArray[sggbe_paneIndex]){
					cookieValue = Get_Cookie(cookieArray[sggbe_paneIndex]);
					if(cookieValue)panelDisplayed[sggbe_paneIndex] = cookieValue==1?true:false;
					
				}
				
				if(!panelDisplayed[sggbe_paneIndex]){
					outerContentDiv.style.height = '0px';
					contentDiv.style.top = 0 - contentDiv.offsetHeight + 'px';
					if(document.all)outerContentDiv.style.display='none';
					img.src = imglocation + '/arrow_down.gif';
				}
								
				topBar.className='topBar';
				divs[no].appendChild(topBar);				
				divs[no].appendChild(outerContentDiv);	
				sggbe_paneIndex++;			
			}			
		}
	}