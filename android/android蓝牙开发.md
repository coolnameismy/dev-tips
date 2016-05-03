##  需要了解的内容

###   android蓝牙开发需要知道的事情

-  Bluetooth4.0从 api18（Android4.3） 以上版本开始支持,支持中心模式,外设模式到api21以上才开始支持.
-  

###  android 蓝牙开发主要涉及到的类

-  BluetoothAdapter
-  BluetoothGatt
-  BluetoothProfile
-  BluetoothDevice
-  BluetoothSocket



###  BluetoothAdapter

BluetoothAdapter类的对象代表本地的蓝牙适配器,相当于iOS里面的CBCentralManager或CBPeripheralManager

主要作用：

-  发现其他蓝牙设备
-  查询已配对的设备
-  通过已知的MAC地址实例化远程蓝牙设备
-  创建BluetoothServerSocket类（下文2.4）对象监听与其他蓝牙设备的通信。

示例：

````java 
//声明一个BluetoothAdapter
// 初始化蓝牙适配器
final BluetoothManager bluetoothManager =
        (BluetoothManager) getSystemService(Context.BLUETOOTH_SERVICE);
mBluetoothAdapter = bluetoothManager.getAdapter();
````

###  BluetoothDevice
表示远程的蓝牙设备。使用该类对象可进行远程蓝牙设备的连接请求，以及查询该蓝牙设备的信息，例如名称，地址

###  BluetoothSocket，BluetoothServerSocket
BluetoothSocket :表示蓝牙socket的接口（与TCP Socket类似， 关于socket的概念请自行查阅计算机网络的相关内容）。该类的对象作为应用中数据传输的连接点
BluetoothServerSocket:表示服务器socket，用来监听未来的请求（和TCP ServerSocket类似）。为了能使两个蓝牙设备进行连接，一个设备必须使用该类开启服务器socket，当远程的蓝牙设备请求该服务端设备时，如果连接被接受，BluetoothServerSocket将会返回一个已连接的BluetoothSocket类对象。

###   BluetoothProfile
表示蓝牙规范



##  准备工作

1：声明蓝牙权限 
````
<uses-permission android:name="android.permission.BLUETOOTH"/>
<uses-permission android:name="android.permission.BLUETOOTH_ADMIN"/>

//仅仅支持BLE的Android设备上安装运行
<uses-feature android:name="android.hardware.bluetooth_le" android:required="true"/>
````

}
2:开启蓝牙

````java
 // 确保蓝牙在设备上可以开启，如果没开启提示用户设置开启蓝牙
if (mBluetoothAdapter == null || !mBluetoothAdapter.isEnabled()) {
   Intent enableBtIntent = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
   startActivityForResult(enableBtIntent, REQUEST_ENABLE_BT);
}
````


##  中心模式流程

###  扫描 
>  1：扫描使用startLeScan()方法，这个方法需要一个参数BluetoothAdapter.LeScanCallback。你必须实现它的回调函数，那就是返回的扫描结果,如果你只想扫描指定类型的外围设备，可以改为调用startLeScan(UUID[], BluetoothAdapter.LeScanCallback))

````java
/**
 * 扫描和显示可以提供的蓝牙设备.
 */
public class DeviceScanActivity extends ListActivity {

    private BluetoothAdapter mBluetoothAdapter;
    private boolean mScanning;
    private Handler mHandler;

    // 10秒后停止寻找.
    private static final long SCAN_PERIOD = 10000;
    ...
    private void scanLeDevice(final boolean enable) {
        if (enable) {
            // 经过预定扫描期后停止扫描
            mHandler.postDelayed(new Runnable() {
                @Override
                public void run() {
                    mScanning = false;
                    mBluetoothAdapter.stopLeScan(mLeScanCallback);
                }
            }, SCAN_PERIOD);

            mScanning = true;
            mBluetoothAdapter.startLeScan(mLeScanCallback);
        } else {
            mScanning = false;
            mBluetoothAdapter.stopLeScan(mLeScanCallback);
        }
        ...
    }
...
}
````


扫描的回调


````
private LeDeviceListAdapter mLeDeviceListAdapter;
...
// Device scan callback.
private BluetoothAdapter.LeScanCallback mLeScanCallback =
        new BluetoothAdapter.LeScanCallback() {
    @Override
    public void onLeScan(final BluetoothDevice device, int rssi,
            byte[] scanRecord) {
        runOnUiThread(new Runnable() {
           @Override
           public void run() {
               mLeDeviceListAdapter.addDevice(device);
               mLeDeviceListAdapter.notifyDataSetChanged();
           }
       });
   }

````

###  连接



##  其他蓝牙常用方法

````
<!-- 获取已配对的蓝牙设备 -->
Set<BluetoothDevice> pairedDevices = mBluetoothAdapter.getBondedDevices()
````

##  Android蓝牙开发常见的坑

1：startDiscovery() and startLeScan() 区别

startDiscovery()默认扫12描，**大部分手机**可以扫到经典蓝牙和ble蓝牙，而startLeScan只能扫到ble蓝牙。


http://ricardoli.com/2014/07/31/%E8%93%9D%E7%89%9940%E2%80%94%E2%80%94android-ble%E5%BC%80%E5%8F%91%E5%AE%98%E6%96%B9%E6%96%87%E6%A1%A3%E7%BF%BB%E8%AF%91/

http://www.jianshu.com/p/fc46c154eb77