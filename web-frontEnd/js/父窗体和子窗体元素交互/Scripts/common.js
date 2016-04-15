$(document).ready(function() {

	//selectLoc
	var ulIndex = $('body').find('div.selectLoc').length;
	var ulArray = [];

	for(var j=0,k=ulIndex;j<ulIndex,k>=0;j++,k--) {
		ulArray[k] = j + 50;
	}

	$('div.selectLoc').each(function(slindex) {
		var locname = $(this).children('div.locName');
		var locopts = $(this).children('select').find('option');
		
		$(this).children('select').hide();

		var simul = '<ul class="simul" id='+$(this).children('select').attr('name') +' style="z-index:'+ulArray[slindex]+'">';
		for(var i=0;i<locopts.length;i++) {
			simul += '<li>'+locopts[i].text+'</li>';
		}
		simul += '</ul>';

		$(this).children('select').removeAttr('id');

		$(this).css({
			zIndex: ulArray[slindex]
		}).append(simul);

		$(this).children('ul.simul').css({
			width: $(this).width() - locname.position().left - 2 + 'px',
			marginLeft: locname.position().left + 'px'
		})

		$(this).find('ul.simul li').each(function(index) {
			$(this).click(function() {
				$(this).addClass('cur').siblings().removeClass('cur');
				locname.text($(this).text());
				locopts.eq(index).attr('selected', true).siblings().attr('selected', false);
			})
		})

		locname.html($(this).find('select option:selected').text());

		locname.click(function(event) {
			$('body').find('div.selectLoc ul:visible').hide();
			$(this).siblings('ul').toggle();
			event.stopPropagation();
		})
	})

	//Location
	$('#city li').each(function(index) {
		$(this).attr('dp',$('select[name=city] option').eq(index).attr('data-province'));
	})

	$('#province li').click(function() {
	    var dc = $(this).text();
		if(dc == '所有') {
			$('#city li').show();
		} else {
			$('#city li').each(function() {
				$(this).show();
				if($(this).attr('dp') != dc) {
					$(this).hide();
				}
			})
		}
	})

	$('#city li').click(function () {
	    var dc = $(this).text();
	    $("#CityData").html(dc);
	    
	})

	$(document).click(function() {
		$('ul.simul').hide();
	})

	//tabbed
	$('div.tabbed li').each(function(index) {

		$(this).click(function() {
			$(this).addClass('cur').siblings().removeClass('cur');
			$('div.tabbedCons').hide();
			$('div.tabbedCons').eq(index).show();
		})
	})

	//Homepage Banner
	var sWidth = $(".slidesImgs").width();
	var len = $(".slidesImgs ul li").length;
	var index = 0;
	var picTimer;
	
	var btn = "<div class='slidesBtns'><ul>";
	for(var i=0; i < len; i++) {
		btn += "<li></li>";
	}
	btn += "</ul></div>"

	$(btn).insertAfter('.slidesImgs')
	
	$(".slidesBtns li").mouseenter(function() {
		index = $(".slidesBtns li").index(this);
		showPics(index);
	}).eq(0).trigger("mouseenter");
	
	$(".slidesImgs ul").css("width",sWidth * (len + 1));
	
	$(".slidesImgs").hover(function() {
		clearInterval(picTimer);
	},function() {
		picTimer = setInterval(function() {
			if(index == len) {
				showFirPic();
				index = 0;
			} else { 
				showPics(index);
			}
			index++;
		},3000);
	}).trigger("mouseleave");
	

	function showPics(index) { 
		var nowLeft = -index*sWidth;
		$(".slidesImgs ul").stop(true,false).animate({"left":nowLeft},1000); 
		$(".slidesBtns li").removeClass("cur").eq(index).addClass("cur");
	}
	
	function showFirPic() {
		$(".slidesImgs ul").append($(".slidesImgs li:first-child").clone());
		var nowLeft = -len*sWidth;
		$(".slidesImgs ul").stop(true,false).animate({"left":nowLeft},1000,function() {
			$(".slidesImgs ul").css("left","0");
			$(".slidesImgs ul li:last-child").remove();
		}); 
		$(".slidesBtns li").removeClass("cur").eq(0).addClass("cur");
	}

	//navi
	if($.browser.msie&&($.browser.version == "6.0")&&!$.support.style) { //IE6
		$('.navi li:first-child,.slp .tabbed li:first-child').css({marginLeft: 0})
		$('.prdList').each(function() { $(this).find('li:first-child').css({marginLeft: 0}) });
		$('.navi > ul').addClass('cl');
		$('div.nPanel').wrap('<div class="nWrap"></div>');
		$('div.nWrap').css({ width: '980px', position: 'absolute', left: 0, top: 0 })
	}

	//FAQ
	$('.faq .quiz').each(function(index) {
		$(this).click(function() {
			if(!$(this).hasClass('cur')) {
				$('.quiz').removeClass('cur').animate({ height: '39px' });
				$(this).addClass('cur').animate({
					height: $(this).children('div.a').height() + 'px'
				});
			} else {
				$(this).removeClass('cur').animate({
					height: '39px'
				});
			}
		})
	})

	//在线提问列表
	$('.olqa ul li').each(function() {
		$(this).click(function() {
			
			if(!$(this).index() == 0) {
				$(this).css({borderTop: 0})
			}

			$(this).toggleClass('opened').find('.qCon,.a').slideToggle('slow')
					.end().siblings().find('.a').slideUp(500).end().find('.qCon').slideUp(500)
					.end().removeClass('opened');

		})
	})
	
	//外部链接
	var exLink = '<div class="exLink"><p>请注意，您即将离开本网站(www.jjmc.com.cn)，其它网站的法律声明和隐私保护可能不同于本网站(www.jjmc.com.cn)。</p><a class="exConfirm">确认</a><a class="exCancel" href="#">取消</a></div>';
	
	$('a[rel="external"]').each(function() {
		$(this).click(function() {
			$('body').append(exLink);
			$('.exConfirm').attr('href',$(this).attr('href'));
			return false;
		})
	});
	
	$('.exConfirm').click(function() {
		window.open($(this).attr('href'))
	});
	
	$('.exCancel').live('click', function() {
		$('.exLink').remove();
		return false;
	});
})