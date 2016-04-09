## fetch快速示例

` fetch(url,<request>) ` ：参数：路径，请求 ,返回值是Promise对象

示例：

````JavaScript
fetch('https://mywebsite.com/endpoint/', {
  method: 'POST',
  headers: {
    'Accept': 'application/json',
    'Content-Type': 'application/json',
  },
  body: JSON.stringify({
    firstParam: 'yourValue',
    secondParam: 'yourOtherValue',
  })
})
````

````JavaScript
fetch('https://mywebsite.com/endpoint.php')
  .then((response) => response.text())
  .then((responseText) => {
    console.log(responseText);
  })
  .catch((error) => {
    console.warn(error);
  });
````

同步异步，例如使用ES7的async/await语法来发起一个异步调用

````JavaScript
async getUsersFromApi() {
  try {
    let response = await fetch('https://mywebsite.com/endpoint/');
    return response.users;
  } catch(error) {
    throw error;
  }
}
````

##  请求request

-  method - GET, POST, PUT, DELETE, HEAD
-  url - URL of the request
-  headers - associated Headers object
-  referrer - referrer of the request
-  mode - cors, no-cors, same-origin
-  credentials - should cookies go with the request? omit, same-origin
-  redirect - follow, error, manual
-  integrity - subresource integrity value
-  cache - cache mode (default, reload, no-cache)

例如：

````
var request = new Request('/users.json', {
	method: 'POST', 
	mode: 'cors', 
	redirect: 'follow',
	headers: new Headers({
		'Content-Type': 'text/plain'
	})
});

// Now use it!
fetch(request).then(function() { /* handle response */ });
````

##  返回response

### 属性

-  type - basic, cors
-  url
-  useFinalURL - Boolean for if url is the final URL
-  status - status code (ex: 200, 404, etc.)
-  ok - Boolean for successful response (status in the range 200-299)
-  statusText - status code (ex: OK)
-  headers - Headers object associated with the response.

### 方法

-  clone() - Creates a clone of a Response object.
-  error() - Returns a new Response object associated with a network error.
-  redirect() - Creates a new response with a different URL.
-  arrayBuffer() - Returns a promise that resolves with an ArrayBuffer.
-  blob() - Returns a promise that resolves with a Blob.
-  formData() - Returns a promise that resolves with a FormData object.
-  json() - Returns a promise that resolves with a JSON object.
-  text() - Returns a promise that resolves with a USVString (text).

###  例子

````javascript
  //Handling JSON
  fetch(sourceUrl)
      .then((response) => response.json())
      .then((jsonData) => {})
  //Handling html
  fetch(sourceUrl)
      .then((response) => response.test())
      .then((text) => {})
  //Handling BLOB
  fetch(sourceUrl)
      .then((response) => response.blob())
      .then((imageBlob) => {
			document.querySelector('img').src = URL.createObjectURL(imageBlob);
      })
````

##  更多高级技巧

###  合并请求
>  Promise.all可以合并多个请求

````javascript
var request1 = fetch('/users.json');
var request2 = fetch('/articles.json');

Promise.all([request1, request2]).then(function(results) {
    // Both promises done!
});
````

###  竞赛race
>   不知道什么场景用到这个，但是很有意思，多个请求，当一个通过或者reject，就立刻向后输出

````javascript
var req1 = new Promise(function(resolve, reject) { 
    // A mock async action using setTimeout
    setTimeout(function() { resolve('First!'); }, 8000);
});
var req2 = new Promise(function(resolve, reject) { 
    // A mock async action using setTimeout
    setTimeout(function() { resolve('Second!'); }, 3000);
});
Promise.race([req1, req2]).then(function(one) {
    console.log('Then: ', one);
}).catch(function(one, two) {
    console.log('Catch: ', one);
});

// From the console:
// Then: Second!
````   

##  参考文章
-	[rn中文网-网络](http://reactnative.cn/docs/0.23/network.html)
-	[fetchAPI,这篇文章写得很详细](https://davidwalsh.name/fetch)
- [JavaScript Promise API](https://segmentfault.com/a/1190000004476610)
- [promise ES6文档](http://es6.ruanyifeng.com/#docs/promise)
