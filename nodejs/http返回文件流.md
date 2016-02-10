  ````javaScript
    //下载返回文件流
	function download(req,res){
		//写入头
	    var downloadFilePath = "./1.jpg";
	    var filename = path.basename(downloadFilePath);
	    var filesize = fs.readFileSync(downloadFilePath).length;
	    res.setHeader('Content-Disposition','attachment;filename=' + filename);//此处是关键
	    res.setHeader('Content-Length',filesize);
	    res.setHeader('Content-Type','application/octet-stream');
	    var fileStream = fs.createReadStream(downloadFilePath,{bufferSize:1024 * 1024});
		 fileStream.pipe(res,{end:true});
		// res.writeHead(200, {'content-type': 'text/html'});
	}
````