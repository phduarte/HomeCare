import {SUPPLIERS_LOADED, SUPPLIER_LOADED, START_DATA_LOADING} from "../actions/SupplierActions";

const initialState = {
    loading: false,
    supplier: undefined,
    suppliers: [],
    page: 1,
    totalPages: 0
};

export default function supplierReducer(state = initialState, action = {}) {
    switch (action.type) {
        case START_DATA_LOADING:
            return Object.assign({}, state, {
                loading: true,
            });
        case SUPPLIERS_LOADED:
            return Object.assign({}, state, {
                loading: false,
                suppliers: action.payload.suppliers,
                page: action.payload.page,
                totalPages: action.payload.totalPages
            });
        case SUPPLIER_LOADED:
            return Object.assign({}, state, {
                loading: false,
                supplier: action.payload.supplier
            });
        default:
            return state;
    }
}
