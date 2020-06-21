import axios from "axios";

export default class UserApi{
    public static readonly baseUrl = process.env.API_URL;

    public static init(){
      axios.defaults.baseURL = UserApi.baseUrl;
    }

    public static async signin(userName: string, password: string) : Promise<string> {
      return axios.post(`/auth/signin`, {userName, password})
        .then(response => response.data)
        .catch(reason => {throw reason.response.data.errors;});
    }
}

UserApi.init();