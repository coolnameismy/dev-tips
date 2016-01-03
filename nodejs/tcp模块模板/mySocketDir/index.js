require('events')



//测试
hello = function()
{ 

	console.log("Hello node.js!");
}

//处理接受的数据
reviceDataHandler = function(data,socket)
{
	 //console.log(data.toString());
	 console.log(data);
	 socket.write(data);
	 if(data.trim().toLowerCase()==='quit')
	 {
	 	socket.write("bye bye");
	 	return socket.end();
	 }
	 
}

//配置
var code = "utf-8";//字符集
var timeout = 60000;//空闲下线时间
var port = 4001;//监听端口号



var server = require('net').createServer(function(socket){

	//初始化
	socket.setEncoding(code);//字符集
	socket.setTimeout(timeout);//空闲下线时间
	 

	 
	//接受数据
	socket.on('data',function(data){
		 reviceDataHandler(data,socket)
	})
	//关闭连接
	socket.on('end',function(){
		console.log("关闭连接","utf-8");
		
	})
	
	
	//连接超时
	socket.on('timeout',function()
	{
		socket.write("connection is time out !!");
		socket.end();
	})


	//信息
	//socket.write('connection sueess');
	console.log("connection sueess");

}).listen(port);



//server新连接
server.on('connection',function(socket){
    console.log("server has new connection");
})
//server 监听
server.on('listening',function(){
    console.log("server is listening on ",port);
})
//关闭服务
server.on('close',function(){
    console.log("server is close");
})
//server 错误
server.on('error',function(error){
	console.log("connection sueess");
	console.log("error on :",error.message);
})
 
//输出
exports.hello = hello; 