import {HttpGet} from '../utils/HttpRequest'

export const START_DATA_LOADING = 'SupplierState/START_DATA_LOADING';
export const SUPPLIERS_LOADED = 'SupplierState/SUPPLIERS_LOADED';
export const SUPPLIER_LOADED = 'SupplierState/SUPPLIER_LOADED';

function startDataLoading() {
    return {
        type: START_DATA_LOADING,
    };
}

function suppliersLoaded(suppliers, page, totalPages) {
    return {
        type: SUPPLIERS_LOADED,
        payload: {suppliers: suppliers, page: page, totalPages: totalPages}
    };
}

function supplierLoaded(supplier) {
    return {
        type: SUPPLIER_LOADED,
        payload: {supplier: supplier}
    };
}


export function getSupplier(supplierId) {
    if (localStorage.getItem(supplierId)) {
        const supplier = JSON.parse(localStorage.getItem(supplierId))
        return (dispatch) => {
            dispatch(startDataLoading());
            dispatch(supplierLoaded(supplier))
        }
    } else {
        return (dispatch) => {
            dispatch(startDataLoading());

            HttpGet(`characters/${supplierId}?`)
                .then(result => {
                    try {
                        if (result.status === 200) {
                            dispatch(supplierLoaded(result.data.data.results[0]))
                        } else {
                            throw new Error(`Marvel API bad response. Status code ${result.status}.`);
                        }
                    } catch (error) {
                        console.error(error);
                        dispatch(supplierLoaded(undefined))
                    }
                });
        }
    }
}

export function listSuppliers(options) {
    return (dispatch) => {
        dispatch(startDataLoading());
        const {
            offset,
            name,
            sortName,
            limit,
        } = Object.assign({
            offset: 0,
            name: '',
            sortName: '',
            limit: 20,
        }, options);

        let url = `characters?offset=${offset}&orderBy=${sortName}name&limit=${limit}`;
        if (name) {
            url += `&nameStartsWith=${name}`;
        }

        HttpGet(url)
            .then(result => {
                try {
                    if (result.status === 200) {
                        if (offset > result.data.data.total) {
                            throw new Error('Page does not exist.');
                        } else {
                            const page = Math.floor(result.data.data.total / limit);
                            dispatch(suppliersLoaded(result.data.data.results, page, result.data.data.total % limit > 0 ? page + 1 : page))
                        }
                    } else {
                        throw new Error(`Marvel API bad response. Status code ${result.status}.`);
                    }
                } catch (error) {
                    console.error(error);
                    dispatch(suppliersLoaded([], 0, 0))
                }
            });
    };
}
