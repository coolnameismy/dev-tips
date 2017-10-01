 
##  添加submoudle

```` git submodule add http://github.com/xxx/xxx/xxx ````


##  初始化，更新或下载

````

    git submodule init
    git submodule update

   //更新
    git submodule foreach git pull
    
    //遍历更新和下载
    git submodule foreach git submodule init
    git submodule foreach git submodule update



````