## 注释

render方法中只能使用/* ... */方式注释，其余部分可以使用//注释

##  延展属性（Spread Attributes）

{...props}  中````...````是ES6语法，延展属性相当于遍历props所有属性并赋值


````
var props = {
	text1:'text1',
	text2:'text2',
	text3:'text3',
};

var JsxSyntaxView = React.createClass({
  render: function() {
    return (
    	/* 使用延展属性赋值 {...props}  */
      	<MyText  {...props}></MyText>
    );
  }
});

var MyText = React.createClass({
  render: function() {
    return (
      <View style={[styles.container,styles.center]}>
      	<Text style={styles.text}>{this.props.text1} | {this.props.text2} | {this.props.text3} </Text>
      </View>
    );
  }
});
 	

````


##  原始html
````
{{__html: 'First &middot; Second'}}
````