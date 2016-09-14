## gulp任务拆分多个文件

> 在gulp构建中，可以把特别复杂的gulp脚本单独拆分出去利于代码逻辑分解。


假设在gulpfile.js文件有个特别复杂的任务taska我们希望把它拆分出去，taska包含2个子任务，demo如下

taska.js

````js
var gulp = require('gulp');

gulp.task('foo1',function(){
    console.log('foo1 run!'); 
})
 
gulp.task('foo2',function(){
    console.log('foo2 run!'); 
})

//task可以设置一个cb，方便回调
gulp.task('taska', ['foo1','foo2'],function  (cb) {
    cb()
})
````

在gulpfile.js文件中引入taska,执行taska的方式

````js
var gulp = require('gulp');
//导入taska
require('./taska.js');

//执行gulp run 或直接执行gulp taska都可以调用到taska
gulp.task('run', ['taska'],function(cb) {
  console.log('foo task done!'); 
})
````

 
