import { Formula1Team } from "../model";
import Formula1Api from "./formula1api";
import { toast } from 'react-toastify';

export default class Formula1Services{
    public async getFormula1Teams() : Promise<Formula1Team[]> {
        try{
          return await Formula1Api.getAll();
        }
        catch(e){
          console.log(e);
          toast("Error occured during receiving data!", {type: "error"});
        }
    }

    public async createFormula1Team(formula1Team: Formula1Team) : Promise<void> {
      try{
        return await Formula1Api.create(formula1Team);
      }
      catch(e){
        console.log(e);
        throw Error("Error occured during creating data!");
      }
    }

    public async updateFormula1Team(formula1Team: Formula1Team) : Promise<void> {
      try{
        return await Formula1Api.update(formula1Team);
      }
      catch(e){
        console.log(e);
        throw Error("Error occured during update data!");
      }
    }

    public async deleteFormula1Team(id: string) : Promise<void> {
      try{
        return await Formula1Api.delete(id);
      }
      catch(e){
        console.log(e);
        throw Error("Error occured during delete data!");
      }
    }
}