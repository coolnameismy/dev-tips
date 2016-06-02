 
 

 ##  Native调用js传递Native对象
 

````java
//注册一个ScriptableObject 对象
ScriptableObject.defineClass(scope, ScriptHandler.class);
//获取对象
Scriptable scriptHandler = rhino.newObject(scope, "ScriptHandler");

//给native的scriptHandler在js中增加一个log1的方法（原生只有log方法）
Function constructor = (Function) rhino.evaluateString(scope,scriptString,"bizjsConstructor",1,null);
constructor.call(rhino,scope,scope,new Object[]{
      scriptHandler,"b"
  });

//调用注册的log1方法
ScriptableObject.callMethod(scriptHandler,"log1",new Object[]{"this form native call js inject fn"});
````

scriptString中的js如下：


````js
//逻辑脚本
(function(scriptHandler,b){
    //给对象增加新的方法
    scriptHandler.log1 = function(msg){
        scriptHandler.log(msg);
    }
});


````

##  常用方法

判断是否有属性和方法

````
boolean a1 = ScriptableObject.hasProperty(m_bleDelegateScriptable,"init");
````


