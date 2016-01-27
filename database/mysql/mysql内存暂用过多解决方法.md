## mysql 内存暂用过多解决方法

安装mysql的时候，选的是server模式，会配置mysql占用比较多的内容，所以需要修改一下。

###  1：打开my.ini 文件

my.ini文件位置：C:\Documents and Settings\All Users\Application Data\MySQL\MySQL Server 5.6


### 在my.ini中找到并修改下面两行
````
table_definition_cache=400
table_open_cache=256
````