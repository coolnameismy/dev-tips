1导入NavigatorIOS包·


````javascript

import React, {
  ...
  NavigatorIOS,
} from 'react-native';


````

2:设置rootview

````javascript
var MainView = require("./View/MainView.ios.js")

class helloworld extends Component {
  render() {
    return (
       <NavigatorIOS
        style={{flex:1}}
        barTintColor= '#EAF1F1'
        titleTextColor = '#46625B'
        translucent = {false}
        shadowHidden = {false}
        initialRoute={{
          title: '发现',
          component: DiscoveryListView,
          passProps: { sourceUrl: 'http://dip.alibaba-inc.com/api/v2/services/schema/mock/22183?spm=a312q.7764190.0.0.OmhLe7' }
        }} />
    );
  }
}

````

##  导航跳转

````
push(route) - Navigate forward to a new route
pop() - Go back one page
popN(n) - Go back N pages at once. When N=1, behavior matches pop()
replace(route) - Replace the route for the current page and immediately load the view for the new route
replacePrevious(route) - Replace the route/view for the previous page
replacePreviousAndPop(route) - Replaces the previous route/view and transitions back to it
resetTo(route) - Replaces the top item and popToTop
popToRoute(route) - Go back to the item for a particular route object
popToTop() - Go back to the top item
````

例子：


````javascript
click:function(){
    this.props.navigator.push({
      component:Page1View,
      title:"page1"
    });
}
````

````javascript
click:function(){
	this.props.navigator.pop();
}
````

modal

````javascript


````



