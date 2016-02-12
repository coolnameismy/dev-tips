需要安装2个node包，分别是formidable和node-uuid
formidable主要处理文件上传，node-uuid处理重命名


````javaScript
var formidable = require('formidable');
var uuid = require('node-uuid');

//文件上传
	function upload(req,res){
		//创建上传表单
		var form = new formidable.IncomingForm();
		//设置编辑
		form.encoding = 'utf-8';
		//设置上传目录
		form.uploadDir = './upload/';
		form.keepExtensions = true;
		//文件大小
		form.maxFieldsSize = 10 * 1024 * 1024;
		form.parse(req, function (err, fields, files) {
			if(err) {
				res.send(err);
				return;
			}
			console.log(fields);
			// console.log("=====");
			// console.log(files.file.name);
			var extName = /\.[^\.]+/.exec(files.file.name);
			var ext = Array.isArray(extName)
				? extName[0]
				: '';
			//重命名，以防文件重复
			var avatarName = uuid() + ext;
			//移动的文件目录
			var newPath = form.uploadDir + avatarName;
			fs.renameSync(files.file.path, newPath);
			// res.send('success');
			res.write('success');
			res.end();
		});
	}

````