// @flow
import { combineReducers } from 'redux'
import { reducer as formReducer } from 'redux-form'
import supplierReducer from './SupplierReducer';

export default combineReducers({
    supplier: supplierReducer,
    form: formReducer
});
