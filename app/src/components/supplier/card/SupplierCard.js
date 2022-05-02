import React from 'react';
import {Link} from "react-router-dom";
import './style.css'


const SupplierCard = ({ id, name, thumbnail }) => (
    <div id={id} className="supplier col-xs-12 col-md-6" key={id}>
        <Link to={`/supplier/${id}`}>
            <div className="thumbnail card">
                <div className="img-event">
                    <img data-testid="thumbnail" className="group list-group-image img-fluid"
                         src={thumbnail} alt={thumbnail}/>
                </div>
                <div className="caption card-body">
                    <h4 data-testid="name" className="group card-title inner list-group-item-heading">
                        {name}
                    </h4>
                </div>
                <div className="card-overflow">
                    <h4>Visualizar prestador</h4>
                </div>
            </div>
        </Link>
    </div>
);

export default SupplierCard;
