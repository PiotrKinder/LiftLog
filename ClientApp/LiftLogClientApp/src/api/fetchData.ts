import axios from 'axios'

import ApiClientAcces from './ApiClientAcces';
import { AuthRequest } from './Contracts';
const apiURL: string = "http://localhost:5000/api";

export async function fetchLoginData(body: AuthRequest): Promise<any>{
    try{
        const response = await axios.post(`${apiURL}/auth/login`,body);
        return response.data;
    }catch(error){
        console.error("Error fetching data: ", error);
        throw error;
    }
}