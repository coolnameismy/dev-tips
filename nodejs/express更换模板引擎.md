express更换模板引擎

##	把jade改成handlebars

1:安装依赖环境

````
npm install Handlebars --save-dev
npm install Consolidate --save-dev
````

2:修改app.js

````
// view engine setup
// app.set('views', path.join(__dirname, 'views'));
// app.set('view engine', 'jade');

//改为

// Use handlebars as template engine
app.engine("html", consolidate.handlebars);
app.set("view engine", "html");
app.set("views", __dirname + "/views");

````

3：测试可用

在views下面新建一个index.html页面，然后启动应用看是否可以访问的到


4:数据绑定示例：

routes/index.js

````javascript
var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res, next) {
	var data = [
        { "title":"aaa","content":"contentaaa"},
        { "title":"aaa","content":"contentaaa"},
        { "title":"aaa","content":"<h1>h1</h1>"},
        { "title":"aaa","content":"contentaaa"}
    ];
  res.render('index1', { name: 'Express',data:data });
});

module.exports = router;
````

index1.html

````html
<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Document</title>
</head>
<body>
	<h1>hello {{name}}  index! </h1>
	<div id="content"></div>
      {{#each data}}
        <div>
         <h1>{{title}}</h1>
         <p>{{content}}</p>
        </div>
       {{/each}}
</body>
</html>

````


##	把jade改成ejs

````javascript
//use ejs
app.engine('.html', require('ejs').renderFile);
app.set('view engine', 'html');

````

views使用

````
<h2><%= name %></h2>
````


##	自定义模板引擎

切换自定义的模板引擎

````javascript
var selfViewTemplate = require('./templateEngines/selfViewTemplate.js');
//自定义模板引擎
app.set('views', path.join(__dirname, 'views'));
app.engine('.html', selfViewTemplate.render);
app.set('view engine', 'html');
````

route中的使用示例(每个模板引擎的使用几乎都差不多)：

````
router.get('/', function(req, res, next) {
  res.render('index', { name: 'Express'});
});
````

自定义模板引擎的selfViewTemplate.js

````
/* 
	参数说明： path:上下文路径 options:route中render()方法的第二个上下文参数，fn:回教函数function(err,html)
	方法说明：这里的render方法作为一个自定义模板引擎的方法的说明，用于演示如何开发自定义模板引擎，这里最重要的说明是输入和输出
	输入上下文c菜单和回调函数，输出是err和rendre后的html。若无错误则err为null。
 */
exports.render = function(path, options, fn){
  try {
    //do the render job
  } catch (err) {
    fn(err);
    return;
  }
  fn(null,"this is selfViewTemplate.js render !!!!!!!!");
};
````



