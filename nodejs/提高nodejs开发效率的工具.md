## 让你的nodejs代码修改后无需重启应用即可生效的工具supervisor

安装： ```` npm install -g supervisor  ````

使用： 

```` JavaScript
 //启动你的app
supervisor index.js 
//express对于预编译的hbs可能不起作用，执行这段代码即可
supervisor -e js,hbs ./bin/www
````  