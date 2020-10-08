import React, { Component } from "react";
import { Route } from "react-router";
import { FetchData } from "./components/FetchData";
import Counter from "./components/Counter";
import Index from "./components/Index/Index";

import "./custom.css";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <React.Fragment>
        <Route exact path="/" component={Index} />
        <Route path="/counter" component={Counter} />
        <Route path="/fetch-data" component={FetchData} />
      </React.Fragment>
    );
  }
}
