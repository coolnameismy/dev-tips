express使用

##	安装环境


````
//安装生成器
npm install express-generator -g
//创建项目
express myapp
//安装所有依赖包
cd myapp 
npm install

//启动这个应用（MacOS 或 Linux 平台）：
DEBUG=myapp npm start
````

##	路由

````
// 对网站首页的访问返回 "Hello World!" 字样
app.get('/', function (req, res) {
  res.send('Hello World!');
});

// 网站首页接受 POST 请求
app.post('/', function (req, res) {
  res.send('Got a POST request');
});

// /user 节点接受 PUT 请求
app.put('/user', function (req, res) {
  res.send('Got a PUT request at /user');
});

// /user 节点接受 DELETE 请求
app.delete('/user', function (req, res) {
  res.send('Got a DELETE request at /user');
});
````

##	静态文件

````
//将静态资源文件所在的目录作为参数传递给 express.static 中间件就可以提供静态资源文件的访问了
app.use(express.static('public'));
//虚拟目录设置 static为虚拟目录名称
app.use('/static', express.static('public'));
````

##	配置错误处理器

````
app.use(function(err, req, res, next) {
  console.error(err.stack);
  res.status(500).send('Something broke!');
});
````

##	404跳转

````
app.use(function(req, res, next) {
  res.status(404).send('Sorry cant find that!');
});
````

## 渲染html
````
不需要！无需通过 res.render() 渲染 HTML。你可以通过 res.sendFile() 直接对外输出 HTML 文件。如果你需要对外提供的资源文件很多，可以使用 express.static() 中间件。
````