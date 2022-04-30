import React from "react";
import logo from './img/logo_grande.png'
import './index.css'

function Header(){    
        return (
        <div className="container-fluid fixed-top header">                     
              <div className="row">
                <div className="col-3 col-sm-3 col-md-5 col-lg-5 col-xl-5">
                    <img src={logo} className="logo" />         
                </div>
                <div className="col-9 col-sm-9 col-md-7 col-lg-7 col-xl-7">
                        <h1 className="title">Home Care</h1>
                    </div>
                </div>    
         </div>
         );
    
}

export default Header;