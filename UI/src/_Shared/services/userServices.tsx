import userApi from "./userApi";
import { store } from "../../app";
import jwt from "jwt-decode";
import { updateIdentity } from "../actions/authenticationAction";
import { Identity } from "../model";
import axios from "axios";
import { toast } from 'react-toastify';

export default class UserServices{

    public async signIn(userName: string, password: string) : Promise<void> {
      try{
        var token = await userApi.signin(userName, password);
        localStorage.setItem("token", token);
        const identity = jwt(token) as Identity;
        store.dispatch(updateIdentity(identity));
        axios.defaults.headers.common["Authorization"] = "Bearer " + token;
      }
      catch(e){
        console.log(e[""][0]);
        toast("Signing in failed - " + e[""][0], {type: "error"});
      }
    }

    public signOut() : void {
      const token = localStorage.removeItem("token");
      store.dispatch(updateIdentity(null));
    }

    public restoreUser(){
      if(this.checkAuthExist()){
        const token = localStorage.getItem("token");
        const identity = jwt(token) as Identity;
        store.dispatch(updateIdentity(identity));
        axios.defaults.headers.common["Authorization"] = "Bearer " + token;
      }
    }

    private checkAuthExist(): boolean{
      const token = localStorage.getItem("token");
      if(!token){
        return false;
      }
      try {
        const {exp} = jwt(token);
        if(exp < new Date().getTime() / 1000){
          return false;
        }
      }
      catch (e){
        return false;
      }
      return true;
    }
}