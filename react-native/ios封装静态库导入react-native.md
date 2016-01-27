##  第一阶段：创建静态库

-	1：新建一个静态库，放在node_modules目录下
-	2：设置Header Search Paths，这样在开发时候才能````	#import "RCTBridge.h"  ````

build setting 中设置Header Search Paths 为```` $(SRCROOT)/../react-native/React  ````

-	3：设置头文件，build phases -> New Headers phases,选择需要包含的头
- 	4：选择设备（模拟器或者是真机）生成produceName.a文件和header文件
- 	5：编译（选择真机设备，然后 Command+B 编译， libMJRefresh.a 文件从红色变为黑色，然后在选择模拟器Command+B）


##  第二阶段：react-native项目中导入静态库或静态库工程


###  导入静态库
- 将 .a 、 .h 、资源文件拖拽到其他项目中即可

###  导入静态库工程

- 1：在xode中选择 add files to project，把需要导入的项目工程文件加入，或者直接把工程文件拖入项目中。
- 2：设置Build Phases
````
 选择progect的targets，打开Build Phases标签
 选择Link Binary With Libraries，点击+，添加xxx.a
 追加xxx所需要的Frameworks
````
- 3: build setting 中设置Header Search Paths



##  第三阶段：封装npm包

````
npm init
````

输入包信息，设置包入口为：index.ios.js

新建入口页面index.ios.js，设置方法或者界面都可以，示例：

````js
/* @flow */
'use strict';

var React = require('react-native');

var {
  StyleSheet,
  View,
  Text,
  NativeModules
} = React;


var MyNativeStaticModule = NativeModules.MyNativeStaticModule;

var MyNativeStaticModuleExports = React.createClass({
  clicked:function(){
		 MyNativeStaticModule.Hello(function(){
	     console.log(arguments);
	   });
  },
  render: function() {
    return (
      <View style={{flex:1,backgroundColor:'gray'}}>
      	<Text style={{justifyContent:'center',alignItems:'center'}} onPress={this.clicked}>
      		我是MyNativeStaticModule，是原生代码npm模块的封装，点我可以调用原生hello方法。可以参考工程中MyNativeStaticModule子工程.
      	</Text>
      </View>
    );
  }
});


var styles = StyleSheet.create({

});


module.exports = MyNativeStaticModuleExports;

````

##  js中的调用

````js
var MyNativeStaticModule = require('my-native-static-module');

 render: function() {
    return (
      <View style={{flex:1,justifyContent:'center',alignItems:'center',flexDirection:'column'}}>
     		<Text  style={{flex:1,top:80}}onPress={this.clicked}> 
		   		本节主要演示内容：react-native 调用原生ios模块,点击文字调用原生Hello()方法，并且会收到
		   		"afterHello"的事件通知
   			</Text>
        <MyNativeStaticModule></MyNativeStaticModule>
      </View>
    );
  }
````