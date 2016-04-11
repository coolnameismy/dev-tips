##  1：使用pod引入react-native 依赖包

````
pod 'React', :path => '../node_modules/react-native', :subspecs => [
  'Core',
  'RCTImage',
  'RCTNetwork',
  'RCTText',
  'RCTWebSocket',
  # 添加其他你想在工程中使用的依赖。
]
````

使用本地路径速度更快一些


##  2：创建一个UIView的子类，实现从js生成界面

-  引入头文件 `#import "RCTRootView.h"`
-  加载js

````

- (instancetype)initWithFrame:(CGRect)frame {
    self = [super initWithFrame:frame];
    if (self) {
        NSURL * jsCodeLocation = [NSURL URLWithString:@"http://localhost:8081/src/index.bundle?platform=ios&framework=true"];
        RCTRootView * rootView = [[RCTRootView alloc] initWithBundleURL:jsCodeLocation
                                                             moduleName:@"index"
                                                      initialProperties:nil
                                                          launchOptions:nil];
        [self addSubview:rootView];
        rootView.frame = self.bounds;
    }
    
    return self;
}

````

注意路径和moduleName，moduleName一定要和rn中注册的bundle包名相似

##  3：引用界面

示例：
````objc
    ReactView * reactView = [[ReactView alloc] initWithFrame:CGRectMake(0, 40, CGRectGetWidth(self.view.bounds), 100)];
    [self.view addSubview:reactView];
````
