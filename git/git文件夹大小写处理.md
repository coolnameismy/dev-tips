处理办法：


git mv --force myfile MyFile
或者

git mv -f myfile MyFile
然后commit就好了。当然也可以配置一下git：

Add ignorecase = false to [core] in .git/config;