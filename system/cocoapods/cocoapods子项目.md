cocoapods子项目

.podspec 文件设置

````
s.subspec 'Core' do |ss|
   ss.source_files     = "React/**/*.{c,h,m,S}"
   ss.exclude_files    = "**/__tests__/*", "IntegrationTests/*"
   ss.frameworks       = "JavaScriptCore"
 end
````

引用

````
  pod 'React/Core', :git => 'git@gitlab.xxx-inc.com:alinkrn/react-native.git', :branch => '0.19.2-ALI'

````