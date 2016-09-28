requirejs在gulp中的使用

##  基本配置

gulpfile.js

````js
var gulp = require('gulp'),
    rjs = require('gulp-requirejs');


//js require打包
gulp.task('js',function(){
    rjs({
            baseUrl: './src',
            mainConfigFile: './src/config.js',
            name: '_init_',
            out: './out.js',
            exclude: [
                // 'css',
                // 'text'
            ],
            findNestedDependencies: true,
            optimize: 'uglify' 
        })
        //压缩
        //.pipe(uglify({
        //      mangle: {
        //        except: ['$super']
        //      }
        //    }))
        .pipe(n2a({reverse: false}))
        .pipe(gulp.dest('./package/')); // pipe it to the output DIR    
 
})

````
##  requirejs配置文件 config.js

````
require.config({
    baseUrl: "./src/",
    paths:{
        "XXXShim":"./components/XXXShim"
    }
    ,
    // 处理非amd规范
    shim: {
        'XXXShim':{
            exports:'XXXShim'
         }
    }
})

````

shim用于处理一些非amd规范，其他的配置项详细内容可以看requirejs文档

##  启动文件 _init_

这里可以直接在init文件中使用

````
 define([
      "xxx"
    ], function(xxx){
    });
````
不过如果这样用，生成的out.js文件会是这样的

````
define("xxx", (function (global) {
    return function () {
        var ret, fn;
        return ret || global.xxx;
    };
}(this)));

````

导致在使用out.js时，需要单独引入requirejs,如果是希望能把requirejs包含到out.js中，可以修改_init_文件为这样的形式

````

//requirejs源码
...
...
...
...

//添加入口文件，后续文件会从enter.js中执行
require(['enter'], function(){});

````

##  启动文件

启动文件中引入的代码，才会被打包到out.js中，反之，如果没有用到，是不会被打包到out.js当中的。shim也有相同的规则

````
define([
      "xxx"
    ], function(xxx){
        
    });
````

这样的会启动文件就会包xxx打包进out.js

##  其他注意点

- 路径使用相对文件的路面，config.js使用相对config的路径可以统一配置包的路径,config中定义的paths 才能被外部引用到



##  示例，，main包含a,b,c,c包含c1,c2，生成后的代码如下

config

````js
require.config({
    baseUrl: "./src/",
    paths:{
        "a":"./components/a",
        "b":"./components/b",
        "c":"./components/c"
        "c1":"./components/c1",
        "c2":"./components/c2"
    }
    ,
    // 处理非amd规范
    shim: {
    }
})
````


````js
//文件a
define('a',[ ],function(){
  var a = "a";
  return a;
});
	
//文件b
define('b',[ ],function(){
  var b = "b";
  return b;
});
	
 //文件c1
define('c1',[ ],function(){
  var c1 = "c1";
  return c1;
});

//文件c2
define('c2',[ ],function(){
  var c2 = "c2";
  return c2;
});

//文件c
define('c',["c1","c2"],function(c1,c2){
  var c = c1+c2;
  return c;
});
	 
//入口文件
define('main',[
      "a","b","c"
    ], function(a,b,c){
        console.log(">>>  main.js end");
    });
````







