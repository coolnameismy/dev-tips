#  扫描和连接

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

###  api21 以下扫描和停止扫描

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


停止扫描

````
 adapter.stopLeScan(scanCallback);
````

 ###  api21 以上扫描和停止扫描

 扫描

````java
 if (Build.VERSION.SDK_INT > 21){
            BluetoothLeScanner scanner = adapter.getBluetoothLeScanner();
            //setting可以设置扫描的参数，入过滤规则，扫描ble还是所有蓝牙等等
            scannerSettings = new ScanSettings.Builder().setScanMode(ScanSettings.SCAN_MODE_LOW_POWER).build();
            
            this.scannerCallback = new ScanCallback() {
                @Override
                public void onScanResult(int callbackType, ScanResult result) {
                    super.onScanResult(callbackType, result);
                    if (Build.VERSION.SDK_INT > 21){
                        //可以看到resullt中的对象
                        onScan(result.getDevice(),result.getRssi(),result.getScanRecord().getBytes());
                    }
                }
                @Override
                public void onBatchScanResults(List<ScanResult> results) {
                    super.onBatchScanResults(results);
                }

                @Override
                public void onScanFailed(int errorCode) {
                    super.onScanFailed(errorCode);
                    Log.e(TAG,"api21+ 启动扫描失败");
                }
            };

            scanner.startScan(null,scannerSettings,scannerCallback);
        }

````


停止

````java
BluetoothLeScanner scanner = adapter.getBluetoothLeScanner();
scanner.stopScan(scannerCallback);
````




