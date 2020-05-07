import axios from 'axios';

const api = axios.create({
    baseURL: 'https://app-copa-filmes.herokuapp.com/api',
  });
  
  export default api;