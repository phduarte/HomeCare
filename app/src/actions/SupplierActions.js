import {HttpGet} from '../utils/SupplierClient'

export const START_DATA_LOADING = 'SupplierState/START_DATA_LOADING';
export const SUPPLIERS_LOADED = 'SupplierState/SUPPLIERS_LOADED';
export const SUPPLIER_LOADED = 'SupplierState/SUPPLIER_LOADED';

function startDataLoading() {
    return {
        type: START_DATA_LOADING,
    };
}

function suppliersLoaded(suppliers) {
    return {
        type: SUPPLIERS_LOADED,
        payload: {suppliers: suppliers}
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

            HttpGet(`supplier/${supplierId}`)
                .then(result => {
                    try {
                        if (result.status === 200) {
                            dispatch(supplierLoaded(result.data))
                        } else {
                            throw new Error(`API bad response. Status code ${result.status}.`);
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
            latitude,
            longitude,
            range,
            orderBy,
            serviceName
        } = Object.assign({
            latitude: 3,
            longitude: 3,
            range: 3,
            orderBy: 'price',
            serviceName: '',
        }, options);

        let url = `suppliers/search?latitude=${latitude}&longitude=${longitude}&range=${range}&orderBy=${orderBy}&serviceName=${serviceName}`;

        HttpGet(url)
            .then(result => {
                try {
                    if (result.status === 200) {
                        dispatch(suppliersLoaded(result.data))
                    } else {
                        throw new Error(`API bad response. Status code ${result.status}.`);
                    }
                } catch (error) {
                    console.error(error);
                    dispatch(suppliersLoaded([]))
                }
            });
    };
}
