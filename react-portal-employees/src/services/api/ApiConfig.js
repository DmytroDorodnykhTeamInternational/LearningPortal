import axios from 'axios';

export const Api = () =>{
    return axios.create({
        baseURL :'https://localhost:7147/api',
        responsetype: 'json',
    })
}