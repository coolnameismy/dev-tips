new Function()的可以动态构造一个js的fuction，这种动态特性时常能写出很精妙的代码，我是从[ejs.js](https://github.com/tj/ejs/blob/master/lib/ejs.js)第一次看到如何动态编译js代码的例子。


下面是些例子

## 无参数和返回值
````javascript
var hello = new Function('console.log("hello")');
//构造了一个hello的函数,使用hello() 可以看到控制台输出了hello
````

##  带参数不带返回值
````javascript
var hello = new Function('msg','console.log(msg)');
````

##  带返回值
````javascripts
var hello = new Function('msg','return msg');
````

##  带参数和返回值
````javascript
var hello = new Function('msg','return msg');
````

##  带多个参数和返回值
````javascript
var hello = new Function('msg1','msg2','msg3','return msg1+msg2+msg3');
//也可以合并参数
var hello = new Function('msg1,msg2,msg3','return msg1+msg2+msg3');
````

##  动态构造函数的错误处理
````javascript
 try {
    var fn = new Function('locals, filters, escape, rethrow', str);
  } catch (err) {
    if ('SyntaxError' == err.name) {  }
    throw err;
  }
````

## 快速的组合构造出来的函数

````javascript
var segments = ["alert(1)","alert(2)","alert(3)",fun1.tostring()].join('\n');
var myFunction = new Function(segments);
````
主要用到array.join()方法批量加入回车号，使用tostring可以把函数类型转换为函数类型定义的字符串。




