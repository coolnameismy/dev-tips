>  这两种方式都是实现的同一个功能.React一开始用React.createClass方法来创建一个组件类,然后又在以后的更新中提供了一个小小的语法糖来允许我们使用ES6的心特性---我们可以用extends React.Component来代替createClass方法. 两者之间有几处差别,有一些还是挺有意思的,值得一探究竟.你可以看完本文的对比之后再做出适合自己的选择 (译者注:还是用es6的新特性吧,毕竟未来)

##  语法差别

React.createClass 注意,这里我们的const来定义了一个React类(而不是var)

````javaScript
import React from 'react';

const Contacts = React.createClass({
  render() {
    return (
      <div></div>
    );
  }
});

export default Contacts;

````

React.Component 现在可以用babel将es6写的js脚本转化成es5语法以适应现在的浏览器.


````javaScript
import React from 'react';

class Contacts extends React.Component {
  constructor(props) {
    super(props);
  }
  render() {
    return (
      <div></div>
    );
  }
}

export default Contacts;


````
在这里面,我们用到了constructor(构造器),并且调用了super()方法把props传递给了React.Component
通过这种改变,同样是定义一个Contacts类,我们减少了React样本文件的引用,而更多的是用了JS代码.这是一个重要的改变.

##  propTypes and getDefaultProps(prop指属性,state状态)

在声明默认props和state的时候,这两者之间有很大的不同

React.createClass 在使用createClass方法时,propTypes属性是一个对象,我们可以为其中的每个prop声明类型.getDefaultProps这个属性是一个函数,它会返回一个对象来初始化组件的属性

````javaScript
import React from 'react';

const Contacts = React.createClass({
  propTypes: {

  },
  getDefaultProps() {
    return {

    };
  },
  render() {
    return (
      <div></div>
    );
  }
});

export default Contacts;

````

React.Component 在这里

propsTypes变成了Contacts类的一个自有属性,而不是createClass那样需要手动定义.我认为中语法更优秀,因为你可以很清楚的分辨出,这个类里面,那些是React的api,哪些是你自定义的
getDefaultProps被丢弃了,取而代之的是defaultProps,它是类的一个对象属性.并且,defaultProps不是一个函数,它仅仅是一个对象.我喜欢这种语法,因为它避免了过多的React模板,只有干净的JavaScript

````javaScript
import React from 'react';

class Contacts extends React.Component {
  constructor(props) {
    super(props);
  }
  render() {
    return (
      <div></div>
    );
  }
}
Contacts.propTypes = {

};
Contacts.defaultProps = {

};

export default Contacts;

````

##  state(状态)差别

state的改变挺有意思,现在我们用构造器来实现初始状态的改变

-  1. getInitialState只是返回了一个初始状态的对象
-  2. 我们只需要在constructor(构造器)里面简洁的声明一下就可以了.

````javaScript
import React from 'react';

class Contacts extends React.Component {
  constructor(props) {
    super(props);
    this.state = {

    };
  }
  render() {
    return (
      <div></div>
    );
  }
}

export default Contacts;

````

##  this 的差别

createClass 会自动为我们把"this"绑定给正确的值,但是使用ES6中的"类"声明的时候,就不一样了

React.createClass 注意这里的onClick和this.handleClick进行了绑定,当onClick行为被触发的时候,React会自动为handleClick方法配置正确的上下文

````
import React from 'react';

const Contacts = React.createClass({
  handleClick() {
    console.log(this); // React Component instance
  },
  render() {
    return (
      <div onClick={this.handleClick}></div>
    );
  }
});

export default Contacts;
````

React.Component ES6种,React不会把this自动绑定到类的实例中

````javaScript
import React from 'react';

class Contacts extends React.Component {
  constructor(props) {
    super(props);
  }
  handleClick() {
    console.log(this); // null
  }
  render() {
    return (
      <div onClick={this.handleClick}></div>
    );
  }
}

export default Contacts;

````

我们可以用其他的方法实现把this绑定到正确的上下文中,比如这样,在

````javaScript
import React from 'react';

class Contacts extends React.Component {
  constructor(props) {
    super(props);
  }
  handleClick() {
    console.log(this); // React Component instance
  }
  render() {
    return (
      <div onClick={this.handleClick.bind(this)}></div>
    );
  }
}

export default Contacts;

````

我们也可以在构造器中改变this.handleClick的上下文

````javaScript
import React from 'react';

class Contacts extends React.Component {
  constructor(props) {
    super(props);
    this.handleClick = this.handleClick.bind(this);
  }
  handleClick() {
    console.log(this); // React Component instance
  }
  render() {
    return (
      <div onClick={this.handleClick}></div>
    );
  }
}

export default Contacts;
````

##  mixins

  在ES6中,React不用mixins了