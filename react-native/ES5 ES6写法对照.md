var Recipes = React.createClass({

  statics:{
    navbarPassProps:{
      statusBarColor:'black',
      style: {},
      buttons:[{name:'search',iconfont:'&#x3035'}],
      title:'云食谱'
    }
  },


  .....

class Recipes extend {

  static navbarPassProps  = {
      statusBarColor:'black',
      style: {},
      buttons:[{name:'search',iconfont:'&#x3035'}],
      title:'云食谱'
  } 

  ...

}

//ES5
var React = require("react");
var {
    Component,
    PropTypes
} = React;  //引用React抽象组件


//ES6
import React, { 
    Component,
    PropTypes,
} from 'react';
import {
    Image,
    Text
} from 'react-native'



//ES5
var MyComponent = React.createClass({
    ...
});
module.exports = MyComponent;


//ES5
var MyComponent = require('./MyComponent');

//ES6
import MyComponent from './MyComponent';


var Photo = React.createClass({
    render: function() {
        return (
            <Image source={this.props.source} />
        );
    },
});


//ES6
class Photo extends React.Component {
    render() {
        return (
            <Image source={this.props.source} />
        );
    }
}

http://bbs.reactnative.cn/topic/15/react-react-native-%E7%9A%84es5-es6%E5%86%99%E6%B3%95%E5%AF%B9%E7%85%A7%E8%A1%A8