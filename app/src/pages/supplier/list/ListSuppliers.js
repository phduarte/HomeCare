import React, {Component} from 'react'
import SupplierCard from '../../../components/supplier/card/SupplierCard'
import {CircleToBlockLoading} from 'react-loadingg'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import Search from '../../../components/search/Search'
import './style.css'

export default class ListSuppliers extends Component {

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
                                        key={item.supplierId}
                                        id={item.supplierId}
                                        name={item.name}
                                        description={item.description}
                                        image={item.image}
                                        rate={item.rate}
                                        price={item.price}
                                        tags={item.tags}
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
