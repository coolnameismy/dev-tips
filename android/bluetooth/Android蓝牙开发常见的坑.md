##  Android蓝牙开发常见的坑

1：startDiscovery() and startLeScan() 区别

startDiscovery()默认扫12描，**大部分手机**可以扫到经典蓝牙和ble蓝牙，而startLeScan只能扫到ble蓝牙。


http://ricardoli.com/2014/07/31/%E8%93%9D%E7%89%9940%E2%80%94%E2%80%94android-ble%E5%BC%80%E5%8F%91%E5%AE%98%E6%96%B9%E6%96%87%E6%A1%A3%E7%BF%BB%E8%AF%91/

http://www.jianshu.com/p/fc46c154eb77