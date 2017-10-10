## webpack设置host后显示Invalid Host header解决办法



参考issue：https://github.com/webpack/webpack-dev-server/issues/882

解决方法：

behind proxy you can use the disableHostCheck: true flag.

