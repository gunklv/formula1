  export default function AuthenticationReducer(state: any, action: any) {
      switch (action.type) {
        case "LOGIN_USER":
          return action.payload;
        default:
          return null;
      }
    }