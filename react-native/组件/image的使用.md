##  image获取控件获取加载图片

###  加载图片

本地图片： 

````
<Image style={styles.decoratior1} source={require('../res/dashed-line@3x.png')} />
````
网络图片

````
<Image style={styles.cellbg} source={{uri:'https://img.alicdn.com/tps/TB1SLRwMpXXXXaqXFXXXXXXXXXX-384-165.png'}} />
````

###  拉伸

-  cover:等比拉伸
-  strech:保持原有大小 
-  contain:图片拉伸  充满空间