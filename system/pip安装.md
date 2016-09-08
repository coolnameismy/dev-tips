pip安装和使用

> 主页：https://pip.pypa.io/en/latest/installing/#id7
> 需要有Python环境



- 下载： 
wget https://bootstrap.pypa.io/get-pip.py

- 安装 
python get-pip.py 

方法2 sudo easy_install pip （经常因为文件下载超时而失败）

- 配置（文件路径 '~/.pip/pip.conf'）
````
[global]
timeout = 6000 
index-url=http://mirrors.tuna.tsinghua.edu.cn/pypi/simple
````

