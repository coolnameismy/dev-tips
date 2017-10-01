# jq用法

jq is a lightweight and flexible command-line JSON processor [主页](https://stedolan.github.io/jq/)


## 安装

````
mac: brew install jq
ubuntu: sudo apt-get install jq
````

## 常用命令

- 原样输出                               `cat ./package.json | jq '.' `
- 查询key,value                         `cat package.json | jq '.single' `
- 查询key,value,数组元素                 `cat package.json | jq '.single[0]' `
- 过滤                                  `cat package.json| jq '.profile_image'`
- 查询元素个数                           `cat package.json | jq '.single|length'`
