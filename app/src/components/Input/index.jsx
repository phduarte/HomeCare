import React from "react";
import './index.css';

function Input(props){
    const estilo = {
        borderColor: props.valorInvalido ? '#f5021b' : '#000000',
        backgroundColor: props.valorInvalido ?  '#ffcdd2' : '#ffffff'
    };
    let propriedade = Object.assign({}, props);    
    delete propriedade.valorInvalido;
    return (
        <input style={estilo} {...propriedade} className="inputGroup-sizing-sm"></input>
    )
}

export default Input;