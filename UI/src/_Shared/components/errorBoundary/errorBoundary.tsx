import React, { ErrorInfo } from "react";

type ErrorBoundaryState = {
    hasError: boolean
}

export default class ErrorBoundary extends React.Component<any, ErrorBoundaryState> {
    constructor(props: any) {
      super(props);
      this.state = { hasError: false };
    }
  
    componentDidCatch(error: Error, info: ErrorInfo) {
      this.setState({ hasError: true });
    }
  
    render() {
      if (this.state.hasError) {
        return <div>Error occured while rendering components!</div>;
      }
      return this.props.children;
    }
  }