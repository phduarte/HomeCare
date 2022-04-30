class Repository {
    constructor(){
        this.key = 'services';
    }
    salvar(json, callback) {
        let data = JSON.stringify(json);
        window.localStorage.setItem(this.key, data);
        callback();
    }
    obeter(sucesso, falha) {
        let json = JSON.parse (window.localStorage.getItem(this.key));
        if(json)
            sucesso(json)
        else
            falha();
    }
}

export default Repository;