import React, { Component } from "react";
import { Route } from "react-router";
import Index from "./components/Index/Index";
import Home  from "./components/Home/Home";
import "./custom.css";
import ProjectDetail from "./components/ProjectDetail/ProjectDetail";
import CreateProject from "./components/CreateProject/CreateProject";
import Account from "./components/Account/Account";


export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <React.Fragment>
            <Route exact path="/" component={Index} />
            <Route path="/home" component={Home} />
            <Route path="/project-detail" component={ProjectDetail} />
            <Route path="/create-project" component={CreateProject} />
            <Route path="/account" component={Account} />
      </React.Fragment>
    );
  }
}
