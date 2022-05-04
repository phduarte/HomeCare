import axios from 'axios'

class HttpRequest {
    static instance() {
        return axios.create({
            baseURL: 'https://app-suppliers-puc-pi-homecare.azurewebsites.net/',
            timeout: 10000,
            method: 'get',
            responseType: 'json'
        });
    }

    async Get(urlApi, param = {}) {
        try {
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
