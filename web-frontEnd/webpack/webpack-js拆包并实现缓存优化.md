webpack-js拆包并实现缓存优化



webpack.config.js

````js

var webpack = require('webpack');
var path = require('path');
var HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
  entry: {
    bundle:'./entry.js',
    vendor: 'lodash'
  },
  output: {
    filename: '[name].[chunkhash].js',
    //filename: '[name].js',
    path: path.resolve(__dirname, 'build')
  },
  module: {
    loaders: [
      {test: /\.css$/, loader: 'style-loader!css-loader'}
    ]
  }
  ,
  plugins: [
    new webpack.BannerPlugin('created by xuanyan@liuyanwei.com'),
    new webpack.optimize.CommonsChunkPlugin({
      names: ['vendor', 'webpackruntime'] // 指定公共 bundle 的名字
    }),
    new HtmlWebpackPlugin({
      title: 'demo',
      template: 'index.html' // 模板路径
    }),
  ]
}

````

enter.js

````js
import _ from 'lodash';


function enter () {
    var element = document.createElement('div');
    element.innerHTML = _.join(['Hello','webpack1'], ' ');
    document.body.appendChild(element);
}

enter();
````