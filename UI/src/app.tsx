import "react-toastify/dist/ReactToastify.css";
import "./_Shared/styles/global.scss";

import * as React from "react";
import { render } from "react-dom";
import { Provider } from "react-redux";
import Routing from "./_Shared/router";
import ErrorBoundary from "./_Shared/components/errorBoundary/errorBoundary";
import configureStore from "./_Shared/store/configureStore";
import UserServices from "./_Shared/services/userServices";
import { ToastContainer } from "react-toastify";

export const store = configureStore({});

const userServices = new UserServices();
userServices.restoreUser();

const Root = () => (
  <Provider store={store}>
    <ErrorBoundary>
      <Routing />
    </ErrorBoundary>
    <ToastContainer position={"bottom-right"} hideProgressBar newestOnTop pauseOnHover={false} closeOnClick autoClose={3000}/>
  </Provider>
);

render(<Root />, document.getElementById("root"));

