## 启动

在终端 js.jar 所在的目录下，执行 `java -jar js.jar`  进入，成功后可以看到 `js> ` 的开头表示符

## 载入js脚本调试


比如有个js文件叫做test.js和js.jar在同一目录下，文件内容：

````
//判断是否是质数
function isPrime (num)    
{    
    if (num <= 1) {    
        print("Please enter a positive integer >= 2.")    
        return false   
    }    
        
    var prime = true   
    var sqrRoot = Math.round(Math.sqrt(num))    
        
    for (var n = 2; prime & n <= sqrRoot; ++n) {    
        prime = (num % n != 0)    
    }    
        
    return prime    
}  
````

在js.jar中执行：

````
load("./test.js")
isPrime(77)   
//控制台显示 false
````


