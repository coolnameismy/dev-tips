## git提交基线管理技巧

一般来说，一个repo可以建立几个主代码分支

-  master作为主分支，上面的代码用于发布
-  dev分支作为开发分支
-  feature-xxx 作为功能分支


说一下原则: core review时候看log 可以更加的清晰，为了达到这个目录，我们需要去掉讨厌的merge commit message ，例如 `Merge branch 'aaa' of git.xxx.xxx/xxx/xxx into aaa` ,另外，在开发功能分支的时候可以看到分支合并的线，这样我们可以清晰的明白，哪一系类的commit是为了做哪个功能。

再来简单粗暴的直接说一下如何做到

-  git pull --rebase origin xxx
-  git merge --no-ff xxx

第一条可以去掉merge commit message，保证提交线是一条直线
第二条可以保证每次分支merge的时候提交线会出现一个分支合并线

要弄清楚原因，大家可以先去弄明白什么是fast forward，和merge与rebase的区别和作用，我这里简单的描述一下，更多内容可以看最后的参考文章。

rebase：简单的说，就是先砍掉 local branch 分叉点之后自己的 commit，然后把远端的 commit 先一个个 apply 进來，最后再把自己的 commit 再 apply 进去 (如果有 conflict 会中途停下來，等你修好才会继续 apply)，如此一來提交线就会变成一条线而已，也就没有merge commit message 了

fast-forward： 在 Git 是一種 merge 術語，當 B branch (例如一個 local branch) 是從 A branch (例如一個 remote branch) 的最新版(HEAD)分支出來的，那當 A 要把 B merge 進來時，因為 B 的 parent commit 是 A 的 HEAD，所以這兩個 branch 唯一的差異就是 B 後來的 commit 而已，而不會有任何 conflict。所以實際上的動作只要把 A 的 HEAD 改成 B 的 HEAD 就好了，線圖上這兩個 branch 根本是同一條線，此謂 fast-forward。

git pull --rebase origin xxx 会让分支在不是fast-forward的情况，也不会产生merge commit message，而git merge --no-ff xxx会使及时是fast-forward的情况，也会产生一条merge图，而不会提交基线不会成为一个条直线，在代码review时候更清晰。

所以，使用 git pull --rebase 主要是为是将提交约线图平坦化，而 git merge --no-ff 则是刻意制造分叉。

![](http://ww1.sinaimg.cn/large/a74eed94jw1dvnhyrq8rhj.jpg)


-  [Git 版本控制系統(2) 開 branch 分支和操作遠端 repo.](https://ihower.tw/blog/archives/2620)
-  [洁癖者用 Git：pull --rebase 和 merge --no-ff](http://hungyuhei.github.io/2012/08/07/better-git-commit-graph-using-pull---rebase-and-merge---no-ff)