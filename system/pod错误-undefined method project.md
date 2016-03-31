## 错误描述
>  cocoapod 版本大于0.38时 pod instal和 pod update会报错 `undefined method `project' for #<Pod::Installer:0x007ff1ac8fe300>`

````
Generating Pods project
[!] An error occurred while processing the post-install hook of the Podfile.

undefined method `project' for #<Pod::Installer:0x007ff1ac8fe300>
````

##  错误原因

以为cocoapood 0.39更新了一个功能，把project对象改成了pods_project，详细描述参考cocoapod github上的issue [issue3747 点击](https://github.com/CocoaPods/CocoaPods/issues/3747)

##  解决办法：

判断一下对象project和pods_project对象是否存在分别处理。

把原代码 
````
post_install do |installer|
    installer.project.targets.each do |target|
        target.build_configurations.each do |config|
            config.build_settings['ARCHS'] = "arm64 armv7"
            if config.name != 'Release'
                config.build_settings['GCC_PREPROCESSOR_DEFINITIONS'] ||= ['$(inherited)', 'DEBUG=1']
                config.build_settings['GCC_OPTIMIZATION_LEVEL'] = '0'
            end
        end
    end
end

````


改成

````
if defined? installer_representation.project
  post_install do |installer|
      installer.project.targets.each do |target|
          target.build_configurations.each do |config|
              config.build_settings['ARCHS'] = "arm64 armv7"
              if config.name != 'Release'
                  config.build_settings['GCC_PREPROCESSOR_DEFINITIONS'] ||= ['$(inherited)', 'DEBUG=1']
                  config.build_settings['GCC_OPTIMIZATION_LEVEL'] = '0'
              end
          end
      end
  end
end

if defined? installer_representation.pods_project
  post_install do |installer|
      installer.pods_project.targets.each do |target|
          target.build_configurations.each do |config|
              config.build_settings['ARCHS'] = "arm64 armv7"
              if config.name != 'Release'
                  config.build_settings['GCC_PREPROCESSOR_DEFINITIONS'] ||= ['$(inherited)', 'DEBUG=1']
                  config.build_settings['GCC_OPTIMIZATION_LEVEL'] = '0'
              end
          end
      end
  end
end
````