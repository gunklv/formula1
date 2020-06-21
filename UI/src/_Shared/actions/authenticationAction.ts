import { Identity } from "../model";

type UpdateIdentityAction = {
    type: string,
    payload: Identity
}

export function updateIdentity(identity: Identity): UpdateIdentityAction {
    return {
        type: "LOGIN_USER",
        payload: identity
    }
};

export type IdentityActionTypes = UpdateIdentityAction; 

export default IdentityActionTypes;