import React, {Component} from 'react';
import {BrowserRouter as Router, Route} from 'react-router-dom'
import Container from 'react-bootstrap/Container';
import Header from "./components/header/Header";
import ListSuppliersContainer from "./containers/ListSuppliersContainer";
import ViewSupplier from "./containers/ViewSupplierContainer";

class App extends Component {
    render() {
        return (
            <div>
                <Header/>
                <Container className="main">
                    <Router>
                        <Route path="/" exact={true} component={ListSuppliersContainer}/>
                        <Route path="/supplier/:supplierId" component={ViewSupplier}/>
                    </Router>
                </Container>
            </div>
        );
    }
}

export default App;
