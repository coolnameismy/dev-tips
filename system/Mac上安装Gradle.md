##  step1：下载
[下载地址](http://services.gradle.org/distributions)

## step2：解压
下载完解压到任意目录，我解压在/usr/local/下。

## step3：配置环境变量

在命令行运行以下命令

```` vim ~/.bash_profile````

添加以下内容

````
GRADLE_HOME=/usr/local/gradle-2.5;
export GRADLE_HOME
export PATH=$PATH:$GRADLE_HOME/bin
````

gradle -version

 