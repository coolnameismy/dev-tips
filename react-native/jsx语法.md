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

## 条件和分支

jsx不能使用if-else分支，但可以使用条件表达式代替。

如果一定要使用if-else，可以用if-eles生成变量在用{{绑定进去}}

````
  <View style={styles.container}>
    {this.state.name==1?
      <Text style={{fontSize:12,color:'#fff'}}> ' this.state.name==1? xxx : null 条件表达式为真' </Text>
      :null
    }
  </View> 

````

##	循环遍历

````
var items = [0,1,2,3,4];
//遍历构造数组，需要指定一个key否则会产生警告
var dom = items.map(function(item) {
        return (
             <Text key={item} style={{fontSize:12,color:'#fff'}}> {item} </Text>
            );
         });

````

构造好dom后可以在render方法中使用

````
	<View style={{flex:1,flexDirection:'row',}}>{dom}</View>
````


