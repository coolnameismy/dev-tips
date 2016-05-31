##  安装

从[官网](http://www.mozilla.org/rhino/)下载js.jar ,并导入libs目录

## 初始化和设置

大体上分为获取对象，设置对象，退出context，如下

````
Context rhino = Context.enter();//获取对象
rhino.setOptimizationLevel(-1);//rhino兼容Android
rhino.setLanguageVersion(rhino.VERSION_1_6);//设置js版本

try {
	//获取scope对象
    Scriptable scope = rhino.initStandardObjects();
	
	//开始执行js和Native交互代码。。。。。    
	//。。。。。。。
	//。。。。。。。
}
catch (Exception e){
    Log.e("rhino",e.toString());
}
finally {
    Context.exit();
}

````

##  执行js

下面演示几种最常见的情况

- 直接执行js
- 执行js定义一个函数，再直接执行定义的函数
- 执行js定义一个函数，通过java获取函数对象，在执行这个函数
- 执行js定义一个函数，函数返回一个js函数，通过java获取js返回的函数，在转换为java函数，并执行

直接执行js

````java
//获取一个json对象
Object json1 = rhino.evaluateString(scope,"obj={a:1}","MySource",1,null);

````

- 执行js定义一个函数，通过java获取函数对象，在执行这个函数

````java
Object string1 = rhino.evaluateString(scope,"var hi = function(){ return 'hi rhino';}; hi();","MySource",1,null);

````

- 执行js定义一个函数，函数返回一个js函数，通过java获取js返回的函数，在转换为java函数，并执行

````java
/*
  先定义一个方法，java中获取到js function，然后再执行
  注意，最后一个参数不能为null
*/
rhino.evaluateString(scope,"var hi = function(){ return 'hi rhino';};","MySource1",1,null);
Function function1 = (Function)scope.get("hi", scope);
Object string3 = function1.call(rhino,scope,scope,new Object[]{});

````

- 执行js定义一个函数，函数返回一个js函数，通过java获取js返回的函数，在转换为java函数，并执行

````java
/*
     先定义一个方法，java中获取到js function，然后再执行
     注意，最后一个参数不能为null
 */
 rhino.evaluateString(scope,"var hi = function(){ return 'hi rhino';};","MySource1",1,null);
 rhino.evaluateString(scope,"var getHiFunction = function(){ return hi;};","MySource1",1,null);

 Function function1 = (Function)scope.get("getHiFunction", scope);
 Object result = function1.call(rhino,scope,scope,new Object[]{});
 Function function2 = (Function)result;
 Object result2 = function2.call(rhino,scope,scope,new Object[]{});
 //result = hi rhino
````

##  js调用Native方法


##  Scriptable和json的操作


##  参考

[Embed JavaScript in Android Java Code with Rhino](https://vec.io/posts/embed-javascript-in-android-java-code-with-rhino)
[【Android】不使用WebView来执行Javascript脚本（Rhino）](http://www.cnblogs.com/over140/p/3389974.html)



