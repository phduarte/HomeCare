import React from "react";
import Label from "../Label";
import './index.css'
import user from './img/user.png'
import Star from "./Star";

function Provider(props){
    const providers = props.providers
    const listProviders = providers.map((provider) =>
    <div className="provider" key={provider.id}>
            <div className="row">
                <div className="col-5">
                    <img src={user} className="user" />   
                </div>
                <div className="col-7">
                    <div className="row">
                        <div className="col-12 nome" >
                            <h2>
                                <Label text={provider.name} />
                            </h2>
                        </div>
                        <div className="col-12">
                            {Array.apply(null, {length: provider.stars}).map((e,i) => (
                                <Star key={i} marginTop="-20px" color="black"></Star>
                            ))}
                        </div>
                        <div className="col-12">
                            <button>view</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>)
        ;
    return (
        <div>
            {listProviders}
        </div>
    )
};

export default Provider;