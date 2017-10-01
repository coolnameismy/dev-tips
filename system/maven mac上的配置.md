maven mac上的配置

- 下载maven 并解压文件
到[Maven官网](https://maven.apache.org/download.cgi)下载安装包，选择下载Binary zip archive
例如，解压到：/Users/xuanyan.lyw/evnapp/maven3.2.5 路径

- 设置Maven环境变量

vim ~/.bash_profile 编辑配置

````
# maven
export M2_HOME=/Users/xuanyan.lyw/evnapp/maven3.2.5
export PATH=$PATH:$M2_HOME/bin
export JAVA_HOME=$(/usr/libexec/java_home)
````

完成
