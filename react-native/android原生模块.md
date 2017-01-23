##  android端原生模块

### 创建类

` public class SmurfsRNBridgeModule extends ReactContextBaseJavaModule `

### 注册模块名称

````java
//SmurfsRNBridgeModule 中
@Override
public String getName() {
    return "SmurfsRNBridge";
}

````

### 注册方法

````java
@ReactMethod
public void hi(String message) {

    Log.d("smurfs","hi:"+message);
}

````


### 数据下行

````java
    //定义方法
    private void sendEvent(String eventName, @Nullable WritableMap params) {
        ReactContext context = getReactApplicationContext();
        if (null == context) {return;}
        context.getJSModule(DeviceEventManagerModule.RCTDeviceEventEmitter.class)
                .emit(eventName, params);
    }

    //调用
    WritableMap params = Arguments.createMap();
    params.putString("a","aaa");
    sendEvent("SmurfsRNBridgeModule",params);

````




````java
//SmurfsRNBridgeModule 中
@Override
public String getName() {
    return "SmurfsRNBridge";
}

````

## demo

````java
package com.aliyun.alink.auikit.rn.rnpackage.nativemodules;

import android.support.annotation.Nullable;
import android.util.Log;

import com.facebook.react.bridge.Arguments;
import com.facebook.react.bridge.ReactApplicationContext;
import com.facebook.react.bridge.ReactContext;
import com.facebook.react.bridge.ReactContextBaseJavaModule;
import com.facebook.react.bridge.ReactMethod;
import com.facebook.react.bridge.ReadableArray;
import com.facebook.react.bridge.ReadableMap;
import com.facebook.react.bridge.ReadableMapKeySetIterator;
import com.facebook.react.bridge.ReadableType;
import com.facebook.react.bridge.WritableArray;
import com.facebook.react.bridge.WritableMap;
import com.facebook.react.modules.core.DeviceEventManagerModule;

import java.util.Dictionary;
import java.util.HashMap;
import java.util.Hashtable;

/**
 * Created by xuanyan.lyw 刘彦玮（玄彦） on 2017/1/9.
 */
public class SmurfsRNBridgeModule extends ReactContextBaseJavaModule {

//    private final ReactApplicationContext mRNContext;

    public SmurfsRNBridgeModule(ReactApplicationContext reactContext) {
        super(reactContext);
//        this.mRNContext = reactContext;
    }

    @Override
    public String getName() {
        return "SmurfsRNBridge";
    }

    @ReactMethod
    public void hi(String message) {

        Log.d("smurfs","hi:"+message);

        //测试下行数据
        WritableMap params = Arguments.createMap();
        params.putString("a","aaa");
        sendEvent("SmurfsRNBridgeModule",params);
    }

    private void sendEvent(String eventName, @Nullable WritableMap params) {
        ReactContext context = getReactApplicationContext();
        if (null == context) {return;}
        context.getJSModule(DeviceEventManagerModule.RCTDeviceEventEmitter.class)
                .emit(eventName, params);
    }
}
````
