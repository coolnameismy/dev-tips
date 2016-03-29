
## 配置用户信息

````
git config --global user.name coolnameismy
git config --global user.email coolnameismy@hotmail.com
git config --global core.editor vim
````

## 配置alias

````
$ git config --global alias.st status
$ git config --global alias.ci commit
$ git config --global alias.co checkout
$ git config --global alias.br branch
$ git config --global alias.ps push
$ git config --global alias.pl pull
$ git config --global alias.unstage 'reset HEAD'   # 表示拉回的未暂存
$ git config --global alias.last 'log -1'           # 表示查看最后一次提交历史

//下面表示智能个性化log查看
$ git config --global alias.lg "log --color --graph --pretty=format:'%Cred%h%Creset -%C(yellow)%d%Creset %s %Cgreen(%cr) %C(bold blue)<%an>%Creset' --abbrev-commit"

````

上面的是针对当前用户的，如果设置 --system 则表示整个系统通用。或者你可以这样：

````
$ git config -e                #打开当前配置
$ git config -e --global    #打开全局配置
$ git config -e --system        #打开系统配置
````


##  github ssh配置

-	1:进入.ssh目录（或创建一个） ```` cd ~/.ssh ````，生成ssh证书  ```` ssh-keygen -t rsa -C coolnameismy@youremail.com  ````

-	2:在github网站 https://github.com/settings/ssh 设置ssh证书 
-	3：检查,配置完成后，可以检查是否配置成：如下列举Github的：

````
$ ssh -T git@github.com
Hi BeginMan! You've successfully authenticated, but GitHub does not provide shel
l access.
如果它Hi了你，就说用户信息配置成功了。
````
 

