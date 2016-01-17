jsx中style的使用方式

## 创建一个style

````
//创建一个class1和class2的样式

StyleSheet.create({
	class1:{
		.....
	},
	class2:{
		.....
	},
});

````

##	使用样式

````
//直接使用样式
<View style={styles.class1} > </View>

//使用多个样式类
<View style={[styles.class1,styles.class2]} > </View>

//使用内联样式
<View style={{flex:1,...}} > </View>

//混用内联样式和样式类
<View style={[styles.class1,{flex:1,...}]} > </View>
````





