import React from 'react'
import Header from './Header';
import Services from './Services';
import Toast from './Toast';
import 'react-toastify/dist/ReactToastify.css'

class App extends React.Component{
    render(){
        return (
            <>
                <Header/>                                         
                <Services erro={msg=>this.refs.toast.erro(msg)} />                                                    
                <Toast ref="toast" />   
            </>
        );
    }
};

export default App;