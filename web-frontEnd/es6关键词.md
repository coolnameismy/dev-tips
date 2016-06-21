

##  简单关键词

- let  1:定义常量，等同swift的let 2:暂时性死区 3:禁止重复声明 4：不能未定义使用
- const ：定义常量
- Destructuring:
     var [a, b, c] = [1, 2, 3]; let [foo, [[bar], baz]] = [1, [[2], 3]];
     var [foo = true] = [];//指定默认值
     var { foo, bar } = { foo: "aaa", bar: "bbb" }; //适用于数组和对象 ,按变量赋值
     var { foo: baz } = { foo: "aaa", bar: "bbb" }; //按名称赋值
    //字符串的解构赋值：
    const [a, b, c, d, e] = 'hello';
    let {length : len} = 'hello';
- Destructuring 用途
    [x, y] = [y, x]; //交换变量的值
    var { foo, bar } = example(); //从函数返回多个值
    提取JSON数据
    函数参数的默认值
    输入模块的指定方法 //const { SourceMapConsumer, SourceNode } = require("source-map");


## ES6新增方法

字符串扩展

- includes(), startsWith(), endsWith()