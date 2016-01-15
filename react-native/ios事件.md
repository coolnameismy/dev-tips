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


//方法2 component添加点击

````javascript

<Text style={styles.text} onPress={this.click}>
  push 跳转
</Text>

````

 