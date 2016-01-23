##  注册一个可以再react-native中被调用的ios原生类

MyNativeModule.h

````objc
#import <UIKit/UIKit.h>
#import "RCTBridge.h"

@interface MyNativeModule : NSObject<RCTBridgeModule>

@end
````

MyNativeModule.m

````objc
#import "MyNativeModule.h"

@implementation MyNativeModule
//这段必须放在自定义类中，用于实现RCTBridgeModule协议
#define RCT_EXPORT_MODULE(js_name) \
RCT_EXTERN void RCTRegisterModule(Class); \
+ (NSString *)moduleName { return @#js_name; } \
+ (void)load { RCTRegisterModule(self); }

//注册模块
RCT_EXPORT_MODULE()

//注册方法
/*  
RCTResponseSenderBlock 回调函数类型 callback回调函数名称
*/
RCT_EXPORT_METHOD(Hello:(RCTResponseSenderBlock)callback){
   callback(@[[NSNull null],[self m_Hello]]); //调用原生方法
}

//原生方法
-(NSDictionary *)m_Hello{
  return @{@"name":@"xxx"};
}

@end

````

## 	react-native中调用模块MyNativeModule

````javascript

//获取模块的方式1
var {
  ...
  NativeModules,
} = React;
var MyNativeModule = NativeModules.MyNativeModule;

//方式2
var MyNativeModule = React.NativeModules.MyNativeModule;

//方式3
var MyNativeModule = require('NativeModules').MyNativeModule;



//使用模块方法
MyNativeModule.Hello(function(err,data){
	// console.log(arguments);
	// data就是回传的那个dictionary数据{"name":"xxx"}
});
````

##  总结一下ios原生对象和js桥接

###关键步骤：

1:实现RCTBridgeModule协议，并把RCTBridgeModule协议实现的宏copy到implementation文件下方，内容为：

````
#define RCT_EXPORT_MODULE(js_name) \
RCT_EXTERN void RCTRegisterModule(Class); \
+ (NSString *)moduleName { return @#js_name; } \
+ (void)load { RCTRegisterModule(self); }
````

2:使用RCT_EXPORT_MODULE()和RCT_EXPORT_METHOD()注册方法和模块

3:如果有回调函数，有四种类型，一般我们都使用RCTResponseSenderBlock类型，回传一个NSArray对象。如果需要使用其他类型，可以通过实现````RCTConvert````方法进行转换。

4:native每个模块都会独立运行在一个线程当中，如果需要指定线程可以实现````@property (nonatomic, strong, readonly) dispatch_queue_t methodQueue;````属性，返回一个线程

5:如果想导出一些常量，可以使用````- (NSDictionary<NSString *, id> *)constantsToExport;````方法导出

````objc
-(NSDictionary<NSString *,id> *)constantsToExport{
   return @{@"a":@"aa",@"b":@"bb"};
}
//js中使用
MyNativeModule.a,MyNativeModule.b
````

6：事件


## 注意点

-  原生方法和json通信使用json类型



