NetInfo使用


## 引入

````js
var {
  ...
  NetInfo,
} = React;
````

## 监听网络变化

````js
    NetInfo.isConnected.addEventListener(
      'change',
       () => {}
    );
    //移除
	NetInfo.isConnected.removeEventListener(
	'change',
	this._handleConnectivityChange
	);
````


## 获取网络状态

````js
NetInfo.fetch().done((reach) => {
  console.log('Initial: ' + reach);
});
````

[更多](http://reactnative.cn/docs/0.35/netinfo.html#content)