class Provider {
    constructor(){
        this.id = ''
        this.name = ''
        this.stars = ''
        this.img=''
    }
    validar(){
        this.valirdarID()
    }

    valirdarID(){
        if(typeof this.id === 'bigint' && this.id > 0) {
            return true;
        }

        return false;        
    }
}
export default Provider;