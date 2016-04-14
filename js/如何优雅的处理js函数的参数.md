## 例子1 

````javascript

exports.renderFile = function () {
  var args = Array.prototype.slice.call(arguments)
    , path = args.shift()
    , cb = args.pop()
    , data = args.shift() || {}
    , opts = args.pop() || {}
    , result;
    ...
 }

````

简单的说明一下，这个函数来自于[ejs.js v2版本](https://github.com/mde/ejs/blob/master/lib/ejs.js)

````javascript

 Array.prototype.slice.call(arguments) 等价于 arguments.slice();
 shift() //弹出arguments数组第一个元素，也就是获取函数的第一个参数
 pop() //弹出arguments数组最后一个元素，也就是获取函数的最后一个参数
 data = args.shift() || {} //如果参数为空则初始化

````


##	例子2

````javascript
var parse = exports.parse = function(str, options){
  var options = options || {}
    , open = options.open || exports.open || '<%'
    , close = options.close || exports.close || '%>'
    , filename = options.filename
    , compileDebug = options.compileDebug !== false
    , buf = "";
    ...
}

//若为空值则赋默认值，注意，如果options.a为false或0时会产生bug
var a = options.a || 'aaa';
var a = options.a || options.a ||  'aaa';
// 请教大神们一个问题。
// 我看开源库中值赋值时，先判断是否为空，若为空则给默认值，大家代码都这样些的 “   var a = options.a || options.a ||  'aaa'; ”，但是
// 为什么不直接写成这样“  var a = options.a || 'aaa';  ” ，会有什么问题嘛
````

