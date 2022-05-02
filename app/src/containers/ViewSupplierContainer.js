import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'
import * as SupplierActions from '../actions/SupplierActions'
import ViewSupplier from '../pages/supplier/view/ViewSupplier'

export default connect(
    state => ({
        supplier: state.supplier.supplier,
        loading: state.supplier.loading
    }),
    dispatch => ({
        actions: bindActionCreators(SupplierActions, dispatch),
    }),
)(ViewSupplier);
