import axios from 'axios';

export default axios.create({
    baseURL: 'https://localhost:7147/api',
    responsetype: 'json'
});