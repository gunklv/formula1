import { combineReducers } from "redux";
import AuthenticationReducer from "../reducers/authenticationReducer";

export type ApplicationState = {
  identity: typeof AuthenticationReducer
}

const reducer = combineReducers<ApplicationState>({
  identity: AuthenticationReducer
});

const reducers = (state: ApplicationState, action: any) => {
  return reducer(state, action);
};

export default reducers;