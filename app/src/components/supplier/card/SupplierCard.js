import React from 'react'
import {Link} from "react-router-dom"
import './style.css'
import {Row, Col} from 'react-bootstrap'
import StarRatings from 'react-star-ratings';

const SupplierCard = ({ id, name, image, description, rate, price, tags }) => (
    <div id={id} className="supplier col-xs-12 col-md-6" key={id+1}>
        <Link to={`/supplier/${id}`}>
            <div className="thumbnail card">
                <Row> 
                    <Col md={3} xs={3}>
                        <div className="img-event">
                            <img data-testid="thumbnail" className="group list-group-image img-fluid"
                                src={image} alt={image}/>
                        </div>
                    </Col>
                    <Col md={9} xs={9} className="supplier-info">
    
                        <h4 data-testid="name" className="group card-title inner list-group-item-heading">
                            {name}
                        </h4>
                        <p>{description}</p>
                        {tags && tags.split(',').map(tag =>
                            <span className="badge badge-pill badge-primary">{tag}</span>
                            )
                        }
                    </Col>
                </Row>
                        
           
                <div className="caption card-body">
                    <Row>
                        <Col>
                            <StarRatings rating={rate} starDimension="20px" starSpacing="10px" starRatedColor="gold"/>
                        </Col>
                        <Col>
                            <h4 className='price'>R$ {price},00</h4>
                        </Col>
                    </Row>
                </div>
            </div>
        </Link>
    </div>
);

export default SupplierCard;
