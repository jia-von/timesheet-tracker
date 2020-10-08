import "bootstrap/dist/css/bootstrap.css";
import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";
import App from "./App";
import registerServiceWorker from "./registerServiceWorker";
import { createStore } from "redux";
import { Provider } from "react-redux";
import timesheetTrackerReducer from "./reducers/timesheetTracker";

// specify base url and root element to inject jsx into
const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");
const rootElement = document.getElementById("root");

// create the redux store
const timesheetTrackerStore = createStore(timesheetTrackerReducer);

// perform this action everytime the store changes
timesheetTrackerStore.subscribe(() => {
  console.log(timesheetTrackerStore.getState());
});

// use the provider to make the store available to our Components
const Root = (store) => (
  <Provider store={store.store}>
    <BrowserRouter basename={baseUrl}>
      <App />
    </BrowserRouter>
  </Provider>
);

ReactDOM.render(<Root store={timesheetTrackerStore} />, rootElement);

/*
// template from dotnet - react
ReactDOM.render(
<BrowserRouter basename={baseUrl}>
<App />
</BrowserRouter>,
rootElement);
*/

registerServiceWorker();
