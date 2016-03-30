#  gem的使用


````
# 更新Gem自身  
# 注意：在某些linux发行版中为了系统稳定性此命令禁止执行  
$ gem update --system  
  
# 从Gem源安装gem包  
$ gem install [gemname]  
 
# 从本机安装gem包  
$ gem install -l [gemname].gem  
  
# 安装指定版本的gem包  
$ gem install [gemname] --version=[ver]  
$ gem install [gemname] -v=[ver]  


# 更新所有已安装的gem包  
$ gem update  
  
# 更新指定的gem包  
# 注意：gem update [gemname]不会升级旧版本的包，此时你可以使用 gem install [gemname] --version=[ver]代替  
$ gem update [gemname]  
  
# 删除指定的gem包，注意此命令将删除所有已安装的版本  
$ gem uninstall [gemname]  
  
# 删除某指定版本gem  
$ gem uninstall [gemname] --version=[ver]  
  
# 查看本机已安装的所有gem包  
$ gem list [--local]  

````