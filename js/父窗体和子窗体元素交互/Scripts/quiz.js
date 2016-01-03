$(function() {
	
	//问题个数
	var qLength = $('.qCon').length;
	var qIndex  = 1;
	var qSwitch = false;

	$('.quizMask').css({
		width: qLength * 980
	})

	//选项选择
	$('.qCon .qYN label').each(function() {
		$(this).find('input').click(function() {
			$(this).parent().addClass('chked').siblings().removeClass('chked').find('input').removeAttr('checked');
			qSwitch = true;
			//console.log($(this).attr('checked') == 'checked');
			//if($(this).attr('checked') == 'checked') {
			//	console.log($(this).val())
			//}
		})
	})
	//console.log('初始化:'+qIndex)

	//开始测试
	$('.start').click(function(event) {
		event.preventDefault();
		$('.quizMask').animate({ left: -980 }, 800);
		$('.prev,.next,.qTag').css({display: 'block'});
		$('.next').trigger('click');
		//console.log('当前:'+qIndex)
	})

	//上一个问题
	function prevQuestion() {
		$('.prev').click(function(event) {
			event.preventDefault();
			if(qIndex == 1) {
				return false;
			} else {
				if($('.last')) {
					$('.last').removeClass('last').addClass('next');
				}
				qSwitch = true;
				qIndex --;
				NQ();
				//console.log('当前-PREV:'+qIndex)
			}
		})
	}

	//下一个问题
	function nextQuestion() {
		$('.next').click(function(event) {
			event.preventDefault();
			if(qIndex == qLength) {
				return false;
			} else {
				//1
				if(qIndex == 1) {
					$('#q01 input').each(function() {
						$(this).click(function() {
							if($(this).attr("checked") == 'checked' && $(this).val() == 'Y') {
								qIndex = 2;
								//console.log('1Y: '+ $(this).val() +','+ qIndex);
							} else if($(this).attr("checked") == 'checked' && $(this).val() == 'N') {
								qIndex = 3;
								//console.log('1N: '+ $(this).val() +','+ qIndex);
							}
						})
					})
				}

				//2
				if(qIndex == 2) {
					$('#q02 input').each(function() {
						$(this).click(function() {
							if($(this).attr("checked") == 'checked' && $(this).val() == 'Y') {
								qIndex = 4;
								//console.log('2Y: '+qIndex);
							} else if($(this).attr("checked") == 'checked' && $(this).val() == 'N') {
								qIndex = 3;
								//console.log('2N: '+qIndex);
							}
						})
					})
				} 
				
				//3
				if(qIndex == 3) {
					$('#q03 input').each(function() {
						$(this).click(function() {
							if($(this).attr("checked") == 'checked' && $(this).val() == 'Y') {
								qIndex = 4;
								$('.last').removeClass('last').addClass('next');
								//console.log('3Y: '+qIndex);
							} else if($(this).attr("checked") == 'checked' && $(this).val() == 'N') {
								$('.next').addClass('last').removeClass('next');
								qAnswer = 2;
								//console.log('稳择易');
							}
						})
					})
				}
				
				//4
				if(qIndex == 4) {
					$('#q04 input').each(function() {
						$(this).click(function() {
							if($(this).attr("checked") == 'checked' && $(this).val() == 'Y') {
								qAnswer = 0;
								//console.log('倍优');
							} else if($(this).attr("checked") == 'checked' && $(this).val() == 'N') {
								qAnswer = 1;
								//console.log('倍易');
							}
							$('.next').addClass('last').removeClass('next');
						})
					})
				}

				NQ();
			}
		})
	}

	//最终答案
	var qAnswer;
	$('.last').live('click',function() {
		//console.log('on')
		$('.quizMask,.qCon,.prev,.next,.qTag,.last').fadeOut(600);
		setTimeout(function() {
			$('.qF').eq(qAnswer).show();
			$('.qFinal').fadeIn('slow');
		} , 1000)
	})

	function NQ() {
		if(qSwitch) {
			$('.quizMask').animate({ left: -980 * qIndex }, 800);
			$('.qTag li').eq(qIndex-1).addClass('tagCur').siblings().removeClass('tagCur');
			qSwitch = false;
		}
	}

	prevQuestion();
	nextQuestion();

})