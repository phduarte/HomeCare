import React, {Component} from 'react'
import { connect } from 'react-redux'
import {bindActionCreators} from 'redux'
import * as SupplierActions from '../../actions/SupplierActions'
import './style.css'
import { Dropdown, InputGroup, DropdownButton, FormControl} from 'react-bootstrap'
import InputRange from 'react-input-range'
import 'react-input-range/lib/css/index.css'

export class Search extends Component {

    constructor(props) {
        super(props);

        this.state = {
            range: 5,
            orderBy: 'price',
            serviceName: ''
        };
    }

    _setOrder = (event) => {
        this.setState({orderBy: event.target.value}, () => { this.props.actions.listSuppliers(this.state) })
    }

    _setRange = (value) => {
        this.setState({range: value}, () => { this.props.actions.listSuppliers(this.state) })
    }

    _searchSuppliers = (value) => {
        if (this.props.actions) {
            this.setState({serviceName: value},() => { this.props.actions.listSuppliers(this.state) })
        }
    }


    render() {
        return (
            <InputGroup className="mb-3">
                <FormControl size="lg" placeholder='Buscar prestadores de serviços'
                                onChange={event => this._searchSuppliers(event.target.value)}/>

                <DropdownButton size="lg" variant="info" title="Filtrar" align="end">
                    <div className='form-group'>
                        <label className='search-label'>Distancia (KM)</label>
                        <InputRange maxValue={20} minValue={1} value={this.state.range} onChange={this._setRange}/> 
                    </div>        

                    <Dropdown.Divider />
                    <div className='form-group'>
                        <label className='search-label'>Ordernar por: </label>
                        <select className="form-control" value={this.state.orderBy} onChange={this._setOrder}>
                            <option value="price">Preço</option>
                            <option value="quality">Avaliação</option>
                        </select>
                    </div>                  
                </DropdownButton>
            </InputGroup>
        )
    }
}

export default connect(
    state => ({}),
    dispatch => ({
        actions: bindActionCreators(SupplierActions, dispatch),
    }),
)(Search);
