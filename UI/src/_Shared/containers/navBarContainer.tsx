import React from "react";
import UserServices from "../services/userServices";
import NavBar from "../components/navbar/navBar";
import { ApplicationState } from "../store/rootReducer";
import { connect } from "react-redux";
import { Identity } from "../model";

type NavBarContainerProps = {
    identity: Identity;
}

type NavBarContainerState = {
}

class NavBarContainer extends React.Component<NavBarContainerProps, NavBarContainerState>{
    private readonly userServices = new UserServices();

    public render(){
        return (
            <NavBar signIn={this.userServices.signIn} signOut={this.userServices.signOut} identity={this.props.identity}/>
        );
    }
}

function mapStateToProps(state: ApplicationState) {
    return {
        identity: state.identity
    };
}

export default connect(mapStateToProps)(NavBarContainer);