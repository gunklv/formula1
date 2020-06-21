import React from "react";
import { BrowserRouter, Switch, Route, RouteProps } from "react-router-dom";
import HomePage from "../Home";
import NavBarContainer from "./containers/navBarContainer";

export default function Routing() {
    return (
        <BrowserRouter>
            <Switch>
                <Router exact path="/" component={HomePage}/>
            </Switch>
        </BrowserRouter>
    );
}

interface RouterProps extends RouteProps {
    layout?: React.ComponentType<any>;
}

const Router: React.FC<RouterProps> = ({component: Component, ...rest}) => {
    return (
        <Route
            {...rest}
            render={routeProps => (
                <>
                <NavBarContainer />
                <Component {...routeProps} />
                </>
            )}
        />
    );
}