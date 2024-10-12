import axios from 'axios'
const apiURL: string = "http://localhost:5000/api"

export async function fetchLoginData(email: string, password: string): Promise<any>{
    try{
        const response = await axios.post(`${apiURL}/auth/login`,{
            email: email,
            password: password,
        });
        return response.data;
    }catch(error){
        console.error("Error fetching data: ", error);
        throw error;
    }
}