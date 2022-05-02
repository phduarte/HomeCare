import axios from 'axios'

class HttpRequest {
    static instance() {
        return axios.create({
            baseURL: 'https://gateway.marvel.com/v1/public/',
            timeout: 10000,
            method: 'get',
            responseType: 'json'
        });
    }

    async Get(urlApi, param = {}) {
        try {
            urlApi += "&apikey=71c6c66725f512871978edcf015edc26";
            const get = HttpRequest.instance().get(urlApi, param);
            return await get;
        } catch (error) {
            console.error(error)
        }
    }
}

const request = new HttpRequest();

export const HttpGet = async (urlApi, param = {}) => {
    return await request.Get(urlApi, param);
};
