import React from 'react'
import './style.css'

const Header = () => (
    <nav className="navbar navbar-expand-lg navbar-dark navbar-custom fixed-top">
        <div className="container">
            <a className="navbar-brand" href="/">
                <img src="/logo.png"/>
            </a>
        </div>
    </nav>
);

export default Header;
