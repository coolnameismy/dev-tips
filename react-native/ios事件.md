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
