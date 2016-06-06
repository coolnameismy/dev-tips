# java反射使用

##  反射调用私有方法

````java
//带参数的
device.getClass().getMethod("setPairingConfirmation", void.class).invoke(device, true);
//不带参数的
device.getClass().getMethod("removeBond").invoke(device);

//原方法
public boolean setPairingConfirmation(boolean confirm);
public boolean removeBond();
````


