 import React from "react";
 import './index.css'
 import Provider from "../Provider";
 import Input from "../Input";
 import background from './img/background-body3.jpg'
 import { AiOutlineSearch } from "react-icons/ai";
 import Button from "../Button";
 import Toast from "../Toast";
 
 class Services extends React.Component {
     constructor(props){
         super(props)
         this.state = {
             service: {
                 service: ''
             },
             validacao: {
                valorInvalido: false
             },
             providers:[]
         }
     }     
     render(){
         return (
            <div className="container center services">
                <div className="row">
                    <Toast ref="toast" />        
                </div>
                <div className="row">
                    <div className="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
                        <form>                            
                            <Input 
                                id="services"
                                placeholder="services"
                                maxLength="50"
                                readOnly={false}
                                valorInvalido={this.state.validacao.valorInvalido}
                                defaultValue={this.state.service.service}
                                onChange={this.atualizaService}></Input>
                        
                            <Button icon={AiOutlineSearch} size="30" onClick={this.searchService}></Button>                                    
                        </form>
                    </div>                    
                </div>
                <div className="row">
                    <div className="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
                        <Provider providers={this.state.providers} />
                    </div>
                </div>
           </div>
         )         
     }
     
     atualizaService = e => {
        let serviceValue = this.state.service;
        serviceValue.service = e.target.value;            
       this.setState(
           {
               service: serviceValue
           }           
       )           
    }
    searchService = e =>{
        e.stopPropagation();
        e.preventDefault();

        if(this.state.service.service == ''){
            this.props.erro('Erro ao ...')
        }
        else {
            this.props.sucesso('Sucesso ...')
        }

        let providers = this.state.providers;        
        
        providers.push(                
            {id:'1', name: 'Ângelo', stars:'5', img:''},
            {id:'2', name: 'Franclis', stars:'3', img:''},
            {id:'3', name:'Paulo', stars:'4', img:''}
        )
        
        //adicionar a consulta

        this.setState(
            {
                providers: providers
            }
        )
    }
 }
 
 export default Services;