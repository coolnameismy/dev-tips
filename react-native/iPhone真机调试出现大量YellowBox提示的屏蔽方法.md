iPhone 真机调试出现大量 YellowBox 提示的屏蔽方法

修改方法：

````
//注：这个 bug 在0.22 上好像已经消失了，所以作废
React/Modules/RCTTiming.m 第 178 行，将 if (jsSchedulingOverhead < -0) 改为 if (jsSchedulingOverhead < -5)
其实这个数字可以随便整
````

![](https://cloud.githubusercontent.com/assets/3316532/12423267/a30f6b3a-be98-11e5-8579-a8694ad5d2db.png)


- http://bbs.reactnative.cn/topic/747/%E9%A1%B9%E7%9B%AE%E4%B8%AD%E9%81%87%E5%88%B0%E8%BF%87%E7%9A%84%E9%82%A3%E4%BA%9B%E5%9D%91-%E4%B8%8D%E5%AE%9A%E6%9C%9F%E6%9B%B4%E6%96%B0
- https://github.com/facebook/react-native/issues/1598#issuecomment-172890857
