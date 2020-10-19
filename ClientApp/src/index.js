import "bootstrap/dist/css/bootstrap.css";
import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";
import App from "./App";
import registerServiceWorker from "./registerServiceWorker";
import { createStore, combineReducers } from "redux";
import { Provider } from "react-redux";
import userAccountsReducer from "./reducers/userAccounts";
import projectsReducer from "./reducers/projects";
import employeesReducer from "./reducers/employees";



// specify base url and root element to inject jsx into
const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");
const rootElement = document.getElementById("root");

// combine all reducers we want to use
const combinedReducer = combineReducers({
    userAccountsReducer,
    projectsReducer,
    employeesReducer
})

// create the redux store with the combination of all reducers
const timesheetTrackerStore = createStore(combinedReducer);

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

registerServiceWorker();
