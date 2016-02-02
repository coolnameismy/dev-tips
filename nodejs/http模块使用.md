````js
require("http").createServer(
	//中间件
	function(req,res){
		//打印request
		
		/*响应*/
		//写入头
		res.writeHead(200,{
			'Content-type':'text/json'
		});

		res.write('name');
		// res.write({
		// 	'name':'liuyanwei',
		// 	'age':30
		// });

		res.end();


	}).listen(8001);


````