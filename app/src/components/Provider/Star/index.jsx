import React from "react";
import { AiFillStar } from "react-icons/ai";

export default function Star(props) {
    const estilo = {        
        // color:"green",
        color: props.color,
        marginTop: props.marginTop
    };    
    return (
        <AiFillStar style={estilo}></AiFillStar>
    )
}