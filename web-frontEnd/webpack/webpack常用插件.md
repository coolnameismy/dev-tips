

## BannerPlugin
> 实现编译后的文件签名

````js
 plugins: [
    new webpack.BannerPlugin('T111his fisssle is created by xuanyan@liuyanwei.com')
  ]
````

## ExtractTextPlugin 
>  css文件拆包


##  CommonsChunkPlugin
>  用于打包多个插件,可以配合html-webpack-plugin使用，自动引入带hash值的脚本

- [使用参考](https://doc.webpack-china.org/guides/code-splitting-libraries/)

## json-loader

````
//安装 
npm install --save-dev json-loader

//配置    use OR loader
 rules: [
      {
        test: /\.json$/,
        use: 'json-loader'
      }
    ]

````


##  html-webpack-plugin
> html替换

````js
var HtmlWebpackPlugin = require('html-webpack-plugin');
plugins: [
    new HtmlWebpackPlugin({
                  title: 'demo',
                  template: 'index.html' // 模板路径
              }),
  ]
````

##  HotModuleReplacementPlugin实现热更新HMR
>  详细参考目录中另一篇文章


