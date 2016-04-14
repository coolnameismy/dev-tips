##  导航初始化导航传递

````
<Navigator
  initialRoute= {this.props.initialRoute} 
  navigationBar={
     <XYNavigatorBar
           navigator={this.navigator} 
           style={styles.nav}
           titleTextColor = {this.props.titleTextColor}
           >
     </XYNavigatorBar>
  }
  configureScene={(route) => {
    return Navigator.SceneConfigs.VerticalDownSwipeJump;
  }}
  renderScene={(route, navigator) => {
    this.navigator = navigator;
    let Component = route.component;
    return <View style={{height:Dimensions.get('window').height}}><Placeholder></Placeholder>
              <Component 
              {...route.params} 
              {...this.props.initialRoute.passProps} 
              navigator={navigator}
               />
           </View>
  }} 
  {...this.props.attrForNavigator}
/>
````

-  navigationBar： 导航栏，自带的不好用，可以自定义一个，比如XYNavigatorBar
-  renderScene：初始化导航场景的方法
-  configureScene：导航切换方式
-  一定要使用 navigator={navigator} 把导航在容器中进行传递，否则后面的页面无法使用导航栈

##  获取导航参数和上下文方法

上面把navigator传递到下游控件，控件获取一些重要的参数

-  获取导航 ：var navigator = this.props.navigator;
-  获取栈中的路由 navigator.getCurrentRoutes()
-  获取路由层次 navigator.getCurrentRoutes().length

##  导航方法使用

````
getCurrentRoutes() - 获取当前栈里的路由，也就是push进来，没有pop掉的那些。
jumpBack() - 跳回之前的路由，当然前提是保留现在的，还可以再跳回来，会给你保留原样。
jumpForward() - 上一个方法不是调到之前的路由了么，用这个跳回来就好了。
jumpTo(route) - 跳转到已有的场景并且不卸载。
push(route) - 跳转到新的场景，并且将场景入栈，你可以稍后跳转过去
pop() - 跳转回去并且卸载掉当前场景
replace(route) - 用一个新的路由替换掉当前场景
replaceAtIndex(route, index) - 替换掉指定序列的路由场景
replacePrevious(route) - 替换掉之前的场景
immediatelyResetRouteStack(routeStack) - 用新的路由数组来重置路由栈
popToRoute(route) - pop到路由指定的场景，其他的场景将会卸载。
popToTop() - pop到栈中的第一个场景，卸载掉所有的其他场景。

````
###  例子：

````javascript
	return ( <View style={styles.navRightWrap}>
              	  <TouchableOpacity style={styles.navRightWrap} onPress={() => {
              	  	this.props.navigator.push({
	              	  	name: 'SecondPageComponent',
	              	  	component: SecondPageComponent,
              	 	 })
              	  }}>
                  	 <Text style={[styles.navRightText,{ color:this.props.btnTextColor || navStyle.nav_fontColor }]}>
                  	 	 {text || 'next'}
                  	 </Text>
                  </TouchableOpacity>
	          </View>)

	import React, { Component } from 'react-native';
````

SecondPageComponent

````javascript
const {
  StyleSheet,
  View,
  Text,
} = React;

class SecondPageComponent extends Component {
  render() {
    return (
     	<View style ={{
         height:1000,backgroundColor:'red',
         position:'absolute'

       }} >
     	    <Text >SecondPageComponent </Text>
     	</View>
    );
  }
}

var styles = StyleSheet.create({

});


export default SecondPageComponent;
````
