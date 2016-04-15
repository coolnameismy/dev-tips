/* 
	Required: 
	jQuery 1.8.0+ 
	http://www.jquery.com
	TweenMax.js
	http://api.greensock.com/js/
*/
(function() {
	//Navi Rollover
	$('.n02').hover(function() {
		$(this).addClass('cur');
		TweenMax.to($('.n02 .nPanel'), 0.65, {css:{display:'block',height: 281}});
		TweenMax.to($('.n02 .nDivider'), 0.65, {css:{display:'block',height: 281}});
	},function() {
		$(this).removeClass('cur');
		TweenMax.to($('.n02 .nPanel'), 0.35, {css:{display:'none', height: 0}});
		TweenMax.to($('.n02 .nDivider'), 0.65, {css:{display:'none',height: 0}});
	})
	$('.n03').hover(function() {
		$(this).addClass('cur');
		TweenMax.to($('.n03 .nPanel'), 0.65, {css:{display:'block',height: 168}});
		TweenMax.to($('.n03 .nDivider'), 0.65, {css:{display:'block',height: 168}});
	},function() {
		$(this).removeClass('cur');
		TweenMax.to($('.n03 .nPanel'), 0.35, {css:{display:'none', height: 0}});
		TweenMax.to($('.n03 .nDivider'), 0.65, {css:{display:'none',height: 0}});
	})
	$('.n04,.n05,.n07').hover(function() {
		$(this).addClass('cur');
		TweenMax.to($(this).find('.nPanel'), 0.65, {css:{display:'block',height: 111}});
		TweenMax.to($(this).find('.nDivider'), 0.65, {css:{display:'block',height: 111}});
	},function() {
		$(this).removeClass('cur');
		TweenMax.to($(this).find('.nPanel'), 0.35, {css:{display:'none', height: 0}});
		TweenMax.to($(this).find('.nDivider'), 0.65, {css:{display:'none',height: 0}});
	})
})();