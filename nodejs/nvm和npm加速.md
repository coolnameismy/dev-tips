

## nvm加速

````
//其他可选镜像 http://dist.u.qiniudn.com
export NVM_NODEJS_ORG_MIRROR=https://npm.taobao.org/mirrors/node

source ~/git/nvm/nvm.sh
````

添加到.bashrc或.bash_profile或.profile中


## npm加速

````
npm --registry=xxxxxx

//可选镜像
当前 registry.npm.taobao.org 是从 r.cnpmjs.org 进行全量同步的.
当前 npm.taobao.org 运行版本是: cnpmjs.org@2.6.1
本系统运行在 Node.js@v4.2.4 上.
开源镜像: http://npm.taobao.org/mirrors
Node.js 镜像: http://npm.taobao.org/mirrors/node
alinode 镜像: http://npm.taobao.org/mirrors/alinode
phantomjs 镜像: http://npm.taobao.org/mirrors/phantomjs
ChromeDriver 镜像: http://npm.taobao.org/mirrors/chromedriver
OperaDriver 镜像: http://npm.taobao.org/mirrors/operadriver
Selenium 镜像: http://npm.taobao.org/mirrors/selenium
Node.js 文档镜像: http://npm.taobao.org/mirrors/node/latest/docs/api/index.html
NPM 镜像: https://npm.taobao.org/mirrors/npm/
electron 镜像: https://npm.taobao.org/mirrors/electron/
node-inspector 镜像: https://npm.taobao.org/mirrors/node-inspector/
ttp  镜像：ttp://r.cnpmjs.org 
````

[cnpm](http://npm.taobao.org/)

````
$ npm install -g cnpm --registry=https://registry.npm.taobao.org

````

或者你直接通过添加 npm 参数 alias 一个新命令

````
alias cnpm="npm --registry=https://registry.npm.taobao.org \
--cache=$HOME/.npm/.cache/cnpm \
--disturl=https://npm.taobao.org/dist \
--userconfig=$HOME/.cnpmrc"

//Or alias it in .bashrc or .zshrc

$ echo '\n#alias for cnpm\nalias cnpm="npm --registry=https://registry.npm.taobao.org \
  --cache=$HOME/.npm/.cache/cnpm \
  --disturl=https://npm.taobao.org/dist \
  --userconfig=$HOME/.cnpmrc"' >> ~/.zshrc && source ~/.zshrc
````

