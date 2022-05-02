import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'
import * as SupplierActions from '../actions/SupplierActions'
import ListSuppliers from '../pages/supplier/list/ListSuppliers'

export default connect(
    state => ({
        suppliers: state.supplier.suppliers,
        loading: state.supplier.loading
    }),
    dispatch => ({
        actions: bindActionCreators(SupplierActions, dispatch),
    }),
)(ListSuppliers);
