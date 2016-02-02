>  curl是一个向服务器传输数据的工具，支持http、ftp、ftps、scp、sftp、tftp、telnet协议，它可以作为调试接口的利器

## http请求

curl默认是GET方法，使用-X参数可以支持其他动词

````
curl -X POST www.baidu.com
curl -X DELETE www.baidu.com
````

添加头

````		
curl --header "Content-Type:application/json" http://example.com
````

添加user agent

````		
curl --user-agent "[User Agent]" [URL]
````

post数据或get数据（get就是-X GET)

````		
curl -i -H "Accept: application/json" -X POST -d "firstName=james" http://192.168.0.165/persons/person
````
 

## 查看响应头
````
curl -I http://www.baidu.com
````

##  打开网页

````  curl http://www.baidu.com/ ````


##  保存网页

````  curl -o ./baidu.html http://www.baidu.com ````