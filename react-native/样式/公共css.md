react-natice开发时我们希望可以把css抽取出来单独保存为样式文件，我想到一个简单的方案

##	首先建立一个公共样式文件 common.css.js

````css

/* @flow */
'use strict';

var React = require('react-native');

var {
  StyleSheet,
  View,
} = React;

var CommonStyle = StyleSheet.create({
	class1: {},
	class2: {},
	class3: {},
});

module.exports = CommonStyle;

````

##	使用common.css.js

````javascript
//加载公共样式
const styles =  require('../style/common.css.js');

//添加个性化样式
styles.class4 = { };

//覆盖之前的样式
styles.class1 = { };
````

##	其他

这个是最简单的实现方式，还可以通过其他方式实现，比如：

-	封装一个css manager管理类
-	使用gulp等脚本做代码自动构建
