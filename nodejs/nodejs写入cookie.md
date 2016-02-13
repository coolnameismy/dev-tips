
##  方法1：
>	response.writeHead 方法，写入Set-Cookie和值

````javascript
	res.writeHead(200,{
		'Content-type':'text/json',
		"Set-Cookie":['a=001', 'b=1112', 'c=2222']
	});
````

##  方法2：
>	response.setHeader 方法，写入Set-Cookie和值

````javascript
//例子1
 res.setHeader("Set-Cookie", ['a=001', 'b=1112', 'c=2222']);

 //例子2 设置过期时间
var today = new Date();
var time = today.getTime() + 60*1000;
var time2 = new Date(time);
var timeObj = time2.toGMTString();
 res.setHeader("Set-Cookie", ['d=001', 'e=1112', 'f=2222;Expires='+timeObj,]);
````

等价于：
````javascript
res.setHeader("Set-Cookie", "a=001;b=002;c=003");
````

##  说明

-	writeHead方法用过之后不能使用setHeader再次设置响应头
-	setHeader可以多次使用，但后一次会覆盖前一次的内容

## 设置cookie参数

###格式

单个

````
    Set-Cookie:
            cookieName=cookieValue;
            [expires=]
            [;domain=]
            [;path=]
            [;secure=]
            [;httpOnly=]
````

多个

````
    Set-Cookie:'[cookie1,cookie2];
            
````

 options字段含义: 

 ````
        1、expires：指定过期时间，以GMT格式表示的时间字符串，如方法一个的“timeObj”。 
        2、maxAge：指定过期时间，同expires（expires和maxAge选两者其一设值即可）。和expires不同之处在于，maxAge值的单位为毫秒（见方法二中的maxAge:10*1000，即为10秒）。maxAge值可以是正数和负数。正数表示当前COOKIE存活的时间。负数表示当前COOKIE只是随着浏览器存储在客户端的内存里，只要关闭浏览器，此COOKIE就马上消失。默认值为-1。 
        3、domain：指定可访问COOKIE的主机名。主机名是指同一个域名下的不同主机。如：www.google.com和gmail.google.com是在两个不同的主机上，即两个不同的主机名。默认情况下，一个主机中创建的COOKIE在另一个主机下是不能被访问，但可以通过domain参数来实现对其的控制，即所谓的跨子域。以google为例，要实现跨主机（跨子域）访问，写法如下：domain=.google.com，这样就实现了所有google.com下的主机都可以访问此COOKIE。（本机环境上设置此值时，COOKIE无法查看。）    
        4、path：指定可访问此COOKIE的目录。如：path=/default  表示当前COOKIE仅能在 default 目录下使用。默认值为“/”，即根目录下的所有目录皆可以访问。
        5、secure：当设为true时，表示创建的COOKIE会以安全的形式向服务器传输，即只能在HTTPS连接中被浏览器传递到服务器端进行会话验证；若是HTTP连接则不会传递该信息，所以不会被窃取到COOKIE里的具体内容。同理，在客户端，我们也无法使用document.cookie找到被设置了secure=true的cookie健值对。secure属性是防止信息在传递的过程中被监听捕获后信息泄漏，httpOnly属性的目的是防止程序获取COOKIE后进行攻击（XSS）。我们可以把secure=true看成比httpOnly=true是更严格的访问控制。 
        6、httpOnly：是微软对COOKIE做的扩展。如果在COOKIE中设置了“httpOnly”属性，则通过程序（JS脚本、applet等）将无法读取到COOKIE信息，防止XSS攻击产生。
````


