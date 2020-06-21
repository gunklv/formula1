import React from "react";
import DocumentTitle from "react-document-title";
import Formula1GridContainer from "./containers/formula1GridContainer";

export default class HomePage extends React.Component
{
    public render() { 
        return (
            <DocumentTitle title="Formula1 Teams">
                <div style={{width: "100%"}}>
                    <Formula1GridContainer />
                </div>
            </DocumentTitle>
        );
    };
}