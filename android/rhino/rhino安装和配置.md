rhino安装和配置


##  安装

从[官网](http://www.mozilla.org/rhino/)下载js.jar ,并导入libs目录

## 初始化和设置

大体上分为获取对象，设置对象，退出context，如下

````
Context rhino = Context.enter();//获取对象
rhino.setOptimizationLevel(-1);//rhino兼容Android
rhino.setLanguageVersion(rhino.VERSION_1_6);//设置js版本

try {
	//获取scope对象
    Scriptable scope = rhino.initStandardObjects();
	
	//开始执行js和Native交互代码。。。。。    
	//。。。。。。。
	//。。。。。。。
}
catch (Exception e){
    Log.e("rhino",e.toString());
}
finally {
    Context.exit();
}

````