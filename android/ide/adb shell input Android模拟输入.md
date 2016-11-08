adb shell input（Android模拟输入）


## 命令说明
````
  Usage: input [<source>] <command> [<arg>...]

  The sources are:
        trackball
        joystick
        touchnavigation
        mouse
        keyboard
        gamepad
        touchpad
        dpad
        stylus
        touchscreen

  The commands and default sources are:
        text <string> (Default: touchscreen)
        keyevent [--longpress] <key code number or name> ... (Default: keyboard)
        tap <x> <y> (Default: touchscreen)
        swipe <x1> <y1> <x2> <y2> [duration(ms)] (Default: touchscreen)
        press (Default: trackball)
        roll <dx> <dy> (Default: trackball)

//输入命令中text 和 keyevent是通用的；tap和swipe适用于触摸屏；而press和roll用于有触摸球的设备，由于使用的很少，因此不做说明。
````

例如:

````
adb shell input text "hello,world" 
adb shell input keyevent 67
adb shell input swipe 0 20 300 500 #意思从屏幕(0,20)滑动到(300,500)
adb shell input tap 100 400 #轻触
````


按键键码	| 功能 | 对应Android定义KeyEvent
1	| 按menu键	| KEYCODE_MENU
3	| 按home键	| KEYCODE_HOME
4	| 按back键	| KEYCODE_BACK
21	| 光标左移	| KEYCODE_DPAD_LEFT
22	| 光标右移	| KEYCODE_DPAD_RIGHT
67	| 按删除按钮	| KEYCODE_DEL

[完整按键键码查询](http://developer.android.com/reference/android/view/KeyEvent.html)

[参考](http://blog.bihe0832.com/review_adb.html)

