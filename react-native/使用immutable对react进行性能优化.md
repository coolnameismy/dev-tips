使用immutable对react进行性能优化

````js
import { is } from 'immutable';

shouldComponentUpdate: (nextProps = {}, nextState = {}) => {
  const thisProps = this.props || {}, thisState = this.state || {};

  if (Object.keys(thisProps).length !== Object.keys(nextProps).length ||
      Object.keys(thisState).length !== Object.keys(nextState).length) {
    return true;
  }

  for (const key in nextProps) {
    if (!is(thisProps[key], nextProps[key])) {
      return true;
    }
  }

  for (const key in nextState) {
    if (thisState[key] !== nextState[key] || !is(thisState[key], nextState[key])) {
      return true;
    }
  }
  return false;
}
````

使用 Immutable 后，如下图，当红色节点的 state 变化后，不会再渲染树中的所有节点，而是只渲染图中绿色的部分：

![](https://camo.githubusercontent.com/85bcf6a09c811f9e68b729557726504ac008d18e/687474703a2f2f696d672e616c6963646e2e636f6d2f7470732f69332f54423156696e704b58585858585841587058585a5f4f644e4658582d3731352d3332342e706e67)



缓存状态

````js
import { Map, OrderedMap } from 'immutable';
let todos = OrderedMap();
let history = [];  // 普通数组，存放每次操作后产生的数据

let TodoStore = createStore({
  getAll() { return todos; }
});

Dispatcher.register(action => {
  if (action.actionType === 'create') {
    let id = createGUID();
    history.push(todos);  // 记录当前操作前的数据，便于撤销
    todos = todos.set(id, Map({
      id: id,
      complete: false,
      text: action.text.trim()
    }));
    TodoStore.emitChange();
  } else if (action.actionType === 'undo') {
    // 这里是撤销功能实现，
    // 只需从 history 数组中取前一次 todos 即可
    if (history.length > 0) {
      todos = history.pop();
    }
    TodoStore.emitChange();
  }
});
````
