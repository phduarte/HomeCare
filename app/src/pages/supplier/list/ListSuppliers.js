import React, {Component} from 'react'
import SupplierCard from '../../../components/supplier/card/SupplierCard'
import {CircleToBlockLoading} from 'react-loadingg'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import Search from '../../../components/search/Search'
import './style.css'

export default class ListSuppliers extends Component {

    constructor(props) {
        super(props);
    }

    componentDidMount() {
        this.props.actions.listSuppliers();
    }

    render() {
        return (
            <Row className='row'>
                <Col xs={12}>
                    <Search/>
                    <div className='content'>
                        <div className='suppliers row view-group'>
                            {this.props.loading &&
                                <div className='loading'>
                                    <CircleToBlockLoading color={'#1F2E5D'} />
                                </div>
                            }

                            {!this.props.loading && !this.props.suppliers.length &&
                                <div className='col-sm-12 col-lg-12'>
                                    <h1 className='no-result'>Nenhum prestrador disponivel com esse nome</h1>
                                </div>
                            }

                            {!this.props.loading && this.props.suppliers &&
                                this.props.suppliers.map(item =>
                                    <SupplierCard
                                        key={item.id}
                                        id={item.id}
                                        name={item.name}
                                        description={item.description}
                                        thumbnail={item.thumbnail.path + '.' + item.thumbnail.extension}
                                    />
                                )
                            }
                        </div>
                    </div>
                </Col>
            </Row>
        )
    }
}
