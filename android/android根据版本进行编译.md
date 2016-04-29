android 根据版本进行编译

````java
     @TargetApi(18)
    BluetoothAdapter getBluetoothAdapter(){
        BluetoothAdapter adapter;
        if (Build.VERSION.SDK_INT > 16) {
            adapter = ((BluetoothManager)getSystemService(Context.BLUETOOTH_SERVICE)).getAdapter();
        }else {
            adapter = BluetoothAdapter.getDefaultAdapter();
        }
        return adapter;
    }

````