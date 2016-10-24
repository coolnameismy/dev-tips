 # ios事件

 ## 点击事件

````javascript

var {
  StyleSheet,
  View,
  Text,
  TouchableWithoutFeedback,
  TouchableOpacity,
  TouchableHighlight,
} = React;

click:function(){
    this.props.navigator.push({
      component:Page1View,
      title:"page1"
    });
}
````

 //方法1 TouchableOpacity，TouchableWithoutFeedback，TouchableHighlight都可以使用，专门处理点击事件的类
 <TouchableWithoutFeedback onPress={this.click}>

 </TouchableWithoutFeedback>


//方法2 component添加onPress事件

````javascript

<Text style={styles.text} onPress={this.click}>
  push 跳转
</Text>

````
 
 ## 事件传递参数


````
  //设置方法
  clicked:function(message){alert(message);}

  //传递参数要调用事件的bind方法，第一个参数为上下文，第二个为方法的参数
  <Text onPress={this.clicked.bind(this,'message')}>点击</Text>
````

##  委托

先定义一个控件，其click事件由外部获取,这种情况一般需要把上下文设成null，否则会收到一个警告

````
var xxx = React.createClass({
  render: function() {
    return (
        <Text onPress={this.props.clicked.bind(null,'message')} > 
        点击 </Text>
    );
  },
});
````

外部传入clicked事件

````
  //定义外部clicked方法
  externalClicked:function(msg){
     alert(msg);
  },
 <xxx clicked={this.externalClicked}> </xxx>
````

## 阻止冒泡

e.stopPropagation();

e.preventDefault();

##  事件消息

````

var RCTDeviceEventEmitter = require('RCTDeviceEventEmitter');


this.listener = RCTDeviceEventEmitter.addListener('viewDidAppear', this.onViewDidAppear.bind(this))
this.listener = DeviceEventEmitter.addListener('keyboardWillShow', function(e: Event) {
    // handle event.
  });
this.addListenerOn(DeviceEventEmitter,
                      'keyboardWillShow',
                      this.scrollResponderKeyboardWillShow);


RCTDeviceEventEmitter.once('hardwareBackPress', this.hardwareBackPress.bind(this))
//DeviceEventEmitter.emit('自定义名称',发送数据);
DeviceEventEmitter.emit('taobaoBind',{taobaoBind:false,walletSum:0.00,couponNum:0});
````


0.26文档

````
//native 发送事件
@synthesize bridge = _bridge;
- (void)calendarEventReminderReceived:(NSNotification *)notification
{
  NSString *eventName = notification.userInfo[@"name"];
  [self.bridge.eventDispatcher sendAppEventWithName:@"EventReminder"
                                               body:@{@"name": eventName}];
}

//js 订阅
var { NativeAppEventEmitter } = require('react-native');

var subscription = NativeAppEventEmitter.addListener(
  'EventReminder',
  (reminder) => console.log(reminder.name)
);
...
// 千万不要忘记忘记取消订阅, 通常在componentWillUnmount函数中实现。
subscription.remove();

````

## 参考

[ReactNative 学习笔记 Community- 组件，页面通讯](http://vivianking6855.github.io/rn-Community-post/)

