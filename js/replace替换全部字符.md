

例如：````	var str = "abcdaefabc";


使用 ````str.replace("a","xxx") ```` 只会把str中的第一个a替换为xxx, 若想替换str中全部的a，可以使用 

## 最近方法

````str.replace(/a/g,"xxx")````

原理是replace()的第一个参数可以传一个正则，『/』开始『/』结尾，g表示全部替换。

## 另一种方法

````
  var n = 0,str = "abcdaefabc";
  while (~(n = str.indexOf("a", n))) str = str.replace("a","xxx");
````