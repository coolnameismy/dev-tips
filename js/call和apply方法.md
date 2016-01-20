call,apply方法主要有两个作用

-	继承一个类
-	调用一个对象的一个方法，以另一个对象替换当前对象。


##	继承一个类的方法
````javascript
function class2() {class1.call(this);//要想实现class2继承class1 this就是当前对象class2。}
````

##	调用一个对象的一个方法，以另一个对象替换当前对象。

js例子:在A类中调用B类数据

````javascript
function Class(){
    this.name = 'Class';
    this.getName = function(){
        alert( this.name );
    }
}
function ClassA(){
    this.name = 'ClassA';
}
var obj = new Class();
obj.getName.call(ClassA); //调用obj对象的getName方法,以ClassA对象替换当前obj对象,所以class对象中的this指向的ClassA对象.
````

apply方法和call方法作用相同，不同的只是他们的参数 

例如 ：
````	a.call(b,2,3); ==>  a.apply(b,[2,3]) ````