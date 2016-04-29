## android studio log使用和调色

-  1：打开 File>Settings 或mac上的 Android studio偏好设置
-  2：选择 Editor -> Colors &Fonts -> Android Logcat 
-  3：点中Verbose , Info, Debug等选项，然后在后面将Use Inberited attributes 去掉勾选
-  4：再将 Foreground 前的复选框选上，就可以双击后面的框框去选择颜色了
-  5: Apply–>OK

## 颜色对应色值

````
VERBOSE BBBBBB
DEBUG   0070BB
INFO    48BB31
WARN    BBBB23
ERROR   FF0006
ASSERT  8F0005
````



Log.v() Log.d() Log.i() Log.w() Log.e() Log.a() 对应 
VERBOSE，DEBUG,INFO, WARN，ERROR。ASSERT