import React, {Component, useState} from "react"
import {CircleToBlockLoading} from "react-loadingg"
import Col from "react-bootstrap/Col"
import Row from "react-bootstrap/Row"
import StarRatings from 'react-star-ratings';
import './style.css'

export default class ViewSupplier extends Component {
      
    constructor(props) {
        super(props);

        this.state = {
            showPaymentForm: false
        }
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
                                            <img className="img-fluid" src={this.props.supplier.image}/>
                                        </div>
                                    </Col>
                                    <Col md={7}>
                                        <h2>{this.props.supplier.name}</h2>

                                        <StarRatings rating={this.props.supplier.rate} starDimension="30px" starSpacing="15px" starRatedColor="gold"/>

                                        <Row>
                                            <Col md={12} className="tags">
                                                {this.props.supplier.tags && this.props.supplier.tags.split(',').map(tag =>
                                                    <span className="badge badge-pill badge-primary">{tag}</span>
                                                    )
                                                }
                                            </Col>
                                        </Row>

                                   

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

                                {!this.state.showPaymentForm && (
                                    <button className="btn btn-primary btn-block" onClick={event => this.setState({showPaymentForm: true})}>Contratar</button>
                                )}
                                <hr></hr>
                                {this.state.showPaymentForm && (
                                    
                                    <Row className="form-payment">
                                        <Col md={12} className='form-group'><h5>Dados do Pagamento</h5></Col>
                               
                                        <Col md={12}>
                                            <form>
                                                <Row className="form-group">
                                                    <Col md={12}>
                                                        <label className="form-label">Nome do Titular</label>
                                                        <input className="form-control" placeholder="Nome do Titular"></input>
                                                    </Col>
                                                </Row>
                                                <Row className="form-group">
                                                    <Col md={12}>
                                                        <label className="form-label">CPF do Titular</label>
                                                        <input className="form-control" placeholder="CPF do Titular"></input>
                                                    </Col>
                                                </Row>
                                                <Row className="form-group">
                                                    <Col md={12}>
                                                        <label className="form-label">Número do Cartão</label>
                                                        <input className="form-control" placeholder="Número do Cartão"></input>
                                                    </Col>
                                                </Row>
                                                <Row className="form-group">
                                                    <Col md={6}>
                                                        <label className="form-label">CVV</label>
                                                        <input className="form-control" placeholder="CVV"></input>
                                                    </Col>
                                                    <Col md={6}>
                                                        <label className="form-label">Validade</label>
                                                        <input className="form-control" placeholder="Validade"></input>
                                                    </Col>
                                                </Row>
                                                <Row>
                                                    <Col md={6} sm={12}>
                                                        <button className="btn btn-outline-primary btn-block" onClick={event => this.setState({showPaymentForm: false})}>
                                                            Cancelar
                                                        </button>
                                                    </Col>
                                                    <Col md={6} sm={12}>
                                                        <button className="btn btn-primary btn-block" onClick={event => this.setState({showPaymentForm: false})}>
                                                            Pagar
                                                        </button>
                                                    </Col>
                                                </Row>
                                            </form>
                                        </Col>
                                    </Row>
                                )}
                            </Col>
                            
                        </Col>
                    
                    </Row>
                }
            </div>
        )
    }

}
