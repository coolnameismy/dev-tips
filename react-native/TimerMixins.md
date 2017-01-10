##  TimerMixins

我们发现很多React Native应用发生致命错误（闪退）是与计时器有关。具体来说，是在某个组件被卸载（unmount）之后，计时器却仍然被激活。为了解决这个问题，我们引入了TimerMixin。如果你在组件中引入TimerMixin，就可以把你原本的setTimeout(fn, 500)改为this.setTimeout(fn, 500)(只需要在前面加上this.)，然后当你的组件卸载时，所有的计时器事件也会被正确的清除。

这个库并没有跟着React Native一起发布。你需要在项目文件夹下输入npm i react-timer-mixin --save来单独安装它

````js
var TimerMixin = require('react-timer-mixin');

var Component = React.createClass({
  mixins: [TimerMixin],
  componentDidMount: function() {
    this.setTimeout(
      () => { console.log('这样我就不会导致内存泄露!'); },
      500
    );
  }
});
````


我们强烈建议您使用react-timer-mixin提供的this.setTimeout(...)来代替setTimeout(...)。这可以规避许多难以排查的BUG。

译注：Mixin属于ES5语法，对于ES6代码来说，无法直接使用Mixin。如果你的项目是用ES6代码编写，同时又使用了计时器，那么你只需铭记在unmount组件时清除（clearTimeout/clearInterval）所有用到的定时器，那么也可以实现和TimerMixin同样的效果。例如：

````js
import React,{
  Component
} from 'react-native';

export default class Hello extends Component {
  componentDidMount() {
    this.timer = setTimeout(
      () => { console.log('把一个定时器的引用挂在this上'); },
      500
    );
  }
  componentWillUnmount() {
    // 如果存在this.timer，则使用clearTimeout清空。
    // 如果你使用多个timer，那么用多个变量，或者用个数组来保存引用，然后逐个clear
    this.timer && clearTimeout(this.timer);
  }
};
````