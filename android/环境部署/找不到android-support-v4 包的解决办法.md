有时候在开发过程中，总是会遇到一些莫名奇妙的错误，或者在使用fragement和viewpage的时候，就会出现下面这个错误，如果出现找不到android-support-v4 包的时候，可以使用下面的方法进行添加：

 

Project->properties->Java Build Path->Libraries->Add External Jars中加入sdk目录下的extras/android/support/v4/android-support-v4.jar

（如果找不到，则需要用sdk manager下载android support package）