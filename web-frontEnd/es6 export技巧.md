## 导出单个对象

````js
export default function* rootSaga() {...}
import rootSaga from './sagas'
````

## 导出{}对象

````js
export { delay, CANCEL } from './internal/utils'
import { delay } from 'redux-saga'
````

## 导出文件夹

````js
import * as effects from './effects'
import { put, takeEvery,all } from 'redux-saga/effects'
````