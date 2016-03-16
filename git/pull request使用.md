##  发起pull request

-	1：本地fork分支
-	2：修改，发起pull request
-	3：等待repo主merge或reject


##  接受pull request


-	1：找到pull request的commit id，例如abcdefg
-	2：下载对方pull request的代码放入新建分支new  ````git checkout 5b4d575dd66974a8eb6b84f13647e1ea3219898f -b new````
-	3：检查修改并合并到master分支，再提交的版本库
-	4:在提交信息中使用fix,fixes,fixed，close等关键字关闭issue和pr

````
git commit -m "Fix screwup, fixes #12"
````

## fork出来的分支更新主分支上最新代码

````
 git remote add upstream git@10.45.7.208:ZSmartCity-CC-WEB/ccs.git
 git pull upstream xxx

````


##  参考

http://blog.jobbole.com/76854/