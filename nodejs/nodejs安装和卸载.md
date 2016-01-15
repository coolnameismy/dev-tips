## nodejs安装


nvm安装（推荐）

````
//mac 、linux
=
1：先安装一个 nvm（ https://github.com/creationix/nvm ） 当然也可以不装，不过装了的好处是便于nodejs版本切换
$ curl -o- https://raw.githubusercontent.com/creationix/nvm/v0.30.0/install.sh | bash

2：安装 nodejs
$ nvm install v4.2.4

//查看nvm里面nodejs版本
$ nvm ls

//切换nodejs版本
$ nvm use v4.2.4


//windows请访问主页下载安装
http://nodejs.cn/

````

手动安装


````
//下载pkg双击安装

 Node.js was installed at

   /usr/local/bin/node

npm was installed 

   /usr/local/bin/npm

Make sure that /usr/local/bin is in your $PATH.



##  nodejs卸载


````
npm ls -g --depth=0 #查看已经安装在全局的模块，以便删除这些全局模块后再按照不同的 node 版本重新进行全局安装

sudo rm -rf /usr/local/lib/node_modules #删除全局 node_modules 目录
sudo rm /usr/local/bin/node #删除 node
cd  /usr/local/bin && ls -l | grep "../lib/node_modules/" | awk '{print $9}'| xargs rm #删除全局 node 模块注册的软链

````
