##  处理Object空值对象的默认值

在给obj对象赋值时，常常需要判断值是否存在，参数对应的值是否存在，否则会报异常，使用大量的if或者是 条件表达式很麻烦，而使用es6的{...}处理就很轻松

````javascript

  //左侧导航
  LeftBtn(opt){
  	// var opt = {text:'a'};
  	var { text } = {...opt}
    alert(text || 'back')
  }

 ````
 在opt为空的情况下，text未定义，如果不加上 `var { text } = {...opt}` 则会报 undefined错误