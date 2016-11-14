组合两个obj

var a = {"a":"a","b":"b"};
var a1 = {"a":"a1","c":"c"};

Object.assign(a,a1);
//  {a: "a1", b: "b", c: "c"}



## 默认值


var a = {"a":"a","b":"b"};
var a1 = {"a":"a1","c":"c"};
const DEFAULTS = {
  'd': 'd',
};
Object.assign(a,DEFAULTS,a1); 
// {a: "a1", b: "b", d: "d", c: "c"}

其他的使用 

作为opp继承对象：

``
var RecipesStore = assign({},EventEmitter.prototype,{
	...
});
	``