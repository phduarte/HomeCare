import {applyMiddleware, createStore} from 'redux';
import thunk from 'redux-thunk';
import rootReducer from './index';

const configureStore = () => {
    return createStore(
        rootReducer,
        applyMiddleware(thunk)
    );
};

export default configureStore;
