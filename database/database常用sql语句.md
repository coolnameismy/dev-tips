## 建表：

````sql
// 关键字：varchar(20)，int(11) NOT NULL AUTO_INCREMENT date PRIMARY KEY (`id`) DEFAULT '0' ENGINE=MyISAM ENGINE=innodb
CREATE DATABASE `test1` 
CHARSET SET 'utf8 ' 
COLLATE 'utf8_general_ci'; 

DROP TABLE IF EXISTS `tb_words`;  
CREATE TABLE `tb_words` (  
  `id` int(11) NOT NULL AUTO_INCREMENT,  
  `name` varchar(200) NOT NULL,  
  `image` varchar(200),  
  `tips` varchar(200),  
  `categoryId`  int(11) DEFAULT '0',  
   
  PRIMARY KEY (`id`)  
)DEFAULT CHARSET=utf8;  

//user 表
DROP TABLE IF EXISTS `tb_user`;  
CREATE TABLE `tb_user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,  
  `userId` varchar(50) NOT NULL,  
  `pwd` varchar(50) NOT NULL,  
  `name` varchar(20) NOT NULL,  
  `headPortait` varchar(200) ,  
  `isEnable`  int(11),  
  `createDate`  date,  
  `lastLogin` date,
  PRIMARY KEY (`id`)  
)DEFAULT CHARSET=utf8;  

````
## 查询


## 插入
````sql
insert into tb_words (name,image,tips,categoryId) values('test1','test1.jpg','这个测试记录',1);
insert into tb_words (name,image,tips,categoryId) values('test2','test2.jpg','这个测试记录',2);
insert into tb_words (name,image,tips,categoryId) values('test3','test3.jpg','这个测试记录',3);
insert into tb_words (name,image,tips,categoryId) values('test4','test4.jpg','这个测试记录',4);
insert into tb_words (name,image,tips,categoryId) values('test5','test5.jpg','这个测试记录',5);
insert into tb_words (name,image,tips,categoryId) values('test6','test6.jpg','这个测试记录',6);
insert into tb_words (name,image,tips,categoryId) values('test7','test7.jpg','这个测试记录',7);
insert into tb_words (name,image,tips,categoryId) values('test8','test8.jpg','这个测试记录',8);
insert into tb_words (name,image,tips,categoryId) values('test9','test9.jpg','这个测试记录',9);
insert into tb_words (name,image,tips,categoryId) values('test10','test10.jpg','这个测试记录',10);
insert into tb_words (name,image,tips,categoryId) values('test11','test1.1jpg','这个测试记录',11);
insert into tb_words (name,image,tips,categoryId) values('test12','test1.j2pg','这个测试记录',12);
insert into tb_words (name,image,tips,categoryId) values('test13','test1.jp3g','这个测试记录',13);

````

## 设置字符集合

````sql
//查看所有支持的字符集  show charset;
//显示系统字符集设置 show variables like '%char%';

set character_set_client=utf8;
set character_set_connection=utf8;
set character_set_database=utf8;
set character_set_results=utf8;
set character_set_server=utf8;
set character_set_system=utf8;
set collation_connection=utf8;
set collation_database=utf8;
set collation_server=utf8;
set character_set_filesystem=utf8;
alter database memorytrain character set utf8
alter database memorytrain default character set 'charset'；

````

## 查看结构

````sql
查看数据库编码：
SHOW CREATE DATABASE db_name;
查看表编码：
SHOW CREATE TABLE tbl_name;
查看字段编码：
SHOW FULL COLUMNS FROM tbl_name;
````


