##  jdk安装

官网下载和安装


##  配置java jdk和切换


````


# 设置 JDK 7
# export JAVA_7_HOME=$(/usr/libexec/java_home -v 1.7)
# 设置 JDK 8
# export JAVA_8_HOME=$(/usr/libexec/java_home -v 1.8)

# jdk7和8可以切换，注意等号后面不能有空格
export JAVA_HOME=$JAVA_7_HOME

````

##  其他常见配置


````
#  maven
export M2_HOME=/Users/xuanyan.lyw/evnapp/maven3.2.5
export PATH=$PATH:$M2_HOME/bin
# export JAVA_HOME=$(/usr/libexec/java_home)

export ANDROID_HOME=/usr/local/opt/android-sdk

````
