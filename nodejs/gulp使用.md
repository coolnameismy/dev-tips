
>   [gulp](http://gulpjs.com/)是一个nodejs的构建工具,思路更清晰，逻辑更简单，使他慢慢替代了grunt在自动构建工具中的地位。


##  安装gulp
---

```` npm install -g gulp ````

##  常用命令简单介绍

主要的函数并不多，大家大概认识认识就可以了，因为gulp这东西还和代码不一样，也不需要天天写，一共项目就写一次，后面还可以重复用，记不得看看官网文档就好了。

````
gulp.task(name, fn): 创建构建任务
gulp.run(tasks...)  并行运行多个task
gulp.watch(glob, fn) 监听内容改变，自动执行fn
gulp.src(glob)  加载stream
gulp.dest(glob) 返回一个可写的stream
````
[中文gulp api](http://www.gulpjs.com.cn/docs/api/)
[原文gulp api](https://github.com/gulpjs/gulp/blob/master/docs/API.md)

## gulp使用简单例子
---

1全局安装 gulp：

```` $ npm install --global gulp ````

2作为项目的开发依赖（devDependencies）安装：

```` $ npm install --save-dev gulp ````

3在项目根目录下创建一个名为 gulpfile.js 的文件：

````
var gulp = require('gulp');
gulp.task('default', function() {
  // 将你的默认的任务代码放在这
});
````

4运行 gulp：

```` $ gulp ````


那么具体在task中间执行什么样的内容呢？ 用gulp的都是因为项目中大量使用需要自动构建的内容，比如项目中使用的sass，那么可以配置一个task，
把你css文件夹中的sass文件全部压缩后输出到你的dist目录，可以根据你的开发或生产环境决定生成的css是否需要压缩。还可以配置一个watch任务，
监控你css目录的文件改动，只要有改动就重新生成文件。同理对应js也一样有效。此外还可以用自动构建去自动处理图片压缩等等。具体能执行什么样的任务，
根据gulp支持的插件有关系，如果没有插件支持，除非你自己做一个插件，否则没有的功能也是支持不了的。

##  gulp常见的插件及作用
---

````

gulp-autoprefixer //浏览器前缀
gulp-handlebars   //handlebars生产模板js
gulp-imagemin     //图片压缩
gulp-ruby-sass    //sass
gulp-minify-css   //css压缩
gulp-jshint       //js检查
gulp-uglify       //js压缩
gulp-rename       //重命名
gulp-concat       //合并文件
gulp-clean        //清空文件夹
gulp-notify       //消息提示
gulp-sourcemaps   //成maps文件
gulp-changed   //检测文件修改
````

一般在gulpfile.js 文件开始的时候，把这些库引入

````
// 引入 gulp及组件
var gulp    = require('gulp'),                //基础库
    autoprefixer = require('gulp-autoprefixer'),  //浏览器前缀
    handlebars = require('gulp-handlebars') ,
    imagemin = require('gulp-imagemin') ,     //图片压缩
    sass = require('gulp-ruby-sass'),        //sass
    minifycss = require('gulp-minify-css'),   //css压缩
    jshint = require('gulp-jshint'),           //js检查
    uglify  = require('gulp-uglify'),         //js压缩
    rename = require('gulp-rename'),           //重命名
    concat  = require('gulp-concat'),        //合并文件
    clean = require('gulp-clean'),            //清空文件夹
    notify = require('gulp-notify'),
    sourcemaps = require('gulp-sourcemaps');  //生成maps文件


//css编译任务
gulp.task('css', function () {
    //do you task !
});

````


如果要使用这些库，必须在项目中安装 安装命令: ```` npm install gulp-xxx -save-dev ````

这个地方很容易出错，如果任何require() 的库不存在，执行gulp时候都会报错，而且错误信息很难分辨少了哪个，这时候就要一个个检查了。


##  gulp常见任务

常见任务的配置是gulp的核心功能

.pipe()方法是传递数据流的方法，，gulp通过pipe方法把流不断进行处理和传递。


### css编译任务

````
//css编译任务
gulp.task('css', function () {
    sass('app/css/base.scss') .pipe(gulp.dest('app/css/dist/css'));
});
````

上面是一个简单的css编译任务，他所作的就是把app/css/base.scss通过scss组建编译成css，然后放入app/css/dist/css文件夹，如果文件夹不存在
会默认创建一个。

再来看一个复杂点的css编译任务,把scss编译成css，然后重命名为min.css，之后压缩文件，最后把压缩和未压缩的css都输出到目标文件。完成之后调用了
````notify()````方法，输出生成好的文件提示信息。

cssDst和cssSrc是设置好的css输入和输出目录。

````

//css构建任务
gulp.task('css', function () {

    sass(cssSrc)
        .pipe(gulp.dest(cssDst))
        .pipe(rename({ suffix: '.min' }))
        .pipe(minifycss())
        .pipe(gulp.dest(cssDst))
        .pipe(notify({ message: '<%= file.relative %> task complete' }));

});

//命令行敲 gulp css 会执行这个目录

````

### js构建任务

js构建任务例子，和css的构建任务差不多，js文件压缩后和源文件一起放到目标文件夹，完成后通知生成的文件

````

// js构建任务
gulp.task('js', function () {

    gulp.src(jsSrc)
        .pipe(gulp.dest(jsDst))
        .pipe(rename({ suffix: '.min' }))
        .pipe(uglify())
        .pipe(gulp.dest(jsDst))
        .pipe(notify({ message: '<%= file.relative %> task complete' }));

});


````

### clean 任务

有时候我们想清理一些文件夹或者是想在构建前先清空文件夹，我们就可以使用clean任务

````

// clean 任务 如 清空图片、样式
gulp.task('clean', function() {
    gulp.src([jsDst,cssDst], {read: false})
        .pipe(clean())
        .pipe(notify({ message: '<%= file.relative %> folder has been clean' }));

});

````

### watch 任务

watch任务很关键，比如我们使用sass去写css，每次我们修改了sass文件后希望自动就去生成css，或者用coffee scrpit写代码时候自动检测文件修改，
生成目标文件，就使用watch任务

````
// 监听任务 运行语句 gulp watch
gulp.task('watch',function(){

        // 监听css
        gulp.watch(cssSrc, function(){
            gulp.run('css');
        });

        // 监听js
        gulp.watch(jsSrc, function(){
            gulp.run('js');
        });

});

````

### 路径匹配

````
*.js匹配当前目录下的所有js文件,不指名扩展名则匹配所有类型
*/*.js匹配所有第一层子文件夹的js文件,第二层请用*/*/.js
**/*.js匹配所有文件夹层次下的js文件, 包括当前目录
**/*.* 递归匹配所有文件
!:排除文件夹，可以设置gulp的目标文件夹为一个数组，例如： ['**/*', '!./atom-shell.app', '!./atom-shell.app/**/*']. 这样就可以把app完全exclude掉了.
````

### 默认任务

默认任务是直接执行gulp的task，如果没有设置默认任务会报错。

比如默认执行js构建和css构建任务

````
//默认任务
gulp.task('default',['css','js']);
````

这样执行gulp的时候就会执行这两个任务。当然默认任务也不是必须的，你可以执行执行 ```` gulp cmd ``` 去执行你注册过的任务

这里有个值得注意的地方。默认任务中方法名后可以带一个数组，决定要调用的其他任务名称。之前的css或者js任务也可以通过这种方式，去调用依赖任务。


### 其他更酷的任务

gulp还能执行许多更酷的任务，比如图片压缩，服务根据文件修改自动刷新，js组合等等，等待大家自己去挖掘



查看readme说明如何使用

##  参考文章
---

-   [An Introduction to Gulp](http://www.sitepoint.com/introduction-gulp-js/)
-   [gulp入门教程](http://markpop.github.io/2014/09/17/Gulp%E5%85%A5%E9%97%A8%E6%95%99%E7%A8%8B/)
-   [Gulp安装及配合组件构建前端开发一体化](http://www.dbpoo.com/getting-started-with-gulp/)
-   [gulp中文网](http://www.gulpjs.com.cn/)
-   [ruby-sass](https://github.com/sindresorhus/gulp-ruby-sass)
-   [gulp-构建工具](http://www.ydcss.com/archives/category/%E6%9E%84%E5%BB%BA%E5%B7%A5%E5%85%B7)
-   [常用gulp插件介绍(一)](http://pinkyjie.com/2015/08/02/commonly-used-gulp-plugins-part-1/)
-   [常用gulp插件介绍(二)](http://pinkyjie.com/2015/08/02/commonly-used-gulp-plugins-part-2/)
-   [gulp做一个略完整的前端打包工作](http://www.gbtags.com/gb/share/5503.htm)