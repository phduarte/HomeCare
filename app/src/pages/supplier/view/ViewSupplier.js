import React, {Component} from "react"
import {CircleToBlockLoading} from "react-loadingg"
import Col from "react-bootstrap/Col"
import Row from "react-bootstrap/Row"
import StarRatings from 'react-star-ratings';
import './style.css'

export default class ViewSupplier extends Component {

    constructor(props) {
        super(props);
    }

    componentDidMount() {
        const { match: { params } } = this.props;
        this.props.actions.getSupplier(params.supplierId)
    }

    render() {
        return (
            <div className="loading">
                {this.props.loading &&
                    <CircleToBlockLoading color={'#1F2E5D'}/>
                }

                {!this.props.loading && !this.props.supplier &&
                    <div className='col-sm-12 col-lg-12'>
                        <h1 className='no-result'>Supplier not found</h1>
                    </div>
                }

                {!this.props.loading && this.props.supplier &&
                    <Row className='row view-supplier'>
                        <Col md={9}>
                            <Col md={12} className='view-supplier-card'>
                                <Row>
                                    <Col md={5}>
                                        <div className="img-event">
                                            <img className="img-fluid"
                                                src={this.props.supplier.thumbnail.path + '.' + this.props.supplier.thumbnail.extension}/>
                                        </div>
                                    </Col>
                                    <Col md={7}>
                                        <h2>{this.props.supplier.name}</h2>

                                        <StarRatings rating={4.5} starDimension="30px" starSpacing="15px" starRatedColor="gold"/>

                                        {this.props.supplier.description ?
                                            (<p>{this.props.supplier.description}</p>)
                                            :
                                            (<p>No description</p>)
                                        }
                                    </Col>
                                </Row>

                                <hr></hr>
                                
                                <Col md={12}>
                                    <Row ><h3>Localizacao do prestador</h3></Row>
                                    
                                    <Row>
                                        <iframe className="maps-frame" src="https://maps.google.com/maps?q=joao%20pessoa,%20paraiba%20brazil&t=&z=13&ie=UTF8&iwloc=&output=embed" 
                                        frameBorder="0" scrolling="no" marginHeight="0" marginWidth="0"></iframe>
                                    </Row>
                                </Col>
                     
                            </Col>
                  
                        </Col>

                        <Col md={3} >
                            <Col md={12} className='card-price'>
                                <h2>R$ 50,00</h2>
                                <img className='cards' src="/cards.png"/>
                                <btn className="btn btn-primary btn-block">Contratar</btn>
                            </Col>
                        </Col>
                    
                    </Row>
                }
            </div>
        )
    }

}
