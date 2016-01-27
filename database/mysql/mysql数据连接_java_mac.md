##  1：下载mysql jar包，推荐使用maven
````xml
 <dependency> 
  <groupId>mysql</groupId> 
  <artifactId>mysql-connector-java</artifactId> 
  <version>5.1.9</version> 
</dependency>
````
## 2:配置mysql中文环境 utf8字符集

````
show variables like '%char%';
关闭mysql服务
cp /usr/local/mysql/support-files/my-medium.cnf /etc/my.cnf
vi /etc/my.cnf
[mysqld]和[client]两个标签下都加入 default_character_set = utf8
启动mysql服务
````