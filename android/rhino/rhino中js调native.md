 ## js调用rhino内置方法

###  打印native日志

 ````js
java.lang.System.out.println("aaaaaa")
 ````

 定义一个更加方便的方法

 ````js
 function print() {
    for( var i = 0; i < arguments.length; i++ ) {
       var value = arguments[i];
       java.lang.System.out.print( value );
    }
    java.lang.System.out.println();
}

function printf( format ) {
    java.lang.System.out.printf( format, Array.prototype.slice.call(arguments) );
}
 ````


##  js调用Native对象

-  创建一个继承自`ScriptableObject` 接口的类

````java
public class ScriptHandler extends ScriptableObject {

    //必须实现的方法
    @Override
    public String getClassName() {
         return "ScriptHandler";
    }
    
    @JSFunction
    public void log(String msg) {
        Log.e("smurfsLog",msg);
    }

    // @JSGetter
    // @JSConstructor
}

````

-  注册类到js运行时  `  ScriptableObject.defineClass(scope, ScriptHandler.class);`

-  Java中使用这个类（必须先注册）

````java
//获取对象
Scriptable scriptHandler = rhino.newObject(scope, "ScriptHandler");
//调用方法
ScriptableObject.callMethod(scriptHandler,"log",new Object[0]);
//获取属性
Object prop = ScriptableObject.getProperty(scriptHandler, "prpoName");
````

-  js中使用这个类（必须先注册）

````js
var scriptHandler = new ScriptHandler();
scriptHandler.log("cal from smurfsjs log!!!!!!!!!!!!!!!!!!");
````









