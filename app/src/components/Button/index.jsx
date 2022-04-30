import React from "react";
import './index.css'

function Button(props){
    return (
        <button
            onClick={props.onClick}
        > 
            {<props.icon size={props.size} />}            
        </button>                            
    )
}

export default Button;