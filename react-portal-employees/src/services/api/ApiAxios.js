import axios from 'axios';

export default axios.create({
    headers: {'Content-Type' : 'application/json'},
    baseURL: 'https://localhost:7147/api',
    responsetype: 'json'
});