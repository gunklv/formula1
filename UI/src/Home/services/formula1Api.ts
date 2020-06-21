import axios from "axios";
import { Formula1Team } from "../model";

export default class Formula1Api{
    public static readonly baseUrl = process.env.API_URL;

    public static init(){
      axios.defaults.baseURL = Formula1Api.baseUrl;
    }

    public static async getAll() : Promise<Formula1Team[]> {
      return axios.get(`/api/formula1s`)
        .then(response => response.data)
        .catch(error => {throw error;});
    }

    public static async create(formula1Team: Formula1Team) : Promise<void> {
      return axios.post(`/api/formula1s/create`, formula1Team)
        .then(response => response.data)
        .catch(error => {throw error;});
    }

    public static async update(formula1Team: Formula1Team) : Promise<void> {
      return axios.put(`/api/formula1s/update`, formula1Team)
        .then(response => response.data)
        .catch(error => {throw error;});
    }

    public static async delete(id: string) : Promise<void> {
      return axios.delete(`/api/formula1s/delete/${id}`)
        .then(response => response.data)
        .catch(error => {throw error;});
    }
  }

Formula1Api.init();