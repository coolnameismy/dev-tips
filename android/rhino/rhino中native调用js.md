
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


## 得到一个Function的方式

````
//1：通过scope.get得到
Function function1 = (Function)scope.get("getHiFunction", scope);

/**
2:通过执行代码得到
js:
(function(a,b){
    java.lang.System.out.println("smurfsjs:"+ a+"|"+b);
});
**/
Function bizjsConstructor = (Function) rhino.evaluateString(scope,scriptString,"bizjsConstructor",1,null);


/**
3:通过编译得到
js:
function(a,b){
    java.lang.System.out.println("smurfsjs:"+ a+"|"+b);
};
**/
Function fn =  rhino.compileFunction(scope,scriptString,"bizjsConstructor",1,null);

````

##  参考

[Embed JavaScript in Android Java Code with Rhino](https://vec.io/posts/embed-javascript-in-android-java-code-with-rhino)
[【Android】不使用WebView来执行Javascript脚本（Rhino）](http://www.cnblogs.com/over140/p/3389974.html)

