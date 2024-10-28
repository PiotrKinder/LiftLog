import { ApiClient } from "./Contracts";
import axios from "axios";

export class ApiClientAcces {
    private static instance: ApiClient;
    private static apiUrl: string = "http://localhost:5000";

    private static axiosInstance = axios.create();

    private constructor() {}

    public static getInstance(token?: string): ApiClient {
        this.axiosInstance.interceptors.request.use((config) => {
            // const token = "test_token_data";
            //const token = this.getToken();
            if (token) {
                config.headers.Authorization = `Bearer ${token}`;
            }
            return config;
        }, (error) => {
            return Promise.reject(error);
        });
        if (!this.instance) {
            this.instance = new ApiClient( this.apiUrl,this.axiosInstance );
        }
        return this.instance;
    }
}

export default ApiClientAcces