
## 命令工具的入口

这里我先创建了一个npm package叫做xy-cli 

- 1：配置bin节点，指向bin文件下的xy.js这样就安装xy-cli 后，执行xy就可以执行到 `bin/xy.js` 文件了
- 2：在xy-cli目录中执行 `npm link ` 可以把package安装到全局

````
"bin":{
  	"xy":"bin/xy.js"
  },
````
xy.js文件

````js
#!/usr/bin/env node

'use strict'

console.log(">>>","xy bin")
````

这样在命令行中执行，就打印出了 ">>> xy bin" ,这就完成了命令行的入口

## 编写自定义Yeoman生成器

````
	1. 安装生成器
	Yeoman提供了generator-generator方便快速编写自己的生成器。

	安装: npm install -g generator-generator
	运行: yo generator
	输入要自定义生成器的名字后会创建好生成器的架子

	2.安装自定义生成器
	创建好自定义生成器后将生成器开发目录安装到nodejs全局环境就可以使用了。
	例如：generator-demo
	cd generator-demo 目录后，npm link 将generator-demo软链接到全局，使用时在其它目录输入 yo demo。前提是已安装好Yeoman。

	3.定义生成器逻辑
	因为generator-demo已经跟开发目录软链接，写好代码后，可以直接在其它目录中使用yo demo 看效果


	//参考 [自定义Yeoman生成器](http://www.jscon.co/coding/frontend/yeoman_generator.html)
````


## 命令行开发常用的工具介绍

- [chalk](https://github.com/chalk/chalk)

- [minimist](https://github.com/substack/minimist) :parse argument options
- [colors](https://github.com/Marak/colors.js)
- [inquirer](https://github.com/SBoudrias/Inquirer.js)
- [opn](https://github.com/sindresorhus/opn) A better node-open. Opens stuff like websites, files, executables. Cross-platform.
- [readline-sync](https://github.com/anseki/readline-sync) Synchronous Readline for interactively running to have a conversation with the user via a console(TTY).
- [prompt](https://github.com/flatiron/prompt) a beautiful command-line prompt for node.js http://github.com/flatiron/prompt
- [yeoman-environment](https://github.com/yeoman/environment) Yeoman runtime environment
- [generator-generator](https://github.com/yeoman/generator-generator) Generate a Yeoman generator
- [mem-fs-editor](https://github.com/sboudrias/mem-fs-editor) File edition helpers working on top of mem-fs

````js
<!--
使用minimist打印出命令行参数：
var argv = require('minimist')(process.argv.slice(2));
console.log(">>>xy:",argv) 
-->

<!-- 输入  简单的总结一下， 没有-的是cmd，"-"的option "--"的是带参数的option -->
xy init --name liu --gender nan -i

<!-- 输出 -->
{ _: [ 'init' ], name: 'liu', gender: 'm', i: true }
````





