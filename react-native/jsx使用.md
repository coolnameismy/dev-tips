## jsx使用和render方法渲染

在react-native中经常使用组件的rander方法，返回一段jsx

#### render单行,多行编码规范

- 当JSX标签超过一行时，使用括号包裹
- 对于没有子组件的JSX标签，始终自闭合


````js
 
 return <View></View>

 return <Foo className="stuff" />

 return （
 			<View>
 				<Text></Text>
 			</View>
 	）

````

- 关联state的渲染尽可能拆分render层次
- 输出多个重复样式的元素，dom需要使用数组

````js
render () {
	<View style={styles.serach_content_warp}>
	    <View style={styles.serach_hot}>
	        {this._renderHotRecipesDom()}
	    </View>
	</View>
}
_renderSearchHistroyDom:function(){
    var dom = [];
    if (this.state.searchHistroy.length==0) {
       return ( <Text style={{color:'#000',fontSize:24,opacity:0.6 }}>暂无搜索记录</Text> );
    }
    this.state.searchHistroy.forEach((item,i)=>{
       dom.push(<View style={styles.tags} key={"tagkey:"+i}><Text style={[styles.text,{  }]}> {item} </Text></View>) ;
    })
    return (dom);
}, 

````