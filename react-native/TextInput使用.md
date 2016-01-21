
##	示例

````html
<TextInput style={styles.input} returnKeyType='search' placeholder='请输入'>
````

## 属性

````
autoCapitalize enum('none', 'sentences', 'words', 'characters')

可以通知文本输入自动利用某些字符。

characters：所有字符，
words：每一个单词的首字母
sentences：每个句子的首字母（默认情况下）
none：不会自动使用任何东西
autoCorrect 布尔型

如果值为假，禁用自动校正。默认值为真。

autoFocus 布尔型

如果值为真，聚焦 componentDidMount 上的文本。默认值为假。

bufferDelay 数值型

这个会帮助避免由于 JS 和原生文本输入之间的竞态条件而丢失字符。默认值应该是没问题的，但是如果你每一个按键都操作的非常缓慢，那么你可能想尝试增加这个。

clearButtonMode enum('never', 'while-editing', 'unless-editing', 'always')

清除按钮出现在文本视图右侧的时机

controlled 布尔型

如果你真想要它表现成一个控制组件，你可以将它的值设置为真，但是按下按键，并且/或者缓慢打字，你可能会看到它闪烁，这取决于你如何处理 onChange 事件。

editable 布尔型

如果值为假，文本是不可编辑的。默认值为真。

enablesReturnKeyAutomatically 布尔型

如果值为真，当没有文本的时候键盘是不能返回键值的，当有文本的时候会自动返回。默认值为假。

keyboardType enum('default', "ascii-capable", 'numbers-and-punctuation', 'url', 'number-pad', 'phone-pad', 'name-phone-pad', 'email-address', 'decimal-pad', 'twitter', 'web-search', "numeric")

决定打开哪种键盘，例如，数字键盘。

multiline 布尔型

如果值为真，文本输入可以输入多行。默认值为假。

onBlur 函数

当文本输入是模糊的，调用回调函数

onChange 函数

当文本输入的文本发生变化时，调用回调函数

onChangeText 函数

onEndEditing 函数

onFocus 函数

当输入的文本是聚焦状态时，调用回调函数

onSubmitEditing 函数

password 布尔型

如果值为真，文本输入框就成为一个密码区域。默认值为假。

placeholder 字符串型

在文本输入之前字符串将被呈现出来

placeholderTextColor 字符串型

占位符字符串的文本颜色

returnKeyType enum('default', 'go', 'google', 'join', 'next', 'route', 'search', 'send', 'yahoo', 'done', 'emergency-call')

决定返回键的样式

secureTextEntry 布尔型

如果值为真，文本输入框就会使输入的文本变得模糊，以便于像密码这样敏感的文本保持安全。默认值为假。

selectionState 文档选择状态

testID 字符串型

value 字符串型



````